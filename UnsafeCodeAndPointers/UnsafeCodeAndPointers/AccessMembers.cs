using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnsafeCodeAndPointers
{
    class AccessMembers
    {
        struct CoOrds
        {
            public int x;
            public int y;
        }

        public static void Run()
        {
            Console.WriteLine();
            Console.WriteLine("****AccessMembers****");

            CoOrds home;

            unsafe
            {
                CoOrds* p = &home;
                p->x = 25;
                p->y = 12;

                System.Console.WriteLine("The coordinates are: x={0}, y={1}", p->x, p->y);

                Console.WriteLine("&home.x:{0}", (int)(&home.x));
            }
        }
    }
}
