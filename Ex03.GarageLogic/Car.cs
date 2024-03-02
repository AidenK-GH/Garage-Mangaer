using System.Collections.Generic;
using System.Security.Policy;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        // ---------------------- Values ----------------------
        public CarColor Color; // [Blue, White, Red, Yellow]
        public int NumberOfDoors; // 2, 3, 4, 5

        // ---------------------- BUILDER ----------------------
        internal Car(string i_LicenseNumber, char i_FuelOrElectric, int NumberOfWheels, float MaxAirPressure, TypeOfFuel GasType, float MaxAmountOfEnergy)
        : base(i_LicenseNumber, NumberOfWheels, MaxAirPressure, GasType, MaxAmountOfEnergy)
        {
            this.LicenseNumber = i_LicenseNumber;

            // CarQuestions.Add(); // Blue, White, Red, Yellow
            Questions = new List<UniqueQuestion>(); //{ "what color is your car? choose 1-blue 2-White 3-Red 4-Yellow:",1,5 };

            Questions.Add(new UniqueQuestion("what color is your car? choose 1-blue 2-White 3-Red 4-Yellow:", 1, 4, 1));
            Questions.Add(new UniqueQuestion("how many doors does the car have? 2,3,4,5", 2, 5, 1));
            uniqinformation = new Dictionary<string, string>();
            //uniqinformation.Add("CarColor", Color.ToString());
            //uniqinformation.Add("number of doors", "5");

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
        // ------------------- COLOR -------------------
        public void SetCarColore(string whatColor)
        {
            switch (whatColor)
            {
                case "1":
                    Color = CarColor.Blue;
                    break;
                case "2":
                    Color = CarColor.White;
                    break;
                case "3":
                    Color = CarColor.Red;
                    break;
                case "4":
                    Color = CarColor.Yellow;
                    break;
            }
            uniqinformation.Add("Car Color: ", Color.ToString());
        }

        // ------------------- DOOR -------------------
        public void SetCarNumberOfDoors(string whatDoor)
        {
            switch (whatDoor)
            {
                case "2":
                    NumberOfDoors = 2;
                    break;
                case "3":
                    NumberOfDoors = 3;
                    break;
                case "4":
                    NumberOfDoors = 4;
                    break;
                case "5":
                    NumberOfDoors = 5;
                    break;
            }
            uniqinformation.Add("Number Of Doors:", NumberOfDoors.ToString());
        }

        public List<UniqueQuestion> getListOfQuistion()
        {
            return Questions;
        }

    }
}