using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET1MD
{
    //6 UZD
    public class Submission
    {
        public Submission(Assignment assignment, Student student, DateTime submissionTime, int score) //konstruktors, jo bija error (VS piedāvājo šo, kā labojumu)
        {
            Assignment = assignment;
            Student = student;
            SubmissionTime = submissionTime;
            Score = score;
        }
        public Submission() { } //xml my beloved please work
        public Assignment Assignment { get; set; }
        public Student Student { get; set; }
        public DateTime SubmissionTime { get; set; }
        public int Score { get; set; }

        public override string ToString() => $"Submission for {Assignment.Course.Name} by {Student.FullName}, Score: {Score}, Submitted on: {SubmissionTime.ToShortDateString()}\n"; //AI rīks piedāvāja šo, kā labojumu
    }
}
