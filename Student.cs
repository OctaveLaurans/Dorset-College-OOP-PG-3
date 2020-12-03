using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetOOP_v2
{
    class Student : Person, IPayment
    {

        public Branche Branche { get; set; }
        public List<Course> Courses {get; set;}
        public List<Exam> Exams { get; set; }

        public int ToBePaid { get; set; }
        public int NumberOfPayments { get; set; }

        public int NumberOfAbsences { get; set; }
        public int NumberOfPresence { get; set; }
        public int NumberOfDelay { get; set; }

        public List<int> Grades { get; set; }


        public Student(string name, string adress, string phoneNumber, string login, string password, Branche branche, int numberOfPayments, int numberOfAbsences, int numberOfPresence, int numberOfDelay, List<Course> courses)
            : base(name, adress, phoneNumber, login, password)
		{

            this.Branche = branche;

            this.ToBePaid = Branche.FeesAmount;

            this.NumberOfPayments = numberOfPayments;

            this.NumberOfAbsences = numberOfAbsences;

            this.NumberOfPresence = numberOfPresence;

            this.NumberOfDelay = numberOfDelay;

            Courses = courses;
            Exams = new List<Exam>();

            Grades = new List<int>();
            Grades.Add(-1);
            Grades.Add(-1);
            Grades.Add(-1);
        }

        public override void ManageInformation()
        {
            Console.WriteLine("Which information do you want to change ?");
            Console.WriteLine("1. Adress");
            Console.WriteLine("2. Phone Number");
            Console.WriteLine("3. Password");
            Console.Write("Choice : ");
            string choice = Console.ReadLine();
            Console.WriteLine();

            string change;
            switch(choice)
            {
                case "1":
                    Console.Write("Enter your new adress : ");
                    change = Console.ReadLine();
                    this.Adress = change;
                    Console.WriteLine();
                    break;

                case "2":
                    Console.Write("Enter your new phone number : ");
                    change = Console.ReadLine();
                    this.PhoneNumber = change;
                    Console.WriteLine();
                    break;

                case "3":
                    Console.Write("Enter your new password : ");
                    change = Console.ReadLine();
                    this.Password = change;
                    Console.WriteLine();
                    break;
                default:
                    Console.WriteLine("This choice is not available");
                    break;
            }

        }

        public override void DisplayInformation()
        {
            Console.WriteLine($"Name : {Name}");
            Console.WriteLine($"Adress : {Adress}");
            Console.WriteLine($"Phone Number : {PhoneNumber}");
            Console.WriteLine($"Email / Login : {Login}");
            Console.WriteLine($"Branche : {Branche.BrancheName}");
            Console.WriteLine($"Amount that need to be paid : {ToBePaid}$");
            Console.WriteLine();

            Console.WriteLine("Courses : ");
            foreach(Course course in Courses)
            {
                Console.WriteLine(course.NameCourse);
            }

            Console.WriteLine();

        }

        public void Payment()
        {
            int amount = Branche.FeesAmount / NumberOfPayments;

            ToBePaid -= amount;
            Console.WriteLine($"You have just paid {amount}$. You still have to pay {ToBePaid}$.\n");
        }

        public void DisplayAttendance()
        {
            Console.WriteLine("Attendance\n");
            Console.WriteLine("Nomber of Presence : " + NumberOfPresence);
            Console.WriteLine("Nombre of Delay : " + NumberOfDelay);
            Console.WriteLine("Nomber of Absence : " + NumberOfAbsences +"\n");
        }

        public void DisplayTimetable()
        {
            Console.Write("\t\t Monday \tTuesday \tWednesday \tThursday \tFriday\n");
            
            List<string> week = new List<string>();
            week.Add("Monday");
            week.Add("Tuesday");
            week.Add("Wednesday");
            week.Add("Thursday");
            week.Add("Friday");

            bool courseOrNot = false;
            
            for (int i = 8; i < 21; i++)
            {
                Console.Write($"{i}h\t\t");
                foreach (string day in week)
                {
                    foreach(Course course in Courses)
                    {
                        if (course.DayCourse == day && course.HourCourse==i)
                        {
                            Console.Write(course.NameCourse+"\t");
                            courseOrNot = true;
                            break;
                        }
                    }
                    if(courseOrNot==false)
                    {
                        Console.Write("\t\t");
                    }
                    courseOrNot = false;
                }
                Console.WriteLine();
            }
            
        }


        public void DisplayNote()
        {
            Console.WriteLine("Your grades are :");
            for (int i = 0; i < Grades.Count; i++)
            {
                if (Grades[i] == -1)
                {
                    Console.WriteLine($"{Courses[i].NameCourse} : You don't have any grade for this course");
                }
                else Console.WriteLine($"{Courses[i].NameCourse} : {Grades[i]}");

            }
        }
    }
}
