using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B20_Ex03_Eden_311606628_Yair_305789596
{
    class Garage
    {
        List<VehicleInRepair> m_VehiclesInGarage;
        internal void addingNewVehicleToGarage(string i_OwnerName, string i_PhoneNumberOfOwner,
            Dictionary<KnownVehicleTypes.eDataType, string> i_DataMemory, 
            KnownVehicleTypes.eVehicleType i_VehicleType, EnergyType i_EnergyType)
        {
            m_VehiclesInGarage.Add(new VehicleInRepair(i_OwnerName, i_PhoneNumberOfOwner,
                                            i_DataMemory, i_VehicleType, i_EnergyType));
        }
        public bool isLicenseNumberAlrdyExists(string i_LicenseNumber)
        {
            bool res = false;
            foreach (VehicleInRepair vehicle in m_VehiclesInGarage)
            {
                if (vehicle.Vehicle.LicensePlate == i_LicenseNumber)
                {
                    res = true;
                    break;
                }
            }
            return res;
        }
    }

}
