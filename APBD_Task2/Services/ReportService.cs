using System;
using System.Collections.Generic;
using System.Linq;
using APBD_Task2.Models;

namespace APBD_Task2.Services
{
    public class ReportService
    {
        public void PrintEquipmentSummary(List<Equipment> equipment)
        {
            Console.WriteLine("- SUMMARY -");
            Console.WriteLine($"Total: {equipment.Count}");
            Console.WriteLine($"Available: {equipment.Count(e => e.Status == EquipmentStatus.Available)}");
            Console.WriteLine($"Rented: {equipment.Count(e => e.Status == EquipmentStatus.Rented)}");
            Console.WriteLine($"Unavailable: {equipment.Count(e => e.Status == EquipmentStatus.Unavailable)}");
        }
    }
}


