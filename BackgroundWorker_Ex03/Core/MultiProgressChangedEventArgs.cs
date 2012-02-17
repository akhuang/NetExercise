using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Core
{
    public class MultiProgressChangedEventArgs : ProgressChangedEventArgs
    {
        private readonly object _taskID;
        public object TaskID
        {
            get
            {
                return _taskID;
            }
        }

        public MultiProgressChangedEventArgs(object taskId, int progressPercentage, object userState)
            : base(progressPercentage, userState)
        {
            this._taskID = taskId;
        }
    }
}
