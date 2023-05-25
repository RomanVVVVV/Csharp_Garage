using System;

namespace Ex03.GarageLogic
{
    class ElectricEngine : Engine
    {
        private float m_MaximumBatteryTimeInHours;

        public override string getEngineType()
        {
            return "electric";
        }

        public ElectricEngine(float i_MaximumBatteryTimeInHours)
        {
            m_MaximumBatteryTimeInHours = i_MaximumBatteryTimeInHours;
        }

        public float MaximumBatteryTimeInHours
        {
            get
            {
                return m_MaximumBatteryTimeInHours;
            }
            set
            {
                m_MaximumBatteryTimeInHours = value;
            }
        }

        public bool checkEnergyAmountCompatability(int i_MinutesToAdd, float i_CurrentEnergyPercentage)
        {
            float currentBatteryTimeInHours = i_CurrentEnergyPercentage * m_MaximumBatteryTimeInHours;
            bool isAmountCompatible = false;

            if (currentBatteryTimeInHours + i_MinutesToAdd / 60 <= m_MaximumBatteryTimeInHours)
            {
                isAmountCompatible = true;
            }
            else
            {
                throw new ValueOutRangeException(new Exception(), 0, m_MaximumBatteryTimeInHours - currentBatteryTimeInHours);
            }

            return isAmountCompatible;
        }
    }
}
