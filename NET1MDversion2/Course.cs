using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NET1MDversion2
{
    //4 UZD
    public class Course
    {
        [Key]
        public int ID { get; set; }
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
