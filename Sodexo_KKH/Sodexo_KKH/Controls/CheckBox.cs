using Sodexo_KKH.Converters;
using Sodexo_KKH.Events;
using System;
using Xamarin.Forms;

namespace Sodexo_KKH.Controls
{
    public class CheckBox : Button
    {
        public int Id { get; set; }
        public CheckBox()
        {
            base.Image = PlatFromImage.GetImage("newcbu.png");
            base.Clicked += new EventHandler(OnClicked);
            // base.SizeChanged += new EventHandler(OnSizeChanged);
            base.BackgroundColor = Color.Transparent;
            base.BorderWidth = 0;
        }

        private void OnSizeChanged(object sender, EventArgs e)
        {
            //if (base.Height > 0)
            //{
            //    base.WidthRequest = base.Height;
            //}
        }

        public static BindableProperty CheckedProperty = BindableProperty.Create(
            propertyName: "Checked",
            returnType: typeof(Boolean),
            declaringType: typeof(CheckBox),
            defaultValue: false,
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: CheckedValueChanged);

        public Boolean Checked
        {
            get
            {

                return (Boolean)GetValue(CheckedProperty);
            }
            set
            {
                SetValue(CheckedProperty, value);
                OnPropertyChanged();
                RaiseCheckedChanged();
            }
        }

        private static void CheckedValueChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if ((Boolean)newValue == true)
            {

                switch (Device.RuntimePlatform)
                {
                    case Device.Android:
                    case Device.iOS:
                        ((CheckBox)bindable).Image = "newcbc.png";
                        break;
                    case Device.UWP:
                        ((CheckBox)bindable).Image = "Assets/newcbc.png";
                        break;
                }
            }
            else
            {
                switch (Device.RuntimePlatform)
                {
                    case Device.Android:
                    case Device.iOS:
                        ((CheckBox)bindable).Image = "newcbu.png";
                        break;

                    case Device.UWP:
                        ((CheckBox)bindable).Image = "Assets/newcbu.png";
                        break;
                }
            }
        }

        public event EventHandler<EventArgs<bool>> CheckedChanged;
        private void RaiseCheckedChanged()
        {
            CheckedChanged?.Invoke(this, Checked);
        }

        private bool _IsEnabled = true;
        public new bool IsEnabled
        {
            get
            {
                return _IsEnabled;
            }
            set
            {
                _IsEnabled = value;
                OnPropertyChanged();
                if (value == true)
                {
                    this.Opacity = 1;
                }
                else
                {
                    this.Opacity = .5;
                }
            }
        }



        public void OnClicked(object sender, EventArgs e)
        {
            Checked = !Checked;
        }

    }
}
