using System;

namespace B20_Ex03_Eden_311606628_Yair_305789596
{
    public class ElectricEnergyType : EnergyType
    {
        internal readonly float r_FullBatteryInHours;
        internal float m_HourseLeftForEndingBattery;

        internal ElectricEnergyType(float i_HoursLeftInBattery, float i_FullBatteryInHours)
        {
            if(i_HoursLeftInBattery > i_FullBatteryInHours)
            {
                throw new ValueOutOfRangeException(0, i_FullBatteryInHours, "Hours left in battery are bigger then maximum hours in battery");
            }
            else
            {
                m_HourseLeftForEndingBattery = i_HoursLeftInBattery;
                r_FullBatteryInHours = i_FullBatteryInHours;
            }
        }

        public override float CurrentEneregy
        {
            get
            {
                return m_HourseLeftForEndingBattery;
            }
        }

        public override float MaxEnergy
        {
            get
            {
                return r_FullBatteryInHours;
            }
        }

        internal void batteryCharging(float i_HoursToCharge)
        {
            if(i_HoursToCharge + m_HourseLeftForEndingBattery > r_FullBatteryInHours)
            {
                throw new ValueOutOfRangeException(0, r_FullBatteryInHours - m_HourseLeftForEndingBattery, "You cannot charge your battery more than its maxumim");
            }
            else
            {
                m_HourseLeftForEndingBattery += i_HoursToCharge;
            }
        }

        public override string ToString()
        {
            string electricEnergyTypeDetails = "Full battery in hours: " + r_FullBatteryInHours.ToString() + System.Environment.NewLine;
            electricEnergyTypeDetails += "Hours left in battery: " + m_HourseLeftForEndingBattery.ToString() + System.Environment.NewLine;
            return electricEnergyTypeDetails;
        }
    }
}
