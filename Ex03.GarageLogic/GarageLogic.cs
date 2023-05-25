using Ex03.GarageLogic.MyEnums;
using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{

    public class GarageLogic
    {
        private Dictionary<string, VehicleInGarage> m_VehiclesInGarage = new Dictionary<string, VehicleInGarage>();


        public Dictionary<string, VehicleInGarage> VehiclesInGarage
        {
            get => m_VehiclesInGarage;
            set => m_VehiclesInGarage = value;
        }

        public bool isThisVehicleInTheGarage(string licenseNumber)
        {
            return m_VehiclesInGarage.ContainsKey(licenseNumber);
        }

        public void setVehicleStatus(string i_LicenseNumber, eVehicleStatus i_Status)
        {
            m_VehiclesInGarage[i_LicenseNumber].VehicleStatus = i_Status;
        }

        public Vehicle createInstanceOfVehicle(int i_VehicleTypeNumber, string i_LicenseNumber)
        {
            Vehicle returnVehicle = null;
            switch (i_VehicleTypeNumber)
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

        public VehicleInGarage GetVehicleInGarage(string licenseNum)
        {
            return m_VehiclesInGarage[licenseNum];
        }

        public void removeVehicle(string i_LicenseNumber)
        {
            m_VehiclesInGarage.Remove(i_LicenseNumber);
        }

        public void updateStatus(string i_LicenseNumber, eVehicleStatus i_UserChoiceEnum)
        {
            m_VehiclesInGarage[i_LicenseNumber].VehicleStatus = i_UserChoiceEnum;
        }

        public bool checkFuelAmountCompatability(float i_InputAmount, string i_LicenseNumber)
        {
            return m_VehiclesInGarage[i_LicenseNumber].checkFuelAmountCompatability(i_InputAmount);
        }

        public void updateVehicleFuelAmount(float i_FuelAmountToAdd, string i_LicenseNumber)
        {
            m_VehiclesInGarage[i_LicenseNumber].updateVehicleFuelAmount(i_FuelAmountToAdd);
        }

        public bool checkIfFuelCompatibleWithVehicle(eTypesOfFuel i_TypeOfFuel, string i_LicenseNumber)
        {
            return m_VehiclesInGarage[i_LicenseNumber].getTypeOfFuel() == i_TypeOfFuel;
        }

        public bool checkEnergyAmountCompatability(int i_MinutesToAdd, string i_LicenseNumber)
        {
            return m_VehiclesInGarage[i_LicenseNumber].checkEnergyAmountCompatability(i_MinutesToAdd);
        }

        public void updateVehicleBatteryAmount(int i_MinutesToAdd, string i_LicenseNumber)
        {
            m_VehiclesInGarage[i_LicenseNumber].updateVehicleEnergyAmount(i_MinutesToAdd);
        }
    }
}
