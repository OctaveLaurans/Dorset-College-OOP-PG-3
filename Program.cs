using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ProjetOOP_v2
{
    public class Program        
                                
    { // Maxime Geniesse
      // Arthur Gay Bellile
      // Aurélie Leduc _ 22831
      //Camille Lacroix _ 22836
      //Samuel Barbarin
      //Octave Laurans 

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
            string choice = "";
            string choice2 = "";
            Student student = DBStudents[index];

            string answer = "";
            do
            {
                Console.Clear();
                Console.Write("Which program do you want to execute ?\n\n\n1 : To display my information\n2 : To manage my information\n3 : To pay the school fees\n4: To display my attendance\n5 : To display my grade book \n6 : To display my timetable\n7 : To display planned exams\nChoice : ");
                choice = Console.ReadLine();
                Console.WriteLine();
                switch (choice)
                {
                    case "1": 
                        Console.Clear();
                        Console.WriteLine("Your informations :\n");
                        student.DisplayInformation();
                        break;
                    case "2": 
                        do
                        {
                            Console.Clear();
                            student.ManageInformation();
                            Console.Clear();
                            Console.WriteLine("Your new informations are :\n");
                            student.DisplayInformation();
                            Console.WriteLine("Do you want to change an other information ?\n Yes or No ?\nChoice : ");
                            choice2 = Console.ReadLine();
                            Console.WriteLine();

                        }
                        while (choice2 == "Yes");
                        break;
                    case "3": 
                        Console.Clear();
                        student.Payment();
                        break;
                    case "4":
                        Console.Clear();
                        student.DisplayAttendance(); 
                        break;
                    case "5":
                        Console.Clear();
                        student.DisplayGrades();
                        break;
                    case "6":
                        Console.Clear();
                        student.DisplayTimetable();
                        break;
                    case "7":
                        Console.Clear();
                        student.DisplayExams();
                        break;
                    default:
                        Console.WriteLine("\nThis choice is not available");
                        break;
                }
                Console.WriteLine("Do you want to continue ? Yes or No");
                answer = Console.ReadLine();
            } while (answer == "Yes");
        }



        static void ApplicationTeacher(List<Teacher> DBTeacher, int index, List<Student> DBStudents)
        {
            Teacher teacher = DBTeacher[index];
            string choice = "";
            string answer = "";
            do
            {
                Console.Clear();
                Console.Write("Which program do you want to execute ?\n\n\n1 : To display my information\n2 : To manage your information\n3 : To access to my students information\n4 : To display grade books\n5 : To manage grade books\n6 : To display the attendance\n7 : To display the calendar\n8 : To display planned exam\nChoice : ");
                choice = Console.ReadLine();
                Console.WriteLine();
                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("Your informations :\n");
                        teacher.DisplayInformation();
                        break;
                    case "2": 
                        Console.Clear();
                        teacher.ManageInformation(); 
                        break;
                    case "3":
                        Console.Clear();
                        teacher.DisplayStudentsInformation(); 
                        break;
                    case "4": 
                        Console.Clear();
                        teacher.DisplayGradeBook();
                        break;
                    case "5": 
                        Console.Clear();
                        teacher.ManageGradeBook(); 
                        break;
                    case "6":
                        Console.Clear();
                        teacher.DisplayAttendance(); 
                        break;
                    case "7":
                        Console.Clear();
                        teacher.DisplayTimetable();
                        break;
                    case "8":
                        Console.Clear();
                        teacher.DisplayExam();
                        break;
                    default:
                        Console.WriteLine("\nThis choice is not available");
                        break;
                }

                Console.WriteLine("Do you want to continue ? Yes or No");
                answer = Console.ReadLine();
            } while (answer == "Yes");


        }
        static void ApplicationAdmin(List<Admin> DBAdmins, int index, List<Student> DBStudents)
        {
            Admin admin = DBAdmins[index];
            string choice = "";

            string answer = "";
            do
            {
                Console.Clear();
                Console.Write("Which program do you want to execute ?\n\n\n1 : To display my information\n2 : To manage your information\n3 : To access to teachers informations\n4 : To access to students information\n5 : To display grade books\n6 : To display Teacher Timetable\n7 : To display the attendance\n8 : To manage the attendance\n9 : To create a course\n10 :To manage a course\n11 : To delete a course\n12 : To register a teacher to a course\n13 : To create an exam\n14 : To register a student in an exam\n15 : To display planned exams\n16 : To Register a Student\n17 : To Remove a Student\n18 : To Register a Teacher\n19 : To Remove a Teacher\nChoice : ");
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        admin.DisplayInformation();
                        break;
                    case "2": 
                        Console.Clear();
                        admin.ManageInformation(); 
                        break;
                    case "3": 
                        Console.Clear();
                        admin.DisplayTeacherInformation();
                        break;
                    case "4":
                        Console.Clear();
                        admin.DisplayStudentInformation();
                        break;
                    case "5":
                        Console.Clear();
                        admin.DisplayGradeBook(); 
                        break;
                    case "6": 
                        Console.Clear();
                        admin.DisplayTimetableTeacher();
                        break;
                    case "7":
                        Console.Clear();
                        admin.DisplayAttendance(); 
                        break;
                    case "8":
                        Console.Clear();
                        admin.ManageAttendance();
                        break;
                    case "9":
                        Console.Clear();
                        admin.CreationCourse();
                        break;
                    case "10":
                        Console.Clear();
                        admin.ManageCourse();  
                        break;
                    case "11":
                        Console.Clear();
                        admin.DeleteCourse(); 
                        break;
                    case "12":
                        Console.Clear();
                        admin.IncsriptionCourse(); 
                        break;
                    case "13":
                        Console.Clear();
                        admin.CreationExam(); 
                        break;
                    case "14":
                        Console.Clear();
                        admin.RegisterStudent(); 
                        break;
                    case "15":
                        Console.Clear();
                        admin.DisplayExams();
                        break;
                    case "16":
                        Console.Clear();
                        admin.RegisterStudent();
                        break;
                    case "17":
                        Console.Clear();
                        admin.RemoveStudent();
                        break;
                    case "18":
                        Console.Clear();
                        admin.RegisterTeacher();
                        break;
                    case "19":
                        Console.Clear();
                        admin.RemoveTeacher();
                        break;
                    default:
                        Console.WriteLine("\nThis choice is not available");
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


        static void Initialization(string databaseFile, string gradesFile, List<Student> DBStudents, List<Teacher> DBTeachers, List<Admin> DBAdmins, SortedList<string, Branche> branches, List<List<Course>> courses)
        {
            StreamReader fichierLect = new StreamReader(databaseFile);
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
                            Convert.ToInt32(datas[i][9]), Convert.ToInt32(datas[i][10]), courses[index], courses[index].Count);

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

            ReaderGrades(gradesFile, DBStudents);
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

        static void WriterGrades(string nomFichier, List<Student> DBStudents, SortedList<string, Branche> branches)
        {
            StreamWriter fichWriter = new StreamWriter(nomFichier);
            string newInfo = "";

            List<string> writer = new List<string>();

            List<Student> studentsIngeneering = new List<Student>();
            List<Student> studentsBusiness = new List<Student>();
            List<Student> studentsLiterature = new List<Student>();

            foreach(Student student in DBStudents)
            {
                switch(student.Branche.BrancheName)
                {
                    case "Ingeneering":
                        studentsIngeneering.Add(student);
                        break;

                    case "Business":
                        studentsBusiness.Add(student);
                        break;

                    case "Literature":
                        studentsLiterature.Add(student);
                        break;
                }
            }



            foreach(Course course in studentsIngeneering[0].Courses)
            {
                newInfo += ";" + course.NameCourse;
            }
            writer.Add(newInfo);
            foreach(Student student in studentsIngeneering)
            {
                newInfo = "";
                newInfo += student.Name;

                for (int i = 0; i < student.Grades.Count; i++)
                {
                    newInfo += ";";
                    if (student.Grades[i] >= 0) newInfo += student.Grades[i];
                }

                writer.Add(newInfo);
            }
            writer.Add(";");

            newInfo = "";
            foreach (Course course in studentsBusiness[0].Courses)
            {
                newInfo += ";" + course.NameCourse;
            }
            writer.Add(newInfo);
            foreach (Student student in studentsBusiness)
            {
                newInfo = "";
                newInfo += student.Name;

                for (int i = 0; i < student.Grades.Count; i++)
                {
                    newInfo += ";";
                    if (student.Grades[i] >= 0) newInfo += student.Grades[i];
                }

                writer.Add(newInfo);
            }
            writer.Add(";");


            newInfo = "";
            foreach (Course course in studentsLiterature[0].Courses)
            {
                newInfo += ";" + course.NameCourse;
            }
            writer.Add(newInfo);
            foreach (Student student in studentsLiterature)
            {
                newInfo = "";
                newInfo += student.Name;

                for (int i = 0; i < student.Grades.Count; i++)
                {
                    newInfo += ";";
                    if (student.Grades[i] >= 0) newInfo += student.Grades[i];
                }

                writer.Add(newInfo);
            }
            writer.Add(";");



            foreach (string line in writer)
            {
                fichWriter.WriteLine(line);
            }

            fichWriter.Close();


        }

        static void ReaderGrades(string nomFichier, List<Student> DBStudents)
        {
            StreamReader fichierLect = new StreamReader(nomFichier);
            string ligne = "";
            List<string[]> datas = new List<string[]>();
            while (fichierLect.Peek() > 0)
            {
                ligne = fichierLect.ReadLine();
                datas.Add(ligne.Split(';'));
            }

           
            foreach(Student student in DBStudents)
            {
                bool studentFound = false;
                for (int i=0; i<datas.Count; i++)
                {
                    if(student.Name == datas[i][0])
                    {
                        studentFound = true;
                        for(int j=0; j<student.Courses.Count; j++)
                        {
                            if (datas[i][j + 1] == "") student.Grades[j] = -1;
                            else student.Grades[j] = Convert.ToInt32(datas[i][j + 1]);
                        }
                    }
                    if (studentFound == true)
                    {
                        break;
                    }
                }
            }

            fichierLect.Close();
        }

        static List<List<Course>> InitializeCourses(string nomFichier)
        {
            List<List<Course>> AllCourses = new List<List<Course>>();

            List<Course> listIngeneering = new List<Course>();
            List<Course> listBusiness = new List<Course>();
            List<Course> listLiterature = new List<Course>();


            StreamReader fichierLect = new StreamReader(nomFichier);
            string ligne = "";
            List<string[]> datas = new List<string[]>();
            while (fichierLect.Peek() > 0)
            {
                ligne = fichierLect.ReadLine();
                datas.Add(ligne.Split(';'));
            }

            for (int i = 1; i < datas.Count; i++)
            {
                Course course = new Course { NameCourse = datas[i][0], DayCourse = datas[i][2], HourCourse = Convert.ToInt32(datas[i][3]), Duration = Convert.ToDouble(datas[i][4]) };
                
                switch(datas[i][1])
                {
                    case "Business":
                        listBusiness.Add(course);
                        break;

                    case "Ingeneering":
                        listIngeneering.Add(course);
                        break;

                    case "Literature":
                        listLiterature.Add(course);
                        break;
                }
            }
            fichierLect.Close();

            AllCourses.Add(listBusiness);
            AllCourses.Add(listIngeneering);
            AllCourses.Add(listLiterature);

            return AllCourses;
        }
        static void WriterCourses(string nomFichier, List<List<Course>> AllCourses, SortedList<string, Branche> branches)
        {
            StreamWriter fichWriter = new StreamWriter(nomFichier);
            string newInfo = "";

            List<string> writer = new List<string>();

            newInfo = ";Branche;Day Course;Hour Course;Duration";
            writer.Add(newInfo);
            for(int i=0; i<AllCourses.Count; i++)
            {
                foreach (Course course in AllCourses[i])
                {
                    newInfo = course.NameCourse + ";" + branches.ElementAt(i).Value.BrancheName + ";" + course.DayCourse + ";" +
                        course.HourCourse + ";" + course.Duration;
                    writer.Add(newInfo);
                }
            }

            foreach (string line in writer)
            {
                fichWriter.WriteLine(line);
            }

            fichWriter.Close();
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

            string databaseFile = "Database.csv";
            string gradesFile = "DatabaseGrades.csv";
            string coursesFile = "DatabaseCourses.csv";


            List <Student> DBStudents = new List<Student>();
            List<Teacher> DBTeachers = new List<Teacher>();
            List<Admin> DBAdmins = new List<Admin>();


            SortedList<string, Branche> branches = InitializeBranches();

            List<List<Course>> AllCourses = InitializeCourses(coursesFile);

            Initialization(databaseFile, gradesFile, DBStudents, DBTeachers, DBAdmins, branches, AllCourses);

            Application(DBStudents, DBTeachers, DBAdmins, AllCourses);

            Writer(databaseFile, DBStudents, DBTeachers, DBAdmins);

            WriterGrades(gradesFile, DBStudents, branches);

            WriterCourses(coursesFile, AllCourses, branches);

            Console.ReadKey();

        }


    }
}
