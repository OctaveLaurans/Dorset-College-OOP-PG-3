using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetOOP_v2
{
    class Admin : Person
    {

        List<Student> GroupStudents { get; set; }
        List<Teacher> GroupTeachers { get; set; }

        public Admin(string name, string adress, string phoneNumber, string login, string password, List<Student> students, List<Teacher> teachers)
        {
            this.Name = name;
            this.Adress = adress;
            this.PhoneNumber = phoneNumber;
            this.Login = login;
            this.Password = password;
            this.GroupStudents = students;
            this.GroupTeachers = teachers; 

        }

        public Course CreationCourse()
        {
            Console.WriteLine("You want to create a course, what's the subject ?");
            string nameCourse= Console.ReadLine();
            Console.WriteLine("Course date ?");
            string dateCourse = Console.ReadLine();
            Console.WriteLine("At what time ?");
            int hourCourse = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Subject : {nameCourse}, Date : {dateCourse}, Hours : {hourCourse}");

            Course course  = new Course { NameCourse = nameCourse, DateCourse = dateCourse, HourCourse = hourCourse };

            return course;
        }

        public void InscriptionCourse(Course course, Student name, Teacher teacher)
        {
            name.Courses.Add(course);

            teacher.GroupStudents.Add(name);
        }

    }
}
