using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NET1MD
{
    //4 UZD
    public class Course
    {
        public Course() { } //parameterless constructor for serialization
        public Course(string name, Teacher teacher)  //konstruktors, jo bija error (VS piedāvājo šo, kā labojumu)
        {
            Name = name;
            Teacher = teacher;
        }

        [XmlElement("Name")]
        public string Name { get; set; }
        [XmlElement("Teacher")]
        public Teacher Teacher { get; set; }
        public override string ToString() => $"Course Name: {Name}, Teacher: {Teacher.ToString()}\n";
    }
}
