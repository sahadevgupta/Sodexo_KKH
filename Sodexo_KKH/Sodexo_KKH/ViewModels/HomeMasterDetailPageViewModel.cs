using Newtonsoft.Json;
using Plugin.Connectivity;
using Prism.Navigation;
using Prism.Services;
using Rg.Plugins.Popup.Extensions;
using Sodexo_KKH.Helpers;
using Sodexo_KKH.Interfaces;
using Sodexo_KKH.Models;
using Sodexo_KKH.PopUpControl;
using Sodexo_KKH.Repos;
using Sodexo_KKH.Resx;
using System;
using System.Dynamic;
using System.Globalization;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Xamarin.Forms;
using DependencyService = Xamarin.Forms.DependencyService;

namespace Sodexo_KKH.ViewModels
{
    public class HomeMasterDetailPageViewModel : ViewModelBase
    {
        private string _user = Library.KEY_USER_FIRST_NAME;
        public string User
        {
            get { return _user; }
            set { SetProperty(ref _user, value); }
        }

        private string _userRole = Library.KEY_USER_ROLE;
        public string UserRole
        {
            get { return _userRole; }
            set { SetProperty(ref _userRole, value); }
        }
        private string _userSiteCode = Library.KEY_USER_SiteCode;
        public string UserSiteCode
        {
            get { return _userSiteCode; }
            set { SetProperty(ref _userSiteCode, value); }
        }

        private int _orderCount;
        public int OrderCount
        {
            get { return this._orderCount; }
            set { SetProperty(ref _orderCount, value); }
        }


        private bool _isMasterAvailable;

        public bool IsMasterAvailable
        {
            get { return this._isMasterAvailable; }
            set { SetProperty(ref _isMasterAvailable, value); }
        }

        private bool _isMenuAvailable;

        public bool IsMenuAvailable
        {
            get { return this._isMenuAvailable; }
            set { SetProperty(ref _isMenuAvailable, value); }
        }

        public bool isMstrNotificationAvailable;
        public bool isMenuNotificationAvailable;
        public INavigation navigation { get; set; }

        IGenericRepo<mstr_meal_order_local> _orderlocalRepo;
        IGenericRepo<mstr_meal_time> _mealtimeRepo;
        public HomeMasterDetailPageViewModel(INavigationService navigationService, IGenericRepo<mstr_meal_order_local> orderlocalRepo,
            IGenericRepo<mstr_meal_time> mealtimeRepo, IPageDialogService pageDialog) : base(navigationService, pageDialog)
        {
            _orderlocalRepo = orderlocalRepo;
            _mealtimeRepo = mealtimeRepo;

            MessagingCenter.Subscribe<App, string>((App)Xamarin.Forms.Application.Current, "LocalOrder", OnlocalOrderReceived);

            LoadData();
        }

        private void OnlocalOrderReceived(App arg1, string arg2)
        {
            OfflineOrderCount();
        }

        private void LoadData()
        {
            OfflineOrderCount();

            GetUpdateNotification();
        }
        private void GetUpdateNotification()
        {
            System.Timers.Timer timer = new System.Timers.Timer(10000);
            timer.AutoReset = true; // the key is here so it repeats
            timer.Elapsed += timer_elapsed;
            timer.Start();




            //var timer = new System.Threading.Timer((e) =>
            //{
            //    if (!isMstrNotificationAvailable)
            //    {
            //       MasterUpdateNotify();
            //    }
            //    if (!isMenuNotificationAvailable)
            //    {
            //        MenuUpdateNotify();
            //    }
            //}, null, startTimeSpan, periodTimeSpan);




            //Device.StartTimer(TimeSpan.FromSeconds(10), callback: () =>
            //{


            //    return true;
            //});

        }

        private void timer_elapsed(object sender, ElapsedEventArgs e)
        {
            if (!isMstrNotificationAvailable)
            {
                MasterUpdateNotify();
            }
            if (!isMenuNotificationAvailable)
            {
                MenuUpdateNotify();
            }
        }

        void OfflineOrderCount()
        {
            var localOrder = _orderlocalRepo.QueryTable();
            OrderCount = localOrder.Count();

        }

