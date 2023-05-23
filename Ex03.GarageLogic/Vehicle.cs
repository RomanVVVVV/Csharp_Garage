using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Vehicle
    {
        protected Engine m_Engine;
        protected string m_ModelName;
        protected string m_LicenseNumber;
        protected List<Wheel> m_Wheels = null;
    }
}
