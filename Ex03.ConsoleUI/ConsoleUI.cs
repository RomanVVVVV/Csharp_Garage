using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ex03.GarageLogic.MyEnums;


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
                userChoice = readInput();//while not valid

                if(userChoice == eUserMainMenuAction.insertNewVehicle)
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
                    exitProgram();
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
            
            carIsInGarage= m_garageLogic.isThisVehicleInTheGarage(licenseNumber);//easy

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

        private void addVehicleUI(string i_LicenseNumber)
        {
            
        }
    }
}
