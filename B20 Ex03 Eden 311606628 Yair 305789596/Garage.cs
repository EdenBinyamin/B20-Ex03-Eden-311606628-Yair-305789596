using System;
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

        internal void addingNewVehicleToGarage(string i_OwnerName, string i_PhoneNumberOfOwner,
            Dictionary<KnownVehicleTypes.eDataType, string> i_DataMemory, Dictionary<Vehicle.WheelData, string> i_Wheel,
            KnownVehicleTypes.eVehicleType i_VehicleType, EnergyType i_EnergyType)
        {
            m_VehiclesInGarage.Add(i_DataMemory[KnownVehicleTypes.eDataType.LicencePlate], new VehicleInRepair(i_OwnerName, i_PhoneNumberOfOwner,
                                            i_DataMemory, i_Wheel, i_VehicleType, i_EnergyType));
        }
        public bool isLicenseNumberAlrdyExists(string i_LicenseNumber)
        {
            bool res = false;
            if(m_VehiclesInGarage.ContainsKey(i_LicenseNumber))
            {
                res = true;
                m_VehiclesInGarage[i_LicenseNumber].Condition = VehicleInRepair.VehicleCondition.inRepair;
            }
            return res;
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
            m_VehiclesInGarage[licenseNumber].Condition = i_Condition;
        }

        public void fillAirInWheels(string licenseNumber)
        {
            m_VehiclesInGarage[licenseNumber].Vehicle.fillAirInWheels();
        }

        public void fuelVehicle(string i_LicenseNumber, RegularEnergyType.FuelType i_FuelType,
            float i_AmountToFuel)
        {
            RegularEnergyType regularEnergy = m_VehiclesInGarage[i_LicenseNumber].Vehicle.Energy as RegularEnergyType;
            if (regularEnergy != null)
            {
                regularEnergy.fuel(i_AmountToFuel);
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
