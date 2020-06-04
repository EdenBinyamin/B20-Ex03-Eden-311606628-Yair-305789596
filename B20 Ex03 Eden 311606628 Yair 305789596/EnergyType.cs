using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B20_Ex03_Eden_311606628_Yair_305789596
{
    public abstract class EnergyType
    {
        public enum eEnergyType
        {
            Regular = 1,
            Electric
        }

        public abstract float currentEneregy
        {
            get;
        }
        
        public abstract float maxEnergy
        {
            get;
        }
    }
}
