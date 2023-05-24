using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private string m_ManufacturerName;
        private float m_CurrentAirPressure;
        private float m_MaxAirPressure;

        public float MaxAirPressure
        {
            get
            {
                return m_MaxAirPressure;

            }
            set
            {
                m_MaxAirPressure = value;
            }
        }

        public string ManufacturerName
        {
            get
            {
                return m_ManufacturerName;

            }
            set
            {
                m_ManufacturerName = value;
            }
        }

        public float CurrentAirPressure
        {
            get
            {
                return m_CurrentAirPressure;

            }
            set
            {
                m_CurrentAirPressure = value;
            }
        }

        public void addPressure(float i_PressureToAdd)
        {

        }

        public Wheel(int i_MaxAirPressure)
        {
            m_MaxAirPressure = i_MaxAirPressure;
        }

    }
}
