using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using Sodexo_KKH.Models;
using Sodexo_KKH.ViewModels;
using System;
using Xamarin.Forms.Xaml;

namespace Sodexo_KKH.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CaregiverODPopup : PopupPage
    {
        DailyOrderDetailPageViewModel _viewModel;
        mstr_caregiver_mealorder_details careGiver;
        public CaregiverODPopup(mstr_caregiver_mealorder_details selectedCaregiver, ViewModels.DailyOrderDetailPageViewModel dailyOrderDetailPageViewModel)
        {
            InitializeComponent();
            _viewModel = dailyOrderDetailPageViewModel;
            careGiver = selectedCaregiver;
            menuItemNameLabel.Text = selectedCaregiver.menu_item_name;
            AmountLabel.Text = "SGD " + selectedCaregiver.amount.ToString();
            TotalAmountLabel.Text = "SGD " + selectedCaregiver.amount.ToString();
            PaymentModeLabel.Text = selectedCaregiver.paymentmodename;
        }
        private async void DeliverButton_Clicked(object sender, EventArgs e)
        {
            _viewModel.RemarkText = remarksEntry.Text;
            await _viewModel.SendDelivered_request_caregiver();
            await _viewModel.GetMealDeliveredData();
            await Navigation.PopPopupAsync();
        }

        private void CancelButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopPopupAsync();
        }
    }
}