using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using static NET1MDversion2.Person;

namespace NET1MDversion2
{
    internal class Program
    {
        static void Main(string[] args) //Viss kods, kas atrodas main tika uzģenerēts izmantojot AI rīku
        {
            //string filePath = @"C:\Temp\schooldata.xml";
            SchoolInfo school = new SchoolInfo();
            schoolManager manager = new schoolManager(new SchoolInfo());

            manager.createTestData();
            manager.print();
            //manager.save(filePath);
            manager.reset();
            manager.print();
            //manager.load(filePath);
            manager.print();

            school.printAllStudents();
            school.printAllTeachers();
            school.printAllCourses();
            school.printAllAssignments();
            school.printAllSubmissions();

            // Print counts
            //Console.WriteLine($"Total Students: {school.countAllStudents()}");
            //Console.WriteLine($"Total Teachers: {school.countAllTeachers()}");
            //Console.WriteLine($"Total Courses: {school.countAllCourses()}");
            //Console.WriteLine($"Total Assignments: {school.countAllAssignments()}");
            //Console.WriteLine($"Total Submissions: {school.countAllSubmissions()}");

            //Console.ReadLine();
        }
    }
}
