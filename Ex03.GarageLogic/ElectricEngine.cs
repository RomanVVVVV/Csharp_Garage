﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{ 
    class ElectricEngine : Engine
    {
        private float m_MaximumBatteryTimeInHours;

        public override string getEngineType()
        {
            return "electric";
        }
    }
}
