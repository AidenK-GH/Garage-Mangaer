using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {
        public MotorcycleLicenseType MotorcycleLicenseType; // [A1, A2, AB, B2]
        public int EngineVolumeInCC;
        
        // ---------------------- BUILDER ----------------------
        internal Motorcycle(string i_LicenseNumber, char i_FuelOrElectric, int NumberOfWheels, float MaxAirPressure, TypeOfFuel GasType, float MaxAmountOfEnergy)
        : base(i_LicenseNumber, NumberOfWheels, MaxAirPressure, GasType, MaxAmountOfEnergy)
        {
            this.LicenseNumber = i_LicenseNumber;

            Questions = new List<UniqueQuestion>();

            Questions.Add(new UniqueQuestion("what License Type do you have? choose 1-A1 2-A2 3-AB 4-B2:", 1, 4, 1));
            Questions.Add(new UniqueQuestion("what is the Engine Volume In CC?", 0, Convert.ToInt32(float.PositiveInfinity), 2));
            uniqinformation = new Dictionary<string, string>();

            if (i_FuelOrElectric == 'f')
            {
                fuelInformation = new FuelTypeVehicle(GasType, MaxAmountOfEnergy);
                TypeOfEnergy = "gaselin";
                ElectricInformation = null;
            }
            else
            {
                fuelInformation = null;
                ElectricInformation = new ElectricTypeVehicle(MaxAmountOfEnergy);
                TypeOfEnergy = "electricity";
            }
        }
        // ----------------------------------------------------------------------------------
        // ------------------- Motorcycle License Type -------------------
        public void SetMotorcycleLicenseType(string i_whatMotorcycleLicenseType)
        {
            switch (i_whatMotorcycleLicenseType)
            {
                case "1":
                    MotorcycleLicenseType = MotorcycleLicenseType.A1;
                    break;
                case "2":
                    MotorcycleLicenseType = MotorcycleLicenseType.A2;
                    break;
                case "3":
                    MotorcycleLicenseType = MotorcycleLicenseType.AB;
                    break;
                case "4":
                    MotorcycleLicenseType = MotorcycleLicenseType.B2;
                    break;
            }
            uniqinformation.Add("Motorcycle License Type: ", MotorcycleLicenseType.ToString());
        }
        // ------------------- EngineVolumeInCC -------------------
        public void SetEngineVolumeInCC(string i_whatEngineVolumeInCC)
        {

            uniqinformation.Add("Engine Volume In CC: ", EngineVolumeInCC.ToString());
        }
        // ----------------------------------------------------------------------------------
        public List<UniqueQuestion> getListOfQuistion()
        {
            return Questions;
        }
    }
}