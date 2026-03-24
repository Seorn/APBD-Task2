using System;
using System.Collections.Generic;
using System.Text;

namespace APBD_Task2.Models
{
    public class Employee : User
    {
        public Employee(string firstName, string lastName) : base(firstName, lastName)
        {
            UserType = UserType.Employee;
        }

        public override int GetRentalLimit()
        {
            return 5;
        }
    }
}
