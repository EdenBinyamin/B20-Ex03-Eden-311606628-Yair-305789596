using System;

namespace B20_Ex03_Eden_311606628_Yair_305789596
{
    public abstract class EnergyType
    {
        public enum eEnergyType
        {
            Regular = 1,
            Electric
        }

        public abstract float CurrentEneregy
        {
            get;
        }

        public abstract float MaxEnergy
        {
            get;
        }
    }
}
