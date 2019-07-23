using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Sodexo_KKH.Droid
{
    [Application]
    public class MainApplication : Application, Application.IActivityLifecycleCallbacks
    {
        internal static Context ActivityContext { get; private set; }

        public MainApplication(IntPtr handle, JniHandleOwnership transer)
          : base(handle, transer)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();
            RegisterActivityLifecycleCallbacks(this);
        }

        public override void OnTerminate()
        {
            base.OnTerminate();
            UnregisterActivityLifecycleCallbacks(this);
        }

        public void OnActivityCreated(Activity activity, Bundle savedInstanceState)
        {
            ActivityContext = activity;
            //CrossCurrentActivity.Current.Activity = activity;
        }

        public void OnActivityResumed(Activity activity)
        {
            ActivityContext = activity;
           // CrossCurrentActivity.Current.Activity = activity;
        }

        public void OnActivityStarted(Activity activity)
        {
            ActivityContext = activity;
           // CrossCurrentActivity.Current.Activity = activity;
        }

        public void OnActivityDestroyed(Activity activity) { }
        public void OnActivityPaused(Activity activity) { }
        public void OnActivitySaveInstanceState(Activity activity, Bundle outState) { }
        public void OnActivityStopped(Activity activity) { }
    }
}