using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetOOP_v2
{
    class Admin
    {
        public string Id { get; set; }
        public string Password { get; set; }

        public Admin(string Id, string Password)
        {
            this.Id = Id;
            this.Password = Password;
        }
    }
}
