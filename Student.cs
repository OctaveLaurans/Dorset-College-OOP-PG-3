using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetOOP_v2
{
    class Student : Person, IPayment
    {

        public Branche Branche { get; set; }
        public List<ICourses> Courses {get; set;}

        public int ToBePaid { get; set; }
        public int NumberOfPayments { get; set; }

        public int NumberOfAbsences { get; set; }



        public Student(string name, string adress, string phoneNumber, string login, string password, Branche branche, int numberOfPayments, int numberOfAbsences, List<ICourses> courses)
		{
            this.Name = name;
            this.Adress = adress;
            this.PhoneNumber = phoneNumber;
			this.Login = login;
			this.Password = password;

            this.Branche = branche;

            this.ToBePaid = Branche.FeesAmount;

            this.NumberOfPayments = numberOfPayments;

            this.NumberOfAbsences = numberOfAbsences;
            this.Courses = courses;
		}

        public void ManageInformation()
        {
            Console.WriteLine("Which information do you want to change ?");
            Console.WriteLine("1. Adress");
            Console.WriteLine("2. Phone Number");
            Console.WriteLine("3. Password");
            Console.Write("Choice : ");
            int choice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            string change;
            switch(choice)
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

        public void DisplayInformation()
        {
            Console.WriteLine($"Name : {Name}");
            Console.WriteLine($"Adress : {Adress}");
            Console.WriteLine($"Phone Number : {PhoneNumber}");
            Console.WriteLine($"Email / Login : {Login}");
            Console.WriteLine($"Amount that need to be paid : {ToBePaid}$");
            Console.WriteLine($"Number of Absences : {NumberOfAbsences}");
            Console.WriteLine();
        }

        public void Payment()
        {
            int amount = Branche.FeesAmount / NumberOfPayments;

            ToBePaid -= amount;
        }

        public void Inscription(ICourses course)
        {
            courses.Add(course);
            //Ajouter cet élève à la liste du prof qui fait ce cours
        }
    }
}
