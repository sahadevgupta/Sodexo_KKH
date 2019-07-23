using Sodexo_KKH.ViewModels;
using Xamarin.Forms;

namespace Sodexo_KKH.Views
{
    public partial class MealOrderPage : ContentPage
    {
        MealOrderPageViewModel _viewModel;
        public MealOrderPage()
        {
            InitializeComponent();
            _viewModel = BindingContext as MealOrderPageViewModel;
        }

       
        private async void Addremovebtn_Clicked(object sender, System.EventArgs e)
        {
           await _viewModel.AddOrRemoveMenuItem(((Button)sender).BindingContext as MenuItemClass);
        }
    }
}
