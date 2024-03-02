using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    // ValueOutOfRangeException -- throw when the input is invalid on a range level, like input > maxAirPressure
    public class ValueOutOfRangeException : Exception
    {
        public float MaxValue { get; }
        public float MinValue { get; }

        public ValueOutOfRangeException(float minValue, float maxValue)
            : base($"Value is out of range. Allowed range: [{minValue}, {maxValue}]")
        {
            MinValue = minValue;
            MaxValue = maxValue;
        }

    }

}