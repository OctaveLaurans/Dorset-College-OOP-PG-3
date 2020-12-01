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

        public Teacher(string name, string adress, string phoneNumber, string login, string password)
            : base(name, adress, phoneNumber, login, password)
        {
            GroupStudents = new List<Student>();


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



        public void DisplayAttendance()
        {
            bool continu = false;
            do
            {
                bool exist = false;

                Console.Write("Enter the name of the student for whom you want to display the attendance\n");
                string Nchoice = Console.ReadLine();
                Console.WriteLine();
                for (int i = 0; i < GroupStudents.Count; i++)
                {
                    if (GroupStudents[i].Name == Nchoice)
                    {
                        GroupStudents[i].DisplayAttendance();
                        exist = true;
                        break;
                    }
                }
                if(exist==false)
                {
                    Console.WriteLine("You don't have acces to this student information\n");
                    continu = true;
                }
                else
                {
                    Console.WriteLine("Do you want to check the attendance of another student ? Yes or No ?");
                    string choice = Console.ReadLine();
                    if (choice == "Yes") continu = true;
                    else continu = false;
                }
                Console.WriteLine();
            }
            while (continu == true);
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

