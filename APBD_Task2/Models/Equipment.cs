using System;
using System.Collections.Generic;
using System.Text;


namespace APBD_Task2.Models
{
    public abstract class Equipment
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Name { get; set; }
        public EquipmentStatus Status { get; set; }

        protected Equipment(string name)
        {
            Name = name;
            Status = EquipmentStatus.Available;
        }

        public virtual bool IsAvailable()
        {
            return Status == EquipmentStatus.Available;
        }

        public abstract string GetDescription();
    }
}
