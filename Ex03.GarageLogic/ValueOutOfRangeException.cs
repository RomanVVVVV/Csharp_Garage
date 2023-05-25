using System;

namespace Ex03.GarageLogic
{
    public class ValueOutRangeException : Exception
    {
        private float m_MaxValue;
        private float m_MinValue;

        public float MaxValue
        {
            get { return m_MaxValue; }
        }

        public float MinValue
        {
            get { return m_MinValue; }
        }

        public ValueOutRangeException(Exception i_InnerExeption, float i_MinValue, float i_MaxValue)
            : base(string.Format("Please insert a Number bitween {0} to {1}", i_MinValue, i_MaxValue, i_InnerExeption))
        {
            m_MaxValue = i_MaxValue;
            m_MinValue = i_MinValue;
        }
    }
}