using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B20_Ex03_Eden_311606628_Yair_305789596
{
    class ElectricEnergyType : EnergyType
    {
        internal float m_HourseLeftForEndingBattery;
        internal float m_FullBatteryInHours;
        internal ElectricEnergyType(float i_FullBatteryInHourse)
        {
            m_FullBatteryInHours = i_FullBatteryInHourse;
        }
        internal void batteryCharging (float i_HoursToCharge)
        {

        }
    }
}
