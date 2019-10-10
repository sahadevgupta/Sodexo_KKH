using Foundation;
using Prism;
using Prism.Ioc;
using Syncfusion.ListView.XForms.iOS;
using Syncfusion.SfBusyIndicator.iOS;
using Syncfusion.SfBusyIndicator.XForms.iOS;
using Syncfusion.SfAutoComplete.XForms.iOS;

using UIKit;
using Xamarin.Forms;

namespace Sodexo_KKH.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {

            var pushSettings = UIUserNotificationSettings.GetSettingsForTypes(
                               UIUserNotificationType.Alert | UIUserNotificationType.Badge | UIUserNotificationType.Sound,
                               new NSSet());

            UIApplication.SharedApplication.RegisterUserNotificationSettings(pushSettings);

            Rg.Plugins.Popup.Popup.Init();
            global::Xamarin.Forms.Forms.Init();   
           // FormsMaterial.Init();
            SfListViewRenderer.Init();
            SfAutoCompleteRenderer.Init();
            new SfBusyIndicatorRenderer();
            //SfBorderRenderer.Init();
            Syncfusion.XForms.iOS.Buttons.SfCheckBoxRenderer.Init();
            Syncfusion.XForms.iOS.Buttons.SfRadioButtonRenderer.Init();

            LoadApplication(new App(new iOSInitializer()));

            


            return base.FinishedLaunching(app, options);
        }
    }

    public class iOSInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Register any platform specific implementations
        }
    }
}
