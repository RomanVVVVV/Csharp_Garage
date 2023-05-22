using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    class FuelEngine : Engine
    {
        private float m_FuelCapacityInLiters;

        public override string getEngineType()
        {
            return "fuel";
        }
    }
}