        async Task MasterUpdateNotify()
        {
            try
            {
                if (CrossConnectivity.Current.IsConnected == true)
                {
                    string URL = Library.KEY_http + Library.KEY_SERVER_IP + "/" + Library.KEY_SERVER_LOCATION + "/sodexo.svc";

                    //start progessring
                    //   pbar.IsBusy = true;
                    //  pbar.IsEnabled = true;

                    dynamic p = new ExpandoObject();
                    p.country_id = Library.KEY_USER_ccode;
                    string dt = Library.last_mastersynctime;
                    p.date = dt;
                    p.region_id = Library.KEY_USER_regcode;
                    //   p.set_menu_id = setid;
                    p.site_id = Library.KEY_USER_siteid;

                    //var stringPayload = await Task.Run(() => JsonConvert.SerializeObject(p));
                    string stringPayload = JsonConvert.SerializeObject(p);
                    // Wrap our JSON inside a StringContent which then can be used by the HttpClient class
                    var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");

                    // display a message jason conversion
                    //var message1 = new MessageDialog("Data is converted in json.");
                    //await message1.ShowAsync();

                    using (var httpClient = new System.Net.Http.HttpClient())
                    {
                        var httpResponse = new System.Net.Http.HttpResponseMessage();
                        httpResponse = await httpClient.PostAsync(URL + "/othernotification", httpContent);

                        if (httpResponse.Content != null)
                        {
                            var responseContent = await httpResponse.Content.ReadAsStringAsync();
                            if (responseContent == "true")
                            {
                                isMstrNotificationAvailable = true;
                                IsMasterAvailable = true;
                                ShowToastNotification("T2O", "An Update is Available for All Master!");

                            }
                            else
                            {

                                IsMasterAvailable = false;
                            }

                        }
                    }

                }

            }
            catch (Exception)
            {


            }

        }

        async Task MenuUpdateNotify()
        {
            try
            {
                if (CrossConnectivity.Current.IsConnected)
                {
                    string URL = Library.KEY_http + Library.KEY_SERVER_IP + "/" + Library.KEY_SERVER_LOCATION + "/sodexo.svc";


                    dynamic p = new ExpandoObject();
                    p.country_id = Library.KEY_USER_ccode;
                    string dt = Library.last_mealssynctime;
                    p.date = dt;
                    p.region_id = Library.KEY_USER_regcode;
                    //   p.set_menu_id = setid;
                    p.site_id = Library.KEY_USER_siteid;

                    //var stringPayload = await Task.Run(() => JsonConvert.SerializeObject(p));
                    string stringPayload = JsonConvert.SerializeObject(p);
                    // Wrap our JSON inside a StringContent which then can be used by the HttpClient class
                    var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");

                    // display a message jason conversion
                    //var message1 = new MessageDialog("Data is converted in json.");
                    //await message1.ShowAsync();

                    using (var httpClient = new System.Net.Http.HttpClient())
                    {
                        var httpResponse = new System.Net.Http.HttpResponseMessage();


                        httpResponse = await httpClient.PostAsync(URL + "/Menunotification", httpContent);



                        if (httpResponse.Content != null)
                        {
                            var responseContent = await httpResponse.Content.ReadAsStringAsync();
                            if (responseContent == "true")
                            {
                                isMenuNotificationAvailable = true;
                                IsMenuAvailable = true;
                                ShowToastNotification("T2O", "An Update is Available for Menu Master!");
                                //   mastervis.Visibility = Visibility.Visible;

                            }
                            else
                            {
                                IsMenuAvailable = false;
                                //   mastervis.Visibility = Visibility.Collapsed;
                            }

                        }
                    }
                    // pbar.IsBusy = false;
                    //    pbar.IsEnabled = false;
                }
            }
            catch (Exception)
            {


            }

        }

        private void ShowToastNotification(string title, string body)
        {
            if (isMenuNotificationAvailable || isMstrNotificationAvailable)
                DependencyService.Get<INotify>().ShowLocalNotification(title, body);

        }

