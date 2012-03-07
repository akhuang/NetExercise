using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IOC_Ex01
{
    public class Container
    {
        static IDictionary<string, object> beans;

        public Container()
        {
            beans = new Dictionary<string, object>();
            Console.WriteLine("初始化Container...");
            //把generator/manager加进beans
            IGenerator pdf = new PdfGenerator();
            beans.Add("pdf", pdf);

            GeneratorManager manager = new GeneratorManager(pdf);
            beans.Add("manager", manager);
            Console.WriteLine("结束初始化Container...");
        }


        public static object GetBean(string key)
        {
            object value;
            beans.TryGetValue(key, out value);

            return value;
        }
    }
}
