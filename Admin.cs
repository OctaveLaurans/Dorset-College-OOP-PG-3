using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetOOP_v2
{
    class Admin : Person
    {

        public List<Student> AllStudents { get; set; }
        public List<Teacher> AllTeachers { get; set; }

        public Admin(string name, string adress, string phoneNumber, string login, string password)
        {
            this.Name = name;
            this.Adress = adress;
            this.PhoneNumber = phoneNumber;
            this.Login = login;
            this.Password = password;
            AllStudents = new List<Student>();
            AllTeachers = new List<Teacher>();

        }



        public List<Student> CreateStudentsGroup(Branche branche)
        {

            List<Student> groupStudents = new List<Student>();

            // Assume that admin knows which groups already exist (to avoid that he creates two TDs with the same number)
            Console.WriteLine("Which numero of TD do you want to create ?");
            int td = Convert.ToInt32(Console.ReadLine());

            int compteur = 0;
            while(groupStudents.Count<5 && compteur<AllStudents.Count)
            {
                if (AllStudents[compteur].Branche == branche && AllStudents[compteur].Group == 0)
                {
                    groupStudents.Add(AllStudents[compteur]);
                    AllStudents[compteur].Group = td;
                }
                compteur++;
            }

            return groupStudents;
        }



        public Course CreationCourse()
        {
            Console.WriteLine("You want to create a course, what's the subject ?");
            string nameCourse= Console.ReadLine();
            Console.WriteLine("Course date ?");
            string dayCourse = Console.ReadLine();
            Console.WriteLine("At what time ?");
            string hourCourse = Console.ReadLine();
            Console.WriteLine("Duration ?");
            double duration = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine($"Subject : {nameCourse}, Date : {dayCourse}, Hours : {hourCourse}");

            Course course  = new Course { NameCourse = nameCourse, DayCourse = dayCourse, HourCourse = hourCourse };

            return course;
        }

        public void IncsriptionCourse(Course course, Teacher teacher, List<Student> students)
        {
            teacher.Course = course;

            teacher.GroupStudents.Add(students);

            foreach(Student student in students)
            {
                student.Courses.Add(course);
            }
        }
    }
}
