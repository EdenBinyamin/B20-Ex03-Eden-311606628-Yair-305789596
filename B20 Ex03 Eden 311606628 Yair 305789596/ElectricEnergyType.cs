using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B20_Ex03_Eden_311606628_Yair_305789596
{
    public class ElectricEnergyType : EnergyType
    {
        internal float m_HourseLeftForEndingBattery;
        internal float m_FullBatteryInHours;
        internal ElectricEnergyType(float i_HoursLeftInBattery, float i_FullBatteryInHourse)
        {
            if(i_HoursLeftInBattery > i_FullBatteryInHourse)
            {
                throw new ArgumentException("There is more hourse left in the battery than its capability");
            }
            else
            {
                m_HourseLeftForEndingBattery = i_HoursLeftInBattery;
                m_FullBatteryInHours = i_FullBatteryInHourse;
            }
        }
        internal void batteryCharging (float i_HoursToCharge)
        {
            if(i_HoursToCharge + m_HourseLeftForEndingBattery > m_FullBatteryInHours)
            {
                throw new ValueOutOfRangeException(0, m_FullBatteryInHours - m_HourseLeftForEndingBattery);
            }
            else
            {
                m_HourseLeftForEndingBattery += i_HoursToCharge;
            }
        }
    }
}
