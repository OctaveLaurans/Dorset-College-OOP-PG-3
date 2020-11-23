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
            : base(name, adress, phoneNumber, login, password)
        {
            AllStudents = new List<Student>();
            AllTeachers = new List<Teacher>();

        }

        public override void DisplayInformation()
        {
            Console.WriteLine($"Name : {Name}");
            Console.WriteLine($"Adress : {Adress}");
            Console.WriteLine($"Phone Number : {PhoneNumber}");
            Console.WriteLine($"Email / Login : {Login}");
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
            Console.WriteLine("Course date ? (Day in the week)");
            string dayCourse = Console.ReadLine();
            Console.WriteLine("At what time ? (HH:MM)");
            string hourCourse = Console.ReadLine();
            Console.WriteLine("Duration ? (in decimal form)");
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

        public Exam CreationExam()
        {
            Console.WriteLine("You want to create an Exam, what's the subject ?");
            string nameExam = Console.ReadLine();
            Console.WriteLine("Exam date ? (DD/MM)");
            string dayExam = Console.ReadLine();
            Console.WriteLine("At what time ? (HH:MM)");
            string hourExam = Console.ReadLine();
            Console.WriteLine("Duration ? (in decimal form)");
            double durationExam = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine($"Subject : {nameExam}, Date : {dayExam}, Hours : {hourExam}");

            Exam exam = new Exam { NameExam = nameExam, DayExam = dayExam, HourExam = hourExam };

            return exam;
        }

        public void IncsriptionExam(Exam exam, List<Student> students)
        {//We have to verify that the student follows the exam subject
            foreach (Student student in students)
            {
                student.Exams.Add(exam);
            }
        }
    }
}
