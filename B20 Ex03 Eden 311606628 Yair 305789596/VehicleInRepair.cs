using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B20_Ex03_Eden_311606628_Yair_305789596
{
    class VehicleInRepair
    {
        private Vehicle m_TypeOfVehicle;
        private string m_Owner;
        private string m_PhoneNumberOfOwner;
        enum VehicleCondition
        {
            inRepair,
            wasFixed,
            paidUp
        }
        private VehicleCondition m_VehicleCondition;
    }
}
