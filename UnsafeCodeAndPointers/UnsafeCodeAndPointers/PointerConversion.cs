using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnsafeCodeAndPointers
{
    class PointerConversion
    {
        public static void Run()
        {
            Console.WriteLine();
            Console.WriteLine("****PointerConversion****");

            int number = 1024;

            unsafe
            {
                byte* p = (byte*)&number;
                Console.Write("The 4 bytes of the integer:");

                //int=int32,32位; sizeof(int)=4; int占4个字节; 1字节8位
                for (int i = 0; i < sizeof(int); i++)
                {
                    Console.Write(" {0:x2}", *p);
                    p++;
                }

                Console.WriteLine();
                Console.WriteLine("The value of the integer:{0}", number);

                //1024 
                //0    0    0    0    0    4    0    0
                //0000 0000 0000 0100 0000 0100 0000 0000

                //output:
                //  00
                //  04
                //  00
                //  00
            }

            sbyte dtmf = 66;
            char dc = (char)dtmf;
            Console.WriteLine(dc);
        }
    }
}
