using System;

namespace B20_Ex03_Eden_311606628_Yair_305789596
{
    public class RegularEnergyType : EnergyType
    {
        public enum FuelType
        {
            Soler,
            Octan95,
            Octan96,
            Octan98
        }
        public FuelType m_FuleType;
        internal float m_AmountOfLittersLeftInTank;
        internal float m_FullTank;

        internal RegularEnergyType(FuelType i_FuelType,
            float i_AmountOfLittersInTank,
                    float i_FullTank)
        {
            m_FuleType = i_FuelType;
            if (m_AmountOfLittersLeftInTank < i_AmountOfLittersInTank)
            {
                m_AmountOfLittersLeftInTank = i_AmountOfLittersInTank;
            }
            else
            {
                throw new ArgumentException("There are more litter in the tank than the maximum capabailty of it");
            }
            m_FullTank = i_FullTank;
        }

        public static FuelType FuelTypeParse(string i_FuelType)
        {
            FuelType type;
            if (i_FuelType == "Octan95")
            {
                type = FuelType.Octan95;
            }
            else if (i_FuelType == "Octan96")
            {
                type = FuelType.Octan96;
            }
            else if (i_FuelType == "Octan98")
            {
                type = FuelType.Octan98;
            }
            else if(i_FuelType == "Soler")
            {
                type = FuelType.Soler;
            }
            else
            {
                throw new ArgumentException("Wrong type of fuel!");
            }
            return type;
        }



        public void fuel(float i_Litters)
        {
            if (m_AmountOfLittersLeftInTank + i_Litters > m_FullTank)
            {
                throw new ValueOutOfRangeException(0, m_FullTank - m_AmountOfLittersLeftInTank);
            }
            else
            {
                m_AmountOfLittersLeftInTank += i_Litters;
            }
            
        }

        internal static FuelType ParseFuelType(string i_FuelType)
        {
            i_FuelType = i_FuelType.Trim();
            i_FuelType = i_FuelType.ToUpper();
            FuelType fuelType;          
            if (i_FuelType == "OCTAN98")
            {
                fuelType = FuelType.Octan98;
            }
            else if (i_FuelType == "OCTAN95")
            {
                fuelType = FuelType.Octan95;
            }
            else if(i_FuelType== "OCTAN96")
            {
                fuelType = FuelType.Octan96;
            }
            else if(i_FuelType == "SOLER")
            {
                fuelType = FuelType.Soler;
            }
            else
            {
                throw new ArgumentException("Known Fuel Type");
            }
            return fuelType;
        }
    }
}
