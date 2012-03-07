using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IOC_Ex01
{
    public class GeneratorManager
    {
        private IGenerator generator;
        public GeneratorManager(GeneratorType type)
        {
            //这里根据传入的类型进行动态构建
            switch (type)
            {
                case GeneratorType.Pdf:
                    {
                        generator = new PdfGenerator();
                        break;
                    }
                case GeneratorType.Excel:
                    {
                        generator = new ExcelGenerator();
                        break;
                    }
                default:
                    break;
            }
        }
        public GeneratorManager(IGenerator generator)
        {
            this.generator = generator;
        }

        public void DoSomething()
        {
            Console.WriteLine("Manager do sth...");
            generator.Generate();
        }

    }

    public enum GeneratorType
    {
        Pdf = 1,
        Excel = 2,
    }
}
