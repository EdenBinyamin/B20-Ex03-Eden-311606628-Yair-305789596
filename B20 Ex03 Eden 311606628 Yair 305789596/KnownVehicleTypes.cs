using System;
using System.Collections.Generic;
using System.Linq;
using B20_Ex03_Eden_311606628_Yair_305789596;

namespace B20_Ex03_Eden_311606628_Yair_305789596
{
    public class KnownVehicleTypes
    {
        internal const int k_MotorcycleMaxAirPressure = 30;
        internal const int k_CarMaxAirPressure = 32;
        internal const int k_TruckMaxAirPressure = 28;
        internal const int k_RegualrCarFullTank = 60;
        internal const int k_RegularMotorcycleFullTank = 7;
        internal const int k_RegularTruckFullTank = 120;
        internal const float k_ElectricCarMaxBatteryHourTime = 2.1f;
        internal const float k_ElectricMotorcycleMaxBatteryHourTime = 1.5f;

        public enum eVehicleType
        {
            RegularCar = 1,
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
            Color,
            AmountOfFuelLeft,
            HoursLeftInBattery,
        }

        public static Vehicle CreateVehicle(List<string> i_Properties, eVehicleType i_Type)
        {
            Dictionary<eDataType, string> dataMemory = new Dictionary<eDataType, string>();
            Dictionary<Vehicle.WheelData, string> wheelsData = new Dictionary<Vehicle.WheelData, string>();
            int indexInProperties = 0;
            dataMemory.Add(eDataType.Model, i_Properties[indexInProperties++]);
            dataMemory.Add(eDataType.LicencePlate, i_Properties[indexInProperties++]);
            wheelsData.Add(Vehicle.WheelData.CurrentAirPressure, i_Properties[indexInProperties++]);
            checkAlpabeatStrings(i_Properties[indexInProperties]); // check manufactuereName
            wheelsData.Add(Vehicle.WheelData.ManufacturerName, i_Properties[indexInProperties++]);
            switch (i_Type)
            {
                case eVehicleType.RegularCar:
                case eVehicleType.RegularMotorcycle:
                case eVehicleType.Truck:
                    dataMemory.Add(eDataType.AmountOfFuelLeft, i_Properties[indexInProperties++]);
                    break;
                case eVehicleType.ElectricCar:
                case eVehicleType.ElectricMotorcycle:
                    dataMemory.Add(eDataType.HoursLeftInBattery, i_Properties[indexInProperties++]);
                    break;
            }

            switch (i_Type)
            {
                case eVehicleType.RegularCar:
                case eVehicleType.ElectricCar:
                    dataMemory.Add(eDataType.Color, i_Properties[indexInProperties++]);
                    dataMemory.Add(eDataType.NumOfDoors, i_Properties[indexInProperties++]);
                    wheelsData.Add(Vehicle.WheelData.MaxAirPressure, k_CarMaxAirPressure.ToString());
                    break;
                case eVehicleType.RegularMotorcycle:
                case eVehicleType.ElectricMotorcycle:
                    dataMemory.Add(eDataType.LicenceType, i_Properties[indexInProperties++]);
                    dataMemory.Add(eDataType.EngineCapacity, i_Properties[indexInProperties++]);
                    wheelsData.Add(Vehicle.WheelData.MaxAirPressure, k_MotorcycleMaxAirPressure.ToString());
                    break;
                case eVehicleType.Truck:
                    dataMemory.Add(eDataType.HavingHazardousMeterials, i_Properties[indexInProperties++]);
                    dataMemory.Add(eDataType.CargoVolume, i_Properties[indexInProperties++]);
                    wheelsData.Add(Vehicle.WheelData.MaxAirPressure, k_TruckMaxAirPressure.ToString());
                    break;
            }

            return CreateVehicle(dataMemory, i_Type, wheelsData);
        }

