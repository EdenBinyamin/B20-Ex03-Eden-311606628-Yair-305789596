﻿using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Management.Instrumentation;
using System.Security.AccessControl;
using B20_Ex03_Eden_311606628_Yair_305789596;

namespace ConsoleUI
{
    public class UI
    {
        private const string k_WrongInput = "Wrong Input! Please Try Again.";
        private const string k_BreakLine = " --------------------------  ";

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
Press 1 - To Add a new vehicle into the Garage
Press 2 - To Display the entire list of vechicle license plates in the Garage
Press 3 - For Changing the state of a vehicle in the Garage
Press 4 - For Blowing air in the wheels of a certain vehicle
Press 5 - To Fuel a regular vechile
Press 6 - To Recharge a electric vechile
Press 7 - To Display the entire details of a certain vechile
Press 8 - To Exit");
            Console.WriteLine(menuMsg);
            string userSelection = Console.ReadLine();
            while (!checkMenuSelection(userSelection))
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
            Console.WriteLine();
            eUserSelectionType userSelection = Menu();
            Garage garage = new Garage();
            while (userSelection != eUserSelectionType.ExitTheSystem)
            {
                switch (userSelection)
                {
                    case eUserSelectionType.AddNewVehicle:
                        addANewVehicleToGarage(garage);
                        break;
                    case eUserSelectionType.DisplayLicensePlates:
                        displayLicensePlates(garage);
                        break;
                    case eUserSelectionType.ChangeTheStateOfVehicleInGarage:
                        changeVehicleStatus(garage);
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

                userSelection = Menu();
                Console.WriteLine();
            }
        }

