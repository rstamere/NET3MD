using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static System.Formats.Asn1.AsnWriter;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NET1MDversion2
{
    public class schoolManager : IDataManager
    {
        private SchoolInfo _schoolinfo;
        private SchoolContext _schoolContext; //lai varētu save changes db
        private string _connectionString; 

        public schoolManager(SchoolInfo schoolinfo, string connectionString)
        {
            _schoolinfo = schoolinfo;
            _connectionString = connectionString;
            _schoolContext = new SchoolContext(_connectionString);
        }

        public schoolManager(SchoolInfo schoolinfo) //konstruktors, kas inicialize schoolinfo
        {
            _schoolinfo = new SchoolInfo();
            _schoolContext = new SchoolContext(); //please work stop ruining my database
        }

        public SchoolInfo SchoolInfo
        {
            get { return _schoolinfo; } 
        }


        //public string printAllStudentsDB()
        //{
        //    string text = "Students: \n";
        //    try
        //    {
        //        if (_schoolContext.Students.Any())
        //        {
        //            foreach (var student in _schoolContext.Students)
        //            {
        //                text += student.ToString() + Environment.NewLine;
        //            }
        //        }
        //        else
        //        {
        //            text = "No students found in the database.";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        text = "An error occurred while fetching students: " + ex.Message;
        //    }
        //    return text;
        //}

        //public string printAllTeachersDB()
        //{
        //    string text = "Teachers: \n";
        //    try
        //    {
        //        if (_schoolContext.Teachers.Any())
        //        {
        //            foreach (var teacher in _schoolContext.Teachers)
        //            {
        //                text += teacher.ToString() + Environment.NewLine;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        text = "An error occurred while fetching teachers: " + ex.Message;
        //    }
        //    return text;
        //}

        //public string printAllCoursesDB()
        //{
        //    string text = "Courses: \n";
        //    try
        //    {
        //        if (_schoolContext.Courses.Any())
        //        {
        //            foreach (var course in _schoolContext.Courses)
        //            {
        //                text += course.ToString() + Environment.NewLine;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        text = "An error occurred while fetching courses: " + ex.Message;
        //    }
        //    return text;
        //}

        //public string printAllAssignmentsDB()
        //{
        //    string text = "Assignments: \n";
        //    try
        //    {
        //        if (_schoolContext.Assignments.Any())
        //        {
        //            foreach (var assignment in _schoolContext.Assignments)
        //            {
        //                text += assignment.ToString() + Environment.NewLine;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        text = "An error occurred while fetching assignments: " + ex.Message;
        //    }
        //    return text;
        //}

        //public string printAllSubmissionsDB()
        //{
        //    string text = "Submissions: \n";
        //    try
        //    {
        //        if (_schoolContext.Submissions.Any())
        //        {
        //            foreach (var submission in _schoolContext.Submissions)
        //            {
        //                text += submission.ToString() + Environment.NewLine;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        text = "An error occurred while fetching submissions: " + ex.Message;
        //    }
        //    return text;
        //}
        public string print() //mazliet izmainiju (VS automatiski piedavaja)
        {
            string text = "";

            try
            {
                if (_schoolContext.Students.Any())
                {
                    text += "Students:\n";
                    foreach (var student in _schoolContext.Students)
                    {
                        text += student.ToString() + Environment.NewLine;
                    }
                }

                if (_schoolContext.Teachers.Any())
                {
                    text += "Teachers:\n";
                    foreach (var teacher in _schoolContext.Teachers)
                    {
                        text += teacher.ToString() + Environment.NewLine;
                    }
                }

                if (_schoolContext.Courses.Any())
                {
                    text += "Courses:\n";
                    foreach (var course in _schoolContext.Courses)
                    {
                        text += course.ToString() + Environment.NewLine;
                    }
                }

                if (_schoolContext.Assignments.Any())
                {
                    text += "Assignments:\n";
                    foreach (var assignment in _schoolContext.Assignments)
                    {
                        text += assignment.ToString() + Environment.NewLine;
                    }
                }

                if (_schoolContext.Submissions.Any())
                {
                    text += "Submissions:\n";
                    foreach (var submission in _schoolContext.Submissions)
                    {
                        text += submission.ToString() + Environment.NewLine;
                    }
                }
            }
            catch (Exception ex)
            {
                text = "An error occurred while fetching data: " + ex.Message;
            }

            return text;

            //string text = _schoolContext.printAllStudentsDB();
            //text += printAllTeachersDB();
            //text += printAllCoursesDB();
            //text += printAllAssignmentsDB();
            //text += printAllSubmissionsDB();
            //return text;

            //string result = _schoolinfo.printAllStudents();
            //result += "Teachers:\n";
            //foreach (var teacher in _schoolContext.Teachers.ToList())
            //{
            //    result += teacher.ToString() + "\n";
            //}
            //result += "Courses:\n";
            //foreach (var course in _schoolContext.Courses.ToList())
            //{
            //    var teacher = _schoolContext.Teachers.FirstOrDefault(t => t.ID == course.TeacherId);
            //    result += $"Course Name: {course.Name}, Teacher: {teacher.ToString()}\n";
            //}
            ////result += _schoolinfo.printAllTeachers();
            ////result += $"Courses: {_schoolinfo.countAllCourses()}\n";
            //result += _schoolinfo.printAllAssignments();
            //result += _schoolinfo.printAllSubmissions();
            ////foreach (var submission in _schoolContext.Submissions.ToList())
            ////{
            ////    result += submission.ToString() + "\n";
            ////}
            //return result;
        }

        public void createTestData() //sis kods tika uzgenerets izmantojot AI riku
        {
            if (_schoolinfo == null) //initialize schoolinfo if it is null
            {
                _schoolinfo = new SchoolInfo();
            }
            var testData = SchoolInfo.GetTestData();

            // Add students one by one - jo ObservableCollection nevar pievienot visu sarakstu uzreiz (diemzel)
            foreach (var student in testData.Students)
            {
                _schoolinfo.Students.Add(student);
                _schoolContext.Students.Add(student); //saglaba izmainas db
            }

            // Add teachers one by one
            foreach (var teacher in testData.Teachers)
            {
                _schoolinfo.Teachers.Add(teacher);
                _schoolContext.Teachers.Add(teacher); 
            }

            // Add courses one by one
            foreach (var course in testData.Courses)
            {
                _schoolinfo.Courses.Add(course);
                _schoolContext.Courses.Add(course);
            }

            // Add assignments one by one
            foreach (var assignment in testData.Assignments)
            {
                _schoolinfo.Assignments.Add(assignment);
                _schoolContext.Assignments.Add(assignment);
            }

            // Add submissions one by one
            foreach (var submission in testData.Submissions)
            {
                _schoolinfo.Submissions.Add(submission);
                _schoolContext.Submissions.Add(submission);
            }

            _schoolContext.SaveChanges(); //saglabā izmaiņas db
        }
        public void reset()
        {
            _schoolinfo.Students.Clear();
            _schoolinfo.Teachers.Clear();
            _schoolinfo.Courses.Clear();
            _schoolinfo.Assignments.Clear();
            _schoolinfo.Submissions.Clear();

            //izdzēš visu no db
            _schoolContext.Students.RemoveRange(_schoolContext.Students);
            _schoolContext.Teachers.RemoveRange(_schoolContext.Teachers);
            _schoolContext.Courses.RemoveRange(_schoolContext.Courses);
            _schoolContext.Assignments.RemoveRange(_schoolContext.Assignments);
            _schoolContext.Submissions.RemoveRange(_schoolContext.Submissions); 

            _schoolContext.SaveChanges(); //saglabā izmaiņas db
        }

        public void addStudent(string name, string surname, Person.GenderType gender, string studentIDNumber) //jauna metode, kas lauj lietotajam pievienot jaunu studentu schoolInfo
        {
            _schoolinfo.Students.Add(new Student(name, surname, gender, studentIDNumber));
            _schoolContext.Students.Add(new Student(name, surname, gender, studentIDNumber)); //idek
            _schoolContext.SaveChanges(); //saglabā izmaiņas db
        }

        public ObservableCollection<Student> getStudents() //man nestradaja _schoolinfo var jo private
        {
            return _schoolinfo.Students;
        }
        public void addAssignment(DateTime deadline, Course course, string description) //jauna metode, kas lauj lietotajam pievienot jaunu Assignment schoolInfo
        {
            _schoolinfo.Assignments.Add(new Assignment(deadline, course, description));
            _schoolContext.Assignments.Add(new Assignment(deadline, course, description));
            _schoolContext.SaveChanges(); //saglabā izmaiņas db
        }
        public void addSubmission(Assignment assignment, Student student, DateTime submissionDate, int score) //jauna metode, kas lauj lietotajam pievienot jaunu Submission schoolInfo
        {
            _schoolinfo.Submissions.Add(new Submission(assignment, student, submissionDate, score));
            _schoolContext.Submissions.Add(new Submission(assignment, student, submissionDate, score));
            _schoolContext.SaveChanges(); //saglabā izmaiņas db
        }

        // Kāpēc šo vajag you may ask?
        // man nav editSubmission un editAssignment šeit, tāpēc būs vnk jāuztaisa metode save un jareferenco tajās lapās, kur notiek edit
        public void saveChanges() //jauna metode, kas lauj saglabat izmainas db
        {
            _schoolContext.SaveChanges();
        }
    }
}
