using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    class Vehicle
    {
        protected string m_ModelName;
        protected string m_LicenseNumber;
        protected float m_EnergyPercentageRemaining;
        protected List<Wheel> m_Wheels = new List<Wheel>();
    }
}
