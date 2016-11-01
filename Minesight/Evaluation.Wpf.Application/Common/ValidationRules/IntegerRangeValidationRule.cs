using System;
using System.Globalization;
using System.Windows.Controls;

namespace Evaluation.Wpf.Application.Common.ValidationRules
{
    public class IntegerRangeValidationRule : ValidationRule
    {
        private int m_Max = int.MaxValue;

        private int m_Min = int.MinValue;
        private string m_Name;

        public IntegerRangeValidationRule()
        {
            Name = "Field";
        }

        public string Name
        {
            get
            {
                return m_Name;
            }
            set
            {
                m_Name = string.IsNullOrEmpty(Name)
                             ? "Field"
                             : value;
            }
        }

        public int Min
        {
            get
            {
                return m_Min;
            }
            set
            {
                m_Min = value;
            }
        }

        public int Max
        {
            get
            {
                return m_Max;
            }
            set
            {
                m_Max = value;
            }
        }

        public override ValidationResult Validate(object value,
                                                  CultureInfo cultureInfo)
        {
            if ( string.IsNullOrEmpty(( string ) value) )
            {
                return ValidationResult.ValidResult;
            }

            try
            {
                if ( ( ( string ) value ).Length > 0 )
                {
                    int val = int.Parse(( string ) value);
                    if ( val > m_Max )
                        return new ValidationResult(false,
                                                    Name + " must be <= " + Max + ".");
                    if ( val < m_Min )
                        return new ValidationResult(false,
                                                    Name + " must be >= " + Min + ".");
                }
            }
            catch ( Exception )
            {
                return new ValidationResult(false,
                                            Name + " is not in a correct numeric format.");
            }

            return ValidationResult.ValidResult;
        }
    }
}