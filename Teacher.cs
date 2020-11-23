using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetOOP_v2
{
    class Teacher : Person
    {
        public Course Course;
        public List<List<Student>> GroupStudents { get; set; }

        public Teacher(string name, string adress, string phoneNumber, string login, string password)
            : base(name, adress, phoneNumber, login, password)
        {
            GroupStudents = new List<List<Student>>();
        }

        public override void DisplayInformation()
        {
            Console.WriteLine($"Name : {Name}");
            Console.WriteLine($"Adress : {Adress}");
            Console.WriteLine($"Phone Number : {PhoneNumber}");
            Console.WriteLine($"Email / Login : {Login}");
        }

        public void InscriptionCourseStudent(Student name)
        {
            name.Courses.Add(Course);
        }

    }
}
