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
            _viewModel.Navigation = Navigation;
            RadioGroup.CheckedChanged += RadioGroup_CheckedChanged;
        }

        private void RadioGroup_CheckedChanged(object sender, int e)
        {
            Library.IsFAGeneralEnable = e == 1 ? false : true;
        }
    }
}
