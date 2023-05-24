using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ex03.GarageLogic.MyEnums;

namespace Ex03.GarageLogic
{
    class FuelEngine : Engine
    {
        private float m_FuelCapacityInLiters;
        private eTypesOfFuel m_TypeOfFuel;

        public override string getEngineType()
        {
            return "fuel";
        }

        public FuelEngine(float i_MaxCapacity, eTypesOfFuel i_typeOfFuel)
        {
            m_FuelCapacityInLiters = i_MaxCapacity;
            m_TypeOfFuel = i_typeOfFuel;
        }

        public float FuelCapacityInLiters
        {
            get
            {
                return m_FuelCapacityInLiters;
            }
            set
            {
                m_FuelCapacityInLiters = value;
            }
        }

        public eTypesOfFuel TypeOfFuel
        {
            get
            {
                return m_TypeOfFuel;
            }
            set
            {
                m_TypeOfFuel = value;
            }
        }
    }
}
