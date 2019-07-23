using Sodexo_KKH.Controls;
using Sodexo_KKH.Events;
using Sodexo_KKH.UWP.Renderers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(RadioButton), typeof(RadioButton_UWP))]
namespace Sodexo_KKH.UWP.Renderers
{
    using NativeRadioButton = Windows.UI.Xaml.Controls.RadioButton;
    public class RadioButton_UWP : ViewRenderer<RadioButton, NativeRadioButton>
    {
        NativeRadioButton _checkBox;
        RadioButton _radioButton;
        protected override void OnElementChanged(ElementChangedEventArgs<RadioButton> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                //       _radioButton.CheckedChanged -= CheckedChanged;
                _radioButton.PropertyChanged -= ElementOnPropertyChanged;
            }
            if (e.NewElement == null) return;
            _radioButton = e.NewElement as RadioButton;
            //   _radioButton.CheckedChanged += CheckedChanged;
            _radioButton.PropertyChanged += ElementOnPropertyChanged;
            if (this.Control == null)
            {
                _checkBox = new NativeRadioButton();
                _checkBox.Content = _radioButton.Text;
                _checkBox.IsChecked = _radioButton.Checked;
                _checkBox.FontFamily = new Windows.UI.Xaml.Media.FontFamily("Assets/Fonts/Sansation-Regular.ttf#Sansation");
                _checkBox.Checked += (s, args) => this._radioButton.Checked = true;
                _checkBox.Unchecked += (s, args) => this._radioButton.Checked = false;
                this.SetNativeControl(_checkBox);
            }

        }

        private void ElementOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            if (propertyChangedEventArgs.PropertyName == "Checked")
            {
                this.Control.IsChecked = this.Element.Checked;
            }
            if (propertyChangedEventArgs.PropertyName == "Text")
            {
                this.Control.Content = Element.Text;
            }
            //if (propertyChangedEventArgs.PropertyName == "TextColor")
            //{
            //    this.Control.Foreground = this.Element.TextColor.ToBrush();
            //}

        }

        private void CheckedChanged(object sender, EventArgs<bool> eventArgs)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                _checkBox.IsChecked = eventArgs.Value;
            });
        }


    }
}
