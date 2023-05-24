using Ex03.GarageLogic.MyEnums;
using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{

    public class GarageLogic
    {
        private Dictionary<string, VehicleInGarage> m_VehiclesInGarage = new Dictionary<string, VehicleInGarage>();
        
        public bool isThisVehicleInTheGarage(string licenseNumber)
        {
            return m_VehiclesInGarage.ContainsKey(licenseNumber);
        }

        public void setVehicleStatus(string i_LicenseNumber, eVehicleStatus i_Status)
        {
            m_VehiclesInGarage[i_LicenseNumber].VehicleStatus = i_Status;
        }

        public Vehicle createInstanceOfVehicle(int i_VehicleTypeNumber,string i_LicenseNumber)
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
                    returnVehicle = new Truck();//done
                    break;
                default:
                    throw new FormatException();//change, temporary
            }

            returnVehicle.LicenseNumber = i_LicenseNumber;

            return returnVehicle;
        }

        public void addVehicleToGarageDictionary(Vehicle i_NewVehicle, string i_OwnerPhoneNumber, string i_OwnerName)
        {
            VehicleInGarage newCarToAddToGarage = new VehicleInGarage(i_NewVehicle, i_OwnerPhoneNumber, i_OwnerName);
            m_VehiclesInGarage[i_NewVehicle.LicenseNumber] = newCarToAddToGarage;
        }

        public VehicleInGarage getVehicleInGarageByLicenseNumber(string i_LicenseNumber)
        {
            return m_VehiclesInGarage[i_LicenseNumber];
        }
    }
}
