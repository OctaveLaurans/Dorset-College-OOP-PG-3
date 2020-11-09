using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetOOP_v2
{
    class Student : IExam, ICourses, IPayment
    {
		public string Id { get; set; }
		public string Password { get; set; }

		public Student(string Id, string Password)
		{
			this.Id = Id;
			this.Password = Password;
		}
	}
}
