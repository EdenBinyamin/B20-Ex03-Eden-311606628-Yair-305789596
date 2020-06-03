﻿using System;
using System.Collections.Generic;


namespace B20_Ex03_Eden_311606628_Yair_305789596
{
    public class Garage
    {
        private Dictionary<string, VehicleInRepair> m_VehiclesInGarage;

        public Garage()
        {
            m_VehiclesInGarage = new Dictionary<string, VehicleInRepair>();
        }

        public bool tryAddingNewVehicleToGarage(string i_OwnerName, string i_PhoneNumberOfOwner,
            List<string> i_DataMemory, KnownVehicleTypes.eVehicleType i_VehicleType)
        {
            bool res = true;
            if (!isLicenseNumberAlrdyExists(i_DataMemory[(int)KnownVehicleTypes.eDataType.LicencePlate]))
            {
                m_VehiclesInGarage.Add(i_DataMemory[(int)KnownVehicleTypes.eDataType.LicencePlate], new VehicleInRepair(i_OwnerName, i_PhoneNumberOfOwner,
                                                i_DataMemory, i_VehicleType));
            }
            else
            {
                changeVehicleConditionBackToInRepair(m_VehiclesInGarage[i_DataMemory[(int)KnownVehicleTypes.eDataType.LicenceType]].Vehicle.LicensePlate);
                res = false;
            }
            return res;
        }

        public void changeVehicleConditionBackToInRepair(string licenseNumber)
        {
            m_VehiclesInGarage[licenseNumber].Condition = VehicleInRepair.VehicleCondition.inRepair;
        }

        public bool isLicenseNumberAlrdyExists(string i_LicenseNumber)
        {
            return m_VehiclesInGarage.ContainsKey(i_LicenseNumber);
        }
        
        public List<string> licenseNumbersByConditions(VehicleInRepair.VehicleCondition i_Condition)
        {
            List<string> licenseNumbers = new List<string>();
            foreach(KeyValuePair<string, VehicleInRepair> vehicle in m_VehiclesInGarage)
            {
                if (vehicle.Value.Condition == i_Condition)
                {
                    licenseNumbers.Add(vehicle.Key);
                }
            }
            return licenseNumbers;
        }

        public void changesVehicleCondition(string licenseNumber, VehicleInRepair.VehicleCondition i_Condition)
        {
            if(m_VehiclesInGarage[licenseNumber].Condition == i_Condition)
            {
                throw new ArgumentException("Vehicle is allready in the garage.");
            }
            else
            {
                m_VehiclesInGarage[licenseNumber].Condition = i_Condition;
            }
        }

        public void fillAirInWheels(string licenseNumber)
        {
            m_VehiclesInGarage[licenseNumber].Vehicle.fillAirInWheels();
        }

        public void fuelVehicle(string i_LicenseNumber, RegularEnergyType.FuelType i_FuelType,
            float i_AmountToFuel)
        {
            RegularEnergyType regularEnergy = m_VehiclesInGarage[i_LicenseNumber].Vehicle.Energy as RegularEnergyType;

            if (regularEnergy != null && regularEnergy.m_FuleType == i_FuelType)
            {
                regularEnergy.fuel(i_AmountToFuel);
            }
            else
            {
                throw new ArgumentException("Wrong type of fuel for fueling");
            }
            
        }

        public void chargeVehicle(string i_LicenseNumber, float minutesToCharge)
        {
            ElectricEnergyType electricType = m_VehiclesInGarage[i_LicenseNumber].Vehicle.Energy as ElectricEnergyType;
            if (electricType != null) 
            {
                electricType.batteryCharging(minutesToHours(minutesToCharge));
            }
        }

        private float minutesToHours(float i_Minutes)
        {
            return i_Minutes / 60 + i_Minutes % 60 / 60;
        }

        public Dictionary<string, VehicleInRepair> VehiclesInRepair
        {
            get
            {
                return m_VehiclesInGarage;
            }
        }

        public VehicleInRepair getVehicleByLicenseNumber (string i_LicenseNumber)
        {
            return m_VehiclesInGarage[i_LicenseNumber];
        }

    }
}
