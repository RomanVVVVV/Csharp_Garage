using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ex03.GarageLogic.MyEnums;
using Ex03.GarageLogic;


namespace Ex03.ConsoleUI
{
    class ConsoleUI
    {
        private Ex03.GarageLogic.GarageLogic m_garageLogic = new Ex03.GarageLogic.GarageLogic();
        public void garageProcess()
        {
            bool userWishesToExit = false;
            eUserMainMenuAction userChoice; 

            while(userWishesToExit==false)
            {
                diplayGarageMenu();
                userChoice = (eUserMainMenuAction)getInput(1,8);//while not valid
                
                //userChoice = eUserMainMenuAction.insertNewVehicle;

                if(userChoice == eUserMainMenuAction.insertNewVehicle)
                {
                    insertNewVehicleUI();
                }
                else if (userChoice == eUserMainMenuAction.displayListOfLicenseNumbers)
                {
                    //displayListOfLicenseNumbersUI();
                }
                else if (userChoice == eUserMainMenuAction.changeStatusOfVehicle)
                {
                    //changeStatusOfVehicleUI();
                }
                else if (userChoice == eUserMainMenuAction.inflateWheelsOfVehicle)
                {
                    //inflateWheelsOfVehicleUI();
                }
                else if (userChoice == eUserMainMenuAction.refuelVehicle)
                {
                    //refuelVehicleUI();
                }
                else if (userChoice == eUserMainMenuAction.chargeVehicle)
                {
                    //chargeVehicleUI();
                }
                else if (userChoice == eUserMainMenuAction.displayDataOfVehicle)
                {
                    displayDataOfVehicleUI();
                }
                else if (userChoice == eUserMainMenuAction.exitProgram)
                {
                    //exitProgram();
                }
            }
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

        private eUserMainMenuAction readInput()//will need to implement. how do we use exceptions ?
        {
            //int userChoice = -1;
            //string input;
            //while(expression)
            //{
            //    try
            //    {
            //        while (userChoice < 1 || userChoice > 8)
            //        { 
            //            input = Console.ReadLine();
            //            userChoice = int.TryParse(input);

            //    }
            //    catch (FormatException e)
            //    {
            //        System.Console.WriteLine(e);
            //        throw;
            //    }
            //    catch (Argument)
            //}

            return eUserMainMenuAction.exitProgram;
        }

        private void insertNewVehicleUI()
        {
            string licenseNumber;
            bool carIsInGarage = false;

            Console.Clear();
            Console.WriteLine("Please insert license number.");
            licenseNumber = Console.ReadLine(); // maybe check input ?
            
            carIsInGarage= m_garageLogic.isThisVehicleInTheGarage(licenseNumber);//easy ADD!!

            if(carIsInGarage == false)//add  car 
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
            string licenseNumber= null;
            bool carIsInGarage = false;
            VehicleInGarage selectedVehicle;

            while (carIsInGarage == false)
            {
                Console.Clear();
                Console.WriteLine("Please insert license number:");
                licenseNumber = Console.ReadLine();
                carIsInGarage = m_garageLogic.isThisVehicleInTheGarage(licenseNumber);
            }

            selectedVehicle = m_garageLogic.getVehicleInGarageByLicenseNumber(licenseNumber);
            selectedVehicle.displayAllData();
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
            int vehicleTypeNumber=2;//change to -1 later
            Vehicle newVehicle;
            string ownerPhoneNumber;
            string ownerName;
            int firstOption = 1;
            int lastOption = 5;


            printVehicleOptions();
            vehicleTypeNumber = getInput(firstOption, lastOption);
            newVehicle = m_garageLogic.createInstanceOfVehicle(vehicleTypeNumber,i_LicenseNumber);

            inputSuccessful = fillOutVehicleDataFromUser(newVehicle);

            if(inputSuccessful)
            {
                readPhoneNumberAndName(out ownerPhoneNumber, out ownerName);
                m_garageLogic.addVehicleToGarageDictionary(newVehicle, ownerPhoneNumber, ownerName);

                Console.WriteLine("Vehicle added successfully to garage!");//format
            }
            else
            {
                Console.WriteLine("Vehicle input unsuccessful, you can try again.\n"
                                  + "press ENTER to return to main menu");
                Console.ReadLine();
            }
            
        }

        private bool fillOutVehicleDataFromUser(Vehicle i_NewVehicle)
        {
            bool isRegistrationSuccessful = false;
            string input;
            List<object> inputsFromUser= new List<object>();
            string displayMessageToUser = i_NewVehicle.getDescriptionOfTypesToInput();
            List<Type> listOfMemberTypes = i_NewVehicle.getListOfMemberTypesToFill();

            Console.Clear();
            Console.Write(displayMessageToUser);

            for(int i = 0; i < listOfMemberTypes.Count; i++)
            {
                input = Console.ReadLine();
                inputsFromUser.Add(parseFromStringToType(listOfMemberTypes[i],input));
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
            int choice = -1;
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
    }
}
