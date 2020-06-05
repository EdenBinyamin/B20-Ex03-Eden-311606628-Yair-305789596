using System;
using System.Collections.Generic;

namespace B20_Ex03_Eden_311606628_Yair_305789596
{
    public class Truck : Vehicle
    {
        private bool m_IsHavingHazardousMaterials;
        private float m_CargoVolume;

        internal Truck(bool i_IsHavingHazardousMaterials, float i_CargoVolume, string i_Model, string i_LicensePlate, Dictionary<Vehicle.WheelData, string> i_Wheel, EnergyType i_EnergyType) : base(i_Model, i_LicensePlate, 16, i_Wheel, i_EnergyType)
        {
            m_IsHavingHazardousMaterials = i_IsHavingHazardousMaterials;
            m_CargoVolume = i_CargoVolume;
        }

        internal static bool parseHazardousMeterials(string i_InputStr)
        {
            i_InputStr = i_InputStr.Trim().ToUpper();
            bool res = true;
            if (i_InputStr == "TRUE" || i_InputStr == "YES")
            {
                res = true;
            }
            else if (i_InputStr == "FALSE" || i_InputStr == "NO") 
            {
                res = false;
            }
            else
            {
                throw new ArgumentException("Hazardous Meterials: Not A Vaild input");
            }

            return res;
        }

        public override string ToString()
        {
            string truckDetials = base.ToString();
            truckDetials += "Is it having hazardous materials: " + m_IsHavingHazardousMaterials.ToString() + System.Environment.NewLine;
            truckDetials += "Cargo volume: " + m_CargoVolume.ToString() + System.Environment.NewLine;
            return truckDetials;
        }
    }
}
