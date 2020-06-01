using B20_Ex03_Eden_311606628_Yair_305789596;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Management.Instrumentation;
using System.Security.AccessControl;

namespace ConsoleUI
{
    public class UI
    {

        private const string k_Msg1 = "Press 1 - To Put a new car in the Garage";
        private const string k_Msg2 = "Press 2 - To Display the entire list of vechicle license plates in the Garage";
        private const string k_Msg3 = "Press 3 - For Changing the state of a vehicle in the Garage";
        private const string k_Msg4 = "Press 4 - For Blowing air in the wheels of a certain vehicle";
        private const string k_Msg5 = "Press 5 - To Fuel a regular vechile";
        private const string k_Msg6 = "Press 6 - To Recharge a electric vechile";
        private const string k_Msg7 = "Press 7 - To Display the entire details of a certain vechile";
        private const string k_Msg8 = "Press 8 - To Exit";
        private const string k_WrongInput = "Wrong Input! Please Try Again.";

        public enum eUserSelectionType
        {
            AddNewVehicle = 1,
            DisplayLicensePlates,
            ChangeTheStateOfVehicleInGarage,
            BlowingAirInTheWheels,
            FuelAVehicle,
            RechargeAVehicle,
            DisplayACarDetails,
            ExitTheSystem
        }
        public static void GarageSystem()
        {
            string msg = "=========== Welcome to our Garage System ===========";
            Console.WriteLine(msg);
            eUserSelectionType userSelection = Menu();
            while(userSelection != eUserSelectionType.ExitTheSystem)
            {
                userSelection = Menu();
                switch(userSelection)
                {
                    case eUserSelectionType.AddNewVehicle:
                        AddANewVehicleToGarage();
                        break;





                }
            }
        }

        private static eUserSelectionType Menu ()
        {
            Console.WriteLine(k_Msg1);
            Console.WriteLine(k_Msg2);
            Console.WriteLine(k_Msg3);
            Console.WriteLine(k_Msg4);
            Console.WriteLine(k_Msg5);
            Console.WriteLine(k_Msg6);
            Console.WriteLine(k_Msg7);
            Console.WriteLine(k_Msg8);
            string userSelection = Console.ReadLine(); 
            while(!Validation.MenuSelection(userSelection))
            {
                Console.WriteLine(k_WrongInput);
                userSelection = Console.ReadLine();
            }
            return (eUserSelectionType)int.Parse(userSelection);
        } 

        private static void AddANewVehicleToGarage()
        {
            Console.WriteLine(" ===== Add New Vechile To Our Garage ==== ");
            Console.WriteLine("Press 1 - To Add A Car");
            Console.WriteLine("Press 2 - To Add A Motorcycle");
            Console.WriteLine("Press 3 - To Add A Truck");
            string userInput = Console.ReadLine();
            while(!Validation.AddCarUserSelection(userInput))
            {
                Console.WriteLine(k_WrongInput);
                userInput = Console.ReadLine();
            }
           KnownVehicleTypes.eVehicleType userSelection =(KnownVehicleTypes.eVehicleType)int.Parse(userInput);
            switch(userSelection)
            {
                case KnownVehicleTypes.eVehicleType.Car:
                    addANewCar();
                    break;
                case KnownVehicleTypes.eVehicleType.Motorcycle:
                    addANewMotorcycle();
                    break;
                case KnownVehicleTypes.eVehicleType.Truck:
                    addANewTruck();
                    break;
            }
        }


        private static void addANewCar()
        {
            Dictionary<KnownVehicleTypes.eDataType, string> CarInputs = new Dictionary<KnownVehicleTypes.eDataType, string>;
            Dictionary<Vehicle.WheelData, string> WheelInputs = new Dictionary<Vehicle, string>;
            CarInputs.Add(KnownVehicleTypes.eDataType.Model, getModel());
            CarInputs.Add(KnownVehicleTypes.eDataType.LicencePlate, getLicensePlate());
            CarInputs.Add(KnownVehicleTypes.eDataType.percentage, getPercentage());
            CarInputs.Add(KnownVehicleTypes.eDataType.numOfDoors, getNumOfDoors());
            CarInputs.Add(KnownVehicleTypes.eDataType.Color, getColor());
            WheelInputs.Add(Vehicle.WheelData.ManufacturerName, getManufacturerName());
            WheelInputs.Add(Vehicle.WheelData.MaxAirPressure, getPressure());
            WheelInputs.Add(Vehicle.WheelData.CurrentAirPressure, getPressure());
            WheelInputs.Add(Vehicle.WheelData.NumOfWheels, getNumOfWheel());
            EnergyType engeryType = getEnergyType();

            ///GARAGE function That get  CarInputs,WheelInputs,engeryType, KnownVehicleTypes.eVehicleType
        }

