using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        public float m_CargoVolume;
        public bool m_IsTransportingHazardousMaterials;

        // ---------------------- v BUILDER v ----------------------
        internal Truck(string i_LicenseNumber, char i_FuelOrElectric, int i_NumberOfWheels, float i_MaxAirPressure, TypeOfFuel i_GasType, float i_MaxAmountOfEnergy)
        : base(i_LicenseNumber, i_NumberOfWheels, i_MaxAirPressure, i_GasType, i_MaxAmountOfEnergy)
        {
            this.m_LicenseNumber = i_LicenseNumber;

            m_Questions = new List<UniqueQuestion>();
            m_Questions.Add(new UniqueQuestion("does you truck Transporting Hazardous Materials? choose 1-yes 2-no:", 1, 2, 1));
            m_Questions.Add(new UniqueQuestion("what is the cargo Volume?", 0, Convert.ToInt32(float.PositiveInfinity), 2));
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
        // -------------------------------- v SET v ---------------------------------------------------------------------
        // ------------------- m_IsTransportingHazardousMaterials -------------------
        public void SetIsTransportingHazardousMaterials(string i_WhatIsTransportingHazardousMaterials)
        {
            string answerString = "false";
            switch (i_WhatIsTransportingHazardousMaterials)
            {
                case "1":
                    m_IsTransportingHazardousMaterials = true;
                    answerString = "True";
                    break;
                case "2":
                    m_IsTransportingHazardousMaterials = false;
                    answerString = "False";
                    break;
            }
            m_UniqueInformation.Add("Is Transporting Hazardous Materials: ", answerString);
        }
        // ------------------- cargoVolume -------------------
        public void SetCargoVolume(string i_WhatCargoVolume)
        {
            float CargoVolume;
            float.TryParse(i_WhatCargoVolume, out CargoVolume);
            CargoVolume = CargoVolume;
            m_UniqueInformation.Add("Cargo Volume: {0} ", i_WhatCargoVolume);
        }
        // ------------------------------------- v GET v ----------------------------------------------------------------
        public List<UniqueQuestion> getListOfQuistion()
        {
            return m_Questions;
        }
    }
}