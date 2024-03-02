using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Vehicle
    {
        // every vehicle has
        public string ModelName;
        public string LicenseNumber;
        public float PercentageOfEnergyRemaining;
        public int NumberOfWheels;
        public Wheel[] CollectionOfWheels;

        // garage info
        public string ownersName;
        public string ownersPhoneNumber;
        public ConditionInGarage Condition; //[inRepair, fixed, paid, none]

        // energy - the one the vehicle DOESNT use will be null
        public FuelTypeVehicle fuelInformation;
        public ElectricTypeVehicle ElectricInformation;
        public string TypeOfEnergy;

        // uniqin formation
        public Dictionary<string, string> uniqinformation;
        public List<UniqueQuestion> Questions;

        

        // ----------------------- BUILDER -----------------------------------------

        public Vehicle(string thisLicenseNumber, int thisnumberOfWheels, float MaxAirPressure, TypeOfFuel GasTypey, float MaxAmountOfEnergy)
        {
            LicenseNumber = thisLicenseNumber;

            NumberOfWheels = thisnumberOfWheels;
            CollectionOfWheels = new Wheel[thisnumberOfWheels];
            for (int i = 0; i < CollectionOfWheels.Length; i++)
            {
                CollectionOfWheels[i] = new Wheel(MaxAirPressure);
            }

            Condition = ConditionInGarage.InRepair;
        }

        // -------------------------- Generate Wheels --------------------------------------

        public void GenerateWheels(string[] menufactursnames, float[] currentAirPressurs, float MaxCarWheelsAirPressure, int numberOfWheels)
        {
            for (int i = 0; i < numberOfWheels; i++)
            {
                CollectionOfWheels[i].CurrentAirPressure = currentAirPressurs[i];
                CollectionOfWheels[i].MaxAirPressure = MaxCarWheelsAirPressure;
                CollectionOfWheels[i].manufacturerName = menufactursnames[i];
            }
        }

        public void GenerateWheelsWithoutMaxAirPressure(string[] menufactursnames, float[] currentAirPressurs, int numberOfWheels)
        {
            for (int i = 0; i < numberOfWheels; i++)
            {
                CollectionOfWheels[i].CurrentAirPressure = currentAirPressurs[i];
                CollectionOfWheels[i].manufacturerName = menufactursnames[i];
            }
        }

        // ----------------------------------------------------------------

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

        // ----------------------------------------------------------------
        public Dictionary<string, string> GetVehucleStats()
        {
            Dictionary<string, string> VehicleStats = new Dictionary<string, string>();

            VehicleStats.Add("ModelName", ModelName);
            VehicleStats.Add("LicenseNumber", LicenseNumber);
            VehicleStats.Add("condition", Condition.ToString());
            VehicleStats.Add("ownersName", ownersName);
            // need more info

            return VehicleStats;
        }

        public void SetAmountOfEnergy(float AmountOfEnergy)
        {
            if (fuelInformation == null)
            {
                ElectricInformation.SetCorrentAmountOfBattry(AmountOfEnergy);
            }
            else
            {
                fuelInformation.SetFuel(AmountOfEnergy);
            }
        }

        public string getAmounOfEnergy()
        {
            string AmountOfEnergyNow = "error";
            if(fuelInformation == null)
            {
                AmountOfEnergyNow = ElectricInformation.CorrentAmountOfBattry + "hours";
            }
            else
            {
                AmountOfEnergyNow = fuelInformation.CorrentAmountOfFuel + " liters";
            }
            return AmountOfEnergyNow;
        }

    }
}