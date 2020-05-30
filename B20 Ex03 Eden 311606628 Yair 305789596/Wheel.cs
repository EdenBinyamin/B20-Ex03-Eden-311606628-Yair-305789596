using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B20_Ex03_Eden_311606628_Yair_305789596
{
    class Wheel
    {
        internal string m_ManufacturerName;
        internal float m_CurrentAirPressure;
        internal float m_MaxAirPressure;
        private void fillAirInWheels()
        {

        }
        internal Wheel(string i_ManuFacturer, float i_MaxAirPressure)
        {
            m_ManufacturerName = i_ManuFacturer;
            m_MaxAirPressure = i_MaxAirPressure;
        }
        
    }
}
