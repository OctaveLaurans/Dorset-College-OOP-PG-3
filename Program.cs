﻿using System;
using System.Collections.Generic;


namespace ProjetOOP_v2
{
    public class Program
    {
        /*
        static void ChoixIdentification(List<Student> liste, List<Teacher> liste2, List<Admin> liste3)
        {
            string y = "";
            do
            {
                Console.WriteLine("\nQue voulez vous faire ?\nVous connectez en tant que :\n1 Student\n2 Teacher\n3 Admin\n\nSi vous n'avez pas de compte :\n\n4 Créez un compte");

                int x = Convert.ToInt32(Console.ReadLine());
                switch (x)
                {
                    case 1:
                        Console.WriteLine("Vous tentez de vous connecter en tant qu'étudiant");
                        Identification(liste, liste2, liste3, x);
                        break;
                    case 2:
                        Console.WriteLine("Vous tentez de vous connecter en tant que prof");
                        Identification(liste, liste2, liste3, x);
                        break;
                    case 3:
                        Console.WriteLine("Vous tentez de vous connecter en tant qu'Admin");
                        Identification(liste, liste2, liste3, x);
                        break;
                    case 4:
                        Inscription(liste, liste2, liste3);
                        Console.WriteLine("Voulez vous vous connecter maintenant : oui / non");
                        y = Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Vous avez choisi une option non valable\nVoulez-vous ré essayer : oui / non");
                        y = Console.ReadLine();
                        break;
                }
            }
            while (y == "oui");
        }
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
        static void Identification(List<Student> liste, List<Teacher> liste2, List<Admin> liste3, int x)
        {

            /*
            for (int i = 0; i < 2; i++)
            {
                string id = Console.ReadLine();
                string password = Console.ReadLine();
                Student nouveau1 = new Student(id, password);
                liste.Add(nouveau1);
            }
            foreach (Student a in liste)
            {
                Console.WriteLine(a.Id + "  " + a.Password);
            }
            *

            bool result = true;
            do
            {
                Console.WriteLine("Renseignez votre id");
                string answer1 = Console.ReadLine();
                string stop = "";
                int i = 0;

                if (x == 1)
                {
                    while (i < liste.Count && liste[i].Id != answer1)
                    {
                        i++;
                        if (i == liste.Count)
                        {
                            Console.WriteLine("Erreur d'identification");
                            result = false;
                        }
                    }
                }
                else if (x == 2)
                {
                    while (i < liste2.Count && liste2[i].Id != answer1)
                    {
                        i++;
                        if (i == liste2.Count)
                        {
                            Console.WriteLine("Erreur d'identification");
                            result = false;
                        }
                    }
                }
                else
                {
                    while (i < liste3.Count && liste3[i].Id != answer1)
                    {
                        i++;
                        if (i == liste3.Count)
                        {
                            Console.WriteLine("Erreur d'identification");
                            result = false;
                        }
                    }
                }



                if (result == true)
                {
                    Console.WriteLine("Rentrez votre code");
                    string answer2 = Console.ReadLine();
                    if (x == 1)
                    {
                        if (liste[i].Password == answer2)
                        {
                            Console.WriteLine("Bienvenue");
                            result = false;
                        }
                    }
                    else if (x == 2)
                    {
                        if (liste2[i].Password == answer2)
                        {
                            Console.WriteLine("Bienvenue");
                            result = false;
                        }
                    }
                    else
                    {
                        if (liste3[i].Password == answer2)
                        {
                            Console.WriteLine("Bienvenue");
                            result = false;
                        }
                    }

                    if (result == true)
                    {
                        Console.WriteLine("Mot de passe incorrect");
                        Console.WriteLine("Voulez vous réessayer :\noui ou non ?");
                        stop = Console.ReadLine();
                        if (stop == "non") result = false;
                    }
                }
                else
                {
                    result = true;
                    Console.WriteLine("ID inccorect");
                    Console.WriteLine("Voulez vous réessayer ?\noui ou non ?");
                    stop = Console.ReadLine();
                    if (stop == "non") result = false;
                }
            }
            while (result == true);

        }
        */
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






            Course statistics = director.CreationCourse();
            Course oop = director.CreationCourse();




            Teacher thai = new Teacher("Thai", "Paris", "17", "thai@yahoo.fr", "1234");
            Teacher dupont = new Teacher("Dupont", "Paris", "17", "thai@yahoo.fr", "1234");

            director.AllTeachers.Add(thai);
            director.AllTeachers.Add(dupont);


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
