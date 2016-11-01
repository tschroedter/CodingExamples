using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;

namespace Evaluation.Wpf.Application.Common.ValueConverters
{
    public class IntegerArrayToStringConverter : IValueConverter
    {
        public object Convert(object value,
                              Type targetType,
                              object parameter,
                              CultureInfo culture)
        {
            if ( targetType != typeof( string ) )
            {
                throw new InvalidOperationException("The target must be a string");
            }

            var integers = ( IEnumerable <int> ) value;

            string text = string.Join(", ",
                                      integers);

            return text;
        }

        public object ConvertBack(object value,
                                  Type targetType,
                                  object parameter,
                                  CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}