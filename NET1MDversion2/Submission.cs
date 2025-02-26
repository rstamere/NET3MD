using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET1MDversion2
{
    //6 UZD
    public class Submission
    {
        [Key]
        public int ID { get; set; }
        public Submission(Assignment assignment, Student student, DateTime submissionTime, int score) //konstruktors, jo bija error (VS piedāvājo šo, kā labojumu)
        {
            this.Assignment = assignment;
            this.Student = student;
            this.SubmissionTime = submissionTime;
            this.Score = score;
        }
        public Submission() { } //xml my beloved please work
        public Assignment? Assignment { get; set; }
        public Student? Student { get; set; }
        public DateTime SubmissionTime { get; set; }
        public int Score { get; set; }

        public override string ToString()
        {
            return $"Submission for {Assignment} by {Student}, Score: {Score}, Submitted on: {SubmissionTime}\n"; //nonemu ToString() (please work my dear god)
        } 
    }
}
