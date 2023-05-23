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

        public Vehicle createInstanceOfVehicle(int i_VehicleTypeNumber)
        {
            Vehicle returnVehicle=null;
            switch(i_VehicleTypeNumber)
            {
                case 1:
                    returnVehicle = new Car("fuel");
                    break;
                case 2:
                    returnVehicle = new Car("electric");
                    break;
                case 3:
                    returnVehicle = new Motorcycle("fuel");
                    break;
                case 4:
                    returnVehicle = new Motorcycle("electric");
                    break;
                case 5:
                    returnVehicle = new Truck();
                    break;
                default:
                    throw new FormatException();//change
            }

            return returnVehicle;
        }
    }
}
