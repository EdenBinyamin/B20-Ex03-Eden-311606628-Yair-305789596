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

        internal ElectricEnergyType(float i_HoursLeftInBattery, float i_FullBatteryInHours)
        {
            if(i_HoursLeftInBattery > i_FullBatteryInHours)
            {
                throw new ValueOutOfRangeException(0, i_FullBatteryInHours, "Hours left in battery are bigger then maximum hours in battery");
            }
            else
            {
                m_HourseLeftForEndingBattery = i_HoursLeftInBattery;
                m_FullBatteryInHours = i_FullBatteryInHours;
            }
        }

        internal void batteryCharging(float i_HoursToCharge)
        {
            if(i_HoursToCharge + m_HourseLeftForEndingBattery > m_FullBatteryInHours)
            {
                throw new ValueOutOfRangeException(0, m_FullBatteryInHours - m_HourseLeftForEndingBattery, "You cannot charge your battery more than its maxumim");
            }
            else
            {
                m_HourseLeftForEndingBattery += i_HoursToCharge;
            }
        }

        public override float currentEneregy
        {
            get
            {
                return m_HourseLeftForEndingBattery;
            }
        }

        public override float maxEnergy
        {
            get
            {
                return m_FullBatteryInHours;
            }
        }

        public override string ToString()
        {
            string electricEnergyTypeDetails = "Full battery in hours: " + m_FullBatteryInHours.ToString() + System.Environment.NewLine;
            electricEnergyTypeDetails += "Hours left in battery: " + m_HourseLeftForEndingBattery.ToString() + System.Environment.NewLine;
            return electricEnergyTypeDetails;
        }
    }
}
