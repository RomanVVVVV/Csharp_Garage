using Ex03.GarageLogic.MyEnums;
using System;

namespace Ex03.GarageLogic
{
    public class FuelEngine : Engine
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

        public bool checkFuelAmountCompatability(float i_InputAmount, float i_CurrentEnergyPercentage)
        {
            float currentEnergyInLiters = i_CurrentEnergyPercentage * m_FuelCapacityInLiters;
            bool isFuelAmountCompatible = false;

            if (currentEnergyInLiters + i_InputAmount <= m_FuelCapacityInLiters)
            {
                isFuelAmountCompatible = true;
            }
            else
            {
                throw new ValueOutRangeException(new Exception(), 0, m_FuelCapacityInLiters - currentEnergyInLiters);
                isFuelAmountCompatible = false;
            }

            return isFuelAmountCompatible;
        }
    }
}
