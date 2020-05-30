using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B20_Ex03_Eden_311606628_Yair_305789596
{
    class Car : Vehicle
    { 
        internal enum Color
        {
            Red,
            White,
            Black,
            Silver
        }
        internal Color m_Color;
        internal int m_NumOfDoors;

        internal Car(string i_Model, string i_LicensePlate, 
            Color i_Color, int i_NumOfDoors, string i_ManuFacturer)
        {
            m_Model = i_Model;
            m_LicensePlate = i_LicensePlate;
            m_Color = i_Color;
            m_NumOfDoors = i_NumOfDoors;
            m_Wheels = new Wheel[4];
            for (int i = 0; i < 4; i++) 
            {
                m_Wheels[i] = new Wheel(i_ManuFacturer, 32);
            }
        }
    }
}