        public static List<string> GetPropertiesByVehicleType(Vehicle i_Vehicle)
        {
            List<string> vehicleProprties = new List<string>();
            if (i_Vehicle is Motorcycle)
            {
                if (i_Vehicle.Energy is RegularEnergyType)
                {
                    vehicleProprties = KnownVehicleTypes.GetPropertiesByVehicleType(KnownVehicleTypes.eVehicleType.RegularMotorcycle);
                }

                if (i_Vehicle.Energy is ElectricEnergyType)
                {
                    vehicleProprties = KnownVehicleTypes.GetPropertiesByVehicleType(KnownVehicleTypes.eVehicleType.ElectricMotorcycle);
                }
            }

            if (i_Vehicle is Car)
            {
                if (i_Vehicle.Energy is RegularEnergyType)
                {
                    vehicleProprties = KnownVehicleTypes.GetPropertiesByVehicleType(KnownVehicleTypes.eVehicleType.RegularCar);
                }

                if (i_Vehicle.Energy is ElectricEnergyType)
                {
                    vehicleProprties = KnownVehicleTypes.GetPropertiesByVehicleType(KnownVehicleTypes.eVehicleType.ElectricCar);
                }
            }

            if (i_Vehicle is Truck)
            {
                vehicleProprties = KnownVehicleTypes.GetPropertiesByVehicleType(KnownVehicleTypes.eVehicleType.Truck);
            }

            return vehicleProprties;
        }

