using System;
using System.Collections.Generic;

namespace B20_Ex03_Eden_311606628_Yair_305789596
{
    public class ValueOutOfRangeException : Exception
    {
        float m_MaxValue;
        float m_MinValue;
        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue, string message) : base(message)
        {
            m_MinValue = i_MinValue;
            m_MaxValue = i_MaxValue;
        }

    }
}
