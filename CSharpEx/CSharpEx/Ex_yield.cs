using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpEx
{
    public class Ex_yield
    {

    }

    public class DaysOfTheWeek : IEnumerable
    {
        string[] days = { "Sun", "Mon", "Tue", "Wed", "Thr", "Fri", "Sat" };
        public IEnumerator GetEnumerator()
        {
            foreach (var item in days)
            {
                yield return item;
            }
        }
    }

    public class SampleCollection
    {
        public int[] items;

        public SampleCollection()
        {
            items = new int[5] { 5, 4, 7, 9, 3 };
        }

        public IEnumerable BuildCollection()
        {
            for (int i = 0; i < items.Length; i++)
            {
                yield return items[i];
            }
        }
    }
}
