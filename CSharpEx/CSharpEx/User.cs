using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpEx
{
    public class User
    {
        public string UserName { get; set; }

        public User() { }
    }

    public class Student
    {
        public string Name { get; set; }

        public Student() { }

        public Student(User user)
        {
        }
        public Student(string name) { Name = name; }
    }
}
