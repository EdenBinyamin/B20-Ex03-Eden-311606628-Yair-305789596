using System;
using System.Collections.Generic;

namespace B20_Ex03_Eden_311606628_Yair_305789596
{
    public class VehicleInRepair
    {
        private readonly Vehicle r_TypeOfVehicle;
        private string m_Owner;
        private string m_PhoneNumberOfOwner;

        public enum eVehicleCondition
        {
            inRepair,
            wasFixed,
            paidUp
        }

        internal eVehicleCondition m_VehicleCondition;

        internal VehicleInRepair(string i_OwnerName, string i_PhoneNumberOfOwner, List<string> i_DataMemory, KnownVehicleTypes.eVehicleType i_VehicleType)
        {
            r_TypeOfVehicle = KnownVehicleTypes.CreateVehicle(i_DataMemory, i_VehicleType);
            m_Owner = i_OwnerName;
            m_PhoneNumberOfOwner = i_PhoneNumberOfOwner;
            m_VehicleCondition = eVehicleCondition.inRepair;
        }

        public Vehicle Vehicle
        {
            get
            {
                return r_TypeOfVehicle;
            }
        }
        
        internal eVehicleCondition Condition
        {
            get
            {
                return m_VehicleCondition;
            }

            set
            {
                m_VehicleCondition = value;
            }
        }

        public override string ToString()
        {
            string vehicleInRepairDetails = "Owner name: " + m_Owner + System.Environment.NewLine;
            vehicleInRepairDetails += "Phone number: " + m_PhoneNumberOfOwner + System.Environment.NewLine;
            vehicleInRepairDetails += "Status: " + m_VehicleCondition.ToString() + System.Environment.NewLine;
            vehicleInRepairDetails += r_TypeOfVehicle.ToString();
            return vehicleInRepairDetails;
        }
    }
}
