using B20_Ex03_Eden_311606628_Yair_305789596;
using System;
using System.Collections.Generic;


namespace B20_Ex03_Eden_311606628_Yair_305789596
{
    public class KnownVehicleTypes
    {
        public enum eVehicleType
        {
            Car=1,
            Motorcycle,
            Truck,
        }
        public enum eDataType
        {
            Model,
            LicencePlate,
            LicenceType,
            EngineCapacity,
            NumOfDoors,
            HavingHazardousMeterials,
            CargoVolume,
            Percentage,
            Color,
            
        }

        public static Vehicle CreateVehicle(Dictionary<eDataType, string> i_DataMemory, Dictionary<Vehicle.WheelData, string> i_Wheel, eVehicleType i_VehicleType, EnergyType.eEnergyType i_EnergyType)
        {
            Vehicle vehicle = null;
            switch (i_VehicleType)
            {
                case eVehicleType.Motorcycle:
                    vehicle = CreateMotorCycle(i_DataMemory, i_Wheel, i_EnergyType);
                    break;
                case eVehicleType.Car:
                    vehicle = CreateCar(i_DataMemory, i_Wheel, i_EnergyType);
                    break;
                case eVehicleType.Truck:
                    vehicle = CreateTruck(i_DataMemory, i_Wheel, i_EnergyType);
                    break;
            }
            return vehicle;
        }

        public static Car CreateCar(Dictionary<eDataType, string> i_DataMemory, Dictionary<Vehicle.WheelData, string> i_Wheel, EnergyType.eEnergyType i_EnergyType)
        {
           Car.Color color = (Car.Color)int.Parse(i_DataMemory[eDataType.LicencePlate]);
           int numOfDoors = int.Parse(i_DataMemory[eDataType.NumOfDoors]);
           string model = i_DataMemory[eDataType.Model];
           string licensePlate = i_DataMemory[eDataType.LicencePlate];
           float percentage = float.Parse(i_DataMemory[eDataType.Percentage]);
            EnergyType energyType = null;

            if (i_EnergyType == EnergyType.eEnergyType.Regular)
            {
                energyType = new RegularEnergyType(RegularEnergyType.FuelType.Octan96, 5, 60);
            }
            else if (i_EnergyType == EnergyType.eEnergyType.Electric)
            {
                energyType = new ElectricEnergyType(2.1f);
            }

            return new Car(color, numOfDoors, model, licensePlate, percentage, i_Wheel, energyType);
        }
   
        public static Truck CreateTruck(Dictionary<eDataType, string> i_DataMemory, Dictionary<Vehicle.WheelData, string> i_Wheel, EnergyType.eEnergyType i_EnergyType)
        {
            bool isHavingHazardousMeterials = false;
            if (i_DataMemory[eDataType.HavingHazardousMeterials] == "true")
            {
                 isHavingHazardousMeterials = true;
            }
            float cargoVolume = float.Parse(i_DataMemory[eDataType.CargoVolume]);
            string model = i_DataMemory[eDataType.Model];
            string licensePlate = i_DataMemory[eDataType.LicencePlate];
            float percentage = float.Parse(i_DataMemory[eDataType.Percentage]);

            EnergyType energyType = new RegularEnergyType(RegularEnergyType.FuelType.Soler, 5, 120);
            return new Truck(isHavingHazardousMeterials, cargoVolume, model, licensePlate, percentage, i_Wheel, energyType);
        }

        public static Motorcycle CreateMotorCycle(Dictionary<eDataType, string> i_DataMemory, Dictionary<Vehicle.WheelData,string> i_Wheel, EnergyType.eEnergyType i_EnergyType)
        {

            string model = i_DataMemory[eDataType.Model];
            Motorcycle.licenseType licenceType = (Motorcycle.licenseType)int.Parse(i_DataMemory[eDataType.LicenceType]);
            string licensePlate = i_DataMemory[eDataType.LicencePlate];
            int engineCapacity = int.Parse(i_DataMemory[eDataType.EngineCapacity]);
            float percentage = float.Parse(i_DataMemory[eDataType.Percentage]);
            EnergyType energyType = null;

            if (i_EnergyType == EnergyType.eEnergyType.Regular)
            {
                energyType = new RegularEnergyType(RegularEnergyType.FuelType.Octan96, 5, 60);
            }
            else if (i_EnergyType == EnergyType.eEnergyType.Electric)
            {
                energyType = new ElectricEnergyType(2.1f);
            }

            return new Motorcycle(licenceType, engineCapacity, model, licensePlate, percentage, i_Wheel, energyType);
        }
    }
}



