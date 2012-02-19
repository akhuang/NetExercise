using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace AD101CNET.FileData
{
    public class FileDataCollection : BindingList<FileData>
    {
        FileDataStatusChangedEventHandler handler;
        public FileDataCollection()
        {
            handler = new FileDataStatusChangedEventHandler(FileData_StatusChanged);
            FileData.StatusChanged += handler;
        }

        public void FileData_StatusChanged(FileData data)
        {
            int index = -1;
            if ((index = IndexOf(data)) >= 0)
            {
                this.ResetItem(index);
            }
        }
    }
}
