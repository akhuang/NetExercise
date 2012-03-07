using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IOC_Ex01
{
    public class ExcelGenerator : IGenerator
    {
        public ExcelGenerator()
        {
            Console.WriteLine("ExcelGenerator constructor...");
        }

        public void Generate()
        {
            Console.WriteLine("Generate excel...");
        }
    }
}
