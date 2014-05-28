using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace De.BerndNet2000.TmplGen.Converter {
    /// <summary>
    /// Analog boolToVis nur umgedreht.
    /// </summary>
    public class BooleanNegationToVisibilityConverter: IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (value is bool) {
                return new BooleanToVisibilityConverter().Convert(!(bool)value, targetType, parameter, culture);
            }
            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return null;
        }
    }
}