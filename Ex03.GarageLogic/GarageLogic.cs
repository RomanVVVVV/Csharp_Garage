using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ex03.GarageLogic.MyEnums;

namespace Ex03.GarageLogic
{

    public class GarageLogic
    {
        private Dictionary<string, Vehicle> m_Vehicles = new Dictionary<string, Vehicle>();

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
