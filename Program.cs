using System;
using System.Collections.Generic;


namespace ProjetOOP_v2
{
    public class Program
    {
        
        static int IdentificationChoice()
        {
            int choice = 0;

            string continu = "";
            do
            {
                Console.Write("\nVirtual Global College Application\n\nAre you a student, a teacher or an administrator ?\n1 : Student\n2 : Teacher\n3 : Admin\nChoice : ");
                choice = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine();

                if(choice == 1 || choice == 2 || choice == 3)
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
            int index = 0;
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
            int index = 0;
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
            int index = 0;
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



        static void Application(List<Student> DBStudents, List<Teacher> DBTeachers, List<Admin> DBAdmins)
        {
            int choice = IdentificationChoice();

            int index = -1;

            do
            {
                Console.Write("Login : ");
                string login = Console.ReadLine();
                Console.Write("Password : ");
                string password = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        index = IdentificationStudent(DBStudents, login, password);
                        ApplicationStudent(DBStudents, index);
                        break;

                    case 2:
                        index = IdentificationTeacher(DBTeachers, login, password);
                        ApplicationTeacher(DBTeachers, index);
                        break;

                    case 3:
                        index = IdentificationAdmin(DBAdmins, login, password);
                        ApplicationAdmin(DBAdmins, index);
                        break;
                }

                if (index < 0)
                {
                    Console.WriteLine("Error of connection - Email or Password invalid\nPlease try again\n\n");
                }

            }
            while (index < 0);
        }

        static void ApplicationStudent(List<Student> DBStudents, int index)
        {
            Student student = DBStudents[index];
            student.DisplayInformation();
        }
        static void ApplicationTeacher(List<Teacher> DBTeacher, int index)
        {
            Teacher teacher = DBTeacher[index];
            teacher.DisplayInformation();
        }
        static void ApplicationAdmin(List<Admin> DBAdmins, int index)
        {
            Admin admin = DBAdmins[index];
            admin.DisplayInformation();
        }




        public static void Main(string[] args)
        {

            Branche branche1 = new Branche { BrancheName = "Ingeneering", FeesAmount = 1000 };
            Branche branche2 = new Branche { BrancheName = "Business", FeesAmount = 2000 };
            Branche branche3 = new Branche { BrancheName = "Litterature", FeesAmount = 300 };



            List<Teacher> listTeachers = new List<Teacher>();



            Student max = new Student("Max", "Chaville", "001", "maxime@yahoo.fr", "1234", branche1, 2, 0);
            Student gay = new Student("Gay", "Sevres", "001", "maxime@yahoo.fr", "1234", branche1, 2, 0);
            Student be = new Student("Be", "Meudon", "001", "maxime@yahoo.fr", "1234", branche2, 2, 0);
            Student ime = new Student("Ime", "Clamart", "001", "maxime@yahoo.fr", "1234", branche1, 2, 0);
            Student sam = new Student("Sam", "Bobigny", "001", "maxime@yahoo.fr", "1234", branche1, 2, 0);
            Student url = new Student("Url", "Dublin", "001", "maxime@yahoo.fr", "1234", branche1, 2, 0);
            Student bar = new Student("Bar", "Montcuq", "001", "maxime@yahoo.fr", "1234", branche1, 2, 0);
            Student chut = new Student("Chut", "Tokyo", "001", "maxime@yahoo.fr", "1234", branche1, 2, 0);


            Admin director = new Admin("Pascal", "Paris", "17", "pascal@gmail.com", "1234");


            director.AllStudents.Add(max);
            director.AllStudents.Add(gay);
            director.AllStudents.Add(be);
            director.AllStudents.Add(ime);
            director.AllStudents.Add(sam);
            director.AllStudents.Add(url);
            director.AllStudents.Add(bar);
            director.AllStudents.Add(chut);






            // Course statistics = director.CreationCourse();
            // Course oop = director.CreationCourse();




            Teacher thai = new Teacher("Thai", "Paris", "17", "thai@yahoo.fr", "1234");
            Teacher dupont = new Teacher("Dupont", "Paris", "17", "thai@yahoo.fr", "1234");

            director.AllTeachers.Add(thai);
            director.AllTeachers.Add(dupont);




            List<Student> DBStudents = new List<Student>();
            DBStudents.Add(max);

            List<Teacher> DBTeachers = new List<Teacher>();
            DBTeachers.Add(thai);

            List<Admin> DBAdmins = new List<Admin>();
            DBAdmins.Add(director);

            Application(DBStudents, DBTeachers, DBAdmins);



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
