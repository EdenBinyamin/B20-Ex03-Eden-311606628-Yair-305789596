using B20_Ex03_Eden_311606628_Yair_305789596;
using System;
using System.Collections.Generic;


namespace B20_Ex03_Eden_311606628_Yair_305789596
{
    public class KnownVehicleTypes
    {
        private static readonly int motorcycleMaxAirPressure = 32;
        private static readonly int carMaxAirPressure = 30;
        private static readonly int truckMaxAirPressure = 28;
        public enum eVehicleType
        {
            RegularCar=1,
            ElectricCar,
            RegularMotorcycle,
            ElectricMotorcycle,
            Truck,
        }

        public static readonly string[] r_KnownTypes =
        {
            "Regular Car",
            "Electric Car",
            "Regular Motorcycle",
            "Electric Motorcycle",
            "Truck"
        };
        public enum eDataType
        {
            Model,
            LicencePlate,
            CurrentAirPressure,
            LicenceType,
            EngineCapacity,
            NumOfDoors,
            HavingHazardousMeterials,
            CargoVolume,
            Percentage,
            Color,
            FuelType,
            AmountOfFuelLeft,
            HoursLeftInBattery,
        }

        public static Vehicle CreateVehicle (List<string> i_Properties, eVehicleType i_Type)
        {
            Dictionary<eDataType, string> dataMemory = new Dictionary<eDataType, string>();
            Dictionary<Vehicle.WheelData, string> wheelsData = new Dictionary<Vehicle.WheelData, string>();
            int indexInProperties = 0;
            dataMemory.Add(eDataType.Model, i_Properties[indexInProperties++]);
            dataMemory.Add(eDataType.LicencePlate, i_Properties[indexInProperties++]);
            dataMemory.Add(eDataType.Percentage, i_Properties[indexInProperties++]);
            wheelsData.Add(Vehicle.WheelData.CurrentAirPressure, i_Properties[indexInProperties++]);
            wheelsData.Add(Vehicle.WheelData.ManufacturerName, i_Properties[indexInProperties++]);
            switch (i_Type)
            {
                case eVehicleType.RegularCar:
                case eVehicleType.RegularMotorcycle:
                case eVehicleType.Truck:
                    dataMemory.Add(eDataType.FuelType, i_Properties[indexInProperties++]);
                    dataMemory.Add(eDataType.AmountOfFuelLeft, i_Properties[indexInProperties++]);
                    break;
                case eVehicleType.ElectricCar:
                case eVehicleType.ElectricMotorcycle:
                    dataMemory.Add(eDataType.HoursLeftInBattery, i_Properties[indexInProperties++]);
                    break;
            }
            switch(i_Type)
            {
                case eVehicleType.RegularCar:
                case eVehicleType.ElectricCar:
                    dataMemory.Add(eDataType.Color, i_Properties[indexInProperties++]);
                    dataMemory.Add(eDataType.NumOfDoors, i_Properties[indexInProperties++]);
                    wheelsData.Add(Vehicle.WheelData.MaxAirPressure, carMaxAirPressure.ToString());
                    break;
                case eVehicleType.RegularMotorcycle:
                case eVehicleType.ElectricMotorcycle:
                    dataMemory.Add(eDataType.LicenceType, i_Properties[indexInProperties++]);
                    dataMemory.Add(eDataType.EngineCapacity, i_Properties[indexInProperties++]);
                    wheelsData.Add(Vehicle.WheelData.MaxAirPressure, motorcycleMaxAirPressure.ToString());
                    break;
                case eVehicleType.Truck:
                    dataMemory.Add(eDataType.HavingHazardousMeterials, i_Properties[indexInProperties++]);
                    dataMemory.Add(eDataType.CargoVolume, i_Properties[indexInProperties++]);
                    wheelsData.Add(Vehicle.WheelData.MaxAirPressure, truckMaxAirPressure.ToString());
                    break;
            }
            return CreateVehicle(dataMemory, i_Type, wheelsData);
        }
        
        public static List<string> GetPropertiesByVehicleType(eVehicleType i_Type)
        {
            List<string> properties = new List<string>();
            properties.Add("model:");
            properties.Add("license plate:");
            properties.Add("percentage of energy remained in car:");
            properties.Add("current air pressure in wheels:");
            properties.Add("manufacturer name:");
            switch (i_Type)
            {
                case eVehicleType.RegularCar:
                case eVehicleType.RegularMotorcycle:
                case eVehicleType.Truck:
                    properties.Add("type of fuel:");
                    properties.Add("amount of fuel left:");
                    break;
                case eVehicleType.ElectricCar:
                case eVehicleType.ElectricMotorcycle:
                    properties.Add("hours left for battery usage:");
                    break;
            }
            switch (i_Type)
            {
                case eVehicleType.RegularCar:
                case eVehicleType.ElectricCar:
                    properties.Add("color:");
                    properties.Add("number of doors:");
                    break;
                case eVehicleType.RegularMotorcycle:
                case eVehicleType.ElectricMotorcycle:
                    properties.Add("license type:");
                    properties.Add("engine capacity:");
                    break;
                case eVehicleType.Truck:
                    properties.Add("status about having hazardous materials: ");
                    properties.Add("cargo volume:");
                    break;
            }
            return properties;
        }

        public static Vehicle CreateVehicle(Dictionary<eDataType, string> i_DataMemory, eVehicleType i_VehicleType, Dictionary<Vehicle.WheelData, string> i_Wheel)
        {
            Vehicle vehicle = null;
            switch (i_VehicleType)
            {
                case eVehicleType.RegularMotorcycle:
                    vehicle = CreateMotorCycle(i_DataMemory, i_Wheel, EnergyType.eEnergyType.Regular);
                    break;
                case eVehicleType.ElectricMotorcycle:
                    vehicle = CreateMotorCycle(i_DataMemory, i_Wheel, EnergyType.eEnergyType.Electric);
                    break;
                case eVehicleType.RegularCar:
                    vehicle = CreateCar(i_DataMemory, i_Wheel, EnergyType.eEnergyType.Regular);
                    break;
                case eVehicleType.ElectricCar:
                    vehicle = CreateCar(i_DataMemory,i_Wheel, EnergyType.eEnergyType.Electric);
                    break;
                case eVehicleType.Truck:
                    vehicle = CreateTruck(i_DataMemory, i_Wheel, EnergyType.eEnergyType.Electric);
                    break;
            }
            return vehicle;
        }

        public static Car CreateCar(Dictionary<eDataType, string> i_DataMemory, Dictionary<Vehicle.WheelData, string> i_Wheel, EnergyType.eEnergyType i_EnergyType)
        {
            Car.Color color = Car.colorParse(i_DataMemory[eDataType.Color]);
           int numOfDoors = int.TryParse(i_DataMemory[eDataType.NumOfDoors]);
            if(!int.TryParse(i_DataMemory[eDataType.NumOfDoors],out numOfDoors))
            {
                throw new ArgumentException;
            }
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
                energyType = new ElectricEnergyType(float.Parse(i_DataMemory[eDataType.HoursLeftInBattery]), 1.2f);
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
            Motorcycle.licenseType licenceType = Motorcycle.LicenseTypeParse(i_DataMemory[eDataType.LicenceType]);
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



