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
            if(i_AmountOfLittersInTank > i_FullTank)
            {
                throw new ValueOutOfRangeException(0, i_FullTank, "litters left in the tank is bigger than the tank itself");
            }
            m_AmountOfLittersLeftInTank = i_AmountOfLittersInTank;
            m_FullTank = i_FullTank;
        }
        public void fuel(float i_Litters)
        {
            if (m_AmountOfLittersLeftInTank + i_Litters > m_FullTank)
            {
                throw new ValueOutOfRangeException(0, m_FullTank - m_AmountOfLittersLeftInTank, "You can't fuel more litters then the tank can has");
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
                throw new FormatException("Unknown Fuel Type");
            }
            return fuelType;
        }

        public override float currentEneregy
        {
            get
            {
                return m_AmountOfLittersLeftInTank;
            }
        }
        public override float maxEnergy
        {
            get
            {
                return m_FullTank;
            }
        }

        public override string ToString()
        {
            string regularEnergyTypeDetails = "Fuel type: " + m_FuleType.ToString() + System.Environment.NewLine;
            regularEnergyTypeDetails += "Full tank: " + m_FullTank.ToString() + System.Environment.NewLine;
            regularEnergyTypeDetails += "Litters left in tank: " + m_AmountOfLittersLeftInTank.ToString() + System.Environment.NewLine;
            return regularEnergyTypeDetails;
        }
    }
}
