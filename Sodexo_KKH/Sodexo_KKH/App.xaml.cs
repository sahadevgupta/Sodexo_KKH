using Plugin.Connectivity;
using Prism;
using Prism.Ioc;
using Prism.Services;
using Sodexo_KKH.Helpers;
using Sodexo_KKH.Models;
using Sodexo_KKH.Repos;
using Sodexo_KKH.Services;
using Sodexo_KKH.ViewModels;
using Sodexo_KKH.Views;
using System;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Sodexo_KKH
{
    public partial class App
    {
        
        public static string CultureCode { get; set; }
        public static IPageDialogService pageDialog;
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mzk0MDZAMzEzNjJlMzMyZTMwTmpnaGdFOHZXejE3bUlGTktoTmxTL0FPNGZ2cEplK3l6cnRFUXdadURhVT0=");
            InitializeComponent();
            CultureCode = "";

            Check_User_Already_Exist();

            await NavigationService.NavigateAsync(nameof(LoginPage));
        }

        private async void Check_User_Already_Exist()
        {
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
        }

        protected override void OnStart()
        {
            base.OnStart();

            SessionManager.Instance.SessionDuration = TimeSpan.FromMinutes(20);
            SessionManager.Instance.OnSessionExpired = HandleSessionExpired;
        }
       
        protected override void OnSleep()
        {
            base.OnSleep();
        }
        private async void HandleSessionExpired(object sender, EventArgs e)
        {
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
            SessionManager.Instance.EndTrackSession();

            await pageDialog.DisplayAlertAsync("Alert !!", "Your session has expired. Please login again.",  "OK");

            await NavigationService.NavigateAsync("app:///LoginPage");
        }
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //Initialize Services
            containerRegistry.RegisterSingleton<IMealOrderLocalManager, MealOrderLocalManager>();
            containerRegistry.RegisterSingleton<IPatientManager, PatientManager>();
            containerRegistry.RegisterSingleton<IGenericRepo<mstr_meal_order_local>, GenericRepo<mstr_meal_order_local>>();
            containerRegistry.RegisterSingleton<IGenericRepo<mstr_ward_details>, GenericRepo<mstr_ward_details>>();
            containerRegistry.RegisterSingleton <IGenericRepo<mstr_bed_details>, GenericRepo<mstr_bed_details>>();
            containerRegistry.RegisterSingleton<IGenericRepo<mstr_others_master>, GenericRepo<mstr_others_master>>();
            containerRegistry.RegisterSingleton<IGenericRepo<mstr_allergies_master>, GenericRepo<mstr_allergies_master>>();
            containerRegistry.RegisterSingleton<IGenericRepo<mstr_ingredient>, GenericRepo<mstr_ingredient>>();
            containerRegistry.RegisterSingleton<IGenericRepo<mstr_therapeutic>, GenericRepo<mstr_therapeutic>>();
            containerRegistry.RegisterSingleton<IGenericRepo<mstr_diet_texture>, GenericRepo<mstr_diet_texture>>();
            containerRegistry.RegisterSingleton<IGenericRepo<mstr_meal_type>, GenericRepo<mstr_meal_type>>();
            containerRegistry.RegisterSingleton<IGenericRepo<mstr_meal_time>, GenericRepo<mstr_meal_time>>();
            containerRegistry.RegisterSingleton<IGenericRepo<mstr_menu_item_category>, GenericRepo<mstr_menu_item_category>>();
            containerRegistry.RegisterSingleton<IGenericRepo<mstr_bed_meal_class_mapping>, GenericRepo<mstr_bed_meal_class_mapping>>();
            containerRegistry.RegisterSingleton<IGenericRepo<mstr_mealclass>, GenericRepo<mstr_mealclass>>();
            containerRegistry.RegisterSingleton<IGenericRepo<mstr_meal_option>, GenericRepo<mstr_meal_option>>();
            containerRegistry.RegisterSingleton<IGenericRepo<mstr_diet_type>, GenericRepo<mstr_diet_type>>();
            containerRegistry.RegisterSingleton<IGenericRepo<mstr_remarks>, GenericRepo<mstr_remarks>>();
            containerRegistry.RegisterSingleton<IGenericRepo<mstr_patient_info>, GenericRepo<mstr_patient_info>>();
            containerRegistry.RegisterSingleton<IGenericRepo<mstr_therapeutic_condition>, GenericRepo<mstr_therapeutic_condition>>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<HomeMasterDetailPage, HomeMasterDetailPageViewModel>();
            containerRegistry.RegisterForNavigation<PatientSearchPage, PatientSearchPageViewModel>();
            containerRegistry.RegisterForNavigation<PatientInformationPage>();
            containerRegistry.RegisterForNavigation<MealOrderPage, MealOrderPageViewModel>();
            containerRegistry.RegisterForNavigation<MealSummaryPage, MealSummaryPageViewModel>();
            containerRegistry.RegisterForNavigation<DailyOrderDetailPage, DailyOrderDetailPageViewModel>();
            containerRegistry.RegisterForNavigation<MealOrderStatusPage>();
            containerRegistry.RegisterForNavigation<FeedBackPage, FeedBackPageViewModel>();
        }
    }
}
