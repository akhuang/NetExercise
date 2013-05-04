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
}
