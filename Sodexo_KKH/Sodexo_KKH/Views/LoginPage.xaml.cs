using Sodexo_KKH.ViewModels;
using System;
using Xamarin.Forms;

namespace Sodexo_KKH.Views
{
    public partial class LoginPage : ContentPage
    {
        LoginPageViewModel _viewModel;
        public LoginPage()
        {
            InitializeComponent();
            _viewModel = BindingContext as LoginPageViewModel;
        }
        private async void txtusername_EntryUnfocused(object sender, TextChangedEventArgs e)
        {
           await _viewModel.BindRole();
        }

       
    }
}
