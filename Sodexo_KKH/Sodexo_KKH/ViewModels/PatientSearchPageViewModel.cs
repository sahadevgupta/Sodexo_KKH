﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Plugin.Connectivity;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using Rg.Plugins.Popup.Extensions;
using Sodexo_KKH.Helpers;
using Sodexo_KKH.Interfaces;
using Sodexo_KKH.Models;
using Sodexo_KKH.PopUpControl;
using Sodexo_KKH.Repos;
using Sodexo_KKH.Services;
using Sodexo_KKH.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using DependencyService = Xamarin.Forms.DependencyService;

namespace Sodexo_KKH.ViewModels
{
    public class PatientSearchPageViewModel : ViewModelBase
    {


        private List<mstr_ward_details> _mstrtWards;

        public List<mstr_ward_details> MstrWards
        {
            get { return this._mstrtWards; }
            set { SetProperty(ref _mstrtWards, value); }
        }


        private mstr_ward_details _selectedWard;

        public mstr_ward_details SelectedWard
        {
            get { return this._selectedWard; }
            set
            {
                SetProperty(ref _selectedWard, value);
                if (value != null)
                {
                   
                    BedDetails = new ObservableCollection<mstr_bed_details>(_mstrBedRepo.QueryTable().Where(x => x.ward_id == value.ID && x.status_id == 1));
                    BedDetails.Insert(0,new mstr_bed_details { bed_no = "All" });

                    SelectedBed = BedDetails.First();
                }
            }
        }


        private mstr_bed_details _selectedBed;

        public mstr_bed_details SelectedBed
        {
            get { return this._selectedBed; }
            set
            {
               SetProperty(ref _selectedBed, value);
            }
        }


        private DateTime _selectedDate = DateTime.UtcNow.Date;

        public DateTime SelectedDate
        {
            get { return this._selectedDate; }
            set
            {
                SetProperty(ref _selectedDate, value);
                if (IsWardVisible)
                {
                    if (SelectedWard != null)
                    {
                        GetPatientsList("WardNo");
                    }

                }
                else
                    GetPatientsList("PatientName");

            }
        }

        private ObservableCollection<mstr_patient_info> _patients;

        public ObservableCollection<mstr_patient_info> Patients
        {
            get { return this._patients; }
            set { SetProperty(ref _patients, value); }
        }



        private ObservableCollection<mstr_bed_details> _bedDetails;

        public ObservableCollection<mstr_bed_details> BedDetails
        {
            get { return this._bedDetails; }
            set { SetProperty(ref _bedDetails, value); }
        }


        private DateTime _maxDate;

        public DateTime MaxDate
        {
            get { return this._maxDate; }
            set { SetProperty(ref _maxDate, value); }
        }

        public string PatientName { get; set; }

        private List<string> _patientDatas = new List<string>();  
        public List<string> PatientDatas
        {
            get { return this._patientDatas; }
            set { SetProperty(ref _patientDatas, value); }
        }


        private DateTime _minDate = DateTime.Now.Date;

        public DateTime MinDate
        {
            get { return this._minDate; }
            set { SetProperty(ref _minDate, value); }
        }


        private bool _isWardVisible = true;

        public bool IsWardVisible
        {
            get { return this._isWardVisible; }
            set
            {
                SetProperty(ref _isWardVisible, value);
                if (value && SelectedWard != null)
                {
                    GetPatientsList("WardNo");
                }
            }
        }



        public List<mstr_meal_history> PatientMealHistoryList { get; set; }
        IGenericRepo<mstr_ward_details> _mstrWardRepo;
        IGenericRepo<mstr_bed_details> _mstrBedRepo;
        IGenericRepo<mstr_patient_info> _patientRepo;

        public DelegateCommand<string> SearchBtnCommand { get; set; }
        public INavigation navigation { get; internal set; }

