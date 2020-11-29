using System;
using System.Collections.Generic;


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
                Console.Write("\nVirtual Global College Application\n\nAre you a student, a teacher or an administrator ?\n1 : Student\n2 : Teacher\n3 : Admin\nChoice : ");
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


        /*
        static void Inscription(List<Student> liste, List<Teacher> liste2, List<Admin> liste3)
        {
            Console.WriteLine("Quel type de compte voulez-vous créer :\n1 Student\n2 Teacher\n3 Admin\n");

            int x = Convert.ToInt32(Console.ReadLine());
            switch (x)
            {
                case 1:
                    Console.WriteLine("Vous tentez de vous inscrire en tant qu'étudiant");
                    Console.WriteLine("Veuillez renseigner un identifiant puis un mot de passe");
                    string Id = Console.ReadLine();
                    string password = Console.ReadLine();
                    Student nouv1 = new Student(Id, password);
                    liste.Add(nouv1);
                    break;
                case 2:
                    Console.WriteLine("Vous tentez de vous inscrire en tant que prof");
                    Console.WriteLine("Veuillez renseigner un identifiant puis un mot de passe");
                    string Id2 = Console.ReadLine();
                    string password2 = Console.ReadLine();
                    Teacher nouv2 = new Teacher(Id2, password2);
                    liste2.Add(nouv2);
                    break;
                case 3:
                    Console.WriteLine("Vous tentez de vous inscrire en tant qu'Admin");
                    Console.WriteLine("Veuillez renseigner un identifiant puis un mot de passe");
                    string Id3 = Console.ReadLine();
                    string password3 = Console.ReadLine();
                    Admin nouv3 = new Admin(Id3, password3);
                    liste3.Add(nouv3);
                    break;
                default:
                    Console.WriteLine("Vous avez choisi une option non valable\nVoulez-vous ré essayer : oui / non");
                    break;
            }
        }
        */

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



        static void Application(List<Student> DBStudents, List<Teacher> DBTeachers, List<Admin> DBAdmins, List<Student> AllStudents, List<Course> AllCourses)
        {
            string choice = IdentificationChoice();

            int index = -1;
            if (choice == "1" || choice == "2" || choice == "3")
            {
                do
                {
                    Console.Write("Login : ");
                    string login = Console.ReadLine();
                    Console.Write("Password : ");
                    string password = Console.ReadLine();
                    Console.WriteLine();

                    switch (choice)
                    {
                        case "1":
                            index = IdentificationStudent(DBStudents, login, password);
                            if (index >= 0) ApplicationStudent(DBStudents, index, AllStudents);
                            break;

                        case "2":
                            index = IdentificationTeacher(DBTeachers, login, password);
                            if (index >= 0) ApplicationTeacher(DBTeachers, index, AllStudents, AllCourses);
                            break;

                        case "3":
                            index = IdentificationAdmin(DBAdmins, login, password);
                            if (index >= 0) ApplicationAdmin(DBAdmins, index, AllStudents, AllCourses);
                            break;
                    }

                    if (index < 0)
                    {
                        index = 4;
                        //Console.WriteLine("Error of connection - Email or Password invalid\nPlease try again\n\n");
                        Console.WriteLine("Error of connection - Email or Password invalid\nDo you want to try again ? yes or no ?\n\n");
                        string answer = Console.ReadLine();
                        if (answer == "yes")
                        {
                            index = -1;
                            choice = IdentificationChoice();
                        }
                    }

                }
                while (index < 0);
            }

        }

        static void ApplicationStudent(List<Student> DBStudents, int index, List<Student> AllStudents)
        {
            int choice = 0;
            int choice2 = 0;
            Student student = DBStudents[index];

            string answer = "";
            do
            {
                Console.Write("\nWhich program do you want to execute ?\n\n\n1 : To display my informations\n2 : To manage my informations\n3 : To display my grade book\n4: To display my attendance\n5 : To display my calendar \nChoice : ");
                choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                if (choice == 1) //ok ca marche
                {
                    Console.WriteLine("Your informations :\n");
                    student.DisplayInformation();
                }
                if (choice == 2) //ok ca marche
                    do
                    {
                        student.ManageInformation();
                        Console.WriteLine("Your new informations are :\n");
                        student.DisplayInformation();
                        Console.WriteLine("Do you want to change an other information ?\n1 : Yes\n2 : No\nChoice : ");
                        choice2 = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine();

                    }
                    while (choice2 == 1);
                //if (choice == 3) //a faire
                if (choice == 4)
                {
                    student.DisplayAttendance(AllStudents); //demande juste le nom de l'étudiant et n'affiche pas la suite de la méthode
                }

                if (choice == 5)
                {
                    Console.WriteLine("Your time table :\n\n\n");//n'affiche rien 

                }
                


                Console.WriteLine("Do you want to continue ? yes or no");
                answer = Console.ReadLine();
            } while (answer == "yes");



        }



        static void ApplicationTeacher(List<Teacher> DBTeacher, int index, List<Student> AllStudents, List<Course>AllCourses)
        {
            Teacher teacher = DBTeacher[index];
            int choice = 0;
            string answer = "";
            do
            {
                Console.Write("\nWhich program do you want to execute ?\n\n\n1 : To display my informations\n2 : To access to my students informations\n3 : To register a student in a course\n4: To manage grade books\n5 : To display grade books\n6 : To display the calendar\n7 : To manage the calendar\n8: To manage the attendance\n9 : To display the attendance\nChoice : ");
                choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                if (choice == 1) //ok ca marche
                {
                    Console.WriteLine("Your informations :\n");
                    teacher.DisplayInformation();
                }
                //if (choice == 2)
                {
                    //a faire
                }//
                /*if(choice == 3)
                {
                    teacher.InscriptionCourseStudent(Student name); // a revoir 
                }*/
                //if (choice == 4) // a faire
                //if (choice == 5) // a faire
                                        
             // if (choice == 6) //a faire
                
                if (choice == 7)
                {
                    teacher.CreationTimetable( AllCourses);
                }
                if (choice == 8)
                {
                    Console.WriteLine("You want to manage the attendance, please follow the instructions\n\n");
                    teacher.ManageAttendance(AllStudents); //demande juste le nom de l'étudiant et n'affiche pas la suite de la méthode
                }
                if (choice == 9)
                {
                    teacher.DisplayAttendance(AllStudents); //demande juste le nom de l'étudiant et n'affiche pas la suite de la méthode
                }
                Console.WriteLine("Do you want to continue ? yes or no");
                answer = Console.ReadLine();
            } while (answer == "yes");


        }
        static void ApplicationAdmin(List<Admin> DBAdmins, int index, List<Student> AllStudents, List<Course> AllCourses)
        {
            Admin admin = DBAdmins[index];
            int choice = 0;

            string answer = "";
            do
            {
                Console.Write("\nWhich program do you want to execute ?\n\n\n1 : To display my informations\n2 : To access to students informations\n3 : To access to teachers informations\n4 : To create students groups\n5 : To create a course\n6 : To create an exam\n7 : To display grade books\n8 : To display the calendar\n9 : To manage the calendar\n10 : To display the attendance\n11 : To manage the payment\n12 : To register a student in an exam\nChoice : ");
                choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 1)
                {
                    admin.DisplayInformation();
                }
                //if (choice == 2) a faire
                //if (choice == 3) a faire
                /* (choice == 4)
                {
                    admin.CreateStudentsGroup(Branche branche);
                }*/
                if (choice == 5)
                {
                    admin.CreationCourse(AllCourses);
                }
                if (choice == 6)
                {
                    admin.CreationExam();
                }
                //if (choice == 7) a faire
                //if (choice == 8) a faire
                //if (choice == 9) a faire
                if (choice == 10)
                {
                    admin.DisplayAttendance(AllStudents); //demande juste le nom de l'étudiant et n'affiche pas la suite de la méthode
                }
                Console.WriteLine("Do you want to continue ? yes or no");
                answer = Console.ReadLine();
            } while (answer == "yes");




        }





        public static void Main(string[] args)
        {

            Branche branche1 = new Branche { BrancheName = "Ingeneering", FeesAmount = 1000 };
            Branche branche2 = new Branche { BrancheName = "Business", FeesAmount = 2000 };
            Branche branche3 = new Branche { BrancheName = "Litterature", FeesAmount = 300 };



            List<Teacher> listTeachers = new List<Teacher>();



            Student max = new Student("Max", "Chaville", "001", "maxime@yahoo.fr", "1234", branche1, 2, 1, 1, 0);
            Student gay = new Student("Gay", "Sevres", "001", "arthur", "1234", branche1, 2, 1, 2, 0);
            Student be = new Student("Be", "Meudon", "001", "maxime@yahoo.fr", "1234", branche2, 2, 1, 1, 0);
            Student ime = new Student("Ime", "Clamart", "001", "maxime@yahoo.fr", "1234", branche1, 2, 1, 1, 0);
            Student sam = new Student("Sam", "Bobigny", "001", "maxime@yahoo.fr", "1234", branche1, 2, 1, 1, 0);
            Student url = new Student("Url", "Dublin", "001", "maxime@yahoo.fr", "1234", branche1, 2, 1, 1, 0);
            Student bar = new Student("Bar", "Montcuq", "001", "maxime@yahoo.fr", "1234", branche1, 2, 1, 1, 0);
            Student chut = new Student("Chut", "Tokyo", "001", "maxime@yahoo.fr", "1234", branche1, 2, 1, 1, 0);



            Admin director = new Admin("Pascal", "Paris", "17", "pascal@gmail.com", "1234");
            Admin director2 = new Admin("Pascal2", "Paris2", "18", "pascal2@gmail.com", "1234");


            director.AllStudents.Add(max);
            director.AllStudents.Add(gay);
            director.AllStudents.Add(be);
            director.AllStudents.Add(ime);
            director.AllStudents.Add(sam);
            director.AllStudents.Add(url);
            director.AllStudents.Add(bar);
            director.AllStudents.Add(chut);

            Student arthur = new Student("arthur", "compiegne", "001", "maxime@yahoo.fr", "1234", branche1, 2, 1, 1, 0);
            director.AllStudents.Add(arthur);





            // Course statistics = director.CreationCourse();
            // Course oop = director.CreationCourse();




            Teacher thai = new Teacher("Thai", "Paris", "17", "thai@yahoo.fr", "1234");
            Teacher dupont = new Teacher("Dupont", "Paris", "17", "dupont@yahoo.fr", "1234");

            director.AllTeachers.Add(thai);
            director.AllTeachers.Add(dupont);




            List<Student> DBStudents = new List<Student>();
            DBStudents.Add(max);
            DBStudents.Add(gay);

            List<Teacher> DBTeachers = new List<Teacher>();
            DBTeachers.Add(thai);
            DBTeachers.Add(dupont);

            List<Admin> DBAdmins = new List<Admin>();
            DBAdmins.Add(director);

            List<Student> AllStudents = new List<Student>();
            List<Course> AllCourses = new List<Course>();

            Application(DBStudents, DBTeachers, DBAdmins, AllStudents, AllCourses);



            /*
            List<Student> td1 = director.CreateStudentsGroup(branche1);
            List<Student> td2 = director.CreateStudentsGroup(branche1);


            director.IncsriptionCourse(statistics, thai, td1);
            director.IncsriptionCourse(oop, dupont, td2);




            foreach(Student student in td1)
            {
                Console.WriteLine($"{student.Name}  studies  {student.Courses[0].NameCourse}");
            }
            Console.WriteLine();
            foreach (Student student in td2)
            {
                Console.WriteLine($"{student.Name}  studies  {student.Courses[0].NameCourse}");
            }


            Console.WriteLine();


            Console.WriteLine(thai.Course.NameCourse);
            for (int i=0; i<thai.GroupStudents[0].Count; i++)
            {
                Console.WriteLine(thai.GroupStudents[0][i].Name);
            }


            Console.WriteLine();


            Console.WriteLine(dupont.Course.NameCourse);
            for (int i = 0; i < dupont.GroupStudents[0].Count; i++)
            {
                Console.WriteLine(dupont.GroupStudents[0][i].Name);
            }


            /*

            // maxime.ManageInformation();
            maxime.DisplayInformation();

            maxime.Payment();

            maxime.DisplayInformation();

            */

            Console.ReadKey();

        }


    }
}
