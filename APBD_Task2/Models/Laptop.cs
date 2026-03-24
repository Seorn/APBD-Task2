using System;
using System.Collections.Generic;
using System.Text;

namespace APBD_Task2.Models
{
    public class Laptop : Equipment
    {
        public string OperatingSystem { get; set; }
        public int RamGb { get; set; }

        public Laptop(string name, string operatingSystem, int ramGb) : base(name)
        {
            OperatingSystem = operatingSystem;
            RamGb = ramGb;
        }

        public override string GetDescription()
        {
            return $"Laptop: {Name}, OS: {OperatingSystem}, RAM: {RamGb} GB, Status: {Status}";
        }
    }
}