        IPatientManager _patientManager;
        public PatientSearchPageViewModel(INavigationService navigationService, IGenericRepo<mstr_ward_details> mstrWardRepo,
            IGenericRepo<mstr_bed_details> mstrBedRepo, IPatientManager patientManager, IGenericRepo<mstr_patient_info> patientRepo, IPageDialogService pageDialog) : base(navigationService, pageDialog)
        {
            _mstrWardRepo = mstrWardRepo;
            _mstrBedRepo = mstrBedRepo;
            _patientManager = patientManager;
            _patientRepo = patientRepo;

            SearchBtnCommand = new DelegateCommand<string>(GetPatientsList);

            LoadData();
            var currentDate = DateTime.UtcNow.Date;
            MaxDate = MinDate.AddDays(1);
        }

        internal async Task NavigateToMealPopUp(mstr_patient_info selectedPatient, string mealtype)
        {
            if (CrossConnectivity.Current.IsConnected == true)
            {
                IsPageEnabled = true;

                await GenerateMealHistory(selectedPatient.ID, mealtype);
            }
            else
                await PageDialog.DisplayAlertAsync("Alert!!", "History cannot be shown in offline mode.", "OK");
        }

        private async Task GenerateMealHistory(int ID, string mealtype)
        {
            try
            {
                mstr_meal_history meal = null;
                ObservableCollection<mstr_meal_history> dataList = new ObservableCollection<mstr_meal_history>();

                string URL = Library.URL + "/" + Library.METHODE_SHOWPATIENTMEALDETAILSBYID + "/" + Convert.ToInt32(ID) + "/" + mealtype + "/" + Library.KEY_USER_ccode + "/" + Library.KEY_USER_regcode + "/" + Library.KEY_USER_siteid;
                var uri = new Uri(URL);
                HttpClient httpClient = new System.Net.Http.HttpClient();
                // HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, Library.URL + "/" + Library.METHODE_SHOWPATIENTMEALDETAILSBYID + "/" + Convert.ToInt32(ID) + "/" + mealtype + "/" + Library.KEY_USER_ccode + "/" + Library.KEY_USER_regcode + "/" + Library.KEY_USER_siteid);
                // HttpResponseMessage response = await httpClient.SendAsync(request);

                // var data = await response.Content.ReadAsStringAsync();

                var data = await httpClient.GetStringAsync(uri);

                JArray jarray = JArray.Parse(data);
                if (jarray.Count == 0)
                {
                    await PageDialog.DisplayAlertAsync("Alert!!", "There is no meal history for this patient.", "OK");
                    IsPageEnabled = false;
                    return;
                }

                for (int i = 0; i < jarray.Count; i++)
                {

                    JObject row = JObject.Parse(jarray[i].ToString());
                    meal = new mstr_meal_history
                    {
                        beveragesid = string.IsNullOrEmpty( row["beveragesid"].ToString())? "NA": row["beveragesid"].ToString(),
                        dessertid = string.IsNullOrEmpty( row["dessertid"].ToString()) ? "NA" : row["dessertid"].ToString(),
                        entreeid = string.IsNullOrEmpty(row["entreeid"].ToString()) ? "NA" : row["entreeid"].ToString(),
                        juiceid = string.IsNullOrEmpty(row["juiceid"].ToString()) ? "NA" : row["juiceid"].ToString(),
                        orderdate = row["orderdate"].ToString(),
                        remarkid = string.IsNullOrEmpty(row["remarkid"].ToString()) ? "NA" : row["remarkid"].ToString(),
                        soupid = string.IsNullOrEmpty(row["soupid"].ToString()) ? "NA" : row["soupid"].ToString(),
                        status = string.IsNullOrEmpty(row["status"].ToString()) ? "NA" : row["status"].ToString(),
                        addonid = string.IsNullOrEmpty(row["addonid"].ToString()) ? "NA" : row["addonid"].ToString(),
                        mealoptionid = string.IsNullOrEmpty(row["mealoptionid"].ToString()) ? "NA" : row["mealoptionid"].ToString()
                    };
                    dataList.Add(meal);

                }
                PatientMealHistoryList = new List<mstr_meal_history>(dataList);
                IsPageEnabled = false;
                await navigation.PushPopupAsync(new MealInfoPopUp(dataList, mealtype));
            }
            catch (Exception)
            {
                IsPageEnabled = false;

            }
        }

        public void DeleteOrder(mstr_patient_info patient)
        {
            CancelOrder(patient);
        }

