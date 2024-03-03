using System;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        public string m_ManufacturerName;
        public float m_CurrentAirPressure;
        public float m_MaxAirPressure;
        // --------- builder -------------------------------------
        internal Wheel(float i_MaxAirPressure)
        {
            m_MaxAirPressure = i_MaxAirPressure;
        }
        // ------------ add air Pressure to wheels ---------------------------
        public void InflatingTheWheel(int i_AmountOfAir)
        {
            if (m_MaxAirPressure < i_AmountOfAir + m_CurrentAirPressure)
            {
                throw new ValueOutOfRangeException(0, m_MaxAirPressure);
            }
            else
            {
                m_CurrentAirPressure = i_AmountOfAir + m_CurrentAirPressure;
            }
        }

        public void InflatingTheWheelToMax()
        {
            float howMuchAirWheelNeeds = m_MaxAirPressure - m_CurrentAirPressure;
            m_CurrentAirPressure = howMuchAirWheelNeeds + m_CurrentAirPressure;
        }
    }
}