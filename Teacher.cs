﻿using System;
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
            if (Course != null) Console.WriteLine($"Course : {Course.NameCourse}\n");
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
            switch (choice)
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

        public void DisplayStudentsInformation()
        {
            foreach (Student student in GroupStudents)
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
                Console.Clear();
                foreach (Student studentt in GroupStudents)
                {
                    Console.WriteLine(studentt.Name);
                }
                Console.Write("\nEnter the name of the student for whom you want to display the attendance\n");
                string Nchoice = Console.ReadLine();
                Console.Clear();
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
                if (exist == false)
                {
                    Console.Clear();
                    Console.WriteLine("You don't have acces to this student information\n");
                    Console.WriteLine("Do you want to check the attendance of another student ? Yes or No ?");
                    string choice = Console.ReadLine();
                    if (choice == "Yes") continu = true;
                    else continu = false;
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


        public void GradeBook()
        {
            foreach (Student studentt in GroupStudents)
            {
                Console.WriteLine(studentt.Name);
            }
            Console.WriteLine("\nWhich student do you want to add grade for ?");
            string student = Console.ReadLine();
            string coursee = "";
            string contains = "";
            foreach (Student a in GroupStudents)
            {
                if (student == a.Name)
                {
                    Console.Clear();
                    contains = "yes";
                    Console.WriteLine("Which course do you want to add a grade for ?\n");
                    coursee = Console.ReadLine();
                    Console.WriteLine();
                    for (int i = 0; i <= 2; i++)
                    {

                        if (coursee == a.Courses[i].NameCourse)
                        {
                            Console.WriteLine("Enter the grade !");
                            int gradee = Convert.ToInt32(Console.ReadLine());
                            a.Grades[i] = gradee;
                        }
                    }
                }
            }
            if (contains != "yes")
            {
                Console.Clear();
                Console.WriteLine("You doesn't have this student in your class\n");
            }

        }
    }

}

