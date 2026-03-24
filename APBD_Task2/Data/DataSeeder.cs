using System;
using System.Collections.Generic;
using System.Text;
using APBD_Task2.Models;
using APBD_Task2.Services;

namespace APBD_Task2.Data
{
    public static class DataSeeder
    {
        public static void Seed(RentalService service)
        {
            var student1 = new Student("Soner", "Demir");
            var student2 = new Student("Mert", "Malski");
            var employee1 = new Employee("Maria", "Kramko");

            service.AddUser(student1);
            service.AddUser(student2);
            service.AddUser(employee1);

            service.AddEquipment(new Laptop("Dell Casper", "Windows 11", 16));
            service.AddEquipment(new Projector("Epson SA", 3200, "1920x1080"));
            service.AddEquipment(new Camera("Canon EOS", "CMOS", 24));
            service.AddEquipment(new Laptop("MacBook Hair", "macOS", 8));
        }
    }
}
