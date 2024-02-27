using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Vehicle
    {
        public string ModelName;
        public int NumberOfWheels;
        public string LicenseNumber;
        public string condition;//turn to enum
        public Wheel[] CollectionOfWheels;
        public string ownersName;
        public Dictionary<string, string> uniqinformation; 

        public Vehicle(string thisLicenseNumber, int thisnumberOfWheels)
        {
            LicenseNumber = thisLicenseNumber;

            condition = "in repair";
            NumberOfWheels = thisnumberOfWheels;
            CollectionOfWheels = new Wheel[thisnumberOfWheels];

        }

        public void FillWheelsToMax()
        {
            foreach (Wheel wheel in CollectionOfWheels)
            {
                wheel.InflatingTheWheelToMax();
            }
        }

        public float GetMaxAirPressure()
        {
            return CollectionOfWheels[0].MaxAirPressure;
        }

        public Dictionary<string, string> GetVehucleStats()
        {
            Dictionary<string, string> VehicleStats = new Dictionary<string, string>();

            VehicleStats.Add("ModelName", ModelName);
            VehicleStats.Add("LicenseNumber", LicenseNumber);
            VehicleStats.Add("condition", condition);
            VehicleStats.Add("ownersName", ownersName);
            // need more info

            return VehicleStats;
        }

    }
}