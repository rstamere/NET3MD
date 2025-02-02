using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET1MD
{
    //5 UZD
    public class Assignment
    {
        public Assignment() { } //parameterless constructor for serialization

        public Assignment(DateTime deadline, Course course, string description) //konstruktors, jo bija error (VS piedāvājo šo, kā labojumu)
        {
            Deadline = deadline;
            Course = course;
            Description = description;
        }

        public DateTime Deadline { get; set; }
        public Course Course { get; set; }
        public string Description { get; set; }
        public override string ToString() => $"Assignment deadline: {Deadline}, Course: {Course.ToString()}, Assignment description: {Description}\n";

    }
}
