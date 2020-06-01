using System;
using System.Collections.Generic;

namespace B20_Ex03_Eden_311606628_Yair_305789596
{
    public class VehicleInRepair
    {
        private Vehicle m_TypeOfVehicle;
        private string m_Owner;
        private string m_PhoneNumberOfOwner;
        public enum VehicleCondition
        {
            inRepair,
            wasFixed,
            paidUp
        }
        internal VehicleCondition m_VehicleCondition;
        internal VehicleInRepair(string i_OwnerName, string i_PhoneNumberOfOwner,
            Dictionary<KnownVehicleTypes.eDataType,string> i_DataMemory, Dictionary<Vehicle.WheelData, string> i_Wheel,
            KnownVehicleTypes.eVehicleType i_VehicleType, EnergyType i_EnergyType)
        {
            m_TypeOfVehicle = KnownVehicleTypes.CreateVehicle(i_DataMemory, i_Wheel, i_VehicleType, i_EnergyType);
            m_Owner = i_OwnerName;
            m_PhoneNumberOfOwner = i_PhoneNumberOfOwner;
            m_VehicleCondition = VehicleCondition.inRepair;
        }

        public Vehicle Vehicle
        {
            get
            {
                return m_TypeOfVehicle;
            }
        }
        
        internal VehicleCondition Condition
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

    }
}
