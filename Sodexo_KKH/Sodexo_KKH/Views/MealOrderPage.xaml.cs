using Sodexo_KKH.Models;
using Sodexo_KKH.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
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
        protected override void OnAppearing()
        {
            base.OnAppearing();
            segment.Children = new System.Collections.Generic.List<string>(_viewModel.MstrMeals.Select(x => x.meal_name));
        }

        private async void Addremovebtn_Clicked(object sender, System.EventArgs e)
        {
            await _viewModel.AddOrRemoveMenuItem(((Button)sender).BindingContext as MenuItemClass);
        }
        
        private void MealTime_Tapped(object sender, System.EventArgs e)
        {
            var MealTime =((StackLayout)sender).BindingContext  as mstr_meal_time;
            if (MealTime.IsTapped)
            {
               
            }
            else
            {
                var checkedMealTime = _viewModel.MstrMeals.Where(x => x.IsTapped && x.meal_name != MealTime.meal_name);
                if (checkedMealTime.Any())
                {
                    checkedMealTime.First().IsTapped = false;
                    MealTime.IsTapped = true;
                }
                else
                    MealTime.IsTapped = true;

                _viewModel.SetCutOffTime(MealTime);
            }
                
        }

      
        private void mealtime_SelectedItemChanged(object sender, SelectedItemChangedEventArgs e)
        {
            _viewModel.FilterItemsOnMealTime(e.SelectedItem.ToString());

            _viewModel.ReloadMenuCategory();

        }

        private async void TapGestureRecognizer_Tapped_1(object sender, System.EventArgs e)
        {
            var currentMenu = ((Frame)sender).BindingContext as mstr_menu_item_category;
            await selectMenuCategory(currentMenu);
        }
        
       

        private async void NxtBtn_Clicked(object sender, EventArgs e)
        {
            string param = ((Button)sender).CommandParameter.ToString();
            if (param.Equals("NEXT"))
            {
                if (_viewModel.others.ID == 1 || _viewModel.others.ID == 8 || _viewModel.others.ID == 5)
                {
                    await _viewModel.NavigateToMealSummary();
                }
                else
                {
                    var menu = _viewModel.MenuCategories.Where(x => x.CategoryVisibility).First();
                    await selectMenuCategory(menu);
                    
                }
            }
            else
                _viewModel.PlaceOrder();
        }
        private async Task selectMenuCategory(mstr_menu_item_category currentMenu)
        {
            var previousMenus = _viewModel.MenuCategories.Where(x => x.isSelected && x.ID != currentMenu.ID).ToList();
            if (previousMenus.Any())
            {
                previousMenus.ForEach(x => x.isSelected = false);
            }
            currentMenu.isSelected = true;
            _viewModel.SelectedMenuCategory = currentMenu;

            await Task.Run(async () =>
            {
                await _viewModel.SetMenuCategories(_viewModel.SelectedMenuCategory);
            });
        }

    }
}
