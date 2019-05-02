using Prism;
using Prism.Ioc;
using Sodexo_KKH.ViewModels;
using Sodexo_KKH.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Sodexo_KKH
{
    public partial class App
    {
        public static string CultureCode { get; set; }

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
            await NavigationService.NavigateAsync("app:///NavigationPage/LoginPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
        }
    }
}
