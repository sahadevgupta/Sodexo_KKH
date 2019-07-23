using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Sodexo_KKH.Converters
{
    public class ImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ImageSource One = null;

           

            if (value.ToString() == "NA" || value.ToString() == "0" || value.ToString() == null)
            {
                One = (FileImageSource)PlatFromImage.GetImage("nil.png");// new BitmapImage(new Uri("ms-appx:///Assets/nil.png"));
            }
            if (value.ToString() == "1" || value.ToString() == "CHK")
            {
                One = (FileImageSource)PlatFromImage.GetImage("ok.png");// BitmapImage(new Uri("ms-appx:///Assets/ok.png"));
            }
            if (value.ToString() == "2" || value.ToString() == "NBM/NPO" || value.ToString() == "NBM/NPO")
            {
                One = (FileImageSource)PlatFromImage.GetImage("thums_up.png");// BitmapImage(new Uri("ms-appx:///Assets/thumsup.png"));
            }
            if (value.ToString() == "3" || value.ToString() == "TU")
            {
                One = (FileImageSource)PlatFromImage.GetImage("NBM.png");//(new Uri("ms-appx:///Assets/NBM.png"));
            }
            if (value.ToString() == "Pending")
            {
                One = (FileImageSource)PlatFromImage.GetImage("pendingstatus.png");//(new Uri("ms-appx:///Assets/NBM.png"));
            }
            if (value.ToString() == "4")
            {
                One = (FileImageSource)PlatFromImage.GetImage("hl.png");
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
