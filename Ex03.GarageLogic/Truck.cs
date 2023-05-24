using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ex03.GarageLogic.MyEnums;

namespace Ex03.GarageLogic
{
    class Truck : Vehicle
    {
        private bool m_DeliveringDangerousMaterials;
        private float m_CargoVolume;

        public Truck()
        {
            int numOfWheels = 14;
            m_Engine = new FuelEngine(135, eTypesOfFuel.Soler);
            
            for(int i = 0; i < numOfWheels; i++)
            {
                m_Wheels.Add(new Wheel(26));
            }
        }

        public override string getDescriptionOfTypesToInput()
        {
            string outputMessage;

            outputMessage = "Please enter the following data (after each input press ENTER):\n"
                            + "[model name - string]\n"
                            + "[wheels manufacturer - string]\n"
                            + "[energy percentage - float from 0 to 1]\n"
                            + "[wheels current pressure - int from 0 to 33]\n"
                            + "[is carrying hazardous material - 1 for yes 0 for no]\n"
                            + "[cargo volume - float]\n";

            return outputMessage;
        }

        public override List<Type> getListOfMemberTypesToFill()
        {
            return new List<Type>() { typeof(string), typeof(string), typeof(float), typeof(int), typeof(int), typeof(float) };
            //listOfElectricCarTypesToExpect.Add(String);
        }

        public override bool useInputsToRegisterVehicle(List<object> i_InputsFromUser)
        {
            bool isInputValid = true;
            string wheelsManufacturer = i_InputsFromUser[1] as string;
            float energyPercentageFloat = (float)i_InputsFromUser[2];
            int wheelsCurrentPressureInt = (int)i_InputsFromUser[3];
            int hazardousMaterialInt = (int)(i_InputsFromUser[4]);
            float cargoVolumeFloat = (float)i_InputsFromUser[5];

            m_ModelName = i_InputsFromUser[0] as string;

            if (isInputValid && (energyPercentageFloat) >= 0 && (energyPercentageFloat) <= 1)
            {
                m_Engine.EnergyPercentage = energyPercentageFloat;
            }
            else
            {
                isInputValid = false;
            }

            if (isInputValid && (wheelsCurrentPressureInt) >= 0 && (wheelsCurrentPressureInt) <= m_Wheels[0].MaxAirPressure)
            {
                foreach (Wheel wheel in m_Wheels)
                {
                    wheel.CurrentAirPressure = wheelsCurrentPressureInt;
                    wheel.ManufacturerName = wheelsManufacturer;
                }
            }
            else
            {
                isInputValid = false;
            }

            if (isInputValid && ((hazardousMaterialInt) == 0 || (hazardousMaterialInt) == 1))
            {
                foreach (Wheel wheel in m_Wheels)
                {
                    wheel.CurrentAirPressure = wheelsCurrentPressureInt;
                    wheel.ManufacturerName = wheelsManufacturer;
                }
            }
            else
            {
                isInputValid = false;
            }


            if (isInputValid && (cargoVolumeFloat) >0)
            {
                m_CargoVolume = cargoVolumeFloat;
            }
            else
            {
                isInputValid = false;
            }

            return isInputValid;
        }

        public override string displayAllData()
        {
            throw new NotImplementedException();
        }

        public override string displayAllData()
        {
            string returnString;

            returnString = String.Format("Model Name: {0}\n"
                                         + "License Numer: {1}\n"
                                         + "Wheels Manufacturer Name: {2}\n"
                                         + "Wheels Current Air Pressure: {3}\n"
                                         + "Wheels Max Air Pressure: {4}\n"
                                         + "Car Color: {5}\n"
                                         + "Number Of Doors: {6}\n", m_ModelName, m_LicenseNumber, m_Wheels[0].ManufacturerName, m_Wheels[0].CurrentAirPressure, m_Wheels[0].MaxAirPressure, m_Color, m_NumOfDoors);

            returnString += String.Format("Fuel Capacity In Liters: {0}\n" 
                                          + "Type Of Fuel: {1}\n", (m_Engine as FuelEngine).FuelCapacityInLiters, (m_Engine as FuelEngine).TypeOfFuel);

            returnString += String.Format("Is Delivering Dangerous Materials? {0}\n"
                                          + "Cargo Volume: {1}\n", (m_Engine as FuelEngine).FuelCapacityInLiters, (m_Engine as FuelEngine).TypeOfFuel);

            return returnString;
        }
    }
}
