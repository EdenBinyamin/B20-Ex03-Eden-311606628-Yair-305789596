using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B20_Ex03_Eden_311606628_Yair_305789596
{
    class Motorcycle : Vehicle
    {
        internal enum licenseType
        {
            A,
            A1,
            AA,
            B
        }
        internal licenseType m_LicenseType;
        private int m_EngineCapacity;
        internal Motorcycle(string i_Model, string i_LicensePlate, 
            licenseType i_LceinseType, 
            int i_EngineCapacity, string i_Manufacturer)
        {
            m_Model = i_Model;
            m_LicensePlate = i_LicensePlate;
            m_Wheels = new Wheel[2];
            m_Wheels[0] = new Wheel(i_Manufacturer, 30);
            m_Wheels[1] = new Wheel(i_Manufacturer, 30);
            m_LicenseType = i_LceinseType;
            m_EngineCapacity = i_EngineCapacity;
        }
    }
}
