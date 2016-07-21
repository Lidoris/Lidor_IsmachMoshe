using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQToObjects
{
    class Student
    {
        public int ID { get; private set; }
        public string Name { get; private set; }
        public int Age { get; private set; }

        public Student(int id, string name, int age)
        {
            ID = id;
            Name = name;
            Age = age;
        }

        public override string ToString()
        {
            return string.Format("ID = {0}, Name = {1}, Age = {2} ", ID, Name, Age);
        }
    }
}
