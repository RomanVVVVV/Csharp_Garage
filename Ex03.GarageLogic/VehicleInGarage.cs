using Ex03.GarageLogic.MyEnums;
using System;
using System.Collections.Generic;

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

            returnString = String.Format(
                "Owner Name : {0}\n" + "Owner Phone Number: {1}\n" + "Staus: {2}\n",
                m_OwnerName,
                m_OwnerPhoneNumber,
                m_vehicleStatus);

            returnString += m_Vehicle.displayAllData();

            return returnString;
        }

        public IEnumerable<Wheel> getWheels()
        {
            return m_Vehicle.Wheels;
        }

        public bool checkFuelAmountCompatability(float i_InputAmount)
        {
            FuelEngine fuelEngine = m_Vehicle.Engine as FuelEngine;
            float currentEnergyPercentage = fuelEngine.EnergyPercentage;
            return fuelEngine.checkFuelAmountCompatability(i_InputAmount, currentEnergyPercentage);
        }

        public void updateVehicleFuelAmount(float i_FuelAmountToAdd)
        {
            FuelEngine fuelEngine = m_Vehicle.Engine as FuelEngine;
            float fuelCapacityInLiters = fuelEngine.FuelCapacityInLiters;
            float currentEnergyPercentage = m_Vehicle.Engine.EnergyPercentage;
            float currentEnergyInLiters = fuelCapacityInLiters * currentEnergyPercentage;
            float currentEnergyInLitersAfterAdd = currentEnergyInLiters + i_FuelAmountToAdd;

            m_Vehicle.Engine.EnergyPercentage = currentEnergyInLitersAfterAdd / fuelCapacityInLiters;
        }

        public string getEngineType()
        {
            if (m_Vehicle.Engine is ElectricEngine)
            {
                return "electric";
            }
            if (m_Vehicle.Engine is FuelEngine)
            {
                return "fuel";
            }
            else
            {
                throw new FormatException();
            }
        }

        public eTypesOfFuel getTypeOfFuel()
        {
            return (m_Vehicle.Engine as FuelEngine).TypeOfFuel;
        }

        public bool checkEnergyAmountCompatability(int i_MinutesToAdd)
        {
            ElectricEngine electricEngine = m_Vehicle.Engine as ElectricEngine;
            float currentEnergyPercentage = electricEngine.EnergyPercentage;
            return electricEngine.checkEnergyAmountCompatability(i_MinutesToAdd, currentEnergyPercentage);
        }

        public void updateVehicleEnergyAmount(int i_MinutesToAdd)
        {
            ElectricEngine electricEngine = m_Vehicle.Engine as ElectricEngine;
            float maxHours = electricEngine.MaximumBatteryTimeInHours;
            float currentEnergyPercentage = m_Vehicle.Engine.EnergyPercentage;
            float currentEnergyInHours = maxHours * currentEnergyPercentage;
            float currentEnergyInHoursAfterAdd = currentEnergyInHours + i_MinutesToAdd / 60;

            m_Vehicle.Engine.EnergyPercentage = currentEnergyInHoursAfterAdd / maxHours;
        }
    }
}