        private static void addANewVehicleToGarage(Garage i_Garage)
        {
            Console.WriteLine(" ===== Add New Vechile To Our Garage ==== ");
            KnownVehicleTypes.eVehicleType vehicleType = chooseVechileToAdd();
            Console.WriteLine("Please Type Owner Name");
            string ownerName = getAlphabeatString();
            Console.WriteLine("please Type Phone Number");
            string phoneNumber = getANumericString();
            List<string> propertiesToGet = KnownVehicleTypes.GetPropertiesByVehicleType(vehicleType);
            List<string> userInputProperties = new List<string>();
            foreach (string prop in propertiesToGet)
            {
                Console.WriteLine("Please Type {0}", prop);
                userInputProperties.Add(getNonEmptyString());
            }

            try
            {
                bool res = i_Garage.tryAddingNewVehicleToGarage(ownerName, phoneNumber, userInputProperties, vehicleType);
                if (res)
                {
                    Console.WriteLine("{0}{1}Sucsses Adding A New Vehicle!{1}{0}", k_BreakLine, System.Environment.NewLine);
                }
                else
                {
                    Console.WriteLine("{0}{1}Vechile by the same license plate already exist in the garage{1}{0}", k_BreakLine, System.Environment.NewLine);
                    addANewVehicleToGarage(i_Garage);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("{0}{1}Cannot Adding a New Vechile{1}{2}{1}{0}", k_BreakLine, System.Environment.NewLine, e.Message);
            }
        }

        private static void displayLicensePlates(Garage i_Garage)
        {
            Console.WriteLine(
@"====== Display license Plates of the Vehicles in The Garage =====
Press 1 - To Display only the vehicles in repair
Press 2 - To Display only the repaired vehicles
Press 3 - To Display only the paid up vehicles");
            string userSelection = Console.ReadLine();
            while (userSelection.Length > 1 || char.Parse(userSelection) < '1' || char.Parse(userSelection) > '3')
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

            if (licensePlates.Count == 0) 
            {
                Console.WriteLine("No License Plates To Display");
            }

            foreach (string vechileLicensePlate in licensePlates)
            {
                Console.WriteLine("License Number: {0}", vechileLicensePlate);
            }
        }

        private static void changeVehicleStatus(Garage i_Garage)
        {
            Console.WriteLine("====== Change Vehicle Status =====");
            string vehicleLicenseNumber = getAVehicleLicenseNumber(i_Garage);

            Console.WriteLine(
            @"Please Choose A New Status
Press 1 - If The Vehicle In Repair
Press 2 - If The Vehicle Already Repaired
Press 3 - If the Repair was paid");
            string userSelection = Console.ReadLine();
            while (userSelection.Length > 1 || char.Parse(userSelection) < '1' || char.Parse(userSelection) > '3')
            {
                Console.WriteLine(k_WrongInput);
                userSelection = Console.ReadLine();
            }

            try
            {
                switch (char.Parse(userSelection))
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

                Console.WriteLine("{0}{1}Change Vehicle Status Succeeded!{1}{0}", k_BreakLine, System.Environment.NewLine);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void blowingAirPressure(Garage i_Garage)
        {
            Console.WriteLine(" ===== Blowing Air Pressure In Wheel ==== ");
            string vehicleLicenseNumber = getAVehicleLicenseNumber(i_Garage);
            try
            {
                i_Garage.fillAirInWheels(vehicleLicenseNumber);
                Console.WriteLine("Blow Air Succeeded!");
            }
            catch(Exception e)
            {
                Console.WriteLine("{0}{1}Cannot Blowing Air Pressure in Vehicle!{1}{2}{1}{0}", k_BreakLine, System.Environment.NewLine, e.Message);
            }
        }

        private static void fuelAVehicle(Garage i_Garage)
        {
            Console.WriteLine(" ===== Fuel A Regular Vehicle ==== ");
            string vehicleLicenseNumber = getAVehicleLicenseNumber(i_Garage);
            Console.WriteLine("-Please Type The Amount Of Fuel-");
            string amountToFill = getANumericString();
            Console.WriteLine("-Please Enter A Fuel Type: Octan95/Octan96/Octan98/Soler-");
            string fuelType = getNonEmptyString();
            try 
            {
               i_Garage.fuelVehicle(vehicleLicenseNumber, fuelType, amountToFill);
                Console.WriteLine("Fuel Vechile {0} Succeeded!", vehicleLicenseNumber);
            }
            catch (Exception e) 
            {
                Console.WriteLine("{0}{1}Cannot Fuel A Vehicle!{1}{2}{1}{0}", k_BreakLine, System.Environment.NewLine, e.Message);
            }
        }

        private static void rechargeAVehicle(Garage i_Garage)
        {
            Console.WriteLine(" ===== Recharge A Electric Vehicle ==== ");
            string vehicleLicenseNumber = getAVehicleLicenseNumber(i_Garage);
            Console.WriteLine("-Please Enter requested minutes to recharge the vehicle-");
            string minutesToCharge = getANumericString();
            try
            { 
                i_Garage.chargeVehicle(vehicleLicenseNumber, minutesToCharge);
                Console.WriteLine("Recharge Vehicle {0} in {1} minutes Succeeded!", vehicleLicenseNumber, minutesToCharge);
            }
            catch(Exception e)
            {
                Console.WriteLine("{0}{1}Cannot Recharge Vehicle {3}{1}{2}{1}{0}", k_BreakLine, System.Environment.NewLine, e.Message, vehicleLicenseNumber);
            }
        }

        private static void displayAVehicleDetails(Garage i_Garage)
        {
            string vehicleLicenseNumber = getAVehicleLicenseNumber(i_Garage);
            Console.WriteLine(" ===== Display All The Details Of A Certain Vechile ==== ");
            VehicleInRepair vehicleInGarage = i_Garage.getVehicleByLicenseNumber(vehicleLicenseNumber);
            System.Console.WriteLine(vehicleInGarage.ToString());
        }

        private static KnownVehicleTypes.eVehicleType chooseVechileToAdd()
        {
            char indexForMenu = '1';
            foreach (string vechileType in KnownVehicleTypes.r_KnownTypes)
            {
                Console.WriteLine("Press {0} - To Add New {1} To The Garage", indexForMenu, vechileType);
                indexForMenu++;
            }

            string userSelection = getANumericString();
            bool res = false;
            while(!res)
            {
                foreach (KnownVehicleTypes.eVehicleType type in Enum.GetValues(typeof(KnownVehicleTypes.eVehicleType)))
                {
                    if ((int)type == int.Parse(userSelection))
                    {
                        res = true;
                    }
                }
            }       

            return (KnownVehicleTypes.eVehicleType)int.Parse(userSelection);
        }

        private static string getAVehicleLicenseNumber(Garage i_Garage)
        {
            Console.WriteLine("-Please Type A License Number-");
            string vehicleLicenseNumber = getANumericString();
            while (!i_Garage.isLicenseNumberAlrdyExists(vehicleLicenseNumber))
            {
                Console.WriteLine("The Vehicle with the liecnse number {0}, is not exist", vehicleLicenseNumber);
                Console.WriteLine("Please Try Again!");
                vehicleLicenseNumber = getANumericString();
            }

            return vehicleLicenseNumber;
        }

        private static string getANumericString()
        {
            string inputStr = Console.ReadLine();
            while (inputStr.Length == 0 || !inputStr.All(char.IsDigit))
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

        private static string getAlphabeatString()
        {
            string inputStr = Console.ReadLine();
            while (!inputStr.All(char.IsLetter))
            {
                Console.WriteLine("Not A Alphabeat String, Please Try Again.");
                inputStr = Console.ReadLine();
            }

            return inputStr;
        }

        private static bool checkMenuSelection(string userSelection)
        {
            return userSelection.Length == 1 && char.Parse(userSelection) >= '1' && char.Parse(userSelection) <= '8';
        }
    }
}
