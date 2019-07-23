﻿using Plugin.Connectivity;
using Sodexo_KKH.Helpers;
using Syncfusion.ListView.XForms.UWP;
using Syncfusion.XForms.UWP.Buttons;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Sodexo_KKH.UWP
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : Application
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;
        }
        
        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="e">Details about the launch request and process.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {


            Frame rootFrame = Window.Current.Content as Frame;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (rootFrame == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = new Frame();

                rootFrame.NavigationFailed += OnNavigationFailed;

               

                List<Assembly> assembliesToInclude = new List<Assembly>();
                assembliesToInclude.Add(typeof(Syncfusion.SfBusyIndicator.XForms.UWP.SfBusyIndicatorRenderer).GetTypeInfo().Assembly);
                assembliesToInclude.Add(typeof(Syncfusion.XForms.UWP.ComboBox.SfComboBoxRenderer).GetTypeInfo().Assembly);
                assembliesToInclude.Add(typeof(SfListViewRenderer).GetTypeInfo().Assembly);
                assembliesToInclude.Add(typeof(Syncfusion.SfAutoComplete.XForms.UWP.SfAutoCompleteRenderer).GetTypeInfo().Assembly);
                // Replace the Xamarin.Forms.Forms.Init(e);      
                assembliesToInclude.Add(typeof(SfRadioButtonRenderer).GetTypeInfo().Assembly);
                assembliesToInclude.Add(typeof(SfCheckBoxRenderer).GetTypeInfo().Assembly);



                assembliesToInclude.Add(typeof(ZXing.Net.Mobile.Forms.WindowsUniversal.ZXingScannerViewRenderer).GetTypeInfo().Assembly);
                assembliesToInclude.Add(typeof(ZXing.Net.Mobile.Forms.ZXingScannerPage).GetTypeInfo().Assembly);
                assembliesToInclude.AddRange(Rg.Plugins.Popup.Popup.GetExtraAssemblies());

                Rg.Plugins.Popup.Popup.Init();

                //Xamarin.Forms.Forms.SetFlags("CollectionView_Experimental");
                Xamarin.Forms.Forms.SetFlags("CollectionView_Experimental");
                Xamarin.Forms.Forms.Init(e, assembliesToInclude);

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //TODO: Load state from previously suspended application
                }
                
                // Place the frame in the current Window
                Window.Current.Content = rootFrame;
            }

            if (rootFrame.Content == null)
            {
                // When the navigation stack isn't restored navigate to the first page,
                // configuring the new page by passing required information as a navigation
                // parameter
                rootFrame.Navigate(typeof(MainPage), e.Arguments);
            }
            // Ensure the current window is active
            Window.Current.Activate();
        }


        /// <summary>
        /// Invoked when Navigation to a certain page fails
        /// </summary>
        /// <param name="sender">The Frame which failed navigation</param>
        /// <param name="e">Details about the navigation failure</param>
        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private async void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();


            if (CrossConnectivity.Current.IsConnected)
            {
                if (!string.IsNullOrEmpty(Library.KEY_USER_ID))
                {
                    string URL = Library.KEY_http + Library.KEY_SERVER_IP + "/" + Library.KEY_SERVER_LOCATION + "/sodexo.svc";
                    using (var httpClient = new System.Net.Http.HttpClient())
                    {
                        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, URL + "/updatelogfalse/" + Library.KEY_USER_ID);
                        await httpClient.SendAsync(request);
                    }
                    Library.KEY_USER_ID = string.Empty;
                }
            }

            //TODO: Save application state and stop any background activity
            deferral.Complete();
        }

    }
}
