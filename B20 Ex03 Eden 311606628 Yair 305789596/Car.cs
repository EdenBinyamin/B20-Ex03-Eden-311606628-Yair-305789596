using System;
using System.Collections.Generic;

namespace B20_Ex03_Eden_311606628_Yair_305789596
{
    public class Car : Vehicle
    {
        public enum eColorType
        {
            Red,
            White,
            Black,
            Silver
        }
        private eColorType m_Color;
        private int m_NumOfDoors;

        internal Car(eColorType i_Color, int i_NumOfDoors, string i_Model, string i_LicensePlate,
            Dictionary<Vehicle.WheelData, string> i_Wheel, EnergyType i_EnergyType)
            : base(i_Model, i_LicensePlate, 4, i_Wheel, i_EnergyType)
        {
            m_Color = i_Color;
            m_NumOfDoors = i_NumOfDoors;
        }

        public static int DoorNumbersParse(string i_NumOfDoors)
        {
            int numOfDoors;
            bool res = int.TryParse(i_NumOfDoors, out numOfDoors);
            if(!res)
            {
                throw new FormatException("Not A Valid Number");
            }
            if(numOfDoors < 2 || numOfDoors > 5)
            {
                throw new ValueOutOfRangeException(2, 5,"Wrong number of doors. only 2 to 5 numbers of doors are allowed");
            }
            return numOfDoors;
        }

        public static eColorType ColorParse(string i_Color)
        {
            i_Color = i_Color.Trim();
            i_Color = i_Color.ToUpper();
            eColorType color;
            if (i_Color == "RED")
            {
                color = eColorType.Red;
            }
            else if (i_Color == "WHITE")
            {
                color = eColorType.White;
            }
            else if (i_Color == "BLACK")
            {
                color = eColorType.Black;
            }
            else if (i_Color == "SILVER")
            {
                color = eColorType.Silver;
            }
            else
            {
                throw new FormatException("Wrong Known Color");
            }
            return color;
        }
        public override string ToString()
        {
            string carDetails = base.ToString();
            carDetails += "Car color: " + m_Color.ToString() + System.Environment.NewLine;
            carDetails += "Number of doors: " + m_NumOfDoors.ToString() + System.Environment.NewLine;
            return carDetails;
        }
    }
}
