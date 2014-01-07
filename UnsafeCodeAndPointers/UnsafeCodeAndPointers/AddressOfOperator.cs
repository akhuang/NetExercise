using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnsafeCodeAndPointers
{
    class AddressOfOperator
    {
        public static void Run()
        {
            int number;

            unsafe
            {
                int* p = &number;

                //*p = 0xffff;
                *p = 10; //此处修改了number的值; 因为p存的是nubmer的地址

                Console.WriteLine("AddressOfOperator: value of *p:" + *p);
                Console.WriteLine("AddressOfOperator: address of p:{0}", (int)p);

                //
                Console.WriteLine("AddressOfOperator: address of number:{0}", number);
            }
        }

    }
}
