using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B20_Ex03_Eden_311606628_Yair_305789596
{
    public class Car : Vehicle
    { 
        public enum Color
        {
            Red,
            White,
            Black,
            Silver
        }
        private Color m_Color;
        private int m_NumOfDoors;

        internal Car(Color i_Color, int i_NumOfDoors, string i_Model, string i_LicensePlate,
            float i_Percentage, Dictionary<Vehicle.WheelData, string> i_Wheel, EnergyType i_EnergyType)
            : base(i_Model, i_LicensePlate, i_Percentage, 4, i_Wheel, i_EnergyType)
        {
            m_Color = i_Color;
            m_NumOfDoors = i_NumOfDoors;
        }

        public static Color colorParse(string i_Color)
        {
            Color color;
            if (i_Color == "Red")
            {
                color = Color.Red;
            }
            else if (i_Color == "White")
            {
                color = Color.White;
            }
            else if (i_Color == "Black")
            {
                color = Color.Black;
            }
            else if (i_Color == "Silver")
            {
                color = Color.Silver;
            }
            else
            {
                throw new ArgumentException("Wrong known color");
            }
            return color;
        }
    }
}
