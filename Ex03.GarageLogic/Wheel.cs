﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        public string manufacturerName;
        public float CurrentAirPressure;
        public float MaxAirPressure;

        internal Wheel(string manufacturerName, float currentAirPressure, float maxAirPressure)
        {
            this.manufacturerName = manufacturerName;
            CurrentAirPressure = currentAirPressure;
            MaxAirPressure = maxAirPressure;
        }


        public void InflatingTheWheel(int AmountOfAir)
        {
            if (MaxAirPressure< AmountOfAir+CurrentAirPressure)
            {
                throw new ArgumentException();
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
    }
}