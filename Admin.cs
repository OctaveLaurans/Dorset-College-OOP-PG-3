using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetOOP_v2
{
    class Admin : Person
    {

        public List<Student> AllStudents { get; set; }
        public List<Teacher> AllTeachers { get; set; }
        public List<List<Course>> AllCourses { get; set; }
        public SortedList<string, Branche> Branches { get; set; }

        public Admin(string name, string adress, string phoneNumber, string login, string password, List<Student> allStudents, List<Teacher> allTeachers, List<List<Course>> allCourses, SortedList<string, Branche> branches)
            : base(name, adress, phoneNumber, login, password)
        {
            AllStudents = allStudents;
            AllTeachers = allTeachers;
            AllCourses = allCourses;
            Branches = branches;
        }

        public override void DisplayInformation()
        {
            Console.WriteLine($"Name : {Name}");
            Console.WriteLine($"Adress : {Adress}");
            Console.WriteLine($"Phone Number : {PhoneNumber}");
            Console.WriteLine($"Email / Login : {Login}\n");
        }
        public override void ManageInformation()
        {
            Console.WriteLine("Which information do you want to change ?");
            Console.WriteLine("1. Adress");
            Console.WriteLine("2. Phone Number");
            Console.WriteLine("3. Password");
            Console.Write("Choice : ");
            int choice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            string change;
            switch (choice)
            {
                case 1:
                    Console.Write("Enter your new adress : ");
                    change = Console.ReadLine();
                    this.Adress = change;
                    Console.WriteLine();
                    break;

                case 2:
                    Console.Write("Enter your new phone number : ");
                    change = Console.ReadLine();
                    this.PhoneNumber = change;
                    Console.WriteLine();
                    break;

                case 3:
                    Console.Write("Enter your new password : ");
                    change = Console.ReadLine();
                    this.Password = change;
                    Console.WriteLine();
                    break;
            }

        }


        public void DisplayStudentInformation()
        {
            bool exist = false;

            Console.Write("Enter the name of the student for whom you want to display the information\n");
            string Nchoice = Console.ReadLine();
            Console.WriteLine();
            for (int i = 0; i < AllStudents.Count; i++)
            {
                if (AllStudents[i].Name == Nchoice)
                {
                    AllStudents[i].DisplayInformation();
                    exist = true;
                    break;
                }
            }
            if (exist == false)
            {
                Console.WriteLine("This student doesn't exist ... please try again\n");
            }
        }

        public void DisplayTeacherInformation()
        {
            bool exist = false;

            Console.Write("Enter the name of the teacher for whom you want to display the information\n");
            string Nchoice = Console.ReadLine();
            Console.WriteLine();
            for (int i = 0; i < AllTeachers.Count; i++)
            {
                if (AllTeachers[i].Name == Nchoice)
                {
                    AllTeachers[i].DisplayInformation();
                    exist = true;
                    break;
                }
            }
            if (exist == false)
            {
                Console.WriteLine("This teacher doesn't exist ... please try again\n");
            }
        }

        public Course CreationCourse()
        {
            Console.WriteLine("You want to create a course, whiwh branch is concerned ?");
            string branche = Console.ReadLine();
            Console.WriteLine("What's the subject of the course ?");
            string nameCourse = Console.ReadLine();
            Console.WriteLine("Course date ? (Day in the week)");
            string dayCourse = Console.ReadLine();
            Console.WriteLine("At what time ?");
            int hourCourse = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Duration ?");
            double duration = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine($"Subject : {nameCourse}, Date : {dayCourse}, Hour : {hourCourse}");

            Course course = new Course { NameCourse = nameCourse, DayCourse = dayCourse, HourCourse = hourCourse };

            int brancheNumber = -1;
            switch(branche)
            {
                case "Business":
                    brancheNumber = 0;
                    break;

                case "Ingeneering":
                    brancheNumber = 1;
                    break;

                case "Literature":
                    brancheNumber = 2;
                    break;
            }


            AllCourses[brancheNumber].Add(course);

            return course;
        }


        public void DeleteCourse()
        {
            Console.WriteLine("You want to delete a course, whiwh branch is concerned ?");
            string branche = Console.ReadLine();
            Console.WriteLine("What's the name of the course ?");
            string nameCourse = Console.ReadLine();

            int brancheNumber = -1;
            switch (branche)
            {
                case "Business":
                    brancheNumber = 0;
                    break;

                case "Ingeneering":
                    brancheNumber = 1;
                    break;

                case "Literature":
                    brancheNumber = 2;
                    break;
            }

            for(int i=0; i<AllCourses[brancheNumber].Count; i++)
            {
                if(nameCourse==AllCourses[brancheNumber][i].NameCourse)
                {
                    AllCourses[brancheNumber].RemoveAt(i);
                    Console.WriteLine("Course has been deleted\n");
                    break;
                }
            }

        }


        public void IncsriptionCourse()
        {

            Console.Write("Enter the name of the teacher whom you want to register to a course\n");
            string Nchoice = Console.ReadLine();
            int j = 0;
            for (j = 0; j < AllTeachers.Count; j++)
            {
                if (AllTeachers[j].Name == Nchoice)
                {
                    break;
                }
            }
            Teacher teacher = AllTeachers[j];

            Console.WriteLine("You want to register a teacher for a course, whiwh branch is concerned ?");
            string branche = Console.ReadLine();
            Console.WriteLine("What's the name of the course ?");
            string nameCourse = Console.ReadLine();

            int brancheNumber = -1;
            switch (branche)
            {
                case "Business":
                    brancheNumber = 0;
                    break;

                case "Ingeneering":
                    brancheNumber = 1;
                    break;

                case "Literature":
                    brancheNumber = 2;
                    break;
            }

            for (int i = 0; i < AllCourses[brancheNumber].Count; i++)
            {
                if (nameCourse == AllCourses[brancheNumber][i].NameCourse)
                {
                    teacher.Course = AllCourses[brancheNumber][i];
                    Console.WriteLine($"{teacher.Name} has been registered for the course {teacher.Course.NameCourse}\n");
                    break;
                }
            }

            teacher.GroupStudents.Clear();

            foreach(Student student in AllStudents)
            {
                if (student.Branche.BrancheName == Branches.Keys[brancheNumber])
                {
                    teacher.GroupStudents.Add(student);
                }
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

        public void ManageAttendance()
        {
            int choice = 0;
            bool exist = false;

            Console.Write("Enter the name of the student for whom you want to manage the attendance\n");
            string Nchoice = Console.ReadLine();
            Console.WriteLine();
            for (int i = 0; i < AllStudents.Count; i++)
            {
                if (AllStudents[i].Name == Nchoice)
                {
                    Console.Write("Current ");
                    AllStudents[i].DisplayAttendance();

                    Console.WriteLine("Which modification do you want to do ?");
                    Console.Write("1 : The student was finally present in class (increase the number of presence and decrease the number of absence)\n" +
                                  "2 : The student arrived late (increase the number of delay)\n" +
                                  "3 : The student finally did not attend class (decrease the number of presence and increase the number of absence)\n" +
                                  "Choice : ");
                    choice = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();
                    if (choice == 1)
                    {
                        AllStudents[i].NumberOfPresence++;
                        AllStudents[i].NumberOfAbsences--;
                    }
                    if (choice == 2)
                    {
                        AllStudents[i].NumberOfDelay++;
                    }
                    if (choice == 3)
                    {
                        AllStudents[i].NumberOfAbsences++;
                        AllStudents[i].NumberOfPresence--;
                    }

                    AllStudents[i].DisplayAttendance();

                    exist = true;
                    break;
                }

            }
            if (exist == false)
            {
                Console.WriteLine("This student doesn't exist ... please try again\n");
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
                for (int i = 0; i < AllStudents.Count; i++)
                {
                    if (AllStudents[i].Name == Nchoice)
                    {
                        AllStudents[i].DisplayAttendance();
                        exist = true;
                        break;
                    }
                }
                if (exist == false)
                {
                    Console.WriteLine("This student does not exist. Please try again.\n");
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


        public void DisplayTimetableTeacher()
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
                    foreach (List<Course> list in AllCourses)
                    {
                        foreach(Course course in list)
                        {
                            if (course.DayCourse == day && course.HourCourse == i)
                            {
                                foreach(Teacher teacher in AllTeachers)
                                {
                                    if(teacher.Course==course)
                                    {
                                        Console.Write(teacher.Name + "\t");
                                        courseOrNot = true;
                                        break;
                                    }
                                }
                            }
                        }
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


        public void RegisterStudent()
        {
            Console.WriteLine("Registering of a new student");
            Console.Write("Type his/her name : ");
            string name = Console.ReadLine();
            Console.Write("Type his/her adress : ");
            string adress = Console.ReadLine();
            Console.Write("Type his/her phone number : ");
            string phoneNumber = Console.ReadLine();
            Console.Write("Type his/her email : ");
            string email = Console.ReadLine();
            Console.Write("Type his/her password : ");
            string password = Console.ReadLine();
            Console.Write("Type the name of his/her branch : ");
            string branchName = Console.ReadLine();
            Console.Write("Type the number of payments : ");
            int nbrPayment = Convert.ToInt32(Console.ReadLine());

            int index = Branches.IndexOfKey(branchName);
            Branche branche = Branches.ElementAt(index).Value;

            Student student = new Student(name, adress, phoneNumber, email, password, branche, nbrPayment, 0, 0, 0, AllCourses[index]);
            AllStudents.Add(student);
        }

        public void RemoveStudent()
        {
            Console.WriteLine("Deleting a student");
            Console.Write("Type his/her name : ");
            string name = Console.ReadLine();

            foreach(Student student in AllStudents)
            {
                if(student.Name == name)
                {
                    AllStudents.Remove(student);
                    Console.WriteLine($"{student.Name} has been removed");
                    break;
                }
            }
        }

        public void RegisterTeacher()
        {
            Console.WriteLine("Registering of a new teacher");
            Console.Write("Type his/her name : ");
            string name = Console.ReadLine();
            Console.Write("Type his/her adress : ");
            string adress = Console.ReadLine();
            Console.Write("Type his/her phone number : ");
            string phoneNumber = Console.ReadLine();
            Console.Write("Type his/her email : ");
            string email = Console.ReadLine();
            Console.Write("Type his/her password : ");
            string password = Console.ReadLine();

            Teacher teacher = new Teacher(name, adress, phoneNumber, email, password);
            AllTeachers.Add(teacher);
        }

        public void RemoveTeacher()
        {
            Console.WriteLine("Deleting a teacher");
            Console.Write("Type his/her name : ");
            string name = Console.ReadLine();

            foreach (Teacher teacher in AllTeachers)
            {
                if (teacher.Name == name)
                {
                    AllTeachers.Remove(teacher);
                    Console.WriteLine($"{teacher.Name} has been removed");
                    break;
                }
            }
        }
    }
}
