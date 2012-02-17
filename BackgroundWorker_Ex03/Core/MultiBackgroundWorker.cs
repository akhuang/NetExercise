using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Collections.Specialized;

namespace Core
{
    public partial class MultiBackgroundWorker : Component
    {
        public event MultiDoWorkerEventHandler DoWork;
        public event MultiProgressChangedEventHandler ProgressChanged;
        public event MultiRunWorkerCompletedEventHandler RunWorkerCompleted;

        public readonly SendOrPostCallback onProgressChangedDelegate;
        public readonly SendOrPostCallback onRunWorkerCompletedDelegate;

        public delegate void WorkerThreadStartDelete(AsyncOperation asyncOp, object argument);
        public WorkerThreadStartDelete threadStartDelegate;

        public HybridDictionary userStateToLifeTime = new HybridDictionary();

        public MultiBackgroundWorker()
        {
            InitializeComponent();
        }

        public MultiBackgroundWorker(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            this.threadStartDelegate = new WorkerThreadStartDelete(WorkThreadStart);
            this.onProgressChangedDelegate = new SendOrPostCallback(ProgressReport);
            this.onRunWorkerCompletedDelegate = new SendOrPostCallback(WorkerCompleted);
        }

        public void RunWorkerAsync(object taskId, object argument)
        {
            //新建一个跟踪异步操作的类
            AsyncOperation async = AsyncOperationManager.CreateOperation(taskId);

            //多个线程会访问此集合，所以应该保证线程安全
            lock (this.userStateToLifeTime.SyncRoot)
            {
                if (this.userStateToLifeTime.Contains(async.UserSuppliedState))
                {
                    throw new Exception("The task id must be unique.");
                }
                this.userStateToLifeTime[taskId] = async;
            }

            threadStartDelegate.BeginInvoke(async, argument, null, null);
        }

        public void WorkThreadStart(AsyncOperation async, object argument)
        {
            AsyncOperation asyncOp = async;
            bool cancelled = false;
            Exception error = null;
            object result = null;

            try
            {
                MultiDoWorkEventArgs args = new MultiDoWorkEventArgs(asyncOp.UserSuppliedState, argument);
                this.OnDoWork(args);
                if (args.Cancel)
                {
                    cancelled = true;
                }
                else
                {
                    result = args.Result;
                }

            }
            catch (Exception exception)
            {
                error = exception;
            }

            if (!cancelled)
            {
                lock (this.userStateToLifeTime.SyncRoot)
                {
                    this.userStateToLifeTime.Remove(asyncOp.UserSuppliedState);
                }
            }

            MultiRunWorkerCompletedEventArgs completeArgs = new MultiRunWorkerCompletedEventArgs(asyncOp.UserSuppliedState, result, error, cancelled);
            asyncOp.PostOperationCompleted(onRunWorkerCompletedDelegate, completeArgs);
        }

        public void RunWorker(MultiRunWorkerCompletedEventArgs e)
        {
            MultiRunWorkerCompletedEventArgs args = e as MultiRunWorkerCompletedEventArgs;

        }
        public void OnDoWork(MultiDoWorkEventArgs e)
        {
            if (DoWork != null)
            {
                DoWork(this, e);
            }
        }

        public void WorkerCompleted(object operationState)
        {
            MultiRunWorkerCompletedEventArgs args = operationState as MultiRunWorkerCompletedEventArgs;
            this.OnRaiseRunWorkerCompleted(args);
        }

        public void OnRaiseRunWorkerCompleted(MultiRunWorkerCompletedEventArgs e)
        {
            if (RunWorkerCompleted != null)
            {
                RunWorkerCompleted(this, e);
            }
        }

        public void ProgressReport(object operationState)
        {
            MultiProgressChangedEventArgs e = operationState as MultiProgressChangedEventArgs;
            this.OnRaiseProgressChanged(e);
        }

        public void OnRaiseProgressChanged(MultiProgressChangedEventArgs args)
        {
            if (ProgressChanged != null)
            {
                ProgressChanged(this, args);
            }
        }

        public void ReportProgress(AsyncOperation async, int percentage, object userState)
        {
            if (async != null)
            {
                MultiProgressChangedEventArgs e = new MultiProgressChangedEventArgs(async.UserSuppliedState, percentage, userState);
                async.Post(onProgressChangedDelegate, e);
            }
        }
    }
}
