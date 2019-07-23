using System;
using System.Globalization;
using System.Net;
using System.Threading;
using Sodexo_KKH.Droid.Services;
using Sodexo_KKH.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(LocalizeService_droid))]
namespace Sodexo_KKH.Droid.Services
{
    public class LocalizeService_droid : ILocalize
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

        public void SetLocale()
        {
            var ci = GetCurrentCultureInfo();
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
        }

        public string GetIpAddress()
        {
            string MyIp = string.Empty;
            foreach (IPAddress adress in Dns.GetHostAddresses(Dns.GetHostName()))
            {
                MyIp =  adress.ToString();
                break;
            }
            return MyIp;
        }

        public string GetDeviceName()
        {
            return Android.OS.Build.Model;
        }
    }
}