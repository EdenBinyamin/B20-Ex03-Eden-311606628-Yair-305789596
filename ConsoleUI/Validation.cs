using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    internal class Validation
    {
        internal static bool MenuSelection(string i_UserSelection)
        {
            i_UserSelection = i_UserSelection.Trim();
            return i_UserSelection.Length == 1 && char.IsDigit(i_UserSelection[0])
                        && int.Parse(i_UserSelection) >= 1 && int.Parse(i_UserSelection) <= 8;
        }

        internal static bool AddCarUserSelection(string i_UserSelection)
        {
            i_UserSelection = i_UserSelection.Trim();
            return i_UserSelection.Length == 1 && char.IsDigit(i_UserSelection[0])
                        && int.Parse(i_UserSelection) >= 1 && int.Parse(i_UserSelection) <= 3;
        }

        internal static bool DoorCars(string i_UserInput)
        {
            return i_UserInput.Length == 1 && char.IsDigit(i_UserInput[0])
                        && int.Parse(i_UserInput) >= 2 && int.Parse(i_UserInput) <= 5;
        }

        internal static bool CarColor(ref string userInput)
        {

            userInput = userInput.Trim();
            userInput = userInput.ToUpper();
            return userInput == "SILVER" || userInput == "BLACK" || userInput == "WHITE" || userInput == "RED";
        }


        internal static bool Name(string i_Name)
        {
            return i_Name.Length != 0;

        }

        internal static bool IsANumberStr(string i_StrToCheck)
        {
            return i_StrToCheck.All(char.IsDigit);
        }

        internal static bool Percentage(string precentage)
        {
            return IsANumberStr(precentage) && int.Parse(precentage) <= 100 && int.Parse(precentage) >= 0;
        }

        internal static bool EnergyType(string userSelection)
        {
            return userSelection.Length == 1 && (userSelection == "1" || userSelection == "2");
        }
    }
}








//private static void addANewCar(Garage i_Garage)
//{
//    Dictionary<KnownVehicleTypes.eDataType, string> CarInputs = new Dictionary<KnownVehicleTypes.eDataType, string>();
//    Dictionary<Vehicle.WheelData, string> WheelInputs = new Dictionary<Vehicle.WheelData, string>();
//    KnownVehicleTypes.eVehicleType vehicleType = KnownVehicleTypes.eVehicleType.Car;
//    string ownerName = getName("Owner");
//    string phoneNumberOfOwner = getPhoneNumber();
//    getVehicleProperties(CarInputs, WheelInputs);
//    CarInputs.Add(KnownVehicleTypes.eDataType.NumOfDoors, getNumOfDoors());
//    CarInputs.Add(KnownVehicleTypes.eDataType.Color, getColor());
//    float currentEnergy;
//    EnergyType.eEnergyType vehicleEnergy = getEnergyType(out currentEnergy);

//    i_Garage.tryAddingNewVehicleToGarage(ownerName, phoneNumberOfOwner, CarInputs, WheelInputs, vehicleType, vehicleEnergy);
//}
//private static void addANewTruck(Garage i_Garage)
//{
//    Dictionary<KnownVehicleTypes.eDataType, string> TruckInputs = new Dictionary<KnownVehicleTypes.eDataType, string>();
//    Dictionary<Vehicle.WheelData, string> WheelInputs = new Dictionary<Vehicle.WheelData, string>();
//    KnownVehicleTypes.eVehicleType vehicleType = KnownVehicleTypes.eVehicleType.Truck;
//    string ownerName = getName("Owner");
//    string phoneNumberOfOwner = getPhoneNumber();
//    getVehicleProperties(TruckInputs, WheelInputs);
//    TruckInputs.Add(KnownVehicleTypes.eDataType.HavingHazardousMeterials, getIsHavingHazardousMeterials());
//    float currentEnergy; // NO CHOISE FOR TYPE
//    EnergyType.eEnergyType vehicleEnergy = getEnergyType(out currentEnergy);

