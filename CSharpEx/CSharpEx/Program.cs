using System;
using System.Collections.Generic;
using System.Linq;
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

            Console.ReadKey();
        }
    }
}
