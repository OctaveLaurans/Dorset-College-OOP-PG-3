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

        public void CreationTimetable(List<Course> AllCourses)
        {
            string[][] Timetable = new string[6][];
            Timetable[0][0] = "Monday";
            Timetable[1][0] = "Tuesday";
            Timetable[2][0] = "Wednesday";
            Timetable[3][0] = "Thursday";
            Timetable[4][0] = "Friday";
            Timetable[5][0] = "Saturday";
            for (int j = 0; j < 6; j++)
            {
                for (int i = 8; i < 21; i++)
                {
                    Timetable[j][i - 7] = (i + "H - " + (i + 1) + "H :");
                }
            }
            foreach (Course course in AllCourses)
            {
                if (course.DayCourse == "Monday")
                {
                    for (int i = 0; i < course.Duration; i++)
                    {
                        Timetable[0][course.HourCourse + i] = (Timetable[0][course.HourCourse + i] + course.NameCourse);
                    }
                }
                if (course.DayCourse == "Tuesday")
                {
                    for (int i = 0; i < course.Duration; i++)
                    {
                        Timetable[0][course.HourCourse + i] = (Timetable[0][course.HourCourse + i] + course.NameCourse);
                    }
                }
                if (course.DayCourse == "Wednesday")
                {
                    for (int i = 0; i < course.Duration; i++)
                    {
                        Timetable[0][course.HourCourse + i] = (Timetable[0][course.HourCourse + i] + course.NameCourse);
                    }
                }
                if (course.DayCourse == "Thursday")
                {
                    for (int i = 0; i < course.Duration; i++)
                    {
                        Timetable[0][course.HourCourse + i] = (Timetable[0][course.HourCourse + i] + course.NameCourse);
                    }
                }
                if (course.DayCourse == "Friday")
                {
                    for (int i = 0; i < course.Duration; i++)
                    {
                        Timetable[0][course.HourCourse + i] = (Timetable[0][course.HourCourse + i] + course.NameCourse);
                    }
                }
                if (course.DayCourse == "Saturday")
                {
                    for (int i = 0; i < course.Duration; i++)
                    {
                        Timetable[0][course.HourCourse + i] = (Timetable[0][course.HourCourse + i] + course.NameCourse);
                    }
                }
            }
        }
    }

}