//    i_Garage.tryAddingNewVehicleToGarage(ownerName, phoneNumberOfOwner, TruckInputs, WheelInputs, vehicleType, vehicleEnergy);


//}

//private static void addANewMotorcycle(Garage i_Garage)
//{
//    Dictionary<KnownVehicleTypes.eDataType, string> MotorcycleInputs = new Dictionary<KnownVehicleTypes.eDataType, string>();
//    Dictionary<Vehicle.WheelData, string> WheelInputs = new Dictionary<Vehicle.WheelData, string>();
//    KnownVehicleTypes.eVehicleType vehicleType = KnownVehicleTypes.eVehicleType.Motorcycle;

//    string ownerName = getName("Owner");
//    string phoneNumberOfOwner = getPhoneNumber();
//    getVehicleProperties(MotorcycleInputs, WheelInputs);
//    MotorcycleInputs.Add(KnownVehicleTypes.eDataType.LicenceType, getLicenceType());
//    MotorcycleInputs.Add(KnownVehicleTypes.eDataType.EngineCapacity, getEngineCapacity());
//    float currentEnergy;
//    EnergyType.eEnergyType vehicleEnergy = getEnergyType(out currentEnergy);

//    i_Garage.tryAddingNewVehicleToGarage(ownerName, phoneNumberOfOwner, MotorcycleInputs, WheelInputs, vehicleType, vehicleEnergy);


//}

//private static string getLicenceType()
//{ // לממש
//    throw new NotImplementedException();
//}

//private static string getEngineCapacity()
//{ // לממש
//    throw new NotImplementedException();
//}

//private static string getCargo()
//{
//    string msg = "Please Type Cargo Volume";
//    Console.WriteLine(msg);
//    string cargoVolume = Console.ReadLine();
//    ///Kעשות בדיקה
//    return cargoVolume;
//}

//private static string getIsHavingHazardousMeterials()
//{
//    string msg = "Please Type if Truck have Hazardous Meterials";
//    Console.WriteLine(msg);
//    Console.WriteLine("Type Y for Yes and N for No");
//    string hazardousMeterials = Console.ReadLine();
//    //while () /// לממש את הבדיקה

//    return hazardousMeterials;
//}



//private static void getVehicleProperties(Dictionary<KnownVehicleTypes.eDataType, string> i_CarInputs, Dictionary<Vehicle.WheelData, string> i_WheelInputs)
//{
//    i_CarInputs.Add(KnownVehicleTypes.eDataType.Model, getModel());
//    i_CarInputs.Add(KnownVehicleTypes.eDataType.LicencePlate, getLicensePlate());
//    i_CarInputs.Add(KnownVehicleTypes.eDataType.Percentage, getPercentage());
//    i_WheelInputs.Add(Vehicle.WheelData.ManufacturerName, getName("Manufacturer"));
//    i_WheelInputs.Add(Vehicle.WheelData.MaxAirPressure, getPressure("Max"));
//    i_WheelInputs.Add(Vehicle.WheelData.CurrentAirPressure, getPressure("Current"));
//}

//private static string getPhoneNumber()
//{
//    string msg = "Please Type Owner Phone Number";
//    Console.WriteLine(msg);
//    string phoneNumber = Console.ReadLine();
//    while (!Validation.IsANumberStr(phoneNumber))
//    {
//        Console.WriteLine(k_WrongInput);
//        phoneNumber = Console.ReadLine();
//    }
//    return phoneNumber;
//}

