using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ElectricTypeVehicle
    {
        public float m_CorrentAmountOfBattry; // in hours
        public float m_MaxAmountOfBattry; // in hours

        public ElectricTypeVehicle(float i_MaxAmountOfBattry)
        {
            this.m_MaxAmountOfBattry = i_MaxAmountOfBattry;
        }

        public void CharageBattryToMax()
        {
            m_CorrentAmountOfBattry = m_MaxAmountOfBattry;
        }

        public void CharageBattryWithAdditionalMin(float i_AdditionalEnergy)
        {
            // note i_AdditionalEnergy is in min, need to change to hours
            float additionalEnergyInHours = i_AdditionalEnergy / 60f; // change to hours

            // check if i_AdditionalEnergy is too much
            if (additionalEnergyInHours + m_CorrentAmountOfBattry > m_MaxAmountOfBattry)
            {
                throw new ValueOutOfRangeException(0, m_MaxAmountOfBattry*60 - m_CorrentAmountOfBattry*60);//("Exsids the maximum battry limit.");
            }

            m_CorrentAmountOfBattry += additionalEnergyInHours;
        }

        // SET m_CorrentAmountOfBattry
        public void SetCorrentAmountOfBattry(float i_CorrentAmountOfBattery)
        {
            if (i_CorrentAmountOfBattery > m_MaxAmountOfBattry)
            {
                throw new ValueOutOfRangeException(0, m_MaxAmountOfBattry); //Exception("Exsids the maximum battry limit, can't set.");
            }
            this.m_CorrentAmountOfBattry = i_CorrentAmountOfBattery;
        }


    }
}