        private async void CancelOrder(mstr_patient_info patient, bool IsDeleted = false)
        {
            mstr_meal_history meal = null;
            ObservableCollection<mstr_meal_history> dataList = new ObservableCollection<mstr_meal_history>();

            List<mstr_meal_option> list = new List<mstr_meal_option>();
            HttpClient httpClient = new System.Net.Http.HttpClient();
            string ss = Library.KEY_USER_ROLE.ToString();
            string scode = Library.KEY_USER_SiteCode.ToString();
            HttpRequestMessage request = null;
            //if (ss == "Nurse")
            //{
            //    request = new HttpRequestMessage(HttpMethod.Get, Library.URL + "/Nurse_Cancel_order/" + patient.ID + "/" + patient.meal_order_id + "/" + patient.meal_order_date + "/" + scode);

            //}
            //else
            //{
                request = new HttpRequestMessage(HttpMethod.Get, Library.URL + "/FSA_Cancel_order/" + patient.ID + "/" + patient.meal_order_id + "/" + patient.meal_order_date + "/" + scode);

            //}

            HttpResponseMessage response = await httpClient.SendAsync(request);
            var data = await response.Content.ReadAsStringAsync();
            JArray jarray = JArray.Parse(data);

            for (int i = 0; i < jarray.Count; i++)
            {
                JObject row = JObject.Parse(jarray[i].ToString());
                meal = new mstr_meal_history
                {
                    orderdate = row["orderdate"].ToString(),
                    createdby = row["createdby"].ToString(),
                    mealtimename = row["mealtimename"].ToString(),
                    Id = row["Id"].ToString(),
                    mealtimeid = row["mealtimeid"].ToString(),
                    meal_detail_id = row["meal_detail_id"].ToString(),
                    Cut_Off_time = row["Cut_Off_time"].ToString(),
                    remarks = ""
                };
                if (!String.IsNullOrEmpty(row["orderdate"].ToString()))
                {
                    DateTime dt = SelectedDate;
                    if (dt.Date > DateTime.Now.Date)
                    {
                        dataList.Add(meal);
                    }
                    else
                    {
                        DateTime cutDate = DateTime.ParseExact(row["Cut_Off_time"].ToString(), "HH:mm", CultureInfo.InvariantCulture).ToUniversalTime();
                        DateTime currtime = DateTime.Now.ToUniversalTime();
                        if (currtime >= cutDate)
                        {
                        }
                        else
                        {
                            dataList.Add(meal);
                        }

                    }


                }

                //dbhelper.Insert_INTO_mstr_ingredient(new mstr_ingredient(Convert.ToInt32(row["ID"].ToString()), row["ingredient_name"].ToString(), row["ingredient_description"].ToString(), Convert.ToInt32(row["status_id"].ToString()), row["site_code"].ToString()));
            }
            if (IsDeleted && dataList.Count > 0)
            {
                //   DisplayPatientListOnPatientsearch();
            }
            else if (dataList.Count == 0)
            {

                await PageDialog.DisplayAlertAsync("Alert!!", "No Item Available ", "OK");


                return;
            }
            PatientMealHistoryList = new List<mstr_meal_history>(dataList);

            var a = PatientMealHistoryList;
            var ui = new CancelOrderPopup(PatientMealHistoryList, PageDialog);
            ui.Disappearing += Ui_Disappearing;
            ui.BindingContext = patient;
            await navigation.PushPopupAsync(ui, false);

        }

        private void Ui_Disappearing(object sender, EventArgs e)
        {
            if ((sender as CancelOrderPopup).IsChanged)
            {
                if (IsWardVisible)
                    GetPatientsList("WardNo");
                else
                    GetPatientsList("PatientName");
            }
        }

        internal async void GetPatientInfo(string value)
        {
            PatientName = value;
            var temp = new List<string>();
            if (CrossConnectivity.Current.IsConnected == true)
            {
                try
                {
                    HttpClient httpClient = new System.Net.Http.HttpClient();

                    dynamic p = new JObject();
                    p.Patient_Name = value;
                    p.Site_Code = Library.KEY_USER_SiteCode;

                    string stringPayload = JsonConvert.SerializeObject(p);

                    var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await httpClient.PostAsync(Library.URL + "/Searchpatient", httpContent);

                    // HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, Library.URL + "/Searchpatient/" + value + "/" + Library.KEY_USER_SiteCode);
                   // HttpResponseMessage response = await httpClient.SendAsync(request);

                    var data = await response.Content.ReadAsStringAsync();

                    var namelist = JsonConvert.DeserializeObject<ObservableCollection<dynamic>>(data);

                    foreach (var item in namelist)
                    {
                        string name = item.Patient_Name;
                        temp.Add(name);
                    }
                    PatientDatas = new List<string>(temp);

                    if (!PatientDatas.Any())
                        PatientDatas = new List<string> { "No Results" };

                }
                catch (Exception)
                {

                }
            }
            else
            {
                var data = _patientRepo.QueryTable().Where(x => x.Patientname.ToLower().Contains(value.ToLower()));
                foreach (var item in data)
                {
                    PatientDatas.Add(item.Patientname);
                }
            }
        }

        private void OnSyncMasterTap(App arg1, string arg2)
        {
           
        }

        internal async void NavigateToInfoPage(mstr_patient_info patient)
        {
            IsPageEnabled = true;

            var sqlite = DependencyService.Get<IDBInterface>().GetConnection();
            var MasterMenuInfo = sqlite.Table<mstr_menu_master>();
            if (!MasterMenuInfo.Any())
            {
                await PageDialog.DisplayAlertAsync("Alert!!", "Please sync 'Sync Menu Items' from drawer menu to proceed further.", "OK");
                Library.KEY_SYNC_NOTIFICATION = "1";
                IsPageEnabled = false;
                return;
            }

            if (patient.is_care_giver)
            {
                return;
            }


            if (Library.KEY_USER_ROLE == "FSA")
            {
                if (!String.IsNullOrEmpty(patient.Last_Order_by))
                    AssignPatientInfo(patient);
                else
                {
                    IsPageEnabled = false;
                    await PageDialog.DisplayAlertAsync("Alert!!", "SORRY, You Are Not Authorised To Take First Order Of Patient", "OK");
                    return;
                }
                    
            }
            else
                AssignPatientInfo(patient);

            await NavigationService.NavigateAsync($"{nameof(PatientInformationPage)}", new NavigationParameters { { "PatientInfo", patient } });

            IsPageEnabled = false;
        }

        private void AssignPatientInfo(mstr_patient_info patient)
        {
            Library.KEY_PATIENT_IS_HALAL = patient.ishalal_tab;
            Library.KEY_PATIENT_IS_VEG = patient.isveg_tab;
            Library.KEY_ORDER_DATE = SelectedDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            Library.KEY_CHECK_ORDER_DATE = SelectedDate.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture);

            var id = Convert.ToInt32(patient.Ward_ID);

            Library.KEY_PATIENT_WARD_TYPE_ID = _mstrWardRepo.QueryTable().FirstOrDefault(x => x.ID == id).ward_type;
        }

        private async void GetPatientsList(string param)
        {
            Patients = new ObservableCollection<mstr_patient_info>();
            if (CrossConnectivity.Current.IsConnected)
            {
                if (param.Equals("WardNo"))
                {
                    await GetPatientsFromServer();
                }
                else
                {
                    if (string.IsNullOrEmpty(PatientName))
                    {
                        await PageDialog.DisplayAlertAsync("Alert!!", "Please select patient name from suggestions first", "OK");
                    }
                    else
                    {
                        DisplayPatientListOnPatientsearch();
                    }
                }
            }
            else
            {
                GetOfflinePatients(param);
            }
        }

        private void GetOfflinePatients(string param)
        {

            string order_date = SelectedDate.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture);
            if (param.Equals("WardNo"))
            {
                var wbed = SelectedBed != null ? (SelectedBed.bed_no == "All" ? "0" : SelectedBed.bed_no) : "0";
                var patientlist = new List<mstr_patient_info>();
                if (wbed == "0")
                {
                    patientlist = _patientRepo.QueryTable().Where(x => x.ward_name == SelectedWard.ward_name && x.meal_order_date == order_date).OrderBy(x => x.bed_no).ToList();
                }
                else

                    patientlist = _patientRepo.QueryTable().Where(x => x.ward_name == SelectedWard.ward_name && x.bed_name == wbed && x.meal_order_date == order_date).OrderBy(x => x.bed_no).ToList();


                Patients = new ObservableCollection<mstr_patient_info>(patientlist);

                if (!Patients.Any())
                {
                    DependencyService.Get<INotify>().ShowToast("No patient found!!");
                }

            }
            else
            {
                DisplayPatientListOnPatientsearch();
            }

        }

        public async void DisplayPatientListOnPatientsearch()
        {
            try
            {
                string format = SelectedDate.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture);

                if (CrossConnectivity.Current.IsConnected == true)
                {
                    try
                    {

                        //start progessring
                        IsPageEnabled = true;
                        HttpClient httpClient = new System.Net.Http.HttpClient();

                        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, Library.URL + "/PullpatientData_by_patientname/" + Library.KEY_USER_SiteCode + "/" + format + "/" + PatientName);
                        HttpResponseMessage response = await httpClient.SendAsync(request);

                        var data = await response.Content.ReadAsStringAsync();
                        // JArray jarray = JArray.Parse(data);

                        var pdataList = JsonConvert.DeserializeObject<ObservableCollection<mstr_patient_info>>(data);

                        foreach (var item in pdataList)
                        {
                            item.ward_bed = item.ward_name + "-" + item.bed_name;
                            item.ID = item.ID;
                            if (item.is_care_giver)
                            {
                                item.Patientname = item.Patientname + ' ' + "(Care Giver)";
                            }
                        }

                        Patients = new ObservableCollection<mstr_patient_info>(pdataList);
                        IsPageEnabled = false;

                    }
                    catch (Exception)
                    {
                        // stop progressring
                        IsPageEnabled = false;

                    }


                }
                else
                {

                    var data = _patientRepo.QueryTable().Where(x => x.Patientname == PatientName && x.meal_order_date == format).OrderBy(y => y.Patientname);
                    Patients = new ObservableCollection<mstr_patient_info>(data);

                }

            }
            catch (Exception)
            {

            }
        }



        public async Task GetPatientsFromServer()
        {
            var wbed = 0;
            try
            {
                if (SelectedWard == null)
                    return;
                
                    IsPageEnabled = true;
                    string format = SelectedDate.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture);
                    wbed = SelectedBed != null ? SelectedBed.ID : 0;
                    var patientsData = await _patientManager.GetPatientsByWardBed(format, SelectedWard.ID, wbed);

                if (!patientsData.Any())
                {
                    IsPageEnabled = false;
                    DependencyService.Get<INotify>().ShowToast("No patient found!!");
                    return;
                }

                foreach (var patient in patientsData)
                    {
                        patient.ward_bed = $"{patient.ward_name}-{patient.bed_name}";
                        if (patient.is_care_giver)
                        {
                            patient.Patientname = $"{patient.Patientname} (Care Giver {patient.caregiverno})";
                        }
                        patient.Therapeutic_Condition = string.IsNullOrEmpty(patient.Therapeutic_Condition) ? "NA" : patient.Therapeutic_Condition;
                    }

                    var list = patientsData.OrderBy(x => x.bed_no);
                    Patients = new ObservableCollection<mstr_patient_info>(list);

                    IsPageEnabled = false;
                
            }
            catch (Exception ex)
            {
                IsPageEnabled = false;
                await PageDialog.DisplayAlertAsync("Alert!!", ex.Message, "OK");
            }
        }

        public void LoadData()
        {
            MstrWards = new List<mstr_ward_details>(_mstrWardRepo.QueryTable().Where(x => x.ward_type_name != "Staff" && x.status_id == 1).OrderBy(y => y.ID));

            if (string.IsNullOrEmpty(Library.KEY_SYNC_NOTIFICATION))
            {
                PageDialog.DisplayAlertAsync("Alert!!", "Please sync 'Sync Masters' and 'Sync Menu Items' from drawer menu to proceed further.", "OK");
                Library.KEY_SYNC_NOTIFICATION = "1";
            }
        }

        public async override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            if (CrossConnectivity.Current.IsConnected)
                await GetPatientsFromServer();
        }

    }
}
