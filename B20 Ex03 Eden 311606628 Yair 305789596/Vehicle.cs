﻿using System;
using System.Collections.Generic;


namespace B20_Ex03_Eden_311606628_Yair_305789596
{
    public class Vehicle
    {
        public enum WheelData
        {
            ManufacturerName,
            CurrentAirPressure,
            MaxAirPressure
        }
        internal struct Wheel
        {
            private string m_ManufacturerName;
            private float m_CurrentAirPressure;
            private float m_MaxAirPressure;
            internal void fillAirInWheel(ref bool res)
            {
                if(m_CurrentAirPressure != m_MaxAirPressure)
                {
                    m_CurrentAirPressure = m_MaxAirPressure;
                    res = true;
                }
            }
            public Wheel(string i_ManurfacturerName, float i_CurrentAirPressure, float i_MaxAirPressure)
            {
                m_ManufacturerName = i_ManurfacturerName;
                if (i_CurrentAirPressure > i_MaxAirPressure)
                {
                    throw new ValueOutOfRangeException(0, i_MaxAirPressure, "Current air pressure is more then the maximum of the air pressure of the wheel can has");
                }
                m_CurrentAirPressure = i_CurrentAirPressure;
                m_MaxAirPressure = i_MaxAirPressure;
            }

            public override string ToString()
            {
                string wheelDetails = "Manufacturer of wheels: " + m_ManufacturerName + System.Environment.NewLine;
                wheelDetails += "Current air pressure  in wheels: " + m_CurrentAirPressure.ToString() + System.Environment.NewLine;
                return wheelDetails;
            }
        }
        private string m_Model;
        private string m_LicensePlate;
        private float m_PercentageOfEnergyRemaining;
        private Wheel[] m_Wheels;
        private EnergyType m_EnergyType;
        public Vehicle(string i_Model, string i_LicensePlate, int i_NumOfWheels, Dictionary<WheelData, string> i_Wheel, EnergyType i_EnergyType)
        {
            m_Model = i_Model;
            m_LicensePlate = i_LicensePlate;
            m_PercentageOfEnergyRemaining = i_EnergyType.currentEneregy * 100 / i_EnergyType.maxEnergy; 
            m_Wheels = Wheels(i_Wheel, i_NumOfWheels);
            m_EnergyType = i_EnergyType;
        }
        private Wheel[] Wheels(Dictionary<WheelData,string> i_Wheel, int i_NumOfWheels)
        {
            Wheel[] Wheels = new Wheel[i_NumOfWheels];
            string manufacturer = i_Wheel[WheelData.ManufacturerName];
            float maxAirPressure = float.Parse(i_Wheel[WheelData.MaxAirPressure]);
            float currentAirPressure = float.Parse(i_Wheel[WheelData.CurrentAirPressure]);
            for (int i = 0; i < i_NumOfWheels; i++)
            {
                Wheels[i] = new Wheel(manufacturer, currentAirPressure, maxAirPressure);
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

        public EnergyType Energy
        {
            get
            {
                return m_EnergyType;
            }
        }
        public bool fillAirInWheels()
        {
            bool succeessFillAir = false;
            foreach(Wheel wheel in m_Wheels)
            {
                wheel.fillAirInWheel(ref succeessFillAir);
            }
            return succeessFillAir;
        }

        public override string ToString()
        {
            string vehicleDetails = "Model: " + m_Model + System.Environment.NewLine;
            vehicleDetails += "License Plate: " + m_LicensePlate + System.Environment.NewLine;
            vehicleDetails += "Percentage left fuel: " + m_PercentageOfEnergyRemaining.ToString() + System.Environment.NewLine;
            vehicleDetails += m_Wheels[0].ToString(); /// לשאול את דנה
            vehicleDetails += m_EnergyType.ToString();
            return vehicleDetails;
        }
    }
}
