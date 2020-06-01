using System;
using System.Collections.Generic;

namespace B20_Ex03_Eden_311606628_Yair_305789596
{
    public class Motorcycle : Vehicle
    {
        internal enum licenseType
        {
            A,
            A1,
            AA,
            B
        }
        private licenseType m_LicenseType;
        private int m_EngineCapacity;
        internal Motorcycle(licenseType i_LicenseType, int i_EngineCapacity, 
            string i_Model, string i_LicensePlate,
            float i_Percentage, Dictionary<Vehicle.WheelData, string> i_Wheel, 
            EnergyType i_EnergyType) : base(i_Model, i_LicensePlate, i_Percentage, 2,
                i_Wheel, i_EnergyType)
        {
            m_LicenseType = i_LicenseType;
            m_EngineCapacity = i_EngineCapacity;
        }
    }
}
