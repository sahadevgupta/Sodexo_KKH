using System;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Sodexo_KKH.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FloatingEntry : ContentView
    {
        public event EventHandler EntryUnfocused;
        //int _placeholderFontSize = 18;
        //int _titleFontSize = 14;
        //int _topMargin = -32;

        //public event EventHandler Completed;
        //public event EventHandler EntryUnfocused;

        //public static readonly BindableProperty TextProperty = BindableProperty.Create
        //    (
        //        nameof(Text),
        //        typeof(string),
        //        typeof(string),
        //        string.Empty,
        //        BindingMode.TwoWay,null,HandleBindingPropertyChangedDelegate

        //    );

        //public static readonly BindableProperty TitleProperty = BindableProperty.Create
        //    (
        //        nameof(Title),
        //        typeof(string),
        //        typeof(string),
        //        string.Empty,
        //        BindingMode.TwoWay,null
        //    );
        //public static readonly BindableProperty ReturnTypeProperty = BindableProperty.Create
        //    (
        //        nameof(ReturnType),
        //        typeof(ReturnType),
        //        typeof(FloatingEntry),
        //        ReturnType.Default
        //    );
        //public static readonly BindableProperty IsPasswordProperty = BindableProperty.Create
        //    (
        //        nameof(IsPassword),
        //        typeof(bool),
        //        typeof(FloatingEntry),
        //        default(bool)
        //    );
        //public static readonly BindableProperty KeyboardProperty = BindableProperty.Create
        //    (
        //        nameof(Keyboard),
        //        typeof(Keyboard),
        //        typeof(FloatingEntry),
        //        Keyboard.Default,
        //        coerceValue: (o,v) => (Keyboard)v ?? Keyboard.Default
        //    );
        //public FloatingEntry()
        //{
        //    InitializeComponent();
        //    LabelTitle.TranslationX = 10;
        //    LabelTitle.FontSize = _placeholderFontSize;
        //}
        //public new void Focus()
        //{
        //    if (IsEnabled)
        //    {
        //        EntryField.Focus();
        //    }
        //}


        //public string Text
        //{
        //    get => (string)GetValue(TextProperty);
        //    set => SetValue(TextProperty, value);
        //}

        //public string Title
        //{
        //    get => (string)GetValue(TitleProperty);
        //    set => SetValue(TitleProperty, value);
        //}

        //public ReturnType ReturnType
        //{
        //    get => (ReturnType)GetValue(ReturnTypeProperty);
        //    set => SetValue(ReturnTypeProperty, value);
        //}
        //public bool IsPassword
        //{
        //    get { return (bool)GetValue(IsPasswordProperty); }
        //    set { SetValue(IsPasswordProperty, value); }
        //}

        //public Keyboard Keyboard
        //{
        //    get { return (Keyboard)GetValue(KeyboardProperty); }
        //    set { SetValue(KeyboardProperty, value); }
        //}

        //static async void HandleBindingPropertyChangedDelegate(BindableObject bindable, object oldValue, object newValue)
        //{
        //    var control = bindable as FloatingEntry;
        //    if (!control.EntryField.IsFocused)
        //    {
        //        if (!string.IsNullOrEmpty((string)newValue))
        //        {
        //            await control.TransitionToTitle(false);
        //        }
        //        else
        //        {
        //            await control.TransitionToPlaceholder(false);
        //        }
        //    }
        //}

        //private async void EntryField_Unfocused(object sender, FocusEventArgs e)
        //{
        //    if (string.IsNullOrEmpty(Text))
        //    {
        //        await TransitionToPlaceholder(true);


        //    }
        //    else
        //        EntryUnfocused?.Invoke(this, e);
        //}

        //private async Task TransitionToTitle(bool animated)
        //{
        //    if (animated)
        //    {
        //        var t1 = LabelTitle.TranslateTo(0, _topMargin, 100);
        //        var t2 = SizeTo(_titleFontSize);
        //        await Task.WhenAll(t1, t2);
        //    }
        //    else
        //    {
        //        LabelTitle.TranslationX = 0;
        //        LabelTitle.TranslationY = -30;
        //        LabelTitle.FontSize = 14;
        //    }
        //}
        //async Task TransitionToPlaceholder(bool animated)
        //{
        //    if (animated)
        //    {
        //        var t1 = LabelTitle.TranslateTo(10, 0, 100);
        //        var t2 = SizeTo(_placeholderFontSize);
        //        await Task.WhenAll(t1, t2);
        //    }
        //    else
        //    {
        //        LabelTitle.TranslationX = 10;
        //        LabelTitle.TranslationY = 0;
        //        LabelTitle.FontSize = _placeholderFontSize;
        //    }
        //}

        //private async void EntryField_Focused(object sender, FocusEventArgs e)
        //{
        //    if (string.IsNullOrEmpty(Text))
        //    {
        //        await TransitionToTitle(true);
        //    }
        //}

        //private void Handle_Tapped(object sender, EventArgs e)
        //{
        //    if (IsEnabled)
        //    {
        //        EntryField.Focus();
        //    }
        //}
        //Task SizeTo(int fontSize)
        //{
        //    var taskCompletionSource = new TaskCompletionSource<bool>();

        //    // setup information for animation
        //    Action<double> callback = input => { LabelTitle.FontSize = input; };
        //    double startingHeight = LabelTitle.FontSize;
        //    double endingHeight = fontSize;
        //    uint rate = 5;
        //    uint length = 100;
        //    Easing easing = Easing.Linear;

        //    // now start animation with all the setup information
        //    LabelTitle.Animate("invis", callback, startingHeight, endingHeight, rate, length, easing, (v, c) => taskCompletionSource.SetResult(c));

        //    return taskCompletionSource.Task;
        //}
        //void Handle_Completed(object sender, EventArgs e)
        //{
        //    Completed?.Invoke(this, e);
        //}
        //protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        //{
        //    base.OnPropertyChanged(propertyName);

        //    if (propertyName == nameof(IsEnabled))
        //    {
        //        EntryField.IsEnabled = IsEnabled;
        //    }
        //}


        public static BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(FloatingEntry), defaultBindingMode: BindingMode.TwoWay);
        public static BindableProperty PlaceholderProperty = BindableProperty.Create(nameof(Placeholder), typeof(string), typeof(FloatingEntry), defaultBindingMode: BindingMode.TwoWay, propertyChanged: (bindable, oldVal, newval) =>
        {
            var matEntry = (FloatingEntry)bindable;
            matEntry.EntryField.Placeholder = (string)newval;
            matEntry.HiddenLabel.Text = (string)newval;
        });

        public static BindableProperty IsPasswordProperty = BindableProperty.Create(nameof(IsPassword), typeof(bool), typeof(FloatingEntry), defaultValue: false, propertyChanged: (bindable, oldVal, newVal) =>
        {
            var matEntry = (FloatingEntry)bindable;
            matEntry.EntryField.IsPassword = (bool)newVal;
        });
        public static BindableProperty KeyboardProperty = BindableProperty.Create(nameof(Keyboard), typeof(Keyboard), typeof(FloatingEntry), defaultValue: Keyboard.Default, propertyChanged: (bindable, oldVal, newVal) =>
        {
            var matEntry = (FloatingEntry)bindable;
            matEntry.EntryField.Keyboard = (Keyboard)newVal;
        });
        public static BindableProperty AccentColorProperty = BindableProperty.Create(nameof(AccentColor), typeof(Color), typeof(FloatingEntry), defaultValue: Color.Accent);
        public Color AccentColor
        {
            get
            {
                return (Color)GetValue(AccentColorProperty);
            }
            set
            {
                SetValue(AccentColorProperty, value);
            }
        }
        public Keyboard Keyboard
        {
            get
            {
                return (Keyboard)GetValue(KeyboardProperty);
            }
            set
            {
                SetValue(KeyboardProperty, value);
            }
        }

        public bool IsPassword
        {
            get
            {
                return (bool)GetValue(IsPasswordProperty);
            }
            set
            {
                SetValue(IsPasswordProperty, value);
            }
        }

        public string Text
        {
            get
            {
                return (string)GetValue(TextProperty);
            }
            set
            {
                SetValue(TextProperty, value);
            }
        }
        public string Placeholder
        {
            get
            {
                return (string)GetValue(PlaceholderProperty);
            }
            set
            {
                SetValue(PlaceholderProperty, value);
            }
        }
        public FloatingEntry()
        {
            InitializeComponent();
            EntryField.BindingContext = this;
            EntryField.Focused += async (s, a) =>
            {
                HiddenLabel.TextColor = AccentColor;
                HiddenLabel.IsVisible = true;
                if (string.IsNullOrEmpty(EntryField.Text))
                {
                    // animate both at the same time
                    await Task.WhenAll(
                        HiddenLabel.FadeTo(1, 60),
                        HiddenLabel.TranslateTo(HiddenLabel.TranslationX, EntryField.Y - EntryField.Height + 4, 200, Easing.BounceIn)
                     );
                    EntryField.Placeholder = null;
                }

            };
            EntryField.Unfocused += async (s, a) =>
            {
                HiddenLabel.TextColor = Color.Gray;
                if (string.IsNullOrEmpty(EntryField.Text))
                {
                    // animate both at the same time
                    await Task.WhenAll(
                        HiddenLabel.FadeTo(0, 180),
                        HiddenLabel.TranslateTo(HiddenLabel.TranslationX, EntryField.Y, 200, Easing.BounceIn)
                     );
                    EntryField.Placeholder = Placeholder;
                }

                EntryUnfocused?.Invoke(this, a);
            };
        }
    }
}
