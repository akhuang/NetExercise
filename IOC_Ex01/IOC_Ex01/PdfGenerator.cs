using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IOC_Ex01
{
    public class PdfGenerator : IGenerator
    {
        public void Generate()
        {
            Console.WriteLine("Generate pdf...");
        }

        public PdfGenerator()
        {
            Console.WriteLine("PdfGenerator constructor...");
        }
    }
}
