using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B20_Ex03_Eden_311606628_Yair_305789596
{
    class Truck : Vehicle
    {
        internal bool m_IsHavingHazardousMaterials;
        internal float m_CargoVolume;

        internal Truck(bool i_IsHavingHazardousMaterials, float i_CargoVolume, 
            int i_NumOfDoors, string i_Model, string i_LicensePlate,
            float i_Percentage, Dictionary<Vehicle.WheelData, string> i_Wheel,
            EnergyType i_EnergyType) : base(i_Model, i_LicensePlate, i_Percentage, 
                i_Wheel, i_EnergyType)
        {
            m_IsHavingHazardousMaterials = i_IsHavingHazardousMaterials;
            m_CargoVolume = i_CargoVolume;
        }
    }
}