        public async void DrawerSelected(string obj)
        {

            switch (obj)
            {
                case "Patient_Search":
                    await NavigationService.NavigateAsync("NavigationPage/PatientSearchPage");
                    break;
                case "Patient":
                    {
                        try
                        {
                            if (CrossConnectivity.Current.IsConnected == true)
                            {
                                var ui = new LoadingViewPopup();
                                await navigation.PushPopupAsync(ui);

                                string URL = Library.KEY_http + Library.KEY_SERVER_IP + "/" + Library.KEY_SERVER_LOCATION + "/sodexo.svc";
                                await MasterSync.Sync_mstr_patient_info();

                                await navigation.PopPopupAsync();

                                await PageDialog.DisplayAlertAsync("Alert!!", AppResources.ResourceManager.GetString("msg7", CultureInfo.CurrentCulture), "OK");
                            }
                            else
                                await PageDialog.DisplayAlertAsync("Alert!!", AppResources.ResourceManager.GetString("msg10", CultureInfo.CurrentCulture), "OK");
                        }
                        catch (Exception)
                        {
                        }
                    }
                    break;
                case "Master":
                    {
                        IsPageEnabled = true;
                        if (CrossConnectivity.Current.IsConnected)
                        {
                            isMstrNotificationAvailable = false;
                            var ui = new LoadingViewPopup();
                            await navigation.PushPopupAsync(ui);

                            int atime = Convert.ToInt32(Library.KEY_USER_adjusttime);
                            string tm = DateTime.Now.AddMinutes(-atime).ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);

                            Library.last_mastersynctime = tm;

                            await MasterSync.SyncMaster();


                            await navigation.PopPopupAsync();

                            MessagingCenter.Send<App, string>((App)Xamarin.Forms.Application.Current, "MasterSync", "Master");
                            await PageDialog.DisplayAlertAsync("Alert!!", AppResources.ResourceManager.GetString("msg0", CultureInfo.CurrentCulture), "OK");


                        }
                        else
                            await PageDialog.DisplayAlertAsync("Alert!!", AppResources.ResourceManager.GetString("msg10", CultureInfo.CurrentCulture), "OK");
                        IsPageEnabled = false;

                    }
                    break;
                case "Menu":
                    {
                        IsPageEnabled = true;
                        if (CrossConnectivity.Current.IsConnected)
                        {
                            isMenuNotificationAvailable = false;
                            var ui = new LoadingViewPopup();
                            await navigation.PushPopupAsync(ui);

                            int atime = Convert.ToInt32(Library.KEY_USER_adjusttime);
                            string tm = DateTime.Now.AddMinutes(-atime).ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);

                            Library.last_mealssynctime = tm;

                            await MasterSync.Sync_mstr_menu_master();
                            await MasterSync.Sync_mstr_menu_item();




                            await navigation.PopPopupAsync();

                            await PageDialog.DisplayAlertAsync("Alert!!", AppResources.ResourceManager.GetString("msg8", CultureInfo.CurrentCulture), "OK");
                        }
                        else
                            await PageDialog.DisplayAlertAsync("Alert!!", AppResources.ResourceManager.GetString("msg10", CultureInfo.CurrentCulture), "OK");
                        IsPageEnabled = false;
                    }
                    break;
                case "Order":
                    await NavigationService.NavigateAsync("NavigationPage/DailyOrderDetailPage", new NavigationParameters { { "Create", "Create" } });
                    break;
                case "OrderStatus":
                    await NavigationService.NavigateAsync("NavigationPage/MealOrderStatusPage");
                    break;
                case "Feed":
                    {
                        if (Library.KEY_USER_feedback_link.Contains("http"))
                            await NavigationService.NavigateAsync("NavigationPage/FeedBackPage");
                        else
                            await PageDialog.DisplayAlertAsync("Alert!!", AppResources.ResourceManager.GetString("flna", CultureInfo.CurrentCulture), "OK");
                    }
                    break;
                case "Offline":
                    try
                    {
                        if (CrossConnectivity.Current.IsConnected)
                        {
                            if (OrderCount == 0)
                            {
                                await PageDialog.DisplayAlertAsync("No Data", "There is no offline order to be sync.", "OK");

                                return;
                            }
                            else
                            {
                                var ui = new LoadingViewPopup();
                                await navigation.PushPopupAsync(ui);

                                await ConfirmOrderSync.SyncNow(_orderlocalRepo, _mealtimeRepo, PageDialog);

                                OfflineOrderCount();


                                await navigation.PopPopupAsync();



                                if (OrderCount == 0)
                                {
                                    await PageDialog.DisplayAlertAsync("Alert!!", AppResources.ResourceManager.GetString("msg1", CultureInfo.CurrentCulture), "OK");
                                }

                                MessagingCenter.Send<App, string>((App)Xamarin.Forms.Application.Current, "offlineOrderSync", "offlineOrder");


                            }
                        }
                        else
                            await PageDialog.DisplayAlertAsync("Error!!", "Please check your internet connection.", "OK");
                    }
                    catch (Exception ex)
                    {


                    }

                    break;
                case "LogOut":
                    {
                        var response = await PageDialog.DisplayAlertAsync("Log Out", AppResources.ResourceManager.GetString("logsure", CultureInfo.CurrentCulture), AppResources.ResourceManager.GetString("contentyes", CultureInfo.CurrentCulture), AppResources.ResourceManager.GetString("contentno", CultureInfo.CurrentCulture));
                        if (response)
                        {
                            if (CrossConnectivity.Current.IsConnected)
                            {
                                string URL = Library.KEY_http + Library.KEY_SERVER_IP + "/" + Library.KEY_SERVER_LOCATION + "/sodexo.svc";

                                using (var httpClient = new System.Net.Http.HttpClient())
                                {

                                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, URL + "/updatelogfalse/" + Library.KEY_USER_ID);

                                    await httpClient.SendAsync(request);
                                }
                                Library.KEY_USER_ID = string.Empty;
                            }
                            SessionManager.Instance.EndTrackSession();
                            await NavigationService.NavigateAsync("app:///LoginPage");
                        }
                    }
                    break;
            }
            IsPageEnabled = false;
        }
    }
}
