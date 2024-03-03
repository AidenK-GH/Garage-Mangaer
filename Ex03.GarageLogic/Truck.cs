using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic 
{
    public class Truck : Vehicle
    {
        public float cargoVolume;
        public bool IsTransportingHazardousMaterials;

        // ---------------------- v BUILDER v ----------------------
        internal Truck(string i_LicenseNumber, char i_FuelOrElectric, int NumberOfWheels, float MaxAirPressure, TypeOfFuel GasType, float MaxAmountOfEnergy)
        : base(i_LicenseNumber, NumberOfWheels, MaxAirPressure, GasType, MaxAmountOfEnergy)
        {
            this.LicenseNumber = i_LicenseNumber;

            Questions = new List<UniqueQuestion>();

            Questions.Add(new UniqueQuestion("does you truck Transporting Hazardous Materials? choose 1-yes 2-no:", 1, 2, 1));
            Questions.Add(new UniqueQuestion("what is the cargo Volume?", 0, Convert.ToInt32(float.PositiveInfinity), 2));
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
        // -------------------------------- v SET v ---------------------------------------------------------------------
        // ------------------- IsTransportingHazardousMaterials -------------------
        public void SetIsTransportingHazardousMaterials(string i_whatIsTransportingHazardousMaterials)
        {
            string answerString = "false";
            switch (i_whatIsTransportingHazardousMaterials)
            {
                case "1":
                    IsTransportingHazardousMaterials = true;
                    answerString = "True";
                    break;
                case "2":
                    IsTransportingHazardousMaterials = false;
                    answerString = "False";
                    break;
            }
            uniqinformation.Add("Is Transporting Hazardous Materials: ", answerString);
        }
        // ------------------- cargoVolume -------------------
        public void SetCargoVolume(string i_whatcargoVolume)
        {
            
            uniqinformation.Add("Cargo Volume: ", cargoVolume.ToString());
        }
        // ------------------------------------- v GET v ----------------------------------------------------------------
        public List<UniqueQuestion> getListOfQuistion()
        {
            return Questions;
        }
    }
}