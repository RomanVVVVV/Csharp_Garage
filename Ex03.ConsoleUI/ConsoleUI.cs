using Ex03.GarageLogic;
using Ex03.GarageLogic.MyEnums;
using System;
using System.Collections.Generic;


namespace Ex03.ConsoleUI
{
    class ConsoleUI
    {
        private Ex03.GarageLogic.GarageLogic m_garageLogic = new Ex03.GarageLogic.GarageLogic();
        public void garageProcess()
        {
            bool userWishesToExit = false;
            eUserMainMenuAction userChoice;

            while (userWishesToExit == false)
            {
                diplayGarageMenu();
                userChoice = (eUserMainMenuAction)getInput(1, 8);//while not valid

                if (userChoice == eUserMainMenuAction.insertNewVehicle)
                {
                    insertNewVehicleUI();
                }
                else if (userChoice == eUserMainMenuAction.displayListOfLicenseNumbers)
                {
                    displayListOfLicenseNumbersUI();
                }
                else if (userChoice == eUserMainMenuAction.changeStatusOfVehicle)
                {
                    changeStatusOfVehicleUI();
                }
                else if (userChoice == eUserMainMenuAction.inflateWheelsOfVehicle)
                {
                    inflateWheelsOfVehicleUI();
                }
                else if (userChoice == eUserMainMenuAction.refuelVehicle)
                {
                    refuelVehicleUI();
                }
                else if (userChoice == eUserMainMenuAction.chargeVehicle)
                {
                    chargeVehicleUI();
                }
                else if (userChoice == eUserMainMenuAction.displayDataOfVehicle)
                {
                    displayDataOfVehicleUI();
                }
                else if (userChoice == eUserMainMenuAction.exitProgram)
                {
                    userWishesToExit = true;
                    continue;
                }
                pressEnterToReturnToMainMenu();
            }
        }

        private void chargeVehicleUI()
        {
            bool isSuccessfulOperation = false;
            string licenseNumber;
            int minutesToAdd;
            eTypesOfFuel typeOfFuel;

            if (inputLicenseAndCheckIfVehicleInGarage(out licenseNumber))
            {
                if (m_garageLogic.VehiclesInGarage[licenseNumber].getEngineType() == "electric")
                {
                    if (inputAndCheckEnergyAmount(out minutesToAdd, licenseNumber))
                    {
                        m_garageLogic.updateVehicleBatteryAmount(minutesToAdd, licenseNumber);
                        isSuccessfulOperation = true;
                    }
                }
            }
            if (isSuccessfulOperation)
            {
                Console.WriteLine("Successful operation!");
            }
            else
            {
                Console.WriteLine("unSuccessful operation!");
            }
        }

        private bool inputAndCheckEnergyAmount(out int i_MinutesToAdd, string i_LicenseNumber)
        {
            i_MinutesToAdd = 0;
            Console.WriteLine("enter amount of fuel to add:");
            i_MinutesToAdd = int.Parse(Console.ReadLine());

            return m_garageLogic.checkEnergyAmountCompatability(i_MinutesToAdd, i_LicenseNumber);
        }

        private void changeStatusOfVehicleUI()
        {
            string licenseNumber;
            bool carIsInGarage = false;
            int userChoice;
            eVehicleStatus userChoiceEnum;

            Console.Clear();
            Console.WriteLine("Please insert license number.");
            licenseNumber = Console.ReadLine();
            carIsInGarage = m_garageLogic.isThisVehicleInTheGarage(licenseNumber);
            if (carIsInGarage == false)//add  car 
            {
                Console.Clear();
                Console.WriteLine("This vehicle is not in the garage.");
            }
            else
            {
                Console.WriteLine("please enter desired status to change to (enter 1-under repair/2-finished repair/3-paid and press ENTER):");
                userChoice = getInput(1, 3);
                userChoiceEnum = (eVehicleStatus)(userChoice - 1);
                if (userChoiceEnum == eVehicleStatus.paid)
                {
                    m_garageLogic.removeVehicle(licenseNumber);
                }
                else
                {
                    m_garageLogic.updateStatus(licenseNumber, userChoiceEnum);
                }
                Console.WriteLine("Update successful.");
            }
        }

        private void inflateWheelsOfVehicleUI()
        {
            string licenseNumber;
            bool carIsInGarage = false;

            Console.Clear();
            Console.WriteLine("Please insert license number.");
            licenseNumber = Console.ReadLine(); // maybe check input ?
            carIsInGarage = m_garageLogic.isThisVehicleInTheGarage(licenseNumber);
            if (carIsInGarage == false)//add  car 
            {
                Console.Clear();
                Console.WriteLine("This vehicle is not in the garage.");
            }
            else
            {
                foreach (Wheel wheel in m_garageLogic.GetVehicleInGarage(licenseNumber).getWheels())
                {
                    wheel.CurrentAirPressure = wheel.MaxAirPressure;
                }
                Console.WriteLine("wheels have been infalted.");
            }
        }

        private void displayListOfLicenseNumbersUI()
        {
            int input;
            Console.Clear();
            Dictionary<string, VehicleInGarage>.KeyCollection keys = m_garageLogic.VehiclesInGarage.Keys;

            Console.WriteLine("Please choose what status of cars you would like to see: 1 - underRepair 2 - finishedRepair");
            input = getInput(1, 2);
            foreach (string key in keys)
            {
                if(input == 1 && m_garageLogic.VehiclesInGarage[key].VehicleStatus == eVehicleStatus.underRepair)
                {
                    Console.WriteLine(key);
                }
                if (input == 2 && m_garageLogic.VehiclesInGarage[key].VehicleStatus == eVehicleStatus.finishedRepair)
                {
                    Console.WriteLine(key);
                }
            }
        }

        private void pressEnterToReturnToMainMenu()
        {
            Console.WriteLine("press ENTER to return to main menu");
            Console.ReadLine();
            Console.Clear();
        }

        private void diplayGarageMenu()
        {
            Console.Clear();
            Console.WriteLine("Choose action:");
            Console.WriteLine("1. Insert new car to garage.");
            Console.WriteLine("2. Display list of license numbers of the vehicles in the garage.");
            Console.WriteLine("3. Change the status of a vehicle in the garage.");
            Console.WriteLine("4. Inflate wheels pressure to the maximum.");
            Console.WriteLine("5. Refuel a fuel driven vehicle.");
            Console.WriteLine("6. Charge an electric vehicle.");
            Console.WriteLine("7. Display all vehicle data by license number.");
            Console.WriteLine("8. Close menu.");
        }


        private void insertNewVehicleUI()
        {
            string licenseNumber;
            bool carIsInGarage = false;

            Console.Clear();
            Console.WriteLine("Please insert license number.");
            licenseNumber = Console.ReadLine(); // maybe check input ?
            carIsInGarage = m_garageLogic.isThisVehicleInTheGarage(licenseNumber);
            if (carIsInGarage == false)//add  car 
            {
                addVehicleUI(licenseNumber);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("This vehicle is already in the garage.");
                m_garageLogic.setVehicleStatus(licenseNumber, eVehicleStatus.underRepair);
            }
        }

        private void displayDataOfVehicleUI()
        {
            bool isVehicleInGarage = false;
            string licenseNumber;
            VehicleInGarage selectedVehicle;

            isVehicleInGarage = inputLicenseAndCheckIfVehicleInGarage(out licenseNumber);
            if (isVehicleInGarage)
            {
                selectedVehicle = m_garageLogic.getVehicleInGarageByLicenseNumber(licenseNumber);
                Console.WriteLine(selectedVehicle.displayAllData());
            }
        }

        private bool inputLicenseAndCheckIfVehicleInGarage(out string i_LicenseNumber)
        {
            bool carIsInGarage = false;

            Console.Clear();
            Console.WriteLine("Please insert license number.");
            i_LicenseNumber = Console.ReadLine();
            carIsInGarage = m_garageLogic.isThisVehicleInTheGarage(i_LicenseNumber);
            if (carIsInGarage == false)//add  car 
            {
                Console.Clear();
                Console.WriteLine("This vehicle is not in the garage.");
            }

            return carIsInGarage;
        }

        private void printVehicleOptions()
        {
            Console.WriteLine("Please enter a valid vehicle type:");
            Console.WriteLine("1 - Fuel car ");
            Console.WriteLine("2 - Electric car");
            Console.WriteLine("3 - Fuel motorcycle");
            Console.WriteLine("4 - Electric motorcycle");
            Console.WriteLine("5 - Fuel truck");
        }

        private void addVehicleUI(string i_LicenseNumber)
        {
            bool inputSuccessful = false;
            int vehicleTypeNumber = 2;//change to -1 later
            Vehicle newVehicle;
            string ownerPhoneNumber;
            string ownerName;
            int firstOption = 1;
            int lastOption = 5;

            printVehicleOptions();
            vehicleTypeNumber = getInput(firstOption, lastOption);
            newVehicle = m_garageLogic.createInstanceOfVehicle(vehicleTypeNumber, i_LicenseNumber);
            inputSuccessful = fillOutVehicleDataFromUser(newVehicle);
            if (inputSuccessful)
            {
                readPhoneNumberAndName(out ownerPhoneNumber, out ownerName);
                m_garageLogic.addVehicleToGarageDictionary(newVehicle, ownerPhoneNumber, ownerName);

                Console.WriteLine("Vehicle added successfully to garage!");//format
            }
            else
            {
                Console.WriteLine("Vehicle input unsuccessful, you can try again.\n");
            }
        }

        private bool fillOutVehicleDataFromUser(Vehicle i_NewVehicle)
        {
            bool isRegistrationSuccessful = false;
            string input;
            List<object> inputsFromUser = new List<object>();
            string displayMessageToUser = i_NewVehicle.getDescriptionOfTypesToInput();
            List<Type> listOfMemberTypes = i_NewVehicle.getListOfMemberTypesToFill();

            Console.Clear();
            Console.Write(displayMessageToUser);
            for (int i = 0; i < listOfMemberTypes.Count; i++)
            {
                input = Console.ReadLine();
                inputsFromUser.Add(parseFromStringToType(listOfMemberTypes[i], input));
            }

            isRegistrationSuccessful = i_NewVehicle.useInputsToRegisterVehicle(inputsFromUser);

            return isRegistrationSuccessful;
        }

        private object parseFromStringToType(Type i_Type, string i_Input)//add checks and stuff
        {
            return Convert.ChangeType(i_Input, i_Type);
        }

        private int getInput(int i_FirstOption, int i_LastOption)//change ?
        {
            int choice;
            bool isNumber;
            bool? validInputInserted = null;
            string userInput = null;

            userInput = Console.ReadLine();
            isNumber = int.TryParse(userInput, out choice);
            if (isNumber == true)
            {
                validInputInserted = (choice <= i_LastOption) && (choice >= i_FirstOption);
                if (validInputInserted.GetValueOrDefault() == false)
                {
                    throw new ValueOutRangeException(new Exception(), i_FirstOption, i_LastOption);
                }
            }
            else
            {
                throw new FormatException();
            }

            return choice;
        }

        private void readPhoneNumberAndName(out string i_OwnerPhoneNumber, out string i_OwnerName)
        {
            Console.Clear();
            Console.WriteLine("Please enter your name");
            i_OwnerName = Console.ReadLine();
            Console.WriteLine("Please enter your phone number");
            i_OwnerPhoneNumber = Console.ReadLine();
        }

        private void refuelVehicleUI()
        {
            string licenseNumber;
            bool isSuccessfulOperation = false;
            bool isTypeOfFuelCompatible = false;
            float quantityToFill;
            float fuelAmountToAdd;
            eTypesOfFuel typeOfFuel;

            
            if (inputLicenseAndCheckIfVehicleInGarage(out licenseNumber))
            {
                if (m_garageLogic.VehiclesInGarage[licenseNumber].getEngineType() == "fuel")
                {
                    if (inputAndCheckTypeOfFuel(out typeOfFuel, licenseNumber))
                    {
                        if (inputAndCheckFuelAmount(out fuelAmountToAdd, licenseNumber))
                        {
                            m_garageLogic.updateVehicleFuelAmount(fuelAmountToAdd, licenseNumber);
                            isSuccessfulOperation = true;
                        }
                    }
                }
            }

            if(isSuccessfulOperation)
            {
                Console.WriteLine("Successful operation!");
            }
            else
            {
                Console.WriteLine("unSuccessful operation!");
            }
        }

        private bool inputAndCheckFuelAmount(out float i_FuelAmountToAdd, string i_LicenseNumber)
        {
            i_FuelAmountToAdd = 0;
            Console.WriteLine("enter amount of fuel to add:");
            i_FuelAmountToAdd = float.Parse(Console.ReadLine());

            return m_garageLogic.checkFuelAmountCompatability(i_FuelAmountToAdd, i_LicenseNumber);
        }

        private bool inputAndCheckTypeOfFuel(out eTypesOfFuel o_TypeOfFuel, string i_licenseNumber)
        {
            int userChoice;

            Console.Clear();
            Console.WriteLine(
                "Please choose type of fuel: 1 - Octan98 2 - Octan96 3 - Octan95 4 - Soler \n"
                + "Type 1/2/3/4 and press ENTER");
            userChoice = getInput(1, 4);
            o_TypeOfFuel = (eTypesOfFuel)(userChoice - 1);

            return m_garageLogic.checkIfFuelCompatibleWithVehicle(o_TypeOfFuel, i_licenseNumber);
        }
    }
}
