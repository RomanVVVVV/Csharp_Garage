using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ex03.GarageLogic.MyEnums;

namespace Ex03.GarageLogic
{

    public class GarageLogic
    {
        private Dictionary<string, VehicleInGarage> m_VehiclesInGarage = new Dictionary<string, VehicleInGarage>();

        public bool isThisVehicleInTheGarage(string licenseNumber)
        {
            return false;
        }

        public void setVehicleStatus(string i_LicenseNumber, eVehicleStatus i_Status)
        {
            m_Vehicles[i_LicenseNumber].VehicleStatus = i_Status;
        }
    }
}