//private static EnergyType.eEnergyType getEnergyType(out float o_CurrentEnergy)
//{
//    string msg = "Please Choose Energy Type";
//    Console.WriteLine(msg);
//    Console.WriteLine("For Electric Energy Please press 1");
//    Console.WriteLine("For Regular Energy Please press 2");
//    string userSelection = Console.ReadLine();
//    string currentEnergy = null;
//    while (!Validation.EnergyType(userSelection))
//    {
//        Console.WriteLine(k_WrongInput);
//        userSelection = Console.ReadLine();
//    }
//    EnergyType.eEnergyType veihicleEnergy = (EnergyType.eEnergyType)int.Parse(userSelection);
//    if (veihicleEnergy == EnergyType.eEnergyType.Regular)
//    {
//        Console.WriteLine("Please Choose Current Fuel");
//        currentEnergy = Console.ReadLine();
//        while (!Validation.IsANumberStr(currentEnergy))
//        {
//            Console.WriteLine(k_WrongInput);
//            userSelection = Console.ReadLine();
//        }
//        o_CurrentEnergy = float.Parse(currentEnergy);
//    }
//    else
//    {
//        Console.WriteLine("Please Choose Current Battery Time");
//        currentEnergy = Console.ReadLine();
//        while (!Validation.IsANumberStr(currentEnergy))
//        {
//            Console.WriteLine(k_WrongInput);
//            userSelection = Console.ReadLine();
//        }
//        o_CurrentEnergy = float.Parse(currentEnergy);
//    }
//    return veihicleEnergy;

//}



//private static string getNumOfDoors()
//{
//    string msg = string.Format(
//@"Please Choose numbers of Doors
//You can choose 2/3/4/5.");
//    Console.WriteLine(msg);
//    Console.Write("Please Type: ");
//    string numOfDoors = Console.ReadLine();
//    while (!Validation.DoorCars(numOfDoors))
//    {
//        Console.WriteLine(k_WrongInput);
//        numOfDoors = Console.ReadLine();
//    }

//    return numOfDoors;
//}

//private static string getColor()
//{
//    string msg = string.Format(
//@"Please Choose Car Color
//You can choose Red / White / Silver / Black");
//    Console.WriteLine(msg);
//    Console.Write("Please Type: ");
//    string color = Console.ReadLine();
//    while (!Validation.CarColor(ref color))
//    {
//        Console.WriteLine(k_WrongInput);
//        color = Console.ReadLine();
//    }
//    return color;
//}


//private static string getPressure(string i_Val)
//{
//    string msg = string.Format("Please Type the {0} Pressure of the Vechiale", i_Val);
//    Console.WriteLine(msg);
//    string pressure = Console.ReadLine();
//    while (!Validation.IsANumberStr(pressure))
//    {
//        Console.WriteLine(k_WrongInput);
//        pressure = Console.ReadLine();
//    }

//    return pressure;
//}

//private static string getName(string typeName)
//{
//    string msg = string.Format("Please Type {0} Name", typeName);
//    Console.WriteLine(msg);
//    string name = Console.ReadLine();
//    while (!Validation.Name(name))
//    {
//        Console.WriteLine(k_WrongInput);
//        name = Console.ReadLine();
//    }
//    return name;
//}

//private static string getPercentage()
//{
//    string msg = "Please Type Energy Percentage";
//    Console.WriteLine(msg);
//    string precentage = Console.ReadLine();
//    while (!Validation.Percentage(precentage))
//    {
//        Console.WriteLine(k_WrongInput);
//        precentage = Console.ReadLine();
//    }
//    return precentage;
//}

//private static string getLicensePlate()
//{
//    string msg = "Please Type A License Plate";
//    Console.WriteLine(msg);
//    string licencsePlate = Console.ReadLine();
//    while (!Validation.IsANumberStr(licencsePlate))
//    {
//        Console.WriteLine(k_WrongInput);
//        licencsePlate = Console.ReadLine();
//    }
//    return licencsePlate;
//}

//private static string getModel()
//{
//    string msg = "Please Type A Vehicle Model";
//    Console.WriteLine(msg);
//    string model = Console.ReadLine();
//    while (!Validation.Name(model))
//    {
//        Console.WriteLine(k_WrongInput);
//        model = Console.ReadLine();
//    }
//    return model;
//}
