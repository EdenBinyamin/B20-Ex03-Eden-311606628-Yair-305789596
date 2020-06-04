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
                changeVehicleConditionBackToInRepair(m_VehiclesInGarage[i_DataMemory[(int)KnownVehicleTypes.eDataType.LicencePlate]].Vehicle.LicensePlate);
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
            bool res= m_VehiclesInGarage[licenseNumber].Vehicle.fillAirInWheels();
            if(!res)
            {
                throw new ArgumentException("The Wheels Already fill to the Maximum");
            }
        }

        public void fuelVehicle(string i_LicenseNumber, string i_FuelType, string i_AmountToFuel)
        {
            RegularEnergyType vehicleEnergy = m_VehiclesInGarage[i_LicenseNumber].Vehicle.Energy as RegularEnergyType;
            RegularEnergyType.FuelType fuelType = RegularEnergyType.ParseFuelType(i_FuelType);
            float amountToFuel;
            bool res= float.TryParse(i_AmountToFuel, out amountToFuel);
            if(vehicleEnergy == null)
            {
                throw new ArgumentException("The vehicle isn't using Fuel");
            }
            if (res && vehicleEnergy.m_FuleType == fuelType)
            {
                vehicleEnergy.fuel(amountToFuel);
            }
            else
            {
                throw new ArgumentException("Wrong type of fuel for fueling");
            }
            
        }

        public void chargeVehicle(string i_LicenseNumber, string i_MinutesToCharge)
        {
            ElectricEnergyType electricType = m_VehiclesInGarage[i_LicenseNumber].Vehicle.Energy as ElectricEnergyType;
            float minToRechare = float.Parse(i_MinutesToCharge);
            if (electricType != null) 
            {
                electricType.batteryCharging(minutesToHours(minToRechare));
            }
            else
            {
                throw new ArgumentException("The Vehicle number {0} hasn't Electric Energy", i_LicenseNumber);
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
