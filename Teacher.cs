using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetOOP_v2
{
    class Teacher : Person
    {
        public Course Course;
        public List<Student> GroupStudents { get; set; }

        public Teacher(string name, string adress, string phoneNumber, string login, string password, Course course, List<Student> listOfStudents)
            : base(name, adress, phoneNumber, login, password)
        {
            GroupStudents = listOfStudents;

            Course = course;
        }

        public override void DisplayInformation()
        {
            Console.WriteLine($"Name : {Name}");
            Console.WriteLine($"Adress : {Adress}");
            Console.WriteLine($"Phone Number : {PhoneNumber}");
            Console.WriteLine($"Email / Login : {Login}");
        }

        public void DisplayStudentsInformation()
        {
            foreach(Student student in GroupStudents)
            {
                student.DisplayInformation();
            }
        }


        public void ManageAttendance(List<Student> AllStudent)
        {
            int choice = 0;
            Console.Write("Enter the name of the student for whom you want to manage the attendance :\n");
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
                    if (Course.DayCourse == day && Course.HourCourse == i)
                    {
                        Console.Write(Course.NameCourse + "\t");
                        courseOrNot = true;
                        break;
                    }
                    if (courseOrNot == false)
                    {
                        Console.Write("\t\t");
                    }
                    courseOrNot = false;
                }
                Console.WriteLine();
            }
        }
    }

}

