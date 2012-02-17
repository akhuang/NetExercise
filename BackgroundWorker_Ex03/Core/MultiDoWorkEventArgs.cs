using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Core
{
    public class MultiDoWorkEventArgs : DoWorkEventArgs
    {
        private readonly object _taskID;
        public object TaskID
        {
            get
            {
                return _taskID;
            }
        }

        public MultiDoWorkEventArgs(object taskID, object argument)
            : base(argument)
        {
            this._taskID = taskID;
        }
    }
}
