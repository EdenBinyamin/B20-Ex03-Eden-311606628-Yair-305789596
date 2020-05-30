using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B20_Ex03_Eden_311606628_Yair_305789596
{
    class Truck : Vehicle
    {
        internal bool m_IsHavingHazardousMeterials;
        internal float m_CargoVolume;

        internal Truck(string i_Model, string i_LicensePlate, 
            bool i_IsHavingHazardousMeterials, 
            float i_CargoVolume, string i_Manufacturer)
        {
            m_Model = i_Model;
            m_LicensePlate = i_LicensePlate;
            m_IsHavingHazardousMeterials = i_IsHavingHazardousMeterials;
            m_CargoVolume = i_CargoVolume;
            m_Wheels = new Wheel[16];
            for (int i = 0; i < 16; i++) 
            {
                m_Wheels[i] = new Wheel(i_Manufacturer, 28);
            }
        }
    }
}
