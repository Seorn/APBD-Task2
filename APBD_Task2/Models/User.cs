using System;
using System.Collections.Generic;
using System.Text;


namespace APBD_Task2.Models
{
    public abstract class User
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserType UserType { get; protected set; }

        protected User(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FullName => $"{FirstName} {LastName}";

        public abstract int GetRentalLimit();
    }
}
