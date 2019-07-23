using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace Sodexo_KKH.ViewModels
{
    public class ViewModelBase : BindableBase, INavigationAware, IDestructible
    {
        protected INavigationService NavigationService { get; private set; }
        protected IPageDialogService PageDialog { get; private set; }
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private bool _isPageEnabled;
        public bool IsPageEnabled
        {
            get { return _isPageEnabled; }
            set { SetProperty(ref _isPageEnabled, value); }
        }


        private bool _isNotConnected;

        public bool IsNotConnected
        {
            get { return this._isNotConnected; }
            set { SetProperty(ref _isNotConnected, value); }
        }

        public ViewModelBase(INavigationService navigationService,IPageDialogService pageDialog)
        {
            NavigationService = navigationService;
            PageDialog = pageDialog;
            Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;
            IsNotConnected = Connectivity.NetworkAccess != NetworkAccess.Internet;
        }
        ~ViewModelBase()
        {
            Connectivity.ConnectivityChanged -= Connectivity_ConnectivityChanged;
        }
        private void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            IsNotConnected = e.NetworkAccess != NetworkAccess.Internet;
        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {
            
        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {
            
        }

        public virtual void OnNavigatingTo(INavigationParameters parameters)
        {
            
        }

        public virtual void Destroy()
        {
            
        }
    }
}
