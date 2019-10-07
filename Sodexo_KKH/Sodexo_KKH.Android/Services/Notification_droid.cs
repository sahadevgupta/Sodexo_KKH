using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using Sodexo_KKH.Droid.Services;
using Sodexo_KKH.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(Notification_droid))]
namespace Sodexo_KKH.Droid.Services
{
    public class Notification_droid : INotify
    {
        static readonly int NOTIFICATION_ID = 1000;
        static readonly string CHANNEL_ID = "location_notification";
        internal static readonly string COUNT_KEY = "count";
        public Task<string> ShowAlert(string title, string body)
        {
            throw new NotImplementedException();
        }

        public void ShowLocalNotification(string title, string body)
        {
            //if (Build.VERSION.SdkInt < BuildVersionCodes.O)
            //{
            //    // Notification channels are new in API 26 (and not a part of the
            //    // support library). There is no need to create a notification
            //    // channel on older versions of Android.
            //    return;
            //}

            //var name = Resources.GetString(Resource.String.channel_name);
            //var description = GetString(Resource.String.channel_description);
            //var channel = new NotificationChannel(CHANNEL_ID, name, NotificationImportance.Default)
            //{
            //    Description = description
            //};

            //var notificationManager = (NotificationManager)GetSystemService(NotificationService);
            //notificationManager.CreateNotificationChannel(channel);

            var notificationBuilder = new Notification.Builder(MainApplication.ActivityContext)
                            .SetSmallIcon(Resource.Drawable.ic_mr_button_connecting_26_light)
                            .SetContentTitle(title)
                            .SetContentText(body)
                            .SetAutoCancel(true);
                            

            var notificationManager = NotificationManager.FromContext(MainApplication.ActivityContext);
            notificationManager.Notify(0, notificationBuilder.Build());



        }

        public void ShowToast(string description)
        {
            var activity =   MainApplication.ActivityContext as Activity;
            activity.RunOnUiThread(() =>
            {
                var view = activity.FindViewById(Android.Resource.Id.Content);
                Toast.MakeText(activity, description, ToastLength.Long).Show();
            });
        }

        public Task<string> ShowAlert(string title, string body, string acceptbtn = null, string rejectbtn = null, string cancelbtn = null)
        {
            throw new NotImplementedException();
        }
    }
}