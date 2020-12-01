using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ProjetOOP_v2
{
    public class Program
    {

        static string IdentificationChoice()
        {
            string choice = "";

            string continu = "";
            do
            {
                Console.Clear();
                Console.Write("Virtual Global College Application\n\nAre you a student, a teacher or an administrator ?\n1 : Student\n2 : Teacher\n3 : Admin\nChoice : ");
                choice = Console.ReadLine();

                Console.WriteLine();

                if (choice == "1" || choice == "2" || choice == "3")
                {
                    Console.WriteLine("Accessing application");
                    break;
                }
                else
                {
                    Console.Write("This choice is not available. Type \"Yes\" if you want to try again : ");
                    continu = Console.ReadLine();
                    Console.WriteLine();
                }
            }
            while (continu == "Yes");

            return choice;
        }


        static int IdentificationStudent(List<Student> DBStudents, string login, string password)
        {
            int index = -1;
            for (int i = 0; i < DBStudents.Count; i++)
            {
                if (DBStudents[i].Login == login && DBStudents[i].Password == password)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }

        static int IdentificationTeacher(List<Teacher> DBTeachers, string login, string password)
        {
            int index = -1;
            for (int i = 0; i < DBTeachers.Count; i++)
            {
                if (DBTeachers[i].Login == login && DBTeachers[i].Password == password)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }

        static int IdentificationAdmin(List<Admin> DBAdmins, string login, string password)
        {
            int index = -1;
            for (int i = 0; i < DBAdmins.Count; i++)
            {
                if (DBAdmins[i].Login == login && DBAdmins[i].Password == password)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }



        static void Application(List<Student> DBStudents, List<Teacher> DBTeachers, List<Admin> DBAdmins, List<List<Course>> AllCourses)
        {

            int index = -1;
            do
            {
                string choice = IdentificationChoice();

                Console.Clear();
                Console.CursorTop = 10;
                CentrerLeTexte("Login : ");
                string login = Console.ReadLine();
                CentrerLeTexte("Password : ");
                string password = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        index = IdentificationStudent(DBStudents, login, password);
                        if (index >= 0) ApplicationStudent(DBStudents, index);
                        break;

                    case "2":
                        index = IdentificationTeacher(DBTeachers, login, password);
                        if (index >= 0) ApplicationTeacher(DBTeachers, index, DBStudents);
                        break;

                    case "3":
                        index = IdentificationAdmin(DBAdmins, login, password);
                        if (index >= 0) ApplicationAdmin(DBAdmins, index, DBStudents);
                        break;
                }
                if(index >= 0)
                {
                    Console.WriteLine("Do you want to go to the login page ? Yes or No ?");
                    string answer = Console.ReadLine();
                    if (answer == "Yes")
                    {
                        index = -1;
                    }
                }
                else
                {
                    Console.WriteLine("Error of connection - Email or Password invalid\nDo you want to try again ? Yes or No ?");
                    string answer = Console.ReadLine();
                    if (answer == "No")
                    {
                        index = 0;
                    }
                }

            }
            while (index < 0);
        }

        static void ApplicationStudent(List<Student> DBStudents, int index)
        {
            int choice = 0;
            int choice2 = 0;
            Student student = DBStudents[index];

            string answer = "";
            do
            {
                Console.Clear();
                Console.Write("Which program do you want to execute ?\n\n\n1 : To display my information\n2 : To manage my information\n3 : To display my grade book\n4: To display my attendance\n5 : To display my calendar \nChoice : ");
                choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                switch (choice)
                {
                    case 1: //ok ca marche
                        Console.Clear();
                        Console.WriteLine("Your informations :\n");
                        student.DisplayInformation();
                        break;
                    case 2: // ok ça amarche
                        do
                        {
                            Console.Clear();
                            student.ManageInformation();
                            Console.Clear();
                            Console.WriteLine("Your new informations are :\n");
                            student.DisplayInformation();
                            Console.WriteLine("Do you want to change an other information ?\n1 : Yes\n2 : No\nChoice : ");
                            choice2 = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine();

                        }
                        while (choice2 == 1);
                        break;
                    case 3: // à faire
                        Console.Clear();
                        Console.WriteLine("No grade available");
                        break;
                    case 4:
                        Console.Clear();
                        student.DisplayAttendance(); //demande juste le nom de l'étudiant et n'affiche pas la suite de la méthode
                        break;
                    case 5:
                        Console.Clear();
                        student.DisplayTimetable();
                        break;
                }
                Console.WriteLine("Do you want to continue ? Yes or No");
                answer = Console.ReadLine();
            } while (answer == "Yes");
        }



        static void ApplicationTeacher(List<Teacher> DBTeacher, int index, List<Student> DBStudents)
        {
            Teacher teacher = DBTeacher[index];
            int choice = 0;
            string answer = "";
            do
            {
                Console.Clear();
                Console.Write("Which program do you want to execute ?\n\n\n1 : To display my information\n2 : To access to my students information\n3 : To register a student in a course\n4: To manage grade books\n5 : To display grade books\n6 : To display the calendar\n7 : To manage the calendar\n8: To manage the attendance\n9 : To display the attendance\n10 : To manage your information\nChoice : ");
                choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Your informations :\n");
                        teacher.DisplayInformation();
                        break;
                    case 2: // à faire
                        Console.Clear();
                        teacher.DisplayStudentsInformation();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("à faire");
                        //teacher.InscriptionCourseStudent(Student name); // a revoir 
                        break;
                    case 4: // à faire
                        Console.Clear();
                        Console.WriteLine("à faire");
                        break;
                    case 5: // à faire
                        Console.Clear();
                        Console.WriteLine("à faire");
                        break;
                    case 6: // à faire
                        Console.Clear();
                        teacher.DisplayTimetable();
                        break;
                    case 7:
                        Console.Clear();
                        break;
                    case 8:
                        Console.Clear();
                        break;
                    case 9:
                        Console.Clear();
                        teacher.DisplayAttendance(); //demande juste le nom de l'étudiant et n'affiche pas la suite de la méthode
                        break;
                    case 10:
                        Console.Clear();
                        teacher.ManageInformation();
                        break;
                }

                Console.WriteLine("Do you want to continue ? Yes or No");
                answer = Console.ReadLine();
            } while (answer == "Yes");


        }
        static void ApplicationAdmin(List<Admin> DBAdmins, int index, List<Student> DBStudents)
        {
            Admin admin = DBAdmins[index];
            int choice = 0;

            string answer = "";
            do
            {
                Console.Clear();
                Console.Write("Which program do you want to execute ?\n\n\n1 : To display my information\n2 : To access to students information\n3 : To access to teachers informations\n5 : To create a course\n6 : To create an exam\n7 : To display grade books\n8 : To display the calendar\n9 : To manage the calendar\n10 : To display the attendance\n11 : To manage the attendance\n12 : To register a student in an exam\n13 : To register a teacher to a course\n14 : To delete a course\n15 : To display Teacher Timetable\n16 : To Register a Student\n17 : To Remove a Student\n18 : To Register a Teacher\n19 : To Remove a Teacher\n20 : To manage your information\nChoice : ");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        admin.DisplayInformation();
                        break;
                    case 2: // à faire
                        Console.Clear();
                        admin.DisplayStudentInformation();
                        break;
                    case 3: // à faire
                        Console.Clear();
                        admin.DisplayTeacherInformation();
                        break;
                    case 4: // à faire
                        Console.Clear();
                        Console.WriteLine("à faire");
                        //     admin.CreateStudentsGroup(Branche branche);
                        break;
                    case 5:
                        Console.Clear();
                        admin.CreationCourse();

                        foreach(List<Course> list in admin.AllCourses)
                        {
                            foreach(Course course in list)
                            {
                                Console.WriteLine(course.NameCourse);
                            }
                        }

                        break;
                    case 6:
                        Console.Clear();
                        admin.CreationExam();
                        break;
                    case 7: // à faire
                        Console.Clear();
                        Console.WriteLine("à faire");
                        break;
                    case 8: // à faire
                        Console.Clear();
                        Console.WriteLine("à faire");
                        break;
                    case 9: // à faire
                        Console.Clear();
                        Console.WriteLine("à faire");
                        break;
                    case 10:
                        Console.Clear();
                        admin.DisplayAttendance(); //demande juste le nom de l'étudiant et n'affiche pas la suite de la méthode
                        break;
                    case 11:
                        Console.Clear();
                        admin.ManageAttendance();
                        break;
                    case 13:
                        Console.Clear();
                        admin.IncsriptionCourse();
                        break;

                    case 14:
                        Console.Clear();
                        admin.DeleteCourse();
                        break;

                    case 15:
                        Console.Clear();
                        admin.DisplayTimetableTeacher();
                        break;

                    case 16:
                        Console.Clear();
                        admin.RegisterStudent();
                        break;

                    case 17:
                        Console.Clear();
                        admin.RemoveStudent();
                        break;

                    case 18:
                        Console.Clear();
                        admin.RegisterTeacher();
                        break;

                    case 19:
                        Console.Clear();
                        admin.RemoveTeacher();
                        break;
                    case 20:
                        Console.Clear();
                        admin.ManageInformation();
                        break;
                }
                Console.WriteLine("Do you want to continue ? Yes or No");
                answer = Console.ReadLine();
            } while (answer == "Yes");
        }


        public static void CentrerLeTexte(string texte)
        {
            int nbEspaces = 40;
            Console.SetCursorPosition(nbEspaces, Console.CursorTop);
            Console.Write(texte);
        }


        static void Initialization(string nomFichier, List<Student> DBStudents, List<Teacher> DBTeachers, List<Admin> DBAdmins, SortedList<string, Branche> branches, List<List<Course>> courses)
        {
            StreamReader fichierLect = new StreamReader(nomFichier);
            string ligne = "";
            List<string[]> datas = new List<string[]>();
            while (fichierLect.Peek() > 0)
            {
                ligne = fichierLect.ReadLine();
                datas.Add(ligne.Split(';'));
            }

            for (int i = 2; i < datas.Count; i++)
            {
                string status = datas[i][5];
                switch (status)
                {
                    case "Student":
                        int index = branches.IndexOfKey(datas[i][6]);
                        Branche branche = branches.ElementAt(index).Value;


                        Student student = new Student(datas[i][0], datas[i][1], datas[i][2],
                            datas[i][3], datas[i][4], branche, Convert.ToInt32(datas[i][7]), Convert.ToInt32(datas[i][8]),
                            Convert.ToInt32(datas[i][9]), Convert.ToInt32(datas[i][10]), courses[index]);

                        DBStudents.Add(student);

                        break;

                    case "Teacher":
                        // Create each teacher with his course and his list of students

                        //Course
                        string courseName = datas[i][11];

                        int brancheNumber = 0;
                        int courseNumber = 0;
                        bool courseFound = false;
                        for(brancheNumber=0; brancheNumber<courses.Count; brancheNumber++)
                        {
                            for(courseNumber=0; courseNumber<courses[brancheNumber].Count; courseNumber++)
                            {
                                if (courses[brancheNumber][courseNumber].NameCourse == courseName)
                                {
                                    courseFound = true;
                                    break;
                                }
                            }
                            if(courseFound==true)
                            {
                                break;
                            }
                        }

                        //List of students
                        List<Student> studentOfTeacher = new List<Student>();
                        foreach(Student undergraduate in DBStudents)
                        {
                            if(undergraduate.Branche.BrancheName == branches.Keys[brancheNumber])
                            {
                                studentOfTeacher.Add(undergraduate);
                            }
                        }

                        Teacher teacher = new Teacher(datas[i][0], datas[i][1], datas[i][2], datas[i][3], datas[i][4], courses[brancheNumber][courseNumber],
                            studentOfTeacher);

                        DBTeachers.Add(teacher);

                        break;

                    case "Admin":
                        Admin admin = new Admin(datas[i][0], datas[i][1], datas[i][2], datas[i][3], datas[i][4], DBStudents, DBTeachers, courses, branches);

                        DBAdmins.Add(admin);

                        break;
                }
            }
            fichierLect.Close();
        }
        static void Writer(string nomFichier, List<Student> DBStudents, List<Teacher> DBTeachers, List<Admin> DBAdmins)
        {
            StreamWriter fichWriter = new StreamWriter(nomFichier);
            string newInfo = "";

            List<string> writer = new List<string>();

            newInfo = "Name;Address;Phone Number;Email / Login;Password;Status;Branch;Number of Payments;Absence;Presence;Delay;Course(s)";
            writer.Add(newInfo);
            newInfo = "";
            writer.Add(newInfo);

            foreach (Student student in DBStudents)
            {
                newInfo = student.Name + ";" + student.Adress + ";" + student.PhoneNumber + ";" + student.Login + ";" + student.Password + ";" +
                "Student" + ";" + student.Branche.BrancheName + ";" + student.NumberOfPayments + ";" + student.NumberOfAbsences +
                ";" + student.NumberOfPresence + ";" + student.NumberOfDelay;
                foreach(Course course in student.Courses)
                {
                    newInfo += ";" + course.NameCourse;
                }
                writer.Add(newInfo);
            }
            foreach (Teacher teacher in DBTeachers)
            {
                string nameCourse = "";
                if (teacher.Course != null) { nameCourse = teacher.Course.NameCourse; }

                newInfo = teacher.Name + ";" + teacher.Adress + ";" + teacher.PhoneNumber + ";" + teacher.Login + ";" + teacher.Password + ";" +
                "Teacher" + ";" + ";" + ";" + ";" + ";" + ";" + nameCourse;
                writer.Add(newInfo);
            }
            foreach (Admin admin in DBAdmins)
            {
                newInfo = admin.Name + ";" + admin.Adress + ";" + admin.PhoneNumber + ";" + admin.Login + ";" + admin.Password + ";" +
                "Admin";
                writer.Add(newInfo);
            }

            foreach(string line in writer)
            {
                fichWriter.WriteLine(line);
            }

            fichWriter.Close();

        }

        static List<List<Course>> InitializeCourses()
        {

            List<List<Course>> AllCourses = new List<List<Course>>();

            Course statistics = new Course { NameCourse = "Statistics", DayCourse = "Monday", HourCourse = 9, Duration = 1 };
            Course oop = new Course { NameCourse = "OOP", DayCourse = "Wednesday", HourCourse = 15, Duration = 1 };
            Course dataStructure = new Course { NameCourse = "Data Structure", DayCourse = "Friday", HourCourse = 11, Duration = 1 };

            Course finance = new Course { NameCourse = "Finance", DayCourse = "Tuesday", HourCourse = 10, Duration = 1 };
            Course marketing = new Course { NameCourse = "Marketing", DayCourse = "Wednesday", HourCourse = 12, Duration = 1 };
            Course management = new Course { NameCourse = "Management", DayCourse = "Friday", HourCourse = 17, Duration = 1 };

            Course philosophy = new Course { NameCourse = "Philosophy", DayCourse = "Monday", HourCourse = 15, Duration = 1 };
            Course english = new Course { NameCourse = "English", DayCourse = "Tuesday", HourCourse = 8, Duration = 1 };
            Course history = new Course { NameCourse = "History", DayCourse = "Thursday", HourCourse = 13, Duration = 1 };

            List<Course> listIngeneering = new List<Course>();
            listIngeneering.Add(statistics);
            listIngeneering.Add(oop);
            listIngeneering.Add(dataStructure);

            List<Course> listBusiness = new List<Course>();
            listBusiness.Add(finance);
            listBusiness.Add(marketing);
            listBusiness.Add(management);

            List<Course> listLiterature = new List<Course>();
            listLiterature.Add(philosophy);
            listLiterature.Add(english);
            listLiterature.Add(history);

            AllCourses.Add(listBusiness);
            AllCourses.Add(listIngeneering);
            AllCourses.Add(listLiterature);


            return AllCourses;
        }

        static SortedList<string, Branche> InitializeBranches()
        {
            Branche branche1 = new Branche { BrancheName = "Ingeneering", FeesAmount = 1000 };
            Branche branche2 = new Branche { BrancheName = "Business", FeesAmount = 2000 };
            Branche branche3 = new Branche { BrancheName = "Literature", FeesAmount = 300 };

            SortedList<string, Branche> branches = new SortedList<string, Branche>();
            branches.Add(branche1.BrancheName, branche1);
            branches.Add(branche2.BrancheName, branche2);
            branches.Add(branche3.BrancheName, branche3);

            return branches;
        }

        public static void Main(string[] args)
        {

            string nomFichier = "C:\\Users\\maxim\\Documents\\ESILV A3\\Dorset Online\\OOP\\Project\\Code\\Database.csv";
            string nomFichier2 = "C:\\Users\\maxim\\Documents\\ESILV A3\\Dorset Online\\OOP\\Project\\Database2.csv";



            List<Student> DBStudents = new List<Student>();
            List<Teacher> DBTeachers = new List<Teacher>();
            List<Admin> DBAdmins = new List<Admin>();


            SortedList<string, Branche> branches = InitializeBranches();

            List<List<Course>> AllCourses = InitializeCourses();

            Initialization(nomFichier, DBStudents, DBTeachers, DBAdmins, branches, AllCourses);

            Application(DBStudents, DBTeachers, DBAdmins, AllCourses);

            Writer(nomFichier2, DBStudents, DBTeachers, DBAdmins);


            Console.ReadKey();

        }


    }
}
