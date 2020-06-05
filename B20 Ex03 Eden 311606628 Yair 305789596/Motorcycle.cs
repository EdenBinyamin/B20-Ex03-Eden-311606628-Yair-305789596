using System;
using System.Collections.Generic;

namespace B20_Ex03_Eden_311606628_Yair_305789596
{
    public class Motorcycle : Vehicle
    {
        public enum eLicenseType
        {
            A,
            A1,
            AA,
            B
        }

        private readonly int r_EngineCapacity;
        private eLicenseType m_LicenseType;

        internal Motorcycle(eLicenseType i_LicenseType, int i_EngineCapacity, string i_Model, string i_LicensePlate, Dictionary<Vehicle.WheelData, string> i_Wheel, EnergyType i_EnergyType) : base(i_Model, i_LicensePlate, 2, i_Wheel, i_EnergyType)
        {
            m_LicenseType = i_LicenseType;
            r_EngineCapacity = i_EngineCapacity;
        }

        internal static eLicenseType parseLicenseType(string i_LicenseType)
        {
            eLicenseType licenseType;
            i_LicenseType = i_LicenseType.Trim().ToUpper();
            switch(i_LicenseType)
            {
                case "A":
                    licenseType = Motorcycle.eLicenseType.A;
                    break;
                case "A1":
                    licenseType = Motorcycle.eLicenseType.A1;
                    break;
                case "AA":
                    licenseType = Motorcycle.eLicenseType.AA;
                    break;
                case "B":
                    licenseType = Motorcycle.eLicenseType.B;
                    break;
                default:
                    throw new ArgumentException("Known License Type");
            }

            return licenseType;
        }

        public override string ToString()
        {
            string motorcycleDetials = base.ToString();
            motorcycleDetials += "License type: " + m_LicenseType.ToString() + System.Environment.NewLine;
            motorcycleDetials += "Engine capacity: " + r_EngineCapacity.ToString() + System.Environment.NewLine;
            return motorcycleDetials;
        }
    }
}