        private static EnergyType getEnergyType()
        {
            Dictionary<KnownVehicleTypes.eDataType, string> CarInputs = new Dictionary<KnownVehicleTypes.eDataType, string>;
            Dictionary<Vehicle.WheelData, string> WheelInputs = new Dictionary<Vehicle, string>;
            int maxPressure;
            CarInputs.Add(KnownVehicleTypes.eDataType.Model, getModel());
            CarInputs.Add(KnownVehicleTypes.eDataType.LicencePlate, getLicensePlate());
            CarInputs.Add(KnownVehicleTypes.eDataType.Percentage, getPercentage());
            CarInputs.Add(KnownVehicleTypes.eDataType.NumOfDoors, getNumOfDoors());
            CarInputs.Add(KnownVehicleTypes.eDataType.Color, getColor());
            CarInputs.Add(KnownVehicleTypes.eDataType.Color, getColor());

            WheelInputs.Add(Vehicle.WheelData.ManufacturerName, getManufacturerName());
            WheelInputs.Add(Vehicle.WheelData.MaxAirPressure, getMaxPressure(out maxPressure));
            WheelInputs.Add(Vehicle.WheelData.CurrentAirPressure, getCurrentPressure(maxPressure));
            EnergyType engeryType = getEnergyType(CarInputs);
            ///GARAGE function That get  CarInputs,WheelInputs,engeryType, KnownVehicleTypes.eVehicleType

        }

        private static string getNumOfDoors()
        {
            string msg = string.Format(
@"Please Choose numbers of Doors
You can choose 2/3/4/5.");
            Console.WriteLine(msg);
            Console.Write("Please Type: ");
            string numOfDoors = Console.ReadLine();
            while(!Validation.DoorCars(numOfDoors))
            {
                Console.WriteLine(k_WrongInput);
                numOfDoors = Console.ReadLine();
            }

            return numOfDoors;
        }

        private static string getColor()
        {
            string msg = string.Format(
@"Please Choose Car Color
You can choose Red / White / Silver / Black");
            Console.WriteLine(msg);
            Console.Write("Please Type: ");
            string color = Console.ReadLine();
            while(!Validation.CarColor(ref color))
            {
                Console.WriteLine(k_WrongInput);
                color = Console.ReadLine();
            }
            return color;
        }

        private static string getCurrentPressure(int i_MaxPressure)
        {
            string msg = "Please Type the Current Pressure of the Vechiale";
            Console.WriteLine(msg);
            string currentPressure = Console.ReadLine();
            while(!Validation.CurrentPressure(currentPressure, i_MaxPressure))
            {
                Console.WriteLine(k_WrongInput);
                currentPressure = Console.ReadLine();
            }
            throw new NotImplementedException();
        }

        private static string getMaxPressure(out int o_MaxPressure)
        {
            string msg = "Please Type the Max Pressure of the Vechiale";
            Console.WriteLine(msg);
            string maxPressure = Console.ReadLine();
            bool validNumber = int.TryParse(maxPressure, out o_MaxPressure);
            while(!validNumber)
            {
                Console.WriteLine(k_WrongInput);
                maxPressure = Console.ReadLine();
                validNumber = int.TryParse(maxPressure, out o_MaxPressure);
            }

            return maxPressure;
        }

        private static string getManufacturerName()
        {
            string msg = "Please Type Manufacturer Wheel Name";
            Console.WriteLine(msg);
            string manufacturerName = Console.ReadLine();
            while(!Validation.Name)
            throw new NotImplementedException();
        }

        private static string getPercentage()
        {
            throw new NotImplementedException();
        }

        private static string getLicensePlate()
        {
            throw new NotImplementedException();
        }

        private static string getModel()
        {
            throw new NotImplementedException();
        }

        private static void addANewMotorcycle()
        {



        }

        private static void addANewTruck()
        {



        }





    }
    
}
