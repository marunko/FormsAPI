using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormsAPI
{
    class Person
    {
        public string name { get; set; }
        public int age { get; set; }
        public int id { get; set; }

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
        public Person(int id, string name, int age)
        {
            this.id = id;
            this.name = name;
            this.age = age;
        }
        public Person()
        {

        }
    }
}
