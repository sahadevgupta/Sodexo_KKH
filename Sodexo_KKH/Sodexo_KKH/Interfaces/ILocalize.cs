using System.Globalization;

namespace Sodexo_KKH.Interfaces
{
    public interface ILocalize
    {
        CultureInfo GetCurrentCultureInfo();
        CultureInfo GetCurrentCultureInfo(string sLanguageCode);
        void SetLocale();
        void ChangeLocale(string sLanguageCode);

        string GetIpAddress();

        string GetDeviceName();
    }
}
