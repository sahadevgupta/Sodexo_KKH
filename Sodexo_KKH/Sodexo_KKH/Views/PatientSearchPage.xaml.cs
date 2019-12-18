
using Prism.Services.Dialogs;
using Rg.Plugins.Popup.Extensions;
using Sodexo_KKH.Models;
using Sodexo_KKH.PopUpControl;
using Sodexo_KKH.ViewModels;
using System;
using Xamarin.Forms;

namespace Sodexo_KKH.Views
{
    public partial class PatientSearchPage : ContentPage
    {
        PatientSearchPageViewModel _viewModel;
        public PatientSearchPage()
        {
            InitializeComponent();
            _viewModel = BindingContext as PatientSearchPageViewModel;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.navigation = Navigation;
        }

       
    

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            _viewModel.Patients = new System.Collections.ObjectModel.ObservableCollection<mstr_patient_info>();
            if ((e as TappedEventArgs).Parameter.Equals("ByWard"))
            {
                _viewModel.IsWardVisible = true;
            }
            else
            {
                _viewModel.IsWardVisible = false;
            }


        }
       

        private void DeleteOrder_Clicked(object sender, EventArgs e)
        {
            _viewModel.DeleteOrder(((ImageButton)sender).BindingContext as mstr_patient_info);
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            var imagebtn = ((ImageButton)sender);
            var selectedPatient = imagebtn.BindingContext as mstr_patient_info;
            var mealtype = imagebtn.CommandParameter.ToString();

            await _viewModel.NavigateToMealPopUp(selectedPatient, mealtype);
        }

       

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            _viewModel.NavigateToInfoPage(e.Item as mstr_patient_info);
        }

        private async void ItemholdingEffect_ItemLongPressed(object sender, EventArgs e)
        {
            _viewModel.IsPageEnabled = true;
            var selectedPatient = sender as mstr_patient_info;
            if (selectedPatient.caregiverno == "0")
            {
                //var param = new DialogParameters();
                //param.Add("Message", selectedPatient);
                //_viewModel._dialogService.ShowDialog("DialogView", param, CloseDialogCallback);

                var popup = new PatientInfoPopUp
                {
                    BindingContext = selectedPatient
                };

                await Navigation.PushPopupAsync(popup, true);
            }
            _viewModel.IsPageEnabled = false;
        }

        private void AutoSuggestionBox_TextChanged(object sender, Events.EventArgs<string> e)
        {
            if (!string.IsNullOrEmpty(e.Value))
            {
                _viewModel.GetPatientInfo(e.Value);
            }
        }

        private void AutoSuggestionBox_Item(object sender, Events.EventArgs<object> e)
        {
            _viewModel.PatientName = e.Value.ToString();
        }
    }
}
