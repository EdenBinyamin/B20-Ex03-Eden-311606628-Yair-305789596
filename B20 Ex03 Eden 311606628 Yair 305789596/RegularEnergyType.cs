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
            m_AmountOfLittersLeftInTank = i_AmountOfLittersInTank;
            m_FullTank = i_FullTank;
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
    }
}
