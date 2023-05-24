using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ex03.GarageLogic.MyEnums;

namespace Ex03.GarageLogic
{
    public class VehicleInGarage
    {
        private Vehicle m_Vehicle;
        private string m_OwnerName;
        private string m_OwnerPhoneNumber;
        private MyEnums.eVehicleStatus m_vehicleStatus;

        public MyEnums.eVehicleStatus VehicleStatus
        {
            get
            {
                return m_vehicleStatus;
            }
            set
            {
                m_vehicleStatus = value;
            }
        }

        public VehicleInGarage(Vehicle i_Vehicle, string i_OwnerPhoneNumber, string i_OwnerName)
        {
            m_Vehicle = i_Vehicle;
            m_OwnerPhoneNumber = i_OwnerPhoneNumber;
            m_OwnerName = i_OwnerName;
        }

        public string displayAllData()
        {
            string returnString;

            returnString = String.Format("Owner Name : {0}\n"
                                         + "Owner Phone Number: {1}\n"
                                         + "Staus: {2}\n", m_OwnerName, m_OwnerPhoneNumber, m_vehicleStatus);

            returnString += m_Vehicle.displayAllData();

            return returnString;
        }
    }
}
