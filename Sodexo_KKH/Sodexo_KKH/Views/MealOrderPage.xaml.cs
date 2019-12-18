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

        private void TapGestureRecognizer_Tapped_1(object sender, System.EventArgs e)
        {

            SelectElement((Frame)sender );
        }
        
        private async void SelectElement(Frame frame)
        {
            
            var stack = (frame.Children.Where(p => p is StackLayout).First() as StackLayout);

            if (_viewModel._lastElementSelectedFrame != null)
            {
                VisualStateManager.GoToState(_viewModel._lastElementSelectedFrame, "UnSelected");
                VisualStateManager.GoToState(_viewModel._lastElementSelectedImage, "UnSelected");
                VisualStateManager.GoToState(_viewModel._lastElementSelectedLabel, "UnSelected");
            }

            VisualStateManager.GoToState(frame, "Selected");
            VisualStateManager.GoToState(stack.Children.First(x => x is Label) as Label, "Selected");
            VisualStateManager.GoToState(stack.Children.First(x => x is Image) as Image, "Selected");

            _viewModel._lastElementSelectedFrame = frame;

            _viewModel._lastElementSelectedImage = stack.Children.First(x => x is Image) as Image;
            _viewModel._lastElementSelectedLabel = stack.Children.First(x => x is Label) as Label;


          
            
            _viewModel._lastElementSelectedFrame = frame;
            _viewModel.SelectedMenuCategory = frame.BindingContext as mstr_menu_item_category;

           await Task.Run(async () =>
            {
               await _viewModel.SetMenuCategories(_viewModel.SelectedMenuCategory);
            });
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
                    StackLayout s = this.FindByName<StackLayout>("menuCategories");

                    var enabledView = s.Children.Where(p => p is Frame).Where(x => x.IsEnabled).First();
                    SelectElement(enabledView as Frame);
                }
            }
            else
                _viewModel.PlaceOrder();
        }
        
    }
}
