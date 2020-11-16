using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetOOP_v2
{
    class Admin : Person, ICourses
    {
        public string NameCourse { get; set; }
        public string DateCourse { get; set; }
        public int HourCourse { get; set; }

        List<Student> GroupStudents { get; set; }
        List<Teacher> GroupTeachers { get; set; }

        public Admin(string name, string adress, string phoneNumber, string login, string password, string nameCourse, string dateCourse, int hourCourse, List<Student> students, List<Teacher> teachers)
        {
            this.Name = name;
            this.Adress = adress;
            this.PhoneNumber = phoneNumber;
            this.Login = login;
            this.Password = password;
            this.NameCourse = nameCourse;
            this.DateCourse = dateCourse;
            this.HourCourse = hourCourse;
            this.GroupStudents = students;
            this.GroupTeachers = teachers; 

        }

        public static void CreationCourse()
        {
            Console.WriteLine("You want to create a course, what's the subject ?");
            this.NameCourse = Console.Readline();
            Console.WriteLine("Course date ?");
            this.DateCourse = Console.ReadLine();
            Console.WriteLine("At what time ?");
            this.HourCourse = Console.ReadLine();
            Console.WriteLine($"Subject : {this.NameCourse}, Date : {this.DateCourse}, Hour : {this.HourCourse}");
        }

    }
}
