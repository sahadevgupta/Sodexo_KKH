using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Sodexo_KKH.Converters
{
    public class AllergytextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.ToString() == "" || value.ToString() == "NA" || value.ToString() == "0" || value.ToString() == "NULL")
            {
                return "No";
            }
            else
            {
                return "Yes";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
