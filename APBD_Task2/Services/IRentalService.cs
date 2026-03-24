using System;
using System.Collections.Generic;
using System.Text;

using APBD_Task2.Models;

namespace APBD_Task2.Services
{
    public interface IRentalService
    {
        void AddUser(User user);
        void AddEquipment(Equipment equipment);
        void DisplayAllEquipment();
        void DisplayAvailableEquipment();
        void RentEquipment(Guid userId, Guid equipmentId, int days);
        void ReturnEquipment(Guid equipmentId);
        void MarkEquipmentUnavailable(Guid equipmentId);
        void DisplayActiveRentalsForUser(Guid userId);
        void DisplayOverdueRentals();
        void GenerateSummaryReport();
    }
}


