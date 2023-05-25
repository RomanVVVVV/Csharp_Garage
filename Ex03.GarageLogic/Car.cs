using Ex03.GarageLogic.MyEnums;
using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    class Car : Vehicle
    {
        private eVehicleColor m_Color;

        private int m_NumOfDoors;

        public Car(string i_EngineType)
        {
            int numOfWheels = 5;

            if (i_EngineType == "electric")
            {
                m_Engine = new ElectricEngine(5.2f);
            }
            else if (i_EngineType == "fuel")
            {
                m_Engine = new FuelEngine(46f, eTypesOfFuel.Octan95);
            }
            else
            {
                throw new ArgumentException();
            }

            for (int i = 0; i < numOfWheels; i++)
            {
                m_Wheels.Add(new Wheel(33));
            }
        }

        public int NumOfDoors
        {
            get
            {
                return m_NumOfDoors;
            }
            set
            {
                m_NumOfDoors = value;
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
                            + "[car color - string white/black/yellow/red]\n"
                            + "[number of doors - int 2/3/4/5]\n";

            return outputMessage;
        }

        public override List<Type> getListOfMemberTypesToFill()
        {
            return new List<Type>() { typeof(string), typeof(string), typeof(float), typeof(int), typeof(string), typeof(int) };
            
        }

        public override bool useInputsToRegisterVehicle(List<object> i_InputsFromUser)
        {
            bool isInputValid = true;
            string wheelsManufacturer = i_InputsFromUser[1] as string;
            float energyPercentageFloat = (float)i_InputsFromUser[2];
            int wheelsCurrentPressureInt = (int)i_InputsFromUser[3];
            string colorString = (i_InputsFromUser[4] as string).ToLower();
            int numOfDoorsInt = (int)i_InputsFromUser[5];

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
                isInputValid = convertStringToColor(colorString, out m_Color);
            }

            if (isInputValid && (numOfDoorsInt) >= 2 && (numOfDoorsInt) <= 5)
            {
                NumOfDoors = numOfDoorsInt;
            }
            else
            {
                isInputValid = false;
            }

            return isInputValid;
        }

        private static bool convertStringToColor(string i_ColorString, out eVehicleColor returnColor)
        {
            returnColor = eVehicleColor.yellow;
            bool returnBool = true;
            if (i_ColorString == "yellow" || i_ColorString == "black" || i_ColorString == "white" || i_ColorString == "red")
            {
                if (i_ColorString == "yellow")
                {
                    returnColor = eVehicleColor.yellow;
                }
                if (i_ColorString == "black")
                {
                    returnColor = eVehicleColor.black;
                }
                if (i_ColorString == "white")
                {
                    returnColor = eVehicleColor.white;
                }
                if (i_ColorString == "red")
                {
                    returnColor = eVehicleColor.red;
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
                                              + "Type Of Fuel: {1}\n", (m_Engine as FuelEngine).FuelCapacityInLiters, (m_Engine as FuelEngine).TypeOfFuel.ToString());
            }

            else
            {
                returnString += String.Format("Maximum Battery Time In Hours: {0}\n", (m_Engine as ElectricEngine).MaximumBatteryTimeInHours);
            }

            return returnString;
        }
    }
}
