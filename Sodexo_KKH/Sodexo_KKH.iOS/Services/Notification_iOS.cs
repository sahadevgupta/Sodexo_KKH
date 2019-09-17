using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foundation;
using Sodexo_KKH.Interfaces;
using Sodexo_KKH.iOS.Services;
using UIKit;
using UserNotifications;
using Xamarin.Forms;

[assembly: Dependency(typeof(Notification_iOS))]
namespace Sodexo_KKH.iOS.Services
{
    class Notification_iOS : INotify
    {
        NSTimer alertDelay;
        UIAlertController alert;
        public Task<string> ShowAlert(string title, string body)
        {
            throw new NotImplementedException();
        }

        public Task<string> ShowAlert(string title, string body, string acceptbtn = null, string rejectbtn = null, string cancelbtn = null)
        {
            return null;
        }

        public void ShowLocalNotification(string title, string body)
        {
            var trigger = UNTimeIntervalNotificationTrigger.CreateTrigger(1, false);

            var requestID = "localNotification";
            UNMutableNotificationContent content = new UNMutableNotificationContent()
            {
                Title = title,
                Body = body,
                
            };
            var request = UNNotificationRequest.FromIdentifier(requestID, content, trigger);
            UNUserNotificationCenter.Current.AddNotificationRequest(request, (error) => { });
        }

        public void ShowToast(string descripition)
        {
            alertDelay = NSTimer.CreateScheduledTimer(1, (obj) =>
            {
                dismissMessage();
            });
            alert = UIAlertController.Create(null, descripition, UIAlertControllerStyle.Alert);
            UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(alert, true, null);
        }
        private void dismissMessage()
        {
            if (alert != null)
            {
                alert.DismissViewController(true, null);
            }
            if (alertDelay != null)
            {
                alertDelay.Dispose();
            }
        }
    }
}