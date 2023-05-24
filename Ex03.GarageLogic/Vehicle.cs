using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        protected Engine m_Engine;
        protected string m_ModelName;
        protected string m_LicenseNumber;
        protected List<Wheel> m_Wheels = new List<Wheel>();

        public string LicenseNumber
        {
            get { return m_LicenseNumber; }
            set { m_LicenseNumber = value; }
        }
        public abstract string getDescriptionOfTypesToInput();

        public abstract List<Type> getListOfMemberTypesToFill();

        public abstract bool useInputsToRegisterVehicle(List<object> i_InputsFromUser);

        public abstract string displayAllData();
    }
}
