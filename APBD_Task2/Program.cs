using System;
using APBD_Task2.Services;
using APBD_Task2.Data;

namespace APBD_Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            var rentalService = new RentalService();
            var reportService = new ReportService();

            DataSeeder.Seed(rentalService);

            Console.WriteLine("- ALL EQUIPMENT -");
            rentalService.DisplayAllEquipment();

            Console.WriteLine();
            Console.WriteLine("- AVAILABLE EQUIPMENT -");
            rentalService.DisplayAvailableEquipment();

            var users = rentalService.GetUsers();
            var equipment = rentalService.GetEquipment();

            var student = users[0];
            var employee = users[2];

            var laptop = equipment[0];
            var projector = equipment[1];
            var camera = equipment[2];
            var extraLaptop = equipment[3];

            Console.WriteLine();
            Console.WriteLine("- RENT OPERATIONS -");
            rentalService.RentEquipment(student.Id, laptop.Id, 7);
            rentalService.RentEquipment(student.Id, projector.Id, 5);
            rentalService.RentEquipment(student.Id, camera.Id, 3);

            Console.WriteLine();
            Console.WriteLine("- ACTIVE RENTALS FOR STUDENT -");
            rentalService.DisplayActiveRentalsForUser(student.Id);

            Console.WriteLine();
            Console.WriteLine("- UNAVAILABLE EQUIPMENT -");
            rentalService.MarkEquipmentUnavailable(extraLaptop.Id);

            Console.WriteLine();
            Console.WriteLine("- OVERDUE RENTALS -");
            rentalService.DisplayOverdueRentals();

            Console.WriteLine();
            rentalService.GenerateSummaryReport();

            Console.WriteLine();
            reportService.PrintEquipmentSummary(equipment);

            Console.WriteLine();
            Console.WriteLine("Demo completed.");
        }
    }
}