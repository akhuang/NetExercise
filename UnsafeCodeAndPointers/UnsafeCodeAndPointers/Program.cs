using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnsafeCodeAndPointers
{
    /// <summary>
    /// 指针操作及不安全代码
    /// *表示间接寻址运算符
    /// &表示取存储值的地址
    /// </summary>
    class Program
    {
        unsafe static void Main(string[] args)
        {
            int mynum = 100;
            int* addr = &mynum;

            //*addr表示取值
            Console.WriteLine(*addr);

            addr++;
            Console.WriteLine(*addr);



            char theChar = 'Z';
            char* pChar = &theChar;
            void* pVoid = pChar;
            int* pInt = (int*)pVoid;

            System.Console.WriteLine("Value of theChar = {0}", theChar);
            System.Console.WriteLine("Address of theChar = {0:X2}", (int)pChar);
            System.Console.WriteLine("Value of pChar = {0}", *pChar);
            System.Console.WriteLine("Value of pInt = {0}", *pInt); //此处为什么是90呢
            //  output:
            /*  theChar 的值 = Z
                theChar 的地址 = 12F718
                pChar 的值 = Z
                pInt 的值 = 90 //??
             */

            Console.WriteLine("value of (int)theChar:", theChar);

            AddressOfOperator.Run();
            Console.ReadKey();
        }
    }
}
