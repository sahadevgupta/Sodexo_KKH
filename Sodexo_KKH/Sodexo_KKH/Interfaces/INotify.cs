using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sodexo_KKH.Interfaces
{
    public interface INotify
    {
        void ShowLocalNotification(string title, string body);
        void ShowToast(string body);
        Task<string> ShowAlert(string title, string body);
    }
}
