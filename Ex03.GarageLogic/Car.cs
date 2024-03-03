using System.Collections.Generic;
using System.Security.Policy;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        // ---------------------- Values ----------------------
        public CarColor m_Color; // [Blue, White, Red, Yellow]
        public int m_NumberOfDoors; // 2, 3, 4, 5

        // ---------------------- BUILDER ----------------------
        internal Car(string i_LicenseNumber, char i_FuelOrElectric, int i_NumberOfWheels, float i_MaxAirPressure, TypeOfFuel i_GasType, float i_MaxAmountOfEnergy)
        : base(i_LicenseNumber, i_NumberOfWheels, i_MaxAirPressure, i_GasType, i_MaxAmountOfEnergy)
        {
            this.m_LicenseNumber = i_LicenseNumber;

            // CarQuestions.Add(); // Blue, White, Red, Yellow
            m_Questions = new List<UniqueQuestion>(); //{ "what color is your car? choose 1-blue 2-White 3-Red 4-Yellow:",1,5 };
            m_Questions.Add(new UniqueQuestion("what color is your car? choose 1-blue 2-White 3-Red 4-Yellow:", 1, 4, 1));
            m_Questions.Add(new UniqueQuestion("how many doors does the car have? 2,3,4,5", 2, 5, 1));
            m_UniqueInformation = new Dictionary<string, string>();
            
            if (i_FuelOrElectric == 'f')
            {
                m_FuelInformation = new FuelTypeVehicle(i_GasType, i_MaxAmountOfEnergy);
                m_TypeOfEnergy = "gaselin";
                m_ElectricInformation = null;
            }
            else
            {
                m_FuelInformation = null;
                m_ElectricInformation = new ElectricTypeVehicle(i_MaxAmountOfEnergy);
                m_TypeOfEnergy = "electricity";
            }
        }

        // ----------------------------------------------------------------------------------
        // ------------------- COLOR -------------------
        public void SetCarColore(string i_WhatColor)
        {
            switch (i_WhatColor)
            {
                case "1":
                    m_Color = CarColor.Blue;
                    break;
                case "2":
                    m_Color = CarColor.White;
                    break;
                case "3":
                    m_Color = CarColor.Red;
                    break;
                case "4":
                    m_Color = CarColor.Yellow;
                    break;
            }
            m_UniqueInformation.Add("Car Color: ", m_Color.ToString());
        }

        // ------------------- DOOR -------------------
        public void SetCarNumberOfDoors(string i_WhatDoor)
        {
            switch (i_WhatDoor)
            {
                case "2":
                    m_NumberOfDoors = 2;
                    break;
                case "3":
                    m_NumberOfDoors = 3;
                    break;
                case "4":
                    m_NumberOfDoors = 4;
                    break;
                case "5":
                    m_NumberOfDoors = 5;
                    break;
            }
            m_UniqueInformation.Add("Number Of Doors:", m_NumberOfDoors.ToString());
        }

        public List<UniqueQuestion> getListOfQuistion()
        {
            return m_Questions;
        }

    }
}