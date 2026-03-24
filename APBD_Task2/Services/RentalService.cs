using System;
using System.Collections.Generic;
using System.Linq;
using APBD_Task2.Models;

namespace APBD_Task2.Services
{
    public class RentalService : IRentalService
    {
        private readonly List<User> _users = new();
        private readonly List<Equipment> _equipment = new();
        private readonly List<Rental> _rentals = new();

        private const decimal DailyPenalty = 10m;

        public void AddUser(User user)
        {
            _users.Add(user);
        }

        public void AddEquipment(Equipment equipment)
        {
            _equipment.Add(equipment);
        }

        public void DisplayAllEquipment()
        {
            foreach (var item in _equipment)
            {
                Console.WriteLine(item.GetDescription());
            }
        }

        public void DisplayAvailableEquipment()
        {
            foreach (var item in _equipment.Where(e => e.Status == EquipmentStatus.Available))
            {
                Console.WriteLine(item.GetDescription());
            }
        }

        public void RentEquipment(Guid userId, Guid equipmentId, int days)
        {
            var user = _users.FirstOrDefault(u => u.Id == userId);
            var equipment = _equipment.FirstOrDefault(e => e.Id == equipmentId);

            if (user == null || equipment == null)
            {
                Console.WriteLine("User or equipment not found.");
                return;
            }

            if (equipment.Status != EquipmentStatus.Available)
            {
                Console.WriteLine("Equipment is not available.");
                return;
            }

            int activeRentals = _rentals.Count(r => r.User.Id == userId && r.IsActive());

            if (activeRentals >= user.GetRentalLimit())
            {
                Console.WriteLine($"{user.FullName} reached rental limit.");
                return;
            }

            var rental = new Rental(user, equipment, DateTime.Now.Date, DateTime.Now.Date.AddDays(days));
            _rentals.Add(rental);
            equipment.Status = EquipmentStatus.Rented;

            Console.WriteLine($"{equipment.Name} rented by {user.FullName} until {rental.DueDate:yyyy-MM-dd}");
        }

        public void ReturnEquipment(Guid equipmentId)
        {
            var rental = _rentals.FirstOrDefault(r => r.Equipment.Id == equipmentId && r.IsActive());

            if (rental == null)
            {
                Console.WriteLine("Active rental not found.");
                return;
            }

            rental.ActualReturnDate = DateTime.Now.Date;
            rental.Equipment.Status = EquipmentStatus.Available;

            int lateDays = (rental.ActualReturnDate.Value.Date - rental.DueDate.Date).Days;
            if (lateDays > 0)
            {
                rental.Penalty = lateDays * DailyPenalty;
            }

            Console.WriteLine($"{rental.Equipment.Name} returned. Penalty: {rental.Penalty}");
        }

        public void MarkEquipmentUnavailable(Guid equipmentId)
        {
            var equipment = _equipment.FirstOrDefault(e => e.Id == equipmentId);

            if (equipment == null)
            {
                Console.WriteLine("Equipment not found.");
                return;
            }

            if (equipment.Status == EquipmentStatus.Rented)
            {
                Console.WriteLine("Cannot mark rented equipment as unavailable.");
                return;
            }

            equipment.Status = EquipmentStatus.Unavailable;
            Console.WriteLine($"{equipment.Name} marked as unavailable.");
        }

        public void DisplayActiveRentalsForUser(Guid userId)
        {
            var rentals = _rentals.Where(r => r.User.Id == userId && r.IsActive());

            foreach (var rental in rentals)
            {
                Console.WriteLine($"{rental.Equipment.Name} | Due: {rental.DueDate:yyyy-MM-dd}");
            }
        }

        public void DisplayOverdueRentals()
        {
            var overdue = _rentals.Where(r => r.IsOverdue());

            foreach (var rental in overdue)
            {
                Console.WriteLine($"{rental.User.FullName} | {rental.Equipment.Name} | Due: {rental.DueDate:yyyy-MM-dd}");
            }
        }

        public void GenerateSummaryReport()
        {
            Console.WriteLine("- SUMMARY REPORT -");
            Console.WriteLine($"Total users: {_users.Count}");
            Console.WriteLine($"Total equipment: {_equipment.Count}");
            Console.WriteLine($"Available equipment: {_equipment.Count(e => e.Status == EquipmentStatus.Available)}");
            Console.WriteLine($"Rented equipment: {_equipment.Count(e => e.Status == EquipmentStatus.Rented)}");
            Console.WriteLine($"Unavailable equipment: {_equipment.Count(e => e.Status == EquipmentStatus.Unavailable)}");
            Console.WriteLine($"Active rentals: {_rentals.Count(r => r.IsActive())}");
            Console.WriteLine($"Overdue rentals: {_rentals.Count(r => r.IsOverdue())}");
        }

        public List<User> GetUsers()
        {
            return _users;
        }

        public List<Equipment> GetEquipment()
        {
            return _equipment;
        }
    }
}