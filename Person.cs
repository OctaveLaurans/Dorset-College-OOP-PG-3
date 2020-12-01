using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetOOP_v2
{
    public abstract class Person
    {
        public string Name { get; set; }
        public string Adress { get; set; }
        public string PhoneNumber { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public Person(string name, string adress, string phoneNumber, string login, string password)
        {
            this.Name = name;
            this.Adress = adress;
            this.PhoneNumber = phoneNumber;
            this.Login = login;
            this.Password = password;
        }

        public abstract void DisplayInformation();
        public abstract void ManageInformation();
    }
}
