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

        async void MasterUpdateNotify()
        {
            try
            {
                if (CrossConnectivity.Current.IsConnected == true)
                {
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
                        httpResponse = await httpClient.PostAsync(Library.URL + "/othernotification", httpContent);

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

        async void MenuUpdateNotify()
        {
            try
            {
                if (CrossConnectivity.Current.IsConnected)
                {

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


                        httpResponse = await httpClient.PostAsync(Library.URL + "/Menunotification", httpContent);



                        if (httpResponse.Content != null)
                        {
                            var responseContent = await httpResponse.Content.ReadAsStringAsync();
                            if (responseContent == "true")
                            {
                                isMenuNotificationAvailable = true;
                                IsMenuAvailable = true;
                                ShowToastNotification("T2O", "An Update is Available for Menu Master!");

                            }
                            else
                            {
                                IsMenuAvailable = false;
                            }

                        }
                    }
                    
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

                               await Task.Run(async() => 
                                {
                                    await MasterSync.Sync_mstr_patient_info();
                                });
                                

                                await navigation.PopPopupAsync();

                                await PageDialog.DisplayAlertAsync("Alert!!", "Patient data synced successfully.", "OK");
                            }
                            else
                                await PageDialog.DisplayAlertAsync("Alert!!", "Server is not accessible, please check internet connection.", "OK");
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
                            isMstrNotificationAvailable = true;
                            var ui = new LoadingViewPopup();
                            await navigation.PushPopupAsync(ui);

                            int atime = Convert.ToInt32(Library.KEY_USER_adjusttime);
                            string tm = DateTime.Now.AddMinutes(-atime).ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);

                            Library.last_mastersynctime = tm;
                           
                            await MasterSync.SyncMaster(ui);

                            

                            MessagingCenter.Send<App, string>((App)Xamarin.Forms.Application.Current, "MasterSync", "Master");
                            await PageDialog.DisplayAlertAsync("Alert!!", "Master data synced successfully.", "OK");
                            await navigation.PopPopupAsync();
                            isMstrNotificationAvailable = false;
                           
                        }
                        else
                            await PageDialog.DisplayAlertAsync("Alert!!", "Server is not accessible, please check internet connection.", "OK");
                        IsPageEnabled = false;

                    }
                    break;
                case "Menu":
                    {
                        IsPageEnabled = true;
                        if (CrossConnectivity.Current.IsConnected)
                        {
                            isMenuNotificationAvailable = true;
                           var ui = new LoadingViewPopup();
                            await navigation.PushPopupAsync(ui);

                            int atime = Convert.ToInt32(Library.KEY_USER_adjusttime);
                            string tm = DateTime.Now.AddMinutes(-atime).ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);

                            Library.last_mealssynctime = tm;


                            await MasterSync.SyncMenuMaster(ui);

                            //await MasterSync.Sync_mstr_menu_master();
                            //await MasterSync.Sync_mstr_menu_item();

                            

                            await PageDialog.DisplayAlertAsync("Alert!!", "Menu Items synced succeesfully.", "OK");
                            await navigation.PopPopupAsync();
                            isMenuNotificationAvailable = false;
                           
                        }
                        else
                            await PageDialog.DisplayAlertAsync("Alert!!", "Server is not accessible, please check internet connection.", "OK");
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
                            await PageDialog.DisplayAlertAsync("Alert!!", "Feedback link not available", "OK");
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
                                    await PageDialog.DisplayAlertAsync("Alert!!", "Meal Orders Have been synced successfully", "OK");
                                }

                                MessagingCenter.Send<App, string>((App)Xamarin.Forms.Application.Current, "offlineOrderSync", "offlineOrder");


                            }
                        }
                        else
                            await PageDialog.DisplayAlertAsync("Error!!", "Please check your internet connection.", "OK");
                    }
                    catch (Exception)
                    {


                    }

                    break;
                case "LogOut":
                    {
                        var response = await PageDialog.DisplayAlertAsync("Log Out", "Are you sure you want to logout?", "Yes", "No");
                        if (response)
                        {
                            if (CrossConnectivity.Current.IsConnected)
                            {

                                using (var httpClient = new System.Net.Http.HttpClient())
                                {

                                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, Library.URL + "/updatelogfalse/" + Library.KEY_USER_ID);

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
