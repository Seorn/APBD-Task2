using System;
using System.Collections.Generic;
using System.Text;


namespace APBD_Task2.Models
{
    public class Rental
    {
        public Guid Id { get; } = Guid.NewGuid();
        public User User { get; set; }
        public Equipment Equipment { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ActualReturnDate { get; set; }
        public decimal Penalty { get; set; }

        public Rental(User user, Equipment equipment, DateTime rentalDate, DateTime dueDate)
        {
            User = user;
            Equipment = equipment;
            RentalDate = rentalDate;
            DueDate = dueDate;
        }

        public bool IsActive()
        {
            return ActualReturnDate == null;
        }

        public bool IsOverdue()
        {
            return ActualReturnDate == null && DateTime.Now.Date > DueDate.Date;
        }
    }
}
