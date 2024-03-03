using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class FuelTypeVehicle
    {

        public TypeOfFuel m_TypeOfFuelForOurVehicle; //turn to enum [Soler ,Octan95 ,Octan96 ,Octan98]
        public UniqueQuestion m_TypesOfFuel; // [Soler ,Octan95 ,Octan96 ,Octan98]

        public float m_CorrentAmountOfFuel; // in liters
        public float m_MaxAmountOfFuel; // in liters

        public FuelTypeVehicle(TypeOfFuel i_TypeOfFuel, float i_MaxAmountOfFuel)
        {
            this.m_TypeOfFuelForOurVehicle = i_TypeOfFuel;
            this.m_MaxAmountOfFuel = i_MaxAmountOfFuel;
            m_TypesOfFuel = new UniqueQuestion("choose a fuel type: 1-Soler 2-Octan95 3-Octan96 4-Octan98", 1, 4, 1);
        }

        public void SetFuel(float i_StartingFuel)
        {
            if (i_StartingFuel > m_MaxAmountOfFuel)
            {
                throw new ValueOutOfRangeException(0, m_MaxAmountOfFuel); //Exception("too much fuel try again ");
            }
            
            m_CorrentAmountOfFuel = i_StartingFuel;
        }

        public void FillFuelToMax()
        {
            m_CorrentAmountOfFuel = m_MaxAmountOfFuel;
        }

        public void FillFuel(float i_AdditionalFual)
        {
            if (i_AdditionalFual + m_CorrentAmountOfFuel > m_MaxAmountOfFuel)
            {
                throw new ValueOutOfRangeException(0, m_MaxAmountOfFuel - m_CorrentAmountOfFuel); //Exception("too much fuel can't fill");
            }

            m_CorrentAmountOfFuel = m_CorrentAmountOfFuel + i_AdditionalFual;
        }

    }
}