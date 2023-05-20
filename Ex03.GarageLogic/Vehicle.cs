using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    class Vehicle
    {
        private string m_ModelName;
        private string m_LicenseNumber;
        private float m_EnergyPercentageRemaining;
        private List<Wheel> m_Wheels = new List<Wheel>();
        private string m_OwnerName;
        private string m_OwnerPhoneNumber;
        private MyEnums.eVehicleStatus m_vehicleStatus = MyEnums.eVehicleStatus.underRepair ; // what is initial status ? will put as default

        public eVehicleStatus VehicleStatus
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
    }
}
