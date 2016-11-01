using System.Globalization;
using System.Windows.Controls;

namespace Evaluation.Wpf.Application.Common.ValidationRules
{
    public class DoubleValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value,
                                                  CultureInfo cultureInfo)
        {
            var str = value as string;

            return string.IsNullOrEmpty(str)
                       ? new ValidationResult(false,
                                              "Please enter a double value!")
                       : new ValidationResult(true,
                                              null);
        }
    }
}