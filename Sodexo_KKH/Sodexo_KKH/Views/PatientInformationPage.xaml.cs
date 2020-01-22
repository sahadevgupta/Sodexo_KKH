using Sodexo_KKH.Helpers;
using Sodexo_KKH.ViewModels;
using Xamarin.Forms;

namespace Sodexo_KKH.Views
{
    public partial class PatientInformationPage : ContentPage
    {
        PatientInformationPageViewModel _viewModel;
        public PatientInformationPage()
        {
            InitializeComponent();
            _viewModel = BindingContext as PatientInformationPageViewModel;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
       
    }
}
