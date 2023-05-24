using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ex03.GarageLogic.MyEnums;

namespace Ex03.GarageLogic
{
    class Motorcycle : Vehicle
    {
        private eTypeOfLicense m_TypeOfLicense;
        private int m_EngineVolume;

        public Motorcycle(string i_EngineType)
        {
            int numOfWheels = 2;

            if(i_EngineType == "electric")
            {
                m_Engine = new ElectricEngine(2.6f);
            }
            else if(i_EngineType == "fuel")
            {
                m_Engine = new FuelEngine(6.4f, eTypesOfFuel.Octan98);
            }
            else
            {
                throw new ArgumentException();//CHANGE LATER FIX
            }

            for (int i = 0; i < numOfWheels; i++)
            {
                m_Wheels.Add(new Wheel(31));
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
                            + "[license type - string AA/A2/A1/B1]\n"
                            + "[engine volume - int]\n";

            return outputMessage;
        }

        public override List<Type> getListOfMemberTypesToFill()
        {
            return new List<Type>() { typeof(string), typeof(string), typeof(float), typeof(int), typeof(string), typeof(int) };
            //listOfElectricCarTypesToExpect.Add(String);
        }

        public override bool useInputsToRegisterVehicle(List<object> i_InputsFromUser)
        {
            bool isInputValid = true;
            string wheelsManufacturer = i_InputsFromUser[1] as string;
            float energyPercentageFloat = (float)i_InputsFromUser[2];
            int wheelsCurrentPressureInt = (int)i_InputsFromUser[3];
            string licenseTypeString = (i_InputsFromUser[4] as string).ToLower();
            int engineVolumeInt = (int)i_InputsFromUser[5];

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

            if (isInputValid)
            {
                isInputValid = convertStringToLicenseType(licenseTypeString, out m_TypeOfLicense);
            }

            if (isInputValid && (engineVolumeInt) >= 1 )
            {
                m_EngineVolume = engineVolumeInt;
            }
            else
            {
                isInputValid = false;
            }

            return isInputValid;
        }

        private bool convertStringToLicenseType(string i_LicenseTypeString, out eTypeOfLicense i_TypeOfLicense)
        {
            i_TypeOfLicense = eTypeOfLicense.A1;
            bool returnBool = true;

            i_LicenseTypeString = i_LicenseTypeString.ToUpper();
            if (i_LicenseTypeString == "A1" || i_LicenseTypeString == "A2" || i_LicenseTypeString == "AA" || i_LicenseTypeString == "B1")
            {
                if (i_LicenseTypeString == "AA")
                {
                    i_TypeOfLicense = eTypeOfLicense.AA;
                }
                if (i_LicenseTypeString == "A1")
                {
                    i_TypeOfLicense = eTypeOfLicense.A1;
                }
                if (i_LicenseTypeString == "A2")
                {
                    i_TypeOfLicense = eTypeOfLicense.A2;
                }
                if (i_LicenseTypeString == "B1")
                {
                    i_TypeOfLicense = eTypeOfLicense.B1;
                }
            }
            else
            {
                returnBool = false;
            }

            return returnBool;
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


            if (m_Engine is FuelEngine)
            {
                returnString += String.Format("Fuel Capacity In Liters: {0}\n"
                                              + "Type Of Fuel: {6}\n", (m_Engine as FuelEngine).FuelCapacityInLiters, (m_Engine as FuelEngine).TypeOfFuel);
            }

            else
            {
                returnString += String.Format("Maximum Battery Time In Hours: {0}\n", (m_Engine as ElectricEngine).MaximumBatteryTimeInHours);
            }

            return returnString;
        }
    }
}
