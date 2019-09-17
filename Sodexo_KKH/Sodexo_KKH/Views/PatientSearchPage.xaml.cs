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

            //var effect = new ItemholdingEffect();
            //effect.ItemLongPressed += ItemholdingEffect_ItemLongPressed;
            //patientslist.Effects.Add(effect);
        }

        private async void SfListView_ItemHolding(object sender, Syncfusion.ListView.XForms.ItemHoldingEventArgs e)
        {
            var selectedPatient = e.ItemData as mstr_patient_info;
            if (selectedPatient.caregiverno == "0")
            {
                var popup = new PatientInfoPopUp
                {
                    BindingContext = selectedPatient
                };

                await Navigation.PushPopupAsync(popup);
            }
        }

        private void SfListView_ItemTapped(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
        {
            _viewModel.NavigateToInfoPage(e.ItemData as mstr_patient_info);
            
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

        private void SfAutoComplete_ValueChanged(object sender, Syncfusion.SfAutoComplete.XForms.ValueChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Value))
            {
                _viewModel.GetPatientInfo(e.Value);
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

        private async void ItemholdingEffect_ItemLongPressed(object sender, EventArgs e)
        {
            var selectedPatient = ((ListView)sender).SelectedItem as mstr_patient_info;
            if (selectedPatient == null)
            {
                return;
            }
            if (selectedPatient.caregiverno == "0")
            {
                var popup = new PatientInfoPopUp
                {
                    BindingContext = selectedPatient
                };

                await Navigation.PushPopupAsync(popup);
            }

        }
    }
}
