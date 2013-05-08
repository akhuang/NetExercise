using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpEx
{

    public class Ex_Func
    {
        delegate bool WriteMethod();

        public static void WriteToTarget()
        {
            WriteMethod methodCall = OutputTarget.WriteToConsole;

            if (methodCall())
            {
                Console.WriteLine("success");
            }

            Func<bool> func = (() => OutputTarget.WriteToConsole());

            if (func())
            {
                Console.WriteLine("success");
            }
        }
    }

    public class OutputTarget
    {
        public static bool WriteToConsole()
        {
            Console.Write("write to console....");
            return true;
        }
    }
}
