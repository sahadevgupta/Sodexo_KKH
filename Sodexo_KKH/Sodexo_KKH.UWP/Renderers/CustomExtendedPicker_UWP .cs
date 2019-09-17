using GoodsMan.UWP.Services;
using Sodexo_KKH.UWP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(Picker), typeof(CustomExtendedPicker_UWP))]
namespace GoodsMan.UWP.Services
{
    public class CustomExtendedPicker_UWP : PickerRenderer
    {
        private ScrollViewer _scrollViewer;
        private readonly ComboxScrollControl _scrollControl = new ComboxScrollControl();

        public Picker _pickerControl { get; private set; }

        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
    {
        base.OnElementChanged(e);
        if (Control == null || e.NewElement == null) return;
        //Control.BorderThickness = new Windows.UI.Xaml.Thickness(0, 1, 0, 1);
        if (!string.IsNullOrEmpty(e.NewElement.Title))
        {
                _pickerControl = e.NewElement;

            Control.PlaceholderText = e.NewElement.Title;
            Control.Header = string.Empty;
                Control.SelectionChanged += Control_SelectionChanged;
                _scrollControl.selectedIndex = _pickerControl.SelectedIndex;
                Control.Style = (Windows.UI.Xaml.Style)_scrollControl.Resources["ComboBoxStyle1"];
                Control.Height = 50;
              



                //_scrollViewer = (Windows.UI.Xaml.Style)App.Current.Resources["ComboBoxStyle1"];

                Control.ApplyTemplate();
        }

       // UpdateBorders();
    }

        private void Control_SelectionChanged(object sender, Windows.UI.Xaml.Controls.SelectionChangedEventArgs e)
        {
            _scrollControl.selectedIndex = _pickerControl.SelectedIndex;
        }


        //protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        //{
        //    base.OnElementPropertyChanged(sender, e);
        //    if (Control == null) return;
        //    if (e.PropertyName == ExtendedPicker.IsBorderErrorVisibleProperty.PropertyName)
        //        UpdateBorders();
        //}
        //private void UpdateBorders()
        //{
        //    if (((ExtendedPicker)this.Element).IsBorderErrorVisible)
        //    {
        //        Control.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Red);
        //        Control.PlaceholderForeground = Control.BorderBrush;
        //    }
        //    else
        //    {
        //        Control.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Black);
        //        Control.PlaceholderForeground = Control.BorderBrush;
        //    }
        //}


    }
}

