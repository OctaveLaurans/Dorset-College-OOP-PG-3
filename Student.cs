using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetOOP_v2
{
    class Student : Person, IPayment
    {

        public Branche Branche { get; set; }
        public List<Course> Courses {get; set;}
        public List<Exam> Exams { get; set; }

        public int ToBePaid { get; set; }
        public int NumberOfPayments { get; set; }

        public int NumberOfAbsences { get; set; }
        public int NumberOfPresence { get; set; }
        public int NumberOfDelay { get; set; }

        public int Group { get; set; }

        public Student(string name, string adress, string phoneNumber, string login, string password, Branche branche, int numberOfPayments, int numberOfAbsences, int numberOfPresence, int numberOfDelay)
            : base(name, adress, phoneNumber, login, password)
		{

            this.Branche = branche;

            this.ToBePaid = Branche.FeesAmount;

            this.NumberOfPayments = numberOfPayments;

            this.NumberOfAbsences = numberOfAbsences;

            Courses = new List<Course>();
            Exams = new List<Exam>();
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

        public override void DisplayInformation()
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

        public void DisplayAttendance(List<Student> AllStudent)
        {
            Console.Write("Enter your name :\n");
            string Nchoice = Console.ReadLine();
            for (int i = 0; i < AllStudent.Count; i++)
            {
                if (AllStudent[i].Name == Nchoice)
                {
                    Console.WriteLine("Nomber of Presence :", AllStudent[i].NumberOfPresence);
                    Console.WriteLine("Nombre of Delay :", AllStudent[i].NumberOfDelay);
                    Console.WriteLine("Nomber of Absence :", AllStudent[i].NumberOfAbsences);
                }
                else
                {
                    Console.WriteLine("This student doesn't exist ... please try again\n");
                }
            }
        }


    }
}
