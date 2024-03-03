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
    // Exception
    // FormatException
    //     throw when the input is invalid on a 'prising' level, like input = 'a' when it need to be a number.
    // ArgumentException
    //     throw when the input is invalid on a logic level, like entering the worng fuel type.
    // ValueOutOfRangeException
    //     throw when the input is invalid on a range level, like input > maxAirPressure

}