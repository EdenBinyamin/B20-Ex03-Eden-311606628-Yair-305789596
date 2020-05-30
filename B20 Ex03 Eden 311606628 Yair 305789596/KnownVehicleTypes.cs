using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B20_Ex03_Eden_311606628_Yair_305789596
{
    class KnownVehicleTypes
    {
        private Motorcycle Motorcycle(string i_Model, string i_LicensePlate,
            Motorcycle.licenseType i_LicenseType, int i_EngineCapacity, 
            string i_ManuFacturer, EnergyType i_EnergyType)
        {
            Motorcycle motorCycle = new Motorcycle(i_Model,i_LicensePlate, 
                i_LicenseType, i_EngineCapacity, i_ManuFacturer);
            if(i_EnergyType is RegularEnergyType)
            {
                motorCycle.m_EnergyType = new RegularEnergyType(RegularEnergyType.FuelType.Octan95, 
                                                                                             5, 7);
            }
            else if(i_EnergyType is ElectricEnergyType)
            {
                motorCycle.m_EnergyType = new ElectricEnergyType(1.2f);
            }
            return motorCycle;
        }
        private Car Car(string i_Model, string i_LicensePlate,
            Car.Color i_Color, int i_NumOfDoors, 
            string i_ManuFacturer, EnergyType i_EnergyType)
        {
            Car car = new Car(i_Model, i_LicensePlate, 
                i_Color, i_NumOfDoors, i_ManuFacturer);
            if(i_EnergyType is RegularEnergyType)
            {
                car.m_EnergyType = new RegularEnergyType(RegularEnergyType.FuelType.Octan96, 5, 60);
            }
            else if(i_EnergyType is ElectricEnergyType)
            {
                car.m_EnergyType = new ElectricEnergyType(2.1f);
            }
            return car;
        }

        private Truck Truck(string i_Model, string i_LicensePlate,
            bool i_IsHavingHazardousMeterials, float i_CargoVolume, 
            string i_ManuFactuer, EnergyType i_EnergyType)
        {
            Truck truck = new Truck(i_Model, i_LicensePlate, 
                i_IsHavingHazardousMeterials, i_CargoVolume, i_ManuFactuer);
            if(i_EnergyType is RegularEnergyType)
            {
                truck.m_EnergyType = new RegularEnergyType(RegularEnergyType.FuelType.Soler, 5, 120);
            }
            return truck;
        }
    }
}
