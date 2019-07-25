using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using Foundation;
using Sodexo_KKH.Interfaces;
using Sodexo_KKH.iOS.Services;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(LocalizeService_iOS))]
namespace Sodexo_KKH.iOS.Services
{
    class LocalizeService_iOS : ILocalize
    {
        public void ChangeLocale(string sLanguageCode)
        {
            var ci = CultureInfo.CreateSpecificCulture(sLanguageCode);
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
            Console.WriteLine("ChangeToLanguage: " + ci.Name);
        }

        public CultureInfo GetCurrentCultureInfo()
        {
            CultureInfo ci = null;
            ci = System.Globalization.CultureInfo.CurrentCulture;
            return ci;
        }

        public CultureInfo GetCurrentCultureInfo(string sLanguageCode)
        {
            return CultureInfo.CreateSpecificCulture(sLanguageCode);
        }

        public string GetDeviceName()
        {
           return UIDevice.CurrentDevice.SystemName;
        }

        public string GetIpAddress()
        {
            IPAddress[] adresses = Dns.GetHostAddresses(Dns.GetHostName());

            if (adresses != null && adresses[0] != null)
            {
                return adresses[0].ToString();
            }
            else
            {
                return null;
            }
        }

        public void SetLocale()
        {
            var ci = GetCurrentCultureInfo();
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
        }
    }
}