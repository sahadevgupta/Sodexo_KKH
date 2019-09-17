﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace Sodexo_KKH.Controls
{
    public class SegmentedBarControl : ContentView
    {
        public static readonly BindableProperty ItemSelectedProperty = BindableProperty.Create(nameof(ItemSelected), typeof(string), typeof(SegmentedBarControl), null);
        public static readonly BindableProperty ChildrenProperty = BindableProperty.Create(nameof(Children), typeof(List<string>), typeof(SegmentedBarControl), null);
        public static readonly BindableProperty TextColorProperty = BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(SegmentedBarControl), Color.DarkGray);
        public static readonly BindableProperty SelectedLineColorProperty = BindableProperty.Create(nameof(SelectedLineColor), typeof(Color), typeof(SegmentedBarControl), Color.Black);
        public static readonly BindableProperty SelectedTextColorProperty = BindableProperty.Create(nameof(SelectedTextColor), typeof(Color), typeof(SegmentedBarControl), Color.Black);
        public static readonly BindableProperty AutoScrollProperty = BindableProperty.Create(nameof(AutoScroll), typeof(bool), typeof(SegmentedBarControl), true);


        public static readonly BindableProperty SelectedItemChangedCommandProperty = BindableProperty.Create(nameof(SelectedItemChangedCommand), typeof(Command<string>), typeof(SegmentedBarControl), default(Command<string>), BindingMode.TwoWay, null, SelectedItemChangedCommandPropertyChanged);

        static void SelectedItemChangedCommandPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var source = bindable as SegmentedBarControl;
            if (source == null)
            {
                return;
            }
            source.SelectedItemChangedCommandChanged();
        }

        private void SelectedItemChangedCommandChanged()
        {
            OnPropertyChanged("SelectedItemChangedCommand");
        }

        public Command<string> SelectedItemChangedCommand
        {
            get
            {
                return (Command<string>)GetValue(SelectedItemChangedCommandProperty);
            }
            set
            {
                SetValue(SelectedItemChangedCommandProperty, value);
            }
        }
        public delegate void SelectedItemChangedEventHandler(object sender, SelectedItemChangedEventArgs e);
        public event SelectedItemChangedEventHandler SelectedItemChanged;

        public string ItemSelected
        {
            get
            {
                return (string)GetValue(ItemSelectedProperty);
            }
            set
            {
                SetValue(ItemSelectedProperty, value);
                SelectedItemChanged(this, new SelectedItemChangedEventArgs(value));
                SelectedItemChangedCommand?.Execute(value);
            }
        }

        public List<string> Children
        {
            get
            {
                return (List<string>)GetValue(ChildrenProperty);
            }
            set
            {
                SetValue(ChildrenProperty, value);
            }
        }

        public Color TextColor
        {
            get
            {
                return (Color)GetValue(TextColorProperty);
            }
            set
            {
                SetValue(TextColorProperty, value);
            }
        }

        public Color SelectedTextColor
        {
            get
            {
                return (Color)GetValue(SelectedTextColorProperty);
            }
            set
            {
                SetValue(SelectedTextColorProperty, value);
            }
        }

        public Color SelectedLineColor
        {
            get
            {
                return (Color)GetValue(SelectedLineColorProperty);
            }
            set
            {
                SetValue(SelectedLineColorProperty, value);
            }
        }

        public bool AutoScroll
        {
            get
            {
                return (bool)GetValue(AutoScrollProperty);
            }
            set
            {
                SetValue(AutoScrollProperty, value);
            }
        }


        StackLayout _mainContentLayout = new StackLayout() { Spacing = 10, Orientation = StackOrientation.Horizontal };
        StackLayout _lastElementSelected;
        ScrollView _mainLayout = new ScrollView() { VerticalOptions = LayoutOptions.Start, Orientation = ScrollOrientation.Horizontal, HorizontalScrollBarVisibility = ScrollBarVisibility.Never };

        void LoadChildrens()
        {

            _mainContentLayout.Children.Clear();
            foreach (var item in Children)
            {
                var vstack = new StackLayout();
                
                
                var label = new Label()
                {
                    FontAttributes = FontAttributes.Bold,
                    Text = item,
                    FontSize = 20,
                    TextColor = TextColor,
                    Margin = new Thickness(10, 0),
                    HorizontalOptions = LayoutOptions.CenterAndExpand
                };

                var vBox = new BoxView()
                {
                    Margin = new Thickness(0, 0, 5, 0),
                    HeightRequest = 5,
                    BackgroundColor = Color.Transparent
                };

                vstack.Children.Add(label);
                vstack.Children.Add(vBox);

                var boxview = new BoxView()
                {
                    BackgroundColor = Color.Gray,
                    WidthRequest = 5,
                    HorizontalOptions = LayoutOptions.FillAndExpand
                };
                var childrenLayout = new StackLayout() { Spacing = 5,Orientation = StackOrientation.Horizontal};

                childrenLayout.Children.Add(vstack);
                childrenLayout.Children.Add(boxview);
                childrenLayout.ClassId = item;
                _mainContentLayout.Children.Add(childrenLayout);
                var tapGestureRecognizer = new TapGestureRecognizer();
                tapGestureRecognizer.Tapped += (s, e) => {
                    ItemSelected = ((StackLayout)s).ClassId;
                };
                childrenLayout.GestureRecognizers.Add(tapGestureRecognizer);
            }


            _mainLayout.Content = _mainContentLayout;

            var mainContentLayout = new StackLayout() { Spacing = 0 };
            mainContentLayout.Children.Add(_mainLayout);
            //mainContentLayout.Children.Add(new BoxView() { HeightRequest = 0.5, HorizontalOptions = LayoutOptions.FillAndExpand, BackgroundColor = Color.Silver });

            this.Content = mainContentLayout;

        }

        void SelectElement(StackLayout itemSelected)
        {
            if (_lastElementSelected != null)
            {
                //var box1 = (_lastElementSelected.Children.Where(p => p is BoxView).First() as BoxView);
                //box1.BackgroundColor = Color.Transparent;
                //(_lastElementSelected.Children.First(p => p is Label) as Label).TextColor = TextColor;

                var stack1 = (_lastElementSelected.Children.Where(p => p is StackLayout).First() as StackLayout);
                (stack1.Children.First(x => x is Label) as Label).TextColor = TextColor;
                (stack1.Children.First(x => x is BoxView) as BoxView).BackgroundColor = Color.Transparent;
            }

            //(itemSelected.Children.Where(p => p is BoxView).First() as BoxView).BackgroundColor = SelectedLineColor;
            var stack =  (itemSelected.Children.Where(p => p is StackLayout).First() as StackLayout);
            (stack.Children.First(x => x is Label) as Label).TextColor = SelectedTextColor;
            (stack.Children.First(x => x is BoxView) as BoxView).BackgroundColor = SelectedLineColor;
            _lastElementSelected = itemSelected;

            if (AutoScroll)
                _mainLayout.ScrollToAsync(itemSelected, ScrollToPosition.MakeVisible, true);
        }

        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == ItemSelectedProperty.PropertyName && Children != null && Children.Count > 0)
            {
                SelectElement(_mainContentLayout.Children[Children.IndexOf(ItemSelected)] as StackLayout);
            }
            else if (propertyName == ChildrenProperty.PropertyName && Children != null)
            {
                LoadChildrens();
                if (string.IsNullOrEmpty(ItemSelected))
                {
                    if (Children.Any())
                        ItemSelected = Children?.First();
                    
                }
                else
                {
                    SelectElement(_mainContentLayout.Children[Children.IndexOf(ItemSelected)] as StackLayout);
                }
            }
        }
    }
}