using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Prism.Services;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using Sodexo_KKH.Helpers;
using Sodexo_KKH.Interfaces;
using Sodexo_KKH.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DependencyService = Xamarin.Forms.DependencyService;

namespace Sodexo_KKH.PopUpControl
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CancelOrderPopup : PopupPage
    {
        public IPageDialogService PageDialog { get; private set; }

        List<mstr_meal_history> PatientMealHistoryList;
        public bool IsChanged { get; set; }
        public CancelOrderPopup(List<mstr_meal_history> _PatientMealHistoryList, IPageDialogService pageDialog)
        {
            InitializeComponent();

            PageDialog = pageDialog;
            PatientMealHistoryList = new List<mstr_meal_history>(_PatientMealHistoryList);
            HistoryList.ItemsSource = PatientMealHistoryList;
            //Search clist in T2O PatientSearch page
        }
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            var a = this.BindingContext;
        }
        private async void Titlelbl_Close(object sender, EventArgs e)
        {
            await Navigation.PopPopupAsync();
        }

        private async void CancelBtn_Clicked(object sender, EventArgs e)
        {
            var selectedRecord = (sender as Button).BindingContext as mstr_meal_history;
            if (string.IsNullOrEmpty(selectedRecord.remarks))
            {
                await PageDialog.DisplayAlertAsync("Error!!", "Please Enter Remarks", "OK");
                return;
            }
            else
            {
                dynamic p = new JObject();
                p.Id = selectedRecord.Id;//id;
                p.createdby = selectedRecord.createdby;
                p.meal_detail_id = selectedRecord.meal_detail_id;
                p.mealtimeid = selectedRecord.mealtimeid;
                p.mealtimename = selectedRecord.mealtimename;
                p.orderdate = selectedRecord.orderdate;
                p.remark = selectedRecord.remarks;
                p.ward_bed = "";
                p.wardid = "";
                p.work_station_IP = DependencyService.Get<ILocalize>().GetIpAddress();
                p.system_module = DependencyService.Get<ILocalize>().GetDeviceName();//GetMachineNameFromIPAddress(p.work_station_IP);

                string json = JsonConvert.SerializeObject(p);

                var httpClient = new HttpClient();
                var url = Library.KEY_http + Library.KEY_SERVER_IP + "/" + Library.KEY_SERVER_LOCATION + "/sodexo.svc/OrderCanceled";

                var result = await httpClient.PostAsync(url, new StringContent(json, Encoding.UTF8, "application/json"));
                var contents = await result.Content.ReadAsStringAsync();


                if (contents == "true")
                {
                    await PageDialog.DisplayAlertAsync("Alertt!!", "Meal Order Successfully Cancelled", "OK");
                    HistoryList.ItemsSource = new List<mstr_meal_history>();
                    PatientMealHistoryList.Remove(selectedRecord);
                    HistoryList.ItemsSource = PatientMealHistoryList;
                    IsChanged = true;
                }
                else
                    await DisplayAlert("", "Meal Order cancellation failed!!", "OK");

                if (!PatientMealHistoryList.Any())
                {
                    await Navigation.PopAllPopupAsync();
                }
            }
        }
    }
}