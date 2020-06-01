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
        internal Motorcycle(licenseType i_LicenseType, int i_EngineCapacity, 
            int i_NumOfDoors, string i_Model, string i_LicensePlate,
            float i_Percentage, Dictionary<Vehicle.WheelData, string> i_Wheel, 
            EnergyType i_EnergyType) : base(i_Model, i_LicensePlate, i_Percentage, 
                i_Wheel, i_EnergyType)
        {
            m_LicensePlate = i_LicensePlate;
            m_EngineCapacity = i_EngineCapacity;
        }
    }
}
