using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Winform_ChangeUI
{
    public class MainService
    {
        public Lazy<MainService> _instance = new Lazy<MainService>();
        public MainService Current
        {
            get
            {
                return _instance.Value;
            }
        }

        public Form MainForm
        {
            get;
            set;
        }

        public void Start()
        {
            if (MainForm is Form1)
            {
                Form1 form = MainForm as Form1;
                Utils.AddLog(form);
            }
        }
    }
}
