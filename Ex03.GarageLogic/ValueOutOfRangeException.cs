using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    // ValueOutOfRangeException -- throw when the input is invalid on a range level, like input > maxAirPressure
    public class ValueOutOfRangeException : Exception
    {
        public float m_MaxValue { get; }
        public float m_MinValue { get; }

        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue)
            : base($"Value is out of range. Allowed range: [{i_MinValue}, {i_MaxValue}]")
        {
            m_MinValue = i_MinValue;
            m_MaxValue = i_MaxValue;
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