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
        public string m_ModelName;
        public string m_LicenseNumber;
        public float m_PercentageOfEnergyRemaining;
        public int m_NumberOfWheels;
        public Wheel[] m_CollectionOfWheels;

        // garage info
        public string m_OwnersName;
        public string m_OwnersPhoneNumber;
        public ConditionInGarage m_Condition; //[inRepair, fixed, paid, none]

        // energy - the one the vehicle DOESNT use will be null
        public FuelTypeVehicle m_FuelInformation;
        public ElectricTypeVehicle m_ElectricInformation;
        public string m_TypeOfEnergy;

        // uniqin formation
        public Dictionary<string, string> m_UniqueInformation;
        public List<UniqueQuestion> m_Questions;

        // ----------------------- BUILDER -----------------------------------------

        public Vehicle(string i_ThisLicenseNumber, int i_ThisnumberOfWheels, float i_MaxAirPressure, TypeOfFuel i_GasTypey, float i_MaxAmountOfEnergy)
        {
            m_LicenseNumber = i_ThisLicenseNumber;

            m_NumberOfWheels = i_ThisnumberOfWheels;
            m_CollectionOfWheels = new Wheel[i_ThisnumberOfWheels];
            for (int i = 0; i < m_CollectionOfWheels.Length; i++)
            {
                m_CollectionOfWheels[i] = new Wheel(i_MaxAirPressure);
            }

            m_Condition = ConditionInGarage.InRepair;
        }

        // -------------------------- Generate Wheels --------------------------------------

        public void GenerateWheels(string[] i_Menufactursnames, float[] i_CurrentAirPressurs, float i_MaxCarWheelsAirPressure, int i_NumberOfWheels)
        {
            for (int i = 0; i < i_NumberOfWheels; i++)
            {
                m_CollectionOfWheels[i].m_CurrentAirPressure = i_CurrentAirPressurs[i];
                m_CollectionOfWheels[i].m_MaxAirPressure = i_MaxCarWheelsAirPressure;
                m_CollectionOfWheels[i].m_ManufacturerName = i_Menufactursnames[i];
            }
        }

        public void GenerateWheelsWithoutMaxAirPressure(string[] i_Menufactursnames, float[] i_CurrentAirPressurs, int I_NumberOfWheels)
        {
            for (int i = 0; i < I_NumberOfWheels; i++)
            {
                m_CollectionOfWheels[i].m_CurrentAirPressure = i_CurrentAirPressurs[i];
                m_CollectionOfWheels[i].m_ManufacturerName = i_Menufactursnames[i];
            }
        }

        // ----------------------------------------------------------------

        public void FillWheelsToMax()
        {
            foreach (Wheel wheel in m_CollectionOfWheels)
            {
                wheel.InflatingTheWheelToMax();
            }
        }

        public float GetMaxAirPressure()
        {
            return m_CollectionOfWheels[0].m_MaxAirPressure;
        }

        // ----------------------------------------------------------------
        public Dictionary<string, string> GetVehucleStats()
        {
            Dictionary<string, string> VehicleStats = new Dictionary<string, string>();

            VehicleStats.Add("ModelName", m_ModelName);
            VehicleStats.Add("LicenseNumber", m_LicenseNumber);
            VehicleStats.Add("condition", m_Condition.ToString());
            VehicleStats.Add("ownersName", m_OwnersName);
            // need more info

            return VehicleStats;
        }

        // 1
        public void SetAmountOfEnergy(float i_AmountOfEnergy)
        {
            if (m_FuelInformation == null)
            {
                
                m_ElectricInformation.SetCorrentAmountOfBattry(i_AmountOfEnergy);
            }
            else
            {
                m_FuelInformation.SetFuel(i_AmountOfEnergy);
            }
        }

        // 5 6
        public void FillEnergy(float i_AmountOfEnergy)
        {
            if (m_FuelInformation == null)
            {

                m_ElectricInformation.CharageBattryWithAdditionalMin(i_AmountOfEnergy);
            }
            else
            {
                m_FuelInformation.FillFuel(i_AmountOfEnergy);
            }
        }

        public string getAmounOfEnergy()
        {
            string AmountOfEnergyNow = "error";
            if(m_FuelInformation == null)
            {
                AmountOfEnergyNow = m_ElectricInformation.m_CorrentAmountOfBattry + "hours";
            }
            else
            {
                AmountOfEnergyNow = m_FuelInformation.m_CorrentAmountOfFuel + " liters";
            }
            return AmountOfEnergyNow;
        }

    }
}