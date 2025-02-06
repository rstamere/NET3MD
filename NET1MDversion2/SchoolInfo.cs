using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static NET1MDversion2.Person;

namespace NET1MDversion2
{
    //7 UZD
    [XmlRoot("SchoolInfo")]
    public class SchoolInfo //nomainīju īpašības uz public, lai tas būtu redzams schoolManager
    {
        public ObservableCollection<Student> Students { get; set; } //VS visu šo automātiski piedāvāja
        [XmlArray("Teachers")]
        [XmlArrayItem("Teacher")]
        public ObservableCollection<Teacher> Teachers { get; set; }
        [XmlArray("Courses")]
        [XmlArrayItem("Course")]
        public ObservableCollection<Course> Courses { get; set; }
        public ObservableCollection<Assignment> Assignments { get; set; }
        public ObservableCollection<Submission> Submissions { get; set; }

        public SchoolInfo() // izmantoju https://www.youtube.com/watch?v=aLhAmimoQj8&list=TLPQMDcxMDIwMjS9_9GISlYk1w&index=3 
        {
            Students = new ObservableCollection<Student>(); //nomaiju no List uz ObservableCollection, lai varētu parādīties pie Bindable jaunais elements/atributs (idk)
            Teachers = new ObservableCollection<Teacher>();
            Courses = new ObservableCollection<Course>();
            Assignments = new ObservableCollection<Assignment>();
            Submissions = new ObservableCollection<Submission>();

        }

        public static SchoolInfo GetTestData()
        {
            var schoolInfo = new SchoolInfo();

            schoolInfo.Students.Add(new Student("John", "Doe", GenderType.Man, "jd82218"));  //0
            schoolInfo.Students.Add(new Student("Davis", "Dickinson", GenderType.Man, "dd99623")); //1
            schoolInfo.Students.Add(new Student("Diana", "Myrtle", GenderType.Woman, "dm041278")); //2
            schoolInfo.Students.Add(new Student("Luke", "Skywalker", GenderType.Man, "dm041278")); //3
            schoolInfo.Students.Add(new Student("Elizabeth", "Hartley", GenderType.Woman, "dm041278")); //4
            schoolInfo.Students.Add(new Student("James", "Holland", GenderType.Man, "dm041278")); //5
            schoolInfo.Students.Add(new Student("Martha", "Jenkins", GenderType.Woman, "dm041278")); //6

            schoolInfo.Teachers.Add(new Teacher("Josie", "Doe", GenderType.Woman, new DateTime(2004, 5, 15)));
            schoolInfo.Teachers.Add(new Teacher("Neville", "Longbottom", GenderType.Man, new DateTime(2004, 5, 15)));
            schoolInfo.Teachers.Add(new Teacher("Kristopher", "Ray", GenderType.Man, new DateTime(2004, 5, 15)));

            schoolInfo.Courses.Add(new Course("Abstract Algebra", schoolInfo.Teachers[0]));
            schoolInfo.Courses.Add(new Course("Programming in Python", schoolInfo.Teachers[1]));
            schoolInfo.Courses.Add(new Course("Calculus", schoolInfo.Teachers[2]));

            schoolInfo.Assignments.Add(new Assignment(new DateTime(2024, 6, 7), schoolInfo.Courses[0], "Calculate the determinant of the given matrices."));
            schoolInfo.Assignments.Add(new Assignment(new DateTime(2024, 5, 15), schoolInfo.Courses[1], "Make a program that parses through the given list."));
            schoolInfo.Assignments.Add(new Assignment(new DateTime(2024, 6, 20), schoolInfo.Courses[2], "Find the integral of the given functions."));

            schoolInfo.Submissions.Add(new Submission(schoolInfo.Assignments[0], schoolInfo.Students[0], DateTime.Now, 9)); //jā, visi studenti iesūtīja assignment vienā laikā, kas par to?
            schoolInfo.Submissions.Add(new Submission(schoolInfo.Assignments[1], schoolInfo.Students[0], DateTime.Now, 6));
            schoolInfo.Submissions.Add(new Submission(schoolInfo.Assignments[2], schoolInfo.Students[0], DateTime.Now, 8));

            schoolInfo.Submissions.Add(new Submission(schoolInfo.Assignments[0], schoolInfo.Students[1], DateTime.Now, 10));
            schoolInfo.Submissions.Add(new Submission(schoolInfo.Assignments[1], schoolInfo.Students[1], DateTime.Now, 9));
            schoolInfo.Submissions.Add(new Submission(schoolInfo.Assignments[2], schoolInfo.Students[1], DateTime.Now, 9));

            schoolInfo.Submissions.Add(new Submission(schoolInfo.Assignments[0], schoolInfo.Students[2], DateTime.Now, 7));
            schoolInfo.Submissions.Add(new Submission(schoolInfo.Assignments[1], schoolInfo.Students[2], DateTime.Now, 5));
            schoolInfo.Submissions.Add(new Submission(schoolInfo.Assignments[2], schoolInfo.Students[2], DateTime.Now, 4));

            schoolInfo.Submissions.Add(new Submission(schoolInfo.Assignments[0], schoolInfo.Students[3], DateTime.Now, 6));
            schoolInfo.Submissions.Add(new Submission(schoolInfo.Assignments[1], schoolInfo.Students[3], DateTime.Now, 4));
            schoolInfo.Submissions.Add(new Submission(schoolInfo.Assignments[2], schoolInfo.Students[3], DateTime.Now, 5));

            schoolInfo.Submissions.Add(new Submission(schoolInfo.Assignments[0], schoolInfo.Students[4], DateTime.Now, 10));
            schoolInfo.Submissions.Add(new Submission(schoolInfo.Assignments[1], schoolInfo.Students[4], DateTime.Now, 5));
            schoolInfo.Submissions.Add(new Submission(schoolInfo.Assignments[2], schoolInfo.Students[4], DateTime.Now, 5));

            schoolInfo.Submissions.Add(new Submission(schoolInfo.Assignments[0], schoolInfo.Students[5], DateTime.Now, 8));
            schoolInfo.Submissions.Add(new Submission(schoolInfo.Assignments[1], schoolInfo.Students[5], DateTime.Now, 8));
            schoolInfo.Submissions.Add(new Submission(schoolInfo.Assignments[2], schoolInfo.Students[5], DateTime.Now, 8));

            schoolInfo.Submissions.Add(new Submission(schoolInfo.Assignments[0], schoolInfo.Students[6], DateTime.Now, 7));
            schoolInfo.Submissions.Add(new Submission(schoolInfo.Assignments[1], schoolInfo.Students[6], DateTime.Now, 6));
            schoolInfo.Submissions.Add(new Submission(schoolInfo.Assignments[2], schoolInfo.Students[6], DateTime.Now, 5));

            return schoolInfo;
        }

        public string printAllStudents() //parveidoju metodes, lai taas atgrieztu string un neprintetu konsolee (VS so visu automatiski piedavaja)
        {
            string result = "Students: \n";
            foreach (Student student in Students)
            {
                result += student.ToString() + "\n";
            }
            return result;
        }
        public string printAllTeachers()
        {
            string result = "Teachers: \n";
            foreach (Teacher teacher in Teachers)
            {
                result += teacher.ToString() + "\n";
            }
            return result;
        }
        public string printAllCourses()
        {
            string result = "Courses: \n";
            foreach (Course course in Courses)
            {
                result += course.ToString() + "\n";
            }
            return result;
        }
        public string printAllAssignments()
        {
            string result = "Assignments: \n";
            foreach (Assignment assignment in Assignments)
            {
                result += $"{assignment.ToString()}" + "\n";
            }
            return result;
        }
        public string printAllSubmissions()
        {
            string result = "Submissions: \n";
            foreach (Submission submission in Submissions)
            {
                result += submission.ToString() + "\n";
            }
            return result;

        }
    }
}
