using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace AD101CNET.FileData
{
    public delegate void FileDataStatusChangedEventHandler(FileData data);

    public class FileData : INotifyPropertyChanged
    {
        public static event FileDataStatusChangedEventHandler StatusChanged;

        public FileData() { }

        public string TaskId { get; set; }

        private int _progressPercentage;
        public int ProgressPercentage
        {
            get
            {
                return _progressPercentage;
            }
            set
            {
                if (value != this._progressPercentage)
                {
                    this._progressPercentage = value;
                    NotifyPropertyChanged("ProgressPercentage");
                }
            }
        }
        public string ThreadId { get; set; }
        public string Result { get; set; }

        private void OnRainseStatusChanged(object obj)
        {
            if (StatusChanged != null)
            {
                StatusChanged(this);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
    }


}