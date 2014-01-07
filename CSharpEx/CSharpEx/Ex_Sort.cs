using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpEx
{
    public class Ex_Sort
    {
        public static IEnumerable<int> list = new List<int>() { 
            10,200,8,9,65,2,1,12,38
        };

        public static void SortList()
        {
            IEnumerable<int> tmpList = list.OrderByDescending(x => x);

            foreach (var item in tmpList)
            {
                Console.WriteLine(item);
            }
        }

        public static void BubbleSort()
        {
            
        }
    }
}
