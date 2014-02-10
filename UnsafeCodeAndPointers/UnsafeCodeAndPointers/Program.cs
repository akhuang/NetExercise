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
            Console.WriteLine("after addr++:" + *addr);
            Console.WriteLine("address of addr:{0:X2}", (int)addr);

            addr--;
            Console.WriteLine("after addr--:" + *addr);
            Console.WriteLine("address of addr:{0:X2}", (int)addr);

            string str = "hello world";
            fixed (char* pstr = str) //此处*pstr为指向str的第一个元素
            {
                Console.WriteLine("value of str:{0}", *pstr);
            }
            char[] charArr = str.ToCharArray();
            Console.WriteLine("char[] to string:{0}", new string(charArr)); //对于char[],可以直接使用new string(char[])转换为字符串

            //fixed (char* pstr = &charArr) //此处*pstr为指向str的第一个元素
            //{
            //    Console.WriteLine("value of str:{0}", *pstr);
            //}

            char theChar = 'Z';
            char* pChar = &theChar;
            void* pVoid = pChar;
            int* pInt = (int*)pVoid;

            System.Console.WriteLine("Value of theChar = {0}", theChar);
            System.Console.WriteLine("Address of theChar = {0:X2}", (int)pChar);
            System.Console.WriteLine("Value of pChar = {0}", *pChar);
            System.Console.WriteLine("Value of pInt = {0}", *pInt); //90; 根据地ASCII码对照表,字符'Z'对应的10进制为90
            //  output:
            /*  theChar 的值 = Z
                theChar 的地址 = 12F718
                pChar 的值 = Z
                pInt 的值 = 90 
             */

            Console.WriteLine("value of (int)theChar:", theChar);

            AddressOfOperator.Run();

            AccessMembers.Run();

            PointerConversion.Run();

            Console.ReadKey();
        }
    }
}
