﻿namespace Ex03.GarageLogic
{
    namespace MyEnums
    {
        public enum eUserMainMenuAction
        {
            insertNewVehicle = 1,
            displayListOfLicenseNumbers,
            changeStatusOfVehicle,
            inflateWheelsOfVehicle,
            refuelVehicle,
            chargeVehicle,
            displayDataOfVehicle,
            exitProgram
        }

        public enum eVehicleStatus
        {
            underRepair,
            finishedRepair,
            paid
        }

        public enum eTypesOfFuel
        {
            Octan98,
            Octan96,
            Octan95,
            Soler
        }

        public enum eTypeOfLicense
        {
            A1,
            A2,
            AA,
            B1
        }

        public enum eVehicleColor
        {
            white,
            black,
            yellow,
            red
        }
    }

}
