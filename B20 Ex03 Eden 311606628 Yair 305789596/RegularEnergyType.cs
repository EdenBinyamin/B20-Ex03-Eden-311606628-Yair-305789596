using System;

namespace B20_Ex03_Eden_311606628_Yair_305789596
{
    class RegularEnergyType : EnergyType
    {
        internal enum FuelType
        {
            Soler,
            Octan95,
            Octan96,
            Octan98
        }
        internal FuelType m_FuleType;
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
        public void fuel (float i_Litters)
        {
            
        }
    }
}