        public static List<string> GetPropertiesByVehicleType(eVehicleType i_Type)
        {
            List<string> properties = new List<string>();
            properties.Add("model:");
            properties.Add("license plate:");
            properties.Add("current air pressure in wheels:");
            properties.Add("manufacturer name:");
            switch (i_Type)
            {
                case eVehicleType.RegularCar:
                case eVehicleType.RegularMotorcycle:
                case eVehicleType.Truck:
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
            string licensePlate = i_DataMemory[eDataType.LicencePlate];
            string model = i_DataMemory[eDataType.Model];
            checkNumericStrings(licensePlate, i_Wheel[Vehicle.WheelData.CurrentAirPressure]);
            checkAlpabeatStrings(model);
            Vehicle vehicle = null;
            switch (i_VehicleType)
            {
                case eVehicleType.RegularMotorcycle:
                    vehicle = CreateMotorCycle(licensePlate, model, i_DataMemory, i_Wheel, EnergyType.eEnergyType.Regular);
                    break;
                case eVehicleType.ElectricMotorcycle:
                    vehicle = CreateMotorCycle(licensePlate, model, i_DataMemory, i_Wheel, EnergyType.eEnergyType.Electric);
                    break;
                case eVehicleType.RegularCar:
                    vehicle = CreateCar(licensePlate, model, i_DataMemory, i_Wheel, EnergyType.eEnergyType.Regular);
                    break;
                case eVehicleType.ElectricCar:
                    vehicle = CreateCar(licensePlate, model, i_DataMemory, i_Wheel, EnergyType.eEnergyType.Electric);
                    break;
                case eVehicleType.Truck:
                    vehicle = CreateTruck(licensePlate, model, i_DataMemory, i_Wheel, EnergyType.eEnergyType.Electric);
                    break;
            }

            return vehicle;
        }

        public static Car CreateCar(string i_LicensePlate, string i_Model, Dictionary<eDataType, string> i_DataMemory, Dictionary<Vehicle.WheelData, string> i_Wheel, EnergyType.eEnergyType i_EnergyType)
        {
            checkNumericStrings(i_DataMemory[eDataType.NumOfDoors]);
            Car.eColorType color = Car.parseColor(i_DataMemory[eDataType.Color]);
            int numOfDoors = Car.parseNumOfDoors(i_DataMemory[eDataType.NumOfDoors]);
            EnergyType energyType = null;

            if (i_EnergyType == EnergyType.eEnergyType.Regular)
            {
                checkNumericStrings(i_DataMemory[eDataType.AmountOfFuelLeft]);
                energyType = new RegularEnergyType(RegularEnergyType.eFuelType.Octan96, float.Parse(i_DataMemory[eDataType.AmountOfFuelLeft]), k_RegualrCarFullTank);
            }
            else if (i_EnergyType == EnergyType.eEnergyType.Electric)
            {
                checkNumericStrings(i_DataMemory[eDataType.HoursLeftInBattery]);
                energyType = new ElectricEnergyType(float.Parse(i_DataMemory[eDataType.HoursLeftInBattery]), k_ElectricCarMaxBatteryHourTime);
            }

            return new Car(color, numOfDoors, i_Model, i_LicensePlate, i_Wheel, energyType);
        }

        public static Truck CreateTruck(string i_LicensePlate, string i_Model, Dictionary<eDataType, string> i_DataMemory, Dictionary<Vehicle.WheelData, string> i_Wheel, EnergyType.eEnergyType i_EnergyType)
        {
            checkNumericStrings(i_DataMemory[eDataType.CargoVolume], i_DataMemory[eDataType.AmountOfFuelLeft]);
            bool isHavingHazardousMeterials = Truck.parseHazardousMeterials(i_DataMemory[eDataType.HavingHazardousMeterials]);
            float cargoVolume = float.Parse(i_DataMemory[eDataType.CargoVolume]);

            EnergyType energyType = new RegularEnergyType(RegularEnergyType.eFuelType.Soler, float.Parse(i_DataMemory[eDataType.AmountOfFuelLeft]), k_RegularTruckFullTank);
            return new Truck(isHavingHazardousMeterials, cargoVolume, i_Model, i_LicensePlate, i_Wheel, energyType);
        }

        public static Motorcycle CreateMotorCycle(string i_LicensePlate, string i_Model, Dictionary<eDataType, string> i_DataMemory, Dictionary<Vehicle.WheelData, string> i_Wheel, EnergyType.eEnergyType i_EnergyType)
        {
            checkNumericStrings(i_DataMemory[eDataType.EngineCapacity]);
            Motorcycle.eLicenseType licenceType = Motorcycle.parseLicenseType(i_DataMemory[eDataType.LicenceType]);
            int engineCapacity = int.Parse(i_DataMemory[eDataType.EngineCapacity]);
            EnergyType energyType = null;

            if (i_EnergyType == EnergyType.eEnergyType.Regular)
            {
                checkNumericStrings(i_DataMemory[eDataType.AmountOfFuelLeft]);
                energyType = new RegularEnergyType(RegularEnergyType.eFuelType.Octan95, float.Parse(i_DataMemory[eDataType.AmountOfFuelLeft]), k_RegularMotorcycleFullTank);
            }
            else if (i_EnergyType == EnergyType.eEnergyType.Electric)
            {
                checkNumericStrings(i_DataMemory[eDataType.HoursLeftInBattery]);
                energyType = new ElectricEnergyType(float.Parse(i_DataMemory[eDataType.HoursLeftInBattery]), k_ElectricMotorcycleMaxBatteryHourTime);
            }

            return new Motorcycle(licenceType, engineCapacity, i_Model, i_LicensePlate, i_Wheel, energyType);
        }

        private static void checkNumericStrings(params string[] i_ListStrings)
        {
            foreach (string strToCheck in i_ListStrings)
            {
                if (!strToCheck.All(char.IsDigit))
                {
                    string failedMsg = string.Format("your input: {0}, should be Only Numeric input", strToCheck);
                    throw new FormatException(failedMsg);
                }
            }
        }

        private static void checkAlpabeatStrings(params string[] i_ListStrings)
        {
            foreach (string strToCheck in i_ListStrings)
            {
                if (!strToCheck.All(char.IsLetter))
                {
                    string failedMsg = string.Format("your input: {0}, should be Only Alpabeat input", strToCheck);
                    throw new FormatException(failedMsg);
                }
            }
        }              
    }
}
