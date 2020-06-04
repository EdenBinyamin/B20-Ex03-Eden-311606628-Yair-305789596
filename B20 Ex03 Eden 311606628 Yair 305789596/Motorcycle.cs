using System;
using System.Collections.Generic;

namespace B20_Ex03_Eden_311606628_Yair_305789596
{
    public class Motorcycle : Vehicle
    {
        public enum licenseType
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
            Dictionary<Vehicle.WheelData, string> i_Wheel,
            EnergyType i_EnergyType) : base(i_Model, i_LicensePlate, 2,
                i_Wheel, i_EnergyType)
        {
            m_LicenseType = i_LicenseType;
            m_EngineCapacity = i_EngineCapacity;
        }

        public static licenseType LicenseTypeParse(string licenseType)
        {
            licenseType type;
            if(licenseType == "A")
            {
                type = Motorcycle.licenseType.A;
            }
            else if(licenseType == "A1")
            {
                type = Motorcycle.licenseType.A1;
            }
            else if(licenseType == "AA")
            {
                type = Motorcycle.licenseType.AA;
            }
            else if(licenseType == "B")
            {
                type = Motorcycle.licenseType.B;
            }
            else
            {
                throw new ArgumentException("Wrong License Type");
            }
            return type;
        }
        public override string ToString()
        {
            string motorcycleDetials = base.ToString();
            motorcycleDetials += "License type: " + m_LicenseType.ToString() + System.Environment.NewLine;
            motorcycleDetials += "Engine capacity: " + m_EngineCapacity.ToString() + System.Environment.NewLine;
            return motorcycleDetials;
        }
    }
}
