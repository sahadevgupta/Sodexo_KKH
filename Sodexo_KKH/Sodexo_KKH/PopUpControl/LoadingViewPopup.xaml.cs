using Rg.Plugins.Popup.Pages;
using Sodexo_KKH.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Sodexo_KKH.PopUpControl
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoadingViewPopup : PopupPage
    {
        private float _progress;

        public float Progress
        {
            get { return _progress; }
            set
            {
                _progress = value;
                prog.Progress = value;
                Debug.WriteLine(value);
            }
            
        }

        

        private List<LogDetail> _logDeatils;

        public List<LogDetail> logDeatils
        {
            get { return _logDeatils; }
            set
            {
                _logDeatils = value;
            }
        }


        


        public LoadingViewPopup()
        {
            InitializeComponent();
        }
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            var a = this.Parent as HomeMasterDetailPage;
            (a.Detail as NavigationPage).CurrentPage.Opacity = 0.5;
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            var a = this.Parent as HomeMasterDetailPage;
            (a.Detail as NavigationPage).CurrentPage.Opacity = 1;
        }
        protected override bool OnBackgroundClicked()
        {
            return false;
        }
    }

    public class LogDetail
    {
        public string Name { get; set; }
        public int totalRecord { get; set; }
        public int SuccessCount { get; set; }
    }
}