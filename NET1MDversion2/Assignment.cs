using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET1MDversion2
{
    //5 UZD
    public class Assignment
    {
        [Key]
        public int ID { get; set; }
        public Assignment() { } //parameterless constructor for serialization

        public Assignment(DateTime deadline, Course course, string description) //konstruktors, jo bija error (VS piedāvājo šo, kā labojumu)
        {
            Deadline = deadline;
            Course = course;
            Description = description;
        }

        public DateTime Deadline { get; set; }
        public Course? Course { get; set; }
        public string? Description { get; set; }
        public override string ToString()
        {
            return $"Assignment deadline: {Deadline}, Course: {Course}, Assignment description: {Description}\n"; //nonemu ToString()
        } 

    }
}
