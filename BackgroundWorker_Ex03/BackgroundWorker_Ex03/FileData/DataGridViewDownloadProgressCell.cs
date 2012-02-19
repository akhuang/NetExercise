using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;

namespace AD101CNET
{
    /// <summary>
    /// 能够用一个进度条显示下载进度的单元格控件
    /// </summary>
    public class DataGridViewDownloadProgressCell : DataGridViewImageCell
    {
        /// <summary>
        /// 指示能够使用ViusalStyle模式的控件
        /// 比如Windows XP风格的控件
        /// </summary>
        bool isVisualStyled;
        static Bitmap contentImage = new Bitmap(75, 18, PixelFormat.Format32bppPArgb);
        static Bitmap emptyImage = new Bitmap(75, 18, PixelFormat.Format32bppPArgb);
        static Brush foreColor = new SolidBrush(Color.Navy);
        static Brush blackBrush = new SolidBrush(Color.Black);
        static Brush lightGreenBrush = new SolidBrush(Color.LightGreen);
        static Graphics contentGraphics;
        static Pen blackPen = new Pen(new SolidBrush(Color.Black));
        static Rectangle borderRect = new Rectangle(0, 0, 70, 16);
        static Rectangle bigBorderRect = new Rectangle(0, 0, 70, 18);
        static Rectangle bigProgressRect = new Rectangle(2, 2, 0, 14);
        static Rectangle progressRect = new Rectangle(2, 2, 0, 12);

        static DataGridViewDownloadProgressCell()
        {
            contentGraphics = Graphics.FromImage(contentImage);
        }

        public DataGridViewDownloadProgressCell()
        {
            this.ValueType = typeof(float);
            this.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        protected override object GetFormattedValue(object value, int rowIndex, ref DataGridViewCellStyle cellStyle, TypeConverter valueTypeConverter, TypeConverter formattedValueTypeConverter, DataGridViewDataErrorContexts context)
        {
            isVisualStyled = VisualStyleInformation.IsEnabledByUser & VisualStyleInformation.IsSupportedByOS;
            if (value == null)
            {
                return emptyImage;
            }
            float percentage = (float)((int)value);
            if (percentage == 0)
                return emptyImage;
            else
            {
                contentGraphics.Clear(Color.Transparent);
                float drawedPercentage = percentage > 100 ? 100 : percentage;
                if (isVisualStyled)
                {
                    bigProgressRect.Width = (int)(66 * drawedPercentage / 100.0f);
                    ProgressBarRenderer.DrawHorizontalBar(contentGraphics, bigBorderRect);
                    ProgressBarRenderer.DrawHorizontalChunks(contentGraphics, bigProgressRect);
                }
                else
                {
                    progressRect.Width = (int)(66 * drawedPercentage / 100.0f);
                    contentGraphics.DrawRectangle(blackPen, borderRect);
                    contentGraphics.FillRectangle(lightGreenBrush, progressRect);
                }
                contentGraphics.DrawString(percentage.ToString("0.00") + "%", this.DataGridView.Font, foreColor, 10, 5);
            }
            return contentImage;
        }
    }
}
