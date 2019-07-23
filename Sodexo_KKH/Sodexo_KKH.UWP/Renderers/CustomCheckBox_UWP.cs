using Sodexo_KKH.Controls;
using Sodexo_KKH.Events;
using Sodexo_KKH.UWP.Renderers;
using System.ComponentModel;
using Windows.UI.Xaml.Media;
using Xamarin.Forms.Platform.UWP;
using NativeCheckBox = Windows.UI.Xaml.Controls.CheckBox;

[assembly: ExportRenderer(typeof(CheckBox), typeof(CustomCheckBox_UWP))]
namespace Sodexo_KKH.UWP.Renderers
{
    public class CustomCheckBox_UWP : ViewRenderer<CheckBox, NativeCheckBox>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<CheckBox> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                e.OldElement.CheckedChanged -= CheckedChanged;
            }

            if (Control == null && e.NewElement != null)
            {
                var checkBox = new NativeCheckBox();
                checkBox.Checked += (s, args) => Element.Checked = true;
                checkBox.Unchecked += (s, args) => Element.Checked = false;
               // checkBox.Style = (Windows.UI.Xaml.Style)App.Current.Resources["CustomCheckBoxStyle"];
                SetNativeControl(checkBox);
            }
            if (e.NewElement == null || this.Control == null) return;

            Control.Content = e.NewElement.Text;
            Control.IsChecked = e.NewElement.Checked;
           // Control.Foreground = e.NewElement.TextColor.();

            UpdateFont();

            e.NewElement.CheckedChanged += CheckedChanged;
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "Checked":
                    Control.IsChecked = Element.Checked;
                    Control.Content = Element.Text;
                    break;
                case "TextColor":
                   // Control.Foreground = Element.TextColor.ToUwpSolidColorBrush();
                    break;
                case "FontName":
                case "FontSize":
                    UpdateFont();
                    break;
                case "CheckedText":
                case "UncheckedText":
                    Control.Content = Element.Text;
                    break;
                default:
                    base.OnElementPropertyChanged(sender, e);
                    break;
            }


        }
        private void CheckedChanged(object sender, EventArgs<bool> eventArgs)
        {
            Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
            {
                Control.Content = Element.Text;
                Control.IsChecked = eventArgs.Value;
            });
        }

        private void UpdateFont()
        {
            if (!string.IsNullOrEmpty(Element.FontFamily))
            {
                Control.FontFamily = new FontFamily(Element.FontFamily);
            }

            Control.FontSize = (Element.FontSize > 0) ? (float)Element.FontSize : 15.0f;
        }
    }
}
