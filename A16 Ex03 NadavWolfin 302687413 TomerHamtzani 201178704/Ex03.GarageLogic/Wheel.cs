﻿using Ex03.GarageLogic.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        public Wheel(float maxWheelAirPressure)
        {
            m_MaxAirPressure = maxWheelAirPressure;

            // For now the min air pressure is zero, if it will changed one day we can change it in one place
            m_MinAirPressure = 0;

            m_AdditionalParameters = new Dictionary<string, string>();
            m_AdditionalParameters.Add("Manufacture", "Wheel Manufacturer");
            m_AdditionalParameters.Add("CurrentAirPressure", "Wheel current air pressure");
        }

        public bool SetField(string fieldName, string fieldValue)
        {
            switch (fieldName)
            {
                case k_ManufactureFieldName:
                    Manufacturer = fieldValue;
                    break;
                case k_CurrentAirPressureFieldName:
                    setCurrentAirPressure(fieldValue);
                    break;
                default:
                    throw new ArgumentException(string.Format("The field: '{0}' not exists", fieldName), fieldName);
            }

            return true;
        }

        public virtual IDictionary<string, string> GetAdditionalParameters()
        {
            return m_AdditionalParameters;
        }

        private void setCurrentAirPressure(string currentAirPressureStrValue)
        {
            float currentAirPressure;
            if(!float.TryParse(currentAirPressureStrValue, out currentAirPressure))
            {
                throw new ArgumentException("The field '{0}' must be float", k_CurrentAirPressureFieldName);
            }

            CurrentAirPressure = currentAirPressure;
        }
        public void FillAir(float i_AirToFill)
        {

        }

        public string Manufacturer
        {
            get
            {
                return m_Manufacturer;
            }
            set
            {
                Validator.IsNotNullOrWhiteSpace(value, k_ManufactureFieldName);
                m_Manufacturer = value;
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
                Validator.IsInRange(value, MinAirPressure, MaxAirPressure);
                m_CurrentAirPressure = value;
            }
        }

        public float MaxAirPressure
        {
            get
            {
                return m_MaxAirPressure;
            }
        }

        public float MinAirPressure
        {
            get
            {
                return m_MinAirPressure;
            }
        }

        private const string k_ManufactureFieldName = "Manufacture";
        private const string k_CurrentAirPressureFieldName = "CurrentAirPressure";

        private string m_Manufacturer;
        private float m_CurrentAirPressure;
        private float m_MaxAirPressure;
        private readonly float m_MinAirPressure;
        private readonly IDictionary<string, string> m_AdditionalParameters;
    }
}
