﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    class Truck : Vehicle
    {
        public Truck()
        {
            m_Engine = new FuelEngine(135, eNums.Soler);
            
        }
    }
}