﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    class Motorcycle : Vehicle
    {
        private Engine m_engine;



        public Motorcycle()
        {
            m_Wheels = new List<Wheel>(2);
        }
    }
}
