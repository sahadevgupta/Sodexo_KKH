﻿using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using Sodexo_KKH.Models;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms.Xaml;

namespace Sodexo_KKH.PopUpControl
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MealInfoPopUp : PopupPage
    {
        public MealInfoPopUp(ObservableCollection<mstr_meal_history> MealHistory, string MealType)
        {
            InitializeComponent();

            if (MealType == "BF")
            {
                titlelbl.Text = $"Patient Meal Information (BreakFast)";
            }
            else if (MealType == "LH")
            {
                titlelbl.Text = $"Patient Meal Information (Lunch)";
            }
            else
                titlelbl.Text = $"Patient Meal Information (Dinner)";

            meallist.ItemsSource = MealHistory;
            // BindableLayout.SetItemsSource(mealinfostack, MealHistory);
        }

        private async void Titlelbl_Close(object sender, EventArgs e)
        {
            await Navigation.PopPopupAsync();
        }
    }
}