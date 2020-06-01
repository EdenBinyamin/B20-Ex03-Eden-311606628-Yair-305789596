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

        internal Car(Color i_Color, int i_NumOfDoors, string i_Model, string i_LicensePlate,
            float i_Percentage, Dictionary<Vehicle.WheelData, string> i_Wheel, EnergyType i_EnergyType)
            : base(i_Model, i_LicensePlate, i_Percentage, i_Wheel, i_EnergyType)
        {
            m_Color = i_Color;
            m_NumOfDoors = i_NumOfDoors;
        }
    }
}
