using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {
        public MotorcycleLicenseType m_MotorcycleLicenseType; // [A1, A2, AB, B2]
        public int m_EngineVolumeInCC;
        
        // ---------------------- BUILDER ----------------------
        internal Motorcycle(string i_LicenseNumber, char i_FuelOrElectric, int i_NumberOfWheels, float i_MaxAirPressure, TypeOfFuel i_GasType, float i_MaxAmountOfEnergy)
        : base(i_LicenseNumber, i_NumberOfWheels, i_MaxAirPressure, i_GasType, i_MaxAmountOfEnergy)
        {
            this.m_LicenseNumber = i_LicenseNumber;

            m_Questions = new List<UniqueQuestion>();

            m_Questions.Add(new UniqueQuestion("what License Type do you have? choose 1-A1 2-A2 3-AB 4-B2:", 1, 4, 1));
            m_Questions.Add(new UniqueQuestion("what is the Engine Volume In CC?", 0, 1000000000, 2));
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
        // ------------------- Motorcycle License Type -------------------
        public void SetMotorcycleLicenseType(string i_WhatMotorcycleLicenseType)
        {
            switch (i_WhatMotorcycleLicenseType)
            {
                case "1":
                    m_MotorcycleLicenseType = MotorcycleLicenseType.A1;
                    break;
                case "2":
                    m_MotorcycleLicenseType = MotorcycleLicenseType.A2;
                    break;
                case "3":
                    m_MotorcycleLicenseType = MotorcycleLicenseType.AB;
                    break;
                case "4":
                    m_MotorcycleLicenseType = MotorcycleLicenseType.B2;
                    break;
            }
            m_UniqueInformation.Add("Motorcycle License Type: ", m_MotorcycleLicenseType.ToString());
        }
        // ------------------- m_EngineVolumeInCC -------------------
        public void SetEngineVolumeInCC(string i_whatEngineVolumeInCC)
        {
            int EngineVolumeInCC;
            int.TryParse(i_whatEngineVolumeInCC, out EngineVolumeInCC);
            this.m_EngineVolumeInCC = EngineVolumeInCC;
            m_UniqueInformation.Add("Engine Volume In CC: ", i_whatEngineVolumeInCC);
        }
        // ----------------------------------------------------------------------------------
        public List<UniqueQuestion> getListOfQuistion()
        {
            return m_Questions;
        }
    }
}