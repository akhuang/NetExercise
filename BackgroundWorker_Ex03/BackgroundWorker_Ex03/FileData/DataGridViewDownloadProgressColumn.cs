using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace AD101CNET.FileData
{
    public class DataGridViewDownloadProgressColumn : DataGridViewColumn
    {
        /// <summary>
        /// 以DataGridViewDownloadProgressCell为元素的列
        /// </summary>
        public DataGridViewDownloadProgressColumn()
        {
            this.ValueType = typeof(float);
            this.CellTemplate = new DataGridViewDownloadProgressCell();
        }
    }
}
