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
            Garage garage = new Garage();
            while(userSelection != eUserSelectionType.ExitTheSystem)
            {
                userSelection = Menu();
                switch(userSelection)
                {
                    case eUserSelectionType.AddNewVehicle:
                        AddANewVehicleToGarage(garage);
                        break;





                }
            }
        }

        private static eUserSelectionType Menu ()
        {
            string menuMsg = string.Format
(@"========== MENU ==========
Press 1 - To Put a new car in the Garage
Press 2 - To Display the entire list of vechicle license plates in the Garage
Press 3 - For Changing the state of a vehicle in the Garage
Press 4 - For Blowing air in the wheels of a certain vehicle
Press 5 - To Fuel a regular vechile
Press 6 - To Recharge a electric vechile
Press 7 - To Display the entire details of a certain vechile
Press 8 - To Exit");
            Console.WriteLine(menuMsg);
            string userSelection = Console.ReadLine(); 
            while(!Validation.MenuSelection(userSelection))
            {
                Console.WriteLine(k_WrongInput);
                userSelection = Console.ReadLine();
            }
            return (eUserSelectionType)int.Parse(userSelection);
        } 

        private static void AddANewVehicleToGarage(Garage i_Garage)
        {
            Console.WriteLine(" ===== Add New Vechile To Our Garage ==== ");
            foreach ()
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
                    addANewCar(i_Garage);
                    break;
                case KnownVehicleTypes.eVehicleType.Motorcycle:
                    addANewMotorcycle(i_Garage);
                    break;
                case KnownVehicleTypes.eVehicleType.Truck:
                    addANewTruck(i_Garage);
                    break;
            }
        }




        private static void addANewCar(Garage i_Garage)
        {
            Dictionary<KnownVehicleTypes.eDataType, string> CarInputs = new Dictionary<KnownVehicleTypes.eDataType, string>();
            Dictionary<Vehicle.WheelData, string> WheelInputs = new Dictionary<Vehicle.WheelData, string>();
            KnownVehicleTypes.eVehicleType vehicleType = KnownVehicleTypes.eVehicleType.Car;
            string ownerName = getName("Owner");
            string phoneNumberOfOwner = getPhoneNumber();
            getVehicleProperties(CarInputs, WheelInputs);
            CarInputs.Add(KnownVehicleTypes.eDataType.NumOfDoors, getNumOfDoors());
            CarInputs.Add(KnownVehicleTypes.eDataType.Color, getColor());
            float currentEnergy;
            EnergyType.eEnergyType vehicleEnergy = getEnergyType(out currentEnergy);

            i_Garage.tryAddingNewVehicleToGarage(ownerName, phoneNumberOfOwner, CarInputs, WheelInputs, vehicleType, vehicleEnergy);
        }
        private static void addANewTruck(Garage i_Garage)
        {
            Dictionary<KnownVehicleTypes.eDataType, string> TruckInputs = new Dictionary<KnownVehicleTypes.eDataType, string>();
            Dictionary<Vehicle.WheelData, string> WheelInputs = new Dictionary<Vehicle.WheelData, string>();
            KnownVehicleTypes.eVehicleType vehicleType = KnownVehicleTypes.eVehicleType.Truck;
            string ownerName = getName("Owner");
            string phoneNumberOfOwner = getPhoneNumber();
            getVehicleProperties(TruckInputs, WheelInputs);
            TruckInputs.Add(KnownVehicleTypes.eDataType.HavingHazardousMeterials, getIsHavingHazardousMeterials());
            float currentEnergy; // NO CHOISE FOR TYPE
            EnergyType.eEnergyType vehicleEnergy = getEnergyType(out currentEnergy);

            i_Garage.tryAddingNewVehicleToGarage(ownerName, phoneNumberOfOwner, TruckInputs, WheelInputs, vehicleType, vehicleEnergy);


        }

        private static void addANewMotorcycle(Garage i_Garage)
        {
            Dictionary<KnownVehicleTypes.eDataType, string> MotorcycleInputs = new Dictionary<KnownVehicleTypes.eDataType, string>();
            Dictionary<Vehicle.WheelData, string> WheelInputs = new Dictionary<Vehicle.WheelData, string>();
            KnownVehicleTypes.eVehicleType vehicleType = KnownVehicleTypes.eVehicleType.Motorcycle;

            string ownerName = getName("Owner");
            string phoneNumberOfOwner = getPhoneNumber();
            getVehicleProperties(MotorcycleInputs, WheelInputs);
            MotorcycleInputs.Add(KnownVehicleTypes.eDataType.LicenceType, getLicenceType());
            MotorcycleInputs.Add(KnownVehicleTypes.eDataType.EngineCapacity, getEngineCapacity());
            float currentEnergy;
            EnergyType.eEnergyType vehicleEnergy = getEnergyType(out currentEnergy);

            i_Garage.tryAddingNewVehicleToGarage(ownerName, phoneNumberOfOwner, MotorcycleInputs, WheelInputs, vehicleType, vehicleEnergy);


        }

        private static string getLicenceType()
        { // לממש
            throw new NotImplementedException();
        }

        private static string getEngineCapacity()
        { // לממש
            throw new NotImplementedException();
        }

        private static string getCargo()
        {
            string msg = "Please Type Cargo Volume";
            Console.WriteLine(msg);
            string cargoVolume = Console.ReadLine();
            ///Kעשות בדיקה
            return cargoVolume;
        }

        private static string getIsHavingHazardousMeterials()
        {
            string msg = "Please Type if Truck have Hazardous Meterials";
            Console.WriteLine(msg);
            Console.WriteLine("Type Y for Yes and N for No");
            string hazardousMeterials = Console.ReadLine();
            //while () /// לממש את הבדיקה

            return hazardousMeterials;
        }

 

        private static void getVehicleProperties(Dictionary<KnownVehicleTypes.eDataType, string> i_CarInputs,Dictionary<Vehicle.WheelData, string> i_WheelInputs)
        {
            i_CarInputs.Add(KnownVehicleTypes.eDataType.Model, getModel());
            i_CarInputs.Add(KnownVehicleTypes.eDataType.LicencePlate, getLicensePlate());
            i_CarInputs.Add(KnownVehicleTypes.eDataType.Percentage, getPercentage());
            i_WheelInputs.Add(Vehicle.WheelData.ManufacturerName, getName("Manufacturer"));
            i_WheelInputs.Add(Vehicle.WheelData.MaxAirPressure, getPressure("Max"));
            i_WheelInputs.Add(Vehicle.WheelData.CurrentAirPressure, getPressure("Current"));
        }

        private static string getPhoneNumber()
        {
            string msg = "Please Type Owner Phone Number";
            Console.WriteLine(msg);
            string phoneNumber = Console.ReadLine();
            while(!Validation.IsANumberStr(phoneNumber))
            {
                Console.WriteLine(k_WrongInput);
                phoneNumber = Console.ReadLine();
            }
            return phoneNumber;
        }

        private static EnergyType.eEnergyType getEnergyType(out float o_CurrentEnergy)
        {
            string msg = "Please Choose Energy Type";
            Console.WriteLine(msg);
            Console.WriteLine("For Electric Energy Please press 1");
            Console.WriteLine("For Regular Energy Please press 2");
            string userSelection = Console.ReadLine();
            string currentEnergy = null;
            while(!Validation.EnergyType(userSelection))
            {
                Console.WriteLine(k_WrongInput);
                userSelection = Console.ReadLine();
            }
            EnergyType.eEnergyType veihicleEnergy = (EnergyType.eEnergyType)int.Parse(userSelection);
            if (veihicleEnergy == EnergyType.eEnergyType.Regular)
            {
                Console.WriteLine("Please Choose Current Fuel");
                currentEnergy = Console.ReadLine();
                while(!Validation.IsANumberStr(currentEnergy))
                {
                    Console.WriteLine(k_WrongInput);
                    userSelection = Console.ReadLine();
                }
                o_CurrentEnergy = float.Parse(currentEnergy);
            }
            else
            {
                Console.WriteLine("Please Choose Current Battery Time");
                currentEnergy = Console.ReadLine();
                while (!Validation.IsANumberStr(currentEnergy))
                {
                    Console.WriteLine(k_WrongInput);
                    userSelection = Console.ReadLine();
                }
                o_CurrentEnergy = float.Parse(currentEnergy);
            }
            return veihicleEnergy;

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


        private static string getPressure(string i_Val)
        {
            string msg = string.Format("Please Type the {0} Pressure of the Vechiale",i_Val);
            Console.WriteLine(msg);
            string pressure = Console.ReadLine();
            while(!Validation.IsANumberStr(pressure))
            {
                Console.WriteLine(k_WrongInput);
                pressure = Console.ReadLine();
            }

            return pressure;
        }

        private static string getName(string typeName)
        {
            string msg = string.Format("Please Type {0} Name", typeName);
            Console.WriteLine(msg);
            string name = Console.ReadLine();
            while(!Validation.Name(name))
            {
                Console.WriteLine(k_WrongInput);
                name = Console.ReadLine();
            }
            return name;
        }

        private static string getPercentage()
        {
            string msg = "Please Type Energy Percentage";
            Console.WriteLine(msg);
            string precentage = Console.ReadLine();
            while(!Validation.Percentage(precentage))
            {
                Console.WriteLine(k_WrongInput);
                precentage = Console.ReadLine();
            }
            return precentage;
        }

        private static string getLicensePlate()
        {
            string msg = "Please Type A License Plate";
            Console.WriteLine(msg);
            string licencsePlate = Console.ReadLine();
            while(!Validation.IsANumberStr(licencsePlate))
            {
                Console.WriteLine(k_WrongInput);
                licencsePlate = Console.ReadLine();
            }
            return licencsePlate;
        }

        private static string getModel()
        {
            string msg = "Please Type A Vehicle Model";
            Console.WriteLine(msg);
            string model = Console.ReadLine();
            while (!Validation.Name(model))
            {
                Console.WriteLine(k_WrongInput);
                model = Console.ReadLine();
            }
            return model;
        }

       





    }
    
}
