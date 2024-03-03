using System;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        public string manufacturerName;
        public float CurrentAirPressure;
        public float MaxAirPressure;

        //internal Wheel(string manufacturerName, float currentAirPressure, float maxAirPressure)
        //{
        //    this.manufacturerName = manufacturerName;
        //    CurrentAirPressure = currentAirPressure;
        //    MaxAirPressure = maxAirPressure;
        //}

        // --------- builder -------------------------------------
        internal Wheel(float maxAirPressure)
        {
            MaxAirPressure = maxAirPressure;
        }

        // ------------ add air Pressure to wheels ---------------------------
        public void InflatingTheWheel(int AmountOfAir)
        {
            if (MaxAirPressure < AmountOfAir + CurrentAirPressure)
            {
                throw new ValueOutOfRangeException(0, MaxAirPressure);
            }
            else
            {
                CurrentAirPressure = AmountOfAir + CurrentAirPressure;
            }
        }

        public void InflatingTheWheelToMax()
        {
            float howMuchAirWheelNeeds = MaxAirPressure - CurrentAirPressure;
            CurrentAirPressure = howMuchAirWheelNeeds + CurrentAirPressure;
        }

        //
    }
}