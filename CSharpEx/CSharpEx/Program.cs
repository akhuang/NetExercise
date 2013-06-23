using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CSharpEx
{
    class Program
    {
        static void Main(string[] args)
        {
            DaysOfTheWeek week = new DaysOfTheWeek();
            foreach (var item in week)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine("");

            Console.WriteLine("SampleCollection:");
            SampleCollection sampleCollection = new SampleCollection();
            foreach (var item in sampleCollection.BuildCollection())
            {
                Console.WriteLine(item);
            }

            var componentType = typeof(User);
            var targetType = typeof(Student);
            var argumentExpression = Expression.Parameter(componentType, "component");
            var constructor = targetType.GetConstructor(new Type[] { componentType });
            var newExpression = Expression.New(constructor, argumentExpression);

            Ex_Func.WriteToTarget();

            string plainText = "phoenix";
            Console.WriteLine("plain text:" + plainText);
            string encryTxt = plainText.Encrypt();
            Console.WriteLine("encryption:" + encryTxt);
            Console.WriteLine("decrypt:" + encryTxt.Decrypt());

            Ex_ObjectGc.TestGc();

            Console.ReadKey();
        }
    }
}
