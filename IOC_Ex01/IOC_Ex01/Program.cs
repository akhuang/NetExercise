using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IOC_Ex01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("direct invoke...");
        

            new Container();
            GeneratorManager manager = (GeneratorManager)Container.GetBean("manager");
            manager.DoSomething();
            //Manager与接口有耦合关系
            //generator = manager.generator;


            //generator.Generate();
            Console.WriteLine("----------------------------------------");

            Console.ReadKey();



        }
    }
}
