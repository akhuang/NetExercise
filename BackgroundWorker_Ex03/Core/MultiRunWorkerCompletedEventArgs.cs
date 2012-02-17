using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Core
{
    public class MultiRunWorkerCompletedEventArgs : RunWorkerCompletedEventArgs
    {
        private readonly object _taskId;
        public object TaskId
        {
            get
            {
                return _taskId;
            }
        }

        public MultiRunWorkerCompletedEventArgs(object taskId, object result, Exception error, bool cancelled)
            : base(result, error, cancelled)
        {
            this._taskId = taskId;
        }
    }
}
