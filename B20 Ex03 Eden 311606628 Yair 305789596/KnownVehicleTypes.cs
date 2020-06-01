using B20_Ex03_Eden_311606628_Yair_305789596;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace B20_Ex03_Eden_311606628_Yair_305789596
{
    public class KnownVehicleTypes
    {
        public enum eVehicleType
        {
            Motorcycle,
            Truck,
            Car
        }
        public enum eDataType
        {
            Model,
            LicencePlate,
            EngineCapacity,
            ManuFacturer,
            numOfDoors,
            havingHazardousMeterials,
            cargoVolume
        }

        public static Vehicle CreateVehicle(Dictionary<eDataType, string> i_DataMemory, eVehicleType i_VehicleType, EnergyType i_EnergyType)
        {
            Vehicle vehicle = null;
            string model = i_DataMemory[eDataType.Model];
            string licensePlate = i_DataMemory[eDataType.LicencePlate];
            string ManuFacturer = i_DataMemory[eDataType.ManuFacturer];
            string engineCapacity = i_DataMemory[eDataType.EngineCapacity];
            string numOfDoors = i_DataMemory[eDataType.numOfDoors];
            string isHavingHazardousMeterials = i_DataMemory[eDataType.havingHazardousMeterials];
            string cargoVolume = i_DataMemory[eDataType.cargoVolume];

            switch (i_VehicleType)
            {
                case eVehicleType.Motorcycle:
                    {
                        vehicle = new Motorcycle(model, licensePlate, int.Parse(engineCapacity), ManuFacturer);
                        if (i_EnergyType is RegularEnergyType)
                        {
                            vehicle.m_EnergyType = new RegularEnergyType(RegularEnergyType.FuelType.Octan95, 5, 7);
                        }
                        else if (i_EnergyType is ElectricEnergyType)
                        {
                            vehicle.m_EnergyType = new ElectricEnergyType(1.2f);
                        }
                        break;
                    }
                case eVehicleType.Car:
                    {
                        vehicle = new Car(model, licensePlate, color, numOfDoors, ManuFacturer);
                        if (i_EnergyType is RegularEnergyType)
                        {
                            vehicle.m_EnergyType = new RegularEnergyType(RegularEnergyType.FuelType.Octan96, 5, 60);
                        }
                        else if (i_EnergyType is ElectricEnergyType)
                        {
                            vehicle.m_EnergyType = new ElectricEnergyType(2.1f);
                        }
                        break;
                    }
                case eVehicleType.Truck:
                    {
                        vehicle = new Truck(model, licensePlate, isHavingHazardousMeterials, float.Parse(cargoVolume), ManuFacturer)
                    if (i_EnergyType is RegularEnergyType)
                        {
                            vehicle.m_EnergyType = new RegularEnergyType(RegularEnergyType.FuelType.Soler, 5, 120);
                        }
                        break;
                    }
            }
            return vehicle;
        }
    }
}



