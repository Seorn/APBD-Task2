using System;
using System.Collections.Generic;
using System.Text;

namespace APBD_Task2.Models
{
    public class Camera : Equipment
    {
        public string SensorType { get; set; }
        public int Megapixels { get; set; }

        public Camera(string name, string sensorType, int megapixels) : base(name)
        {
            SensorType = sensorType;
            Megapixels = megapixels;
        }

        public override string GetDescription()
        {
            return $"Camera: {Name}, Sensor: {SensorType}, MP: {Megapixels}, Status: {Status}";
        }
    }
}
