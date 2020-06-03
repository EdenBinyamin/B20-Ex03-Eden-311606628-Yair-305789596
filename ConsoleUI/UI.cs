using B20_Ex03_Eden_311606628_Yair_305789596;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
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

        private static eUserSelectionType Menu()
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
            while (!Validation.MenuSelection(userSelection))
            {
                Console.WriteLine(k_WrongInput);
                userSelection = Console.ReadLine();
            }
            return (eUserSelectionType)int.Parse(userSelection);
        }

        public static void GarageSystem()
        {
            string msg = "=========== Welcome to our Garage System ===========";
            Console.WriteLine(msg);
            eUserSelectionType userSelection = Menu();
            Garage garage = new Garage();
            while (userSelection != eUserSelectionType.ExitTheSystem)
            {
                userSelection = Menu();
                switch (userSelection)
                {
                    case eUserSelectionType.AddNewVehicle:
                        AddANewVehicleToGarage(garage);
                        break;
                    case eUserSelectionType.DisplayLicensePlates:
                        DisplayLicensePlates(garage);
                        break;
                    case eUserSelectionType.ChangeTheStateOfVehicleInGarage:
                        ChangeVehicleStatus(garage);
                        break;
                    case eUserSelectionType.BlowingAirInTheWheels:
                        blowingAirPressure(garage);
                        break;
                    case eUserSelectionType.FuelAVehicle:
                        fuelAVehicle(garage);
                        break;
                    case eUserSelectionType.RechargeAVehicle:
                        rechargeAVehicle(garage);
                        break;
                    case eUserSelectionType.DisplayACarDetails:
                        displayAVehicleDetails(garage);
                        break;
                }
            }
        }

       //Function Menu 7

        private static void displayAVehicleDetails(Garage i_Garage)
        {
            Console.WriteLine(" ===== Display All The Details Of A Certain Vechile ==== ");
            string vehicleLicenseNumber = getAVehicleLicenseNumber(i_Garage);
            //METODS THE RETURN ALL LIST OF VEHICLE, EACH ONE IS A DICTIONARY <STRING AND OBJECT> FOR PRINT
            
        }
        //Function MEnu 6

        private static void rechargeAVehicle(Garage i_Garage)
        {
            Console.WriteLine(" ===== Recharge A Electric Vehicle ==== ");
            string vehicleLicenseNumber = getAVehicleLicenseNumber(i_Garage);
            string amountToRechare = getANumericString();

          ///  i_Garage. MAke the Function

        }

        //Funcion Menu 5
        private static void fuelAVehicle(Garage i_Garage)
        {
            Console.WriteLine(" ===== Fuel A Regular Vehicle ==== ");
            string vehicleLicenseNumber = getAVehicleLicenseNumber(i_Garage);
            string amountToFill = getANumericString();
       //     i_Garage.fuelVehicle() change funciton get only amount and A license number
        }


        //Function Menu 4
        private static void blowingAirPressure(Garage i_Garage)
        {
            Console.WriteLine(" ===== Blowing Air Pressure In Wheel ==== ");
            string vehicleLicenseNumber = getAVehicleLicenseNumber(i_Garage);
            i_Garage.fillAirInWheels(vehicleLicenseNumber);
        }




        //Function menu 1
        private static void AddANewVehicleToGarage(Garage i_Garage)
        {
            Console.WriteLine(" ===== Add New Vechile To Our Garage ==== ");
            KnownVehicleTypes.eVehicleType vehicleType = chooseVechileToAdd();
            Console.WriteLine("Please Type Owner Name");
            string ownerName = getNonEmptyString();
            Console.WriteLine("please Type Phone Number");
            string phoneNumber = getANumericString();
            List<string> propertiesToGet = KnownVehicleTypes.GetPropertiesByVehicleType(vehicleType);
            List<string> userInputProperties = new List<string>();
            foreach (string prop in propertiesToGet)
            {
                Console.WriteLine("Please Type {0}", prop);
                userInputProperties.Add(getNonEmptyString());
            }
            i_Garage.tryAddingNewVehicleToGarage(ownerName, phoneNumber, userInputProperties, vehicleType);
        }


        //Function menu 2
        private static void DisplayLicensePlates(Garage i_Garage)
        {
            Console.WriteLine(
@"====== Display license Plates of the Vehicles in The Garage =====
Press 1 - To Display only the vehicles in repair
Press 2 - To Display only the repaired vehicles
Press 3 - To Display only the paid up vehicles");
            string userSelection = Console.ReadLine();
            while (char.Parse(userSelection) < '1' || char.Parse(userSelection) > '3')
            {
                Console.WriteLine(k_WrongInput);
                userSelection = Console.ReadLine();
            }
            List<string> licensePlates = new List<string>();
            switch (char.Parse(userSelection))
            {
                case '1':
                    Console.WriteLine("==== The Vechile in Repair ==== ");
                    licensePlates = i_Garage.licenseNumbersByConditions(VehicleInRepair.VehicleCondition.inRepair);
                    break;
                case '2':
                    Console.WriteLine("==== The Repaired Vechiles ==== ");
                    licensePlates = i_Garage.licenseNumbersByConditions(VehicleInRepair.VehicleCondition.wasFixed);
                    break;
                case '3':
                    Console.WriteLine("==== The Paid Up Vechiles ==== ");
                    licensePlates = i_Garage.licenseNumbersByConditions(VehicleInRepair.VehicleCondition.paidUp);
                    break;
            }
            foreach (string vechileLicensePlate in licensePlates)
            {
                Console.WriteLine("License Number: {0}", vechileLicensePlate);
            }
        }

        //Function menu 3

        private static void ChangeVehicleStatus(Garage i_Garage)
        {
            Console.WriteLine("====== Change Vehicle Status =====");
            Console.WriteLine("Please Type A License Number");
            string vehicleLicenseNumber = getAVehicleLicenseNumber(i_Garage);

            Console.WriteLine(
            @"Please Choose A New Status
Press 1 - If The Vehicle In Repair
Press 2 - If The Vehicle Already Repaired
Press 3 - If the Repair was paid");
            char userSelection = Console.ReadKey().KeyChar;
            while (userSelection < '1' || userSelection > '3')
            {
                userSelection = Console.ReadKey().KeyChar;
            }
            switch (userSelection)
            {
                case '1':
                    i_Garage.changesVehicleCondition(vehicleLicenseNumber, VehicleInRepair.VehicleCondition.inRepair);
                    break;
                case '2':
                    i_Garage.changesVehicleCondition(vehicleLicenseNumber, VehicleInRepair.VehicleCondition.wasFixed);
                    break;
                case '3':
                    i_Garage.changesVehicleCondition(vehicleLicenseNumber, VehicleInRepair.VehicleCondition.paidUp);
                    break;
            }
        }



        //AUX FUNCTION

        private static KnownVehicleTypes.eVehicleType chooseVechileToAdd()

        {
            char indexForMenu = '1';
            foreach (string vechileType in KnownVehicleTypes.r_KnownTypes)
            {
                Console.WriteLine("Press {0} - To Add New {1} To The Garage", indexForMenu, vechileType);
                indexForMenu++;
            }
            string userSelection = Console.ReadLine();// Key().KeyChar;

            //while (!Enum.IsDefined(typeof(KnownVehicleTypes.eVehicleType), userSelection))
            //{
            //    Console.WriteLine("You Choise is out of Range, Please Try Again!");
            //    userSelection = Console.ReadLine(); // Key().KeyChar;
            //}
            return (KnownVehicleTypes.eVehicleType)int.Parse(userSelection);
        }


        private static string getAVehicleLicenseNumber(Garage i_Garage)
        {
            Console.WriteLine("=Please Type A License Number=");
            string vehicleLicenseNumber = getANumericString();
            if (!i_Garage.isLicenseNumberAlrdyExists(vehicleLicenseNumber))
            {
                Console.WriteLine("The Vehicle with the liecnse number {0}, is not exist", vehicleLicenseNumber);
                Console.WriteLine("Please Try Again!");
                vehicleLicenseNumber = getANumericString();
            }
            return vehicleLicenseNumber;
        }


        //AUXILIARY
        private static string getANumericString()
        {
            string inputStr = Console.ReadLine();
            while (!inputStr.All(char.IsDigit))
            {
                Console.WriteLine("Not A Numeric String, Please Try Again.");
                inputStr = Console.ReadLine();
            }
            return inputStr;
        }

        private static string getNonEmptyString()
        {
            string userInput = Console.ReadLine();
            while (userInput.Length == 0)
            {
                Console.WriteLine("You Enter A Empty Input, please try again!");
                userInput = Console.ReadLine();
            }
            return userInput;
        }
    }
}
