﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Sodexo_KKH.Converters
{
    public class BoolToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string input = value.ToString();
            ImageSource One = null; ;
            if (input == "true" || input == "True")
            {
                One = PlatFromImage.GetImage("qr_verified.png");// new BitmapImage(new Uri("ms-appx:///Assets/qr_128.png"));
            }
            if (input == "false" || input == "False" || input == null)
            {
                One = PlatFromImage.GetImage("qr-code-scan.png"); //new BitmapImage(new Uri("ms-appx:///Assets/qr-code-scan.png"));
            }
            // string FileName = "SAN_P_NU_033-34.JPG";

            //BitmapImage One = new BitmapImage(new Uri("ms-appx:///" + FileName));
            return One;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
