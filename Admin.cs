using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetOOP_v2
{
    class Admin : Person
    {

        public List<Student> AllStudents { get; set; }
        public List<Teacher> AllTeachers { get; set; }
        public List<Course> AllCourses { get; set; }

        public Admin(string name, string adress, string phoneNumber, string login, string password)
            : base(name, adress, phoneNumber, login, password)
        {
            AllStudents = new List<Student>();
            AllTeachers = new List<Teacher>();
            AllCourses = new List<Course>();

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

        public void ManageAttendance(List<Student> AllStudent)
        {
            int choice = 0;
            Console.Write("Enter the name of the student for whom you want to manage the attendance\n");
            string Nchoice = Console.ReadLine();
            bool x = false;
            for (int i = 0; i < AllStudent.Count; i++)
            {
                if (AllStudent[i].Name == Nchoice)
                {
                    x = true;
                }
                else
                {
                    Console.WriteLine("This student doesn't exist ... please try again\n");
                }


                do
                {
                    Console.Write("Teacher's Name ?\n");
                    string Tchoice = Console.ReadLine();
                    Console.WriteLine("Subject of the class?\n");
                    string Schoice = Console.ReadLine();
                    Console.WriteLine("Date  ?\n");
                    string Dchoice = Console.ReadLine();
                    Console.WriteLine("Hour ?\n");
                    string Hchoice = Console.ReadLine();
                    Console.WriteLine("Type 1 if the student is present in class\nType 2 if the student arrived late\nType 3 if the student is absent");
                    choice = Convert.ToInt32(Console.ReadLine());
                    if (choice == 1)
                    {
                        AllStudent[i].NumberOfPresence++;
                    }
                    if (choice == 2)
                    {
                        AllStudent[i].NumberOfDelay++;
                    }
                    if (choice == 3)
                    {
                        AllStudent[i].NumberOfAbsences++;
                    }

                    Console.WriteLine("Nomber of Presence :", AllStudent[i].NumberOfPresence);
                    Console.WriteLine("Nombre of Delay :", AllStudent[i].NumberOfDelay);
                    Console.WriteLine("Nomber of Absence :", AllStudent[i].NumberOfAbsences);
                }
                while (x == true);
            }

        }


        public void DisplayAttendance(List<Student> AllStudent)
        {
            Console.Write("Enter the name of the student for whom you want to manage the attendance\n");
            string Nchoice = Console.ReadLine();
            bool x = false;
            for (int i = 0; i < AllStudent.Count; i++)
            {
                if (AllStudent[i].Name == Nchoice)
                {
                    x = true;
                }
                else
                {
                    Console.WriteLine("This student doesn't exist ... please try again\n");
                }
                do
                {
                    Console.WriteLine("Nomber of Presence :", AllStudent[i].NumberOfPresence);
                    Console.WriteLine("Nombre of Delay :", AllStudent[i].NumberOfDelay);
                    Console.WriteLine("Nomber of Absence :", AllStudent[i].NumberOfAbsences);
                }
                while (x == true);
            }
        }
    }
}
