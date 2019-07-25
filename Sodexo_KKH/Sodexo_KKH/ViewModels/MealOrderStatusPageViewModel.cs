using Newtonsoft.Json;
using Plugin.Connectivity;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using Sodexo_KKH.Helpers;
using Sodexo_KKH.Interfaces;
using Sodexo_KKH.Models;
using Sodexo_KKH.Resx;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using DependencyService = Xamarin.Forms.DependencyService;

namespace Sodexo_KKH.ViewModels
{
    public class MealOrderStatusPageViewModel : ViewModelBase
    {
        private mstr_ward_details _selectedWard;
        public mstr_ward_details SelectedWard
        {
            get { return _selectedWard; }
            set { SetProperty(ref _selectedWard, value); }
        }
        private mstr_meal_time _selectedMealTime;
        public mstr_meal_time SelectedMealTime
        {
            get { return _selectedMealTime; }
            set { SetProperty(ref _selectedMealTime, value); }
        }
        private string _selectedStatus;
        public string SelectedMealStatus
        {
            get { return _selectedStatus; }
            set { SetProperty(ref _selectedStatus, value); }
        }
        private List<mstr_ward_details> _wardData;
        public List<mstr_ward_details> WardData
        {
            get { return _wardData; }
            set { SetProperty(ref _wardData, value); }
        }
        private List<mstr_meal_time> _MealTimeList;
        public List<mstr_meal_time> MealTimeList
        {
            get { return _MealTimeList; }
            set { SetProperty(ref _MealTimeList, value); }
        }
        private ObservableCollection<meal_order_status> _mealOrderStatusCollection;
        public ObservableCollection<meal_order_status> MealOrderStatusCollection
        {
            get { return _mealOrderStatusCollection; }
            set { SetProperty(ref _mealOrderStatusCollection, value); }
        }
        private List<string> _statusList;
        public List<string> StatusList
        {
            get { return _statusList; }
            set { SetProperty(ref _statusList, value); }
        }
        private DateTime _selectedDate = DateTime.UtcNow;
        public DateTime SelectedDate
        {
            get { return _selectedDate; }
            set { SetProperty(ref _selectedDate, value); }
        }
        private bool _pbarBools;
        public bool pbarBools
        {
            get { return _pbarBools; }
            set { SetProperty(ref _pbarBools, value); }
        }
        int mealtime_id = 0;
        int ward_id = 0;

        string URL = Library.KEY_http + Library.KEY_SERVER_IP + "/" + Library.KEY_SERVER_LOCATION + "/sodexo.svc";
        public DelegateCommand SearchCommand { get; set; }
        public MealOrderStatusPageViewModel(INavigationService navigationService, IPageDialogService pageDialog) : base(navigationService, pageDialog)
        {
            MealOrderStatusCollection = new ObservableCollection<meal_order_status>();
            SearchCommand = new DelegateCommand(SearchMethod);
        }

        public void SearchMethod()
        {
            GetMealOrderStatus();
        }

        private async void GetMealOrderStatus()
        {
            try
            {
                if (CrossConnectivity.Current.IsConnected == true)
                {
                    try
                    {
                        MealOrderStatusCollection = new ObservableCollection<meal_order_status>();
                        pbarBools = true;

                        HttpClient httpClient = new System.Net.Http.HttpClient();

                        DateTime dt = SelectedDate;

                        string format_date = dt.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture);
                        var SelectedMealStatusIndex = StatusList.IndexOf(StatusList.First(x => x == SelectedMealStatus));

                        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, URL + "/" + Library.METHODE_GETMEALORDERSTATUS + "/" + SelectedWard.ID + "/" + format_date + "/" + SelectedMealTime.ID + "/" + SelectedMealStatusIndex.ToString() + "/" + Library.KEY_USER_SiteCode);
                        HttpResponseMessage response = await httpClient.SendAsync(request);
                        var data = await response.Content.ReadAsStringAsync();

                        MealOrderStatusCollection = JsonConvert.DeserializeObject<ObservableCollection<meal_order_status>>(data);
                        int srNo = 1;
                        foreach (var item in MealOrderStatusCollection)
                        {
                            item.SrNo = srNo++;
                        }

                        // stop
                        pbarBools = false;
                    }
                    catch (Exception excp)
                    {
                        // stop progressring
                        pbarBools = false;

                    }
                    pbarBools = false;

                }
                else
                {
                    pbarBools = false;
                    await PageDialog.DisplayAlertAsync("Alert!!", AppResources.ResourceManager.GetString("msg10", CultureInfo.CurrentCulture), "OK");
                }
            }
            catch (Exception excp)
            {
                // stop progressring
                pbarBools = false;
            }
        }

        private void FillWard()
        {
            try
            {
                var db = DependencyService.Get<IDBInterface>().GetConnection();

                WardData = new List<mstr_ward_details>(db.Query<mstr_ward_details>("Select ID,ward_name From mstr_ward_details where ward_type_name not like '%staff%' and status_id ='1' order by ID"));
                SelectedWard = WardData.FirstOrDefault();
            }
            catch (Exception exp)
            {
                PageDialog.DisplayAlertAsync("Alert!!", AppResources.ResourceManager.GetString(exp.Message, CultureInfo.CurrentCulture), "OK");
            }
        }
        private void FillStatus()
        {
            StatusList = new List<string> { "All", "Ordered", "Not Ordered", "NBM", "Home Leave", "Delivered" };
            SelectedMealStatus = "All";
        }
        private void FillMealTime()
        {
            try
            {
                var db = DependencyService.Get<IDBInterface>().GetConnection();
                MealTimeList = new List<mstr_meal_time>(db.Query<mstr_meal_time>("Select * From mstr_meal_time where status_id ='1' order by ID"));
                SelectedMealTime = MealTimeList.FirstOrDefault();
            }
            catch (Exception exp)
            {
                PageDialog.DisplayAlertAsync("Alert!!", AppResources.ResourceManager.GetString(exp.Message, CultureInfo.CurrentCulture), "OK");
            }
        }
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            FillWard();
            FillStatus();
            FillMealTime();
        }
    }
}