﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Sodexo_KKH.Converters
{
    public class CheckBoxConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //bool input = value as bool;
            string input = value.ToString();
            string returnvalue = "";


            if (input == "Delivered")
            {
                returnvalue = "False";
            }
            else
            {
                returnvalue = "True";
            }


            return returnvalue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
