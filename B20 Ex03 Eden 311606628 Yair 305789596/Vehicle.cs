using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B20_Ex03_Eden_311606628_Yair_305789596
{
    internal class Vehicle
    {
        internal enum WheelData
        {
            ManufacturerName,
            CurrentAirPressure,
            MaxAirPressure,
            NumOfWheels
        }
        internal struct Wheel
        {
            internal string m_ManufacturerName;
            internal float m_CurrentAirPressure;
            internal float m_MaxAirPressure;
            private void fillAirInWheels()
            {

            }
        }
        private string m_Model;
        private string m_LicensePlate;
        private float m_PercentageOfEnergyRemaining;
        private Wheel[] m_Wheels;
        private EnergyType m_EnergyType;
        internal Vehicle(string i_Model, string i_LicensePlate, float i_Percentage, Dictionary<WheelData,string> i_Wheel, EnergyType i_EnergyType)
        {
            m_Model = i_Model;
            m_LicensePlate = i_LicensePlate;
            m_PercentageOfEnergyRemaining = i_Percentage;
            int numOfWheels = int.Parse(i_Wheel[WheelData.NumOfWheels]);
            m_Wheels = Wheels(i_Wheel);
            m_EnergyType = i_EnergyType;
        }
        private Wheel[] Wheels(Dictionary<WheelData,string> i_Wheel)
        {
            int numOfWheels = int.Parse(i_Wheel[WheelData.NumOfWheels]);
            Wheel[] Wheels = new Wheel[numOfWheels];
            for(int i = 0;i<numOfWheels;i++)
            {
                Wheels[i].m_ManufacturerName = i_Wheel[WheelData.ManufacturerName];
                Wheels[i].m_MaxAirPressure = float.Parse(i_Wheel[WheelData.MaxAirPressure]);
                Wheels[i].m_CurrentAirPressure = float.Parse(i_Wheel[WheelData.CurrentAirPressure]);
            }
            return Wheels;
        }
        public string LicensePlate
        {
            get
            {
                return m_LicensePlate;
            }
            set
            {
                m_LicensePlate = value;
            }
        }
    }
}
