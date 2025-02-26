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
            this.Name = name;
            this.Teacher = teacher;
        }
        public string? Name { get; set; }
        public int? TeacherId { get; set; }
        public Teacher? Teacher { get; set; }
        public override string ToString()
        {
           return $"Course Name: {Name}, Teacher: {Teacher}\n"; //nonemu ToString() (please work my dear god)
        } 
    }
}
