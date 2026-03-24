using System;
using System.Collections.Generic;
using System.Text;

namespace APBD_Task2.Models
{
    public class Student : User
    {
        public Student(string firstName, string lastName) : base(firstName, lastName)
        {
            UserType = UserType.Student;
        }

        public override int GetRentalLimit()
        {
            return 2;
        }
    }
}
