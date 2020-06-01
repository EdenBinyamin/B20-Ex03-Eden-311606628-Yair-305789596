﻿using System;
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