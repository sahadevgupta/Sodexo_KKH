using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Plugin.Connectivity;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using Sodexo_KKH.Helpers;
using Sodexo_KKH.Interfaces;
using Sodexo_KKH.Models;
using Sodexo_KKH.Repos;
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
    public class PatientInformationPageViewModel : ViewModelBase
    {
        private mstr_patient_info _selectedPatient;
        public mstr_patient_info SelectedPatient
        {
            get { return _selectedPatient; }
            set { SetProperty(ref _selectedPatient, value); }
        }
        public List<string> HnHList { get; set; } //Halal NonHalal list
        public List<string> VegNVegList { get; set; }
        public List<string> FluidList { get; set; }


        private ObservableCollection<mstr_others_master> _othersradio;
        public ObservableCollection<mstr_others_master> OthersRadio
        {
            get { return this._othersradio; }
            set { SetProperty(ref _othersradio, value); }
        }

        private ObservableCollection<mstr_others_master> _othersChecBox;
        public ObservableCollection<mstr_others_master> OthersChecBox
        {
            get { return this._othersChecBox; }
            set { SetProperty(ref _othersChecBox, value); }
        }

        private ObservableCollection<mstr_allergies_master> _allergies;
        public ObservableCollection<mstr_allergies_master> Allergies
        {
            get { return this._allergies; }
            set { SetProperty(ref _allergies, value); }
        }

        private ObservableCollection<mstr_ingredient> _ingredients;
        public ObservableCollection<mstr_ingredient> Ingredients
        {
            get { return this._ingredients; }
            set { SetProperty(ref _ingredients, value); }
        }


        private ObservableCollection<mstr_therapeutic> _therapeutics;
        public ObservableCollection<mstr_therapeutic> Therapeutics
        {
            get { return this._therapeutics; }
            set { SetProperty(ref _therapeutics, value); }
        }

        private ObservableCollection<mstr_diet_texture> _dietTextures;
        public ObservableCollection<mstr_diet_texture> DietTextures
        {
            get { return this._dietTextures; }
            set { SetProperty(ref _dietTextures, value); }
        }


        private ObservableCollection<mstr_meal_type> _cuisines;
        public ObservableCollection<mstr_meal_type> Cuisines
        {
            get { return this._cuisines; }
            set { SetProperty(ref _cuisines, value); }
        }


        private bool _isInfantEnabled;
        public bool IsInfantEnabled
        {
            get { return this._isInfantEnabled; }
            set
            {
                SetProperty(ref _isInfantEnabled, value);
                Library.InfantDietEnable = value;
            }
        }

        private bool _isAllergiesEnable;
        public bool IsAllergiesEnable
        {
            get { return this._isAllergiesEnable; }
            set { SetProperty(ref _isAllergiesEnable, value); }
        }

        private async void SelectionForFoodAllergies()
        {
            var response = await DependencyService.Get<INotify>().ShowAlert("Alert!", "Choose preferred menu",  "Allergic Menu","Regular Menu");
            if (response == "Allergic Menu")
            {
               // IsAllergiesEnable = true;
                Library.IsFAGeneralEnable = true;
            }
            else
            {
                //IsAllergiesEnable = false;
                Library.IsFAGeneralEnable = false;
            }
        }

        private bool _isDisposable;
        public bool IsDisposable
        {
            get { return this._isDisposable; }
            set
            {
                SetProperty(ref _isDisposable, value);
                Library.IsDisposableEnable = value;
            }
        }
        private bool _isConfinement;
        public bool IsConfinement
        {
            get { return this._isConfinement; }
            set
            {
                SetProperty(ref _isConfinement, value);
                Library.IsConfinementEnable = value;
            }
        }


        private string _isFAGeneral;
        public string IsFAGeneral
        {
            get { return this._isFAGeneral; }
            set
            {
                if (_isFAGeneral == null)
                {
                    SetProperty(ref _isFAGeneral, value);
                    AssignFoodAllergy(value);

                }
                else if (_isFAGeneral != value)
                {
                    SetProperty(ref _isFAGeneral, value);
                     AssignFoodAllergy(value);
                }
                
            }
        }

        private void AssignFoodAllergy(string value)
        {
            if (value == "Yes")
            {
                SelectionForFoodAllergies();
            }
            else
            {
                Library.IsFAGeneralEnable= false;
               // IsAllergiesEnable = false;
            }
        }

        private bool _isNoMealEnable = true;
        public bool IsNoMealEnable
        {
            get { return this._isNoMealEnable; }
            set { SetProperty(ref _isNoMealEnable, value); }
        }

        public List<string> RadioButtonList { get; set; }

        public DelegateCommand<string> NextCommand { get; set; }
        

        IGenericRepo<mstr_others_master> _OthersRepo;
        IGenericRepo<mstr_allergies_master> _AllergyRepo;
        IGenericRepo<mstr_ingredient> _ingredientRepo;
        IGenericRepo<mstr_therapeutic> _therapeuticsRepo;
        IGenericRepo<mstr_diet_texture> _dietTextureRepo;
        IGenericRepo<mstr_meal_type> _mealTypeRepo;

        public PatientInformationPageViewModel(INavigationService navigationService, IGenericRepo<mstr_others_master> OthersRepo, IGenericRepo<mstr_allergies_master> AllergyRepo,
            IGenericRepo<mstr_ingredient> ingredientRepo, IGenericRepo<mstr_therapeutic> therapeuticsRepo, IGenericRepo<mstr_diet_texture> dietTextureRepo,
            IGenericRepo<mstr_meal_type> mealTypeRepo, IPageDialogService pageDialog) : base(navigationService, pageDialog)
        {
            _OthersRepo = OthersRepo;
            _AllergyRepo = AllergyRepo;
            _ingredientRepo = ingredientRepo;
            _therapeuticsRepo = therapeuticsRepo;
            _dietTextureRepo = dietTextureRepo;
            _mealTypeRepo = mealTypeRepo;

            FluidList = new List<string> { "NA", "Thin" };
            HnHList = new List<string> { "Halal", "Non Halal" };
            VegNVegList = new List<string> { "Veg", "Non-Veg" };

            RadioButtonList = new List<string> { "Yes", "No" };


            NextCommand = new DelegateCommand<string>(NavigateToOrderPage);
        }

        private async void NavigateToOrderPage(string obj)
        {
            IsPageEnabled = true;
            if (obj.Equals("Update"))
            {
                await UpdatePatientInfo();
            }
            else
            {
                IsPageEnabled = true;


                if (!Library.KEY_PATIENT_IS_VEG.Equals(SelectedPatient.isveg) || !Library.KEY_PATIENT_IS_HALAL.Equals(SelectedPatient.ishalal))
                {
                    var response = await PageDialog.DisplayAlertAsync("Meal Prefrence Changed!", "Do you want to Change the (Veg/Nonveg)/(Halal/Non-Halal) Status.", "Yes", "No");
                    if (response)
                    {
                        Library.KEY_PATIENT_IS_VEG = SelectedPatient.isveg;
                        Library.KEY_PATIENT_IS_HALAL = SelectedPatient.ishalal;
                    }
                    else
                    {
                        IsPageEnabled = false;
                        return;
                    }

                }

                #region Future_Order

                bool isChangeTher = CompareStrings(string.IsNullOrEmpty(SelectedPatient.Therapeutic) ? string.Empty : SelectedPatient.Therapeutic, Therapeutics.Where(x => x.IsChecked).Select(x => x.TH_code).ToList());
                bool isChangeAllergy = CompareStrings(SelectedPatient.Allergies == "0" ? string.Empty : SelectedPatient.Allergies, Allergies.Where(x => x.IsChecked).Select(x => x.ID.ToString()).ToList());
                bool isChangeIngredient = CompareStrings(string.IsNullOrEmpty(SelectedPatient.Ingredient) ? string.Empty : SelectedPatient.Ingredient, Ingredients.Where(x => x.IsChecked).Select(x => x.ingredient_name).ToList());
                bool isChangeDietTexture = CompareStrings(string.IsNullOrEmpty(SelectedPatient.Diet_Texture) ? string.Empty : SelectedPatient.Diet_Texture, DietTextures.Where(x => x.IsChecked).Select(x => x.diet_texture_name).ToList());
                bool isChangeMealType = CompareStrings(string.IsNullOrEmpty(SelectedPatient.Meal_Type) ? string.Empty : SelectedPatient.Meal_Type, Cuisines.Where(x => x.IsChecked).Select(x => x.meal_type_name).ToList());

                bool isChange = (isChangeTher || isChangeAllergy || isChangeIngredient || isChangeDietTexture || isChangeMealType);

                if (isChangeMealType && !isChangeTher && !isChangeAllergy && !isChangeIngredient && !isChangeDietTexture)
                {

                   bool resp = await PageDialog.DisplayAlertAsync("", $"Patient's cuisine choice has been changed, \npress OK to proceed", "OK","Cancel");
                    if (!resp)
                    {
                        IsPageEnabled = false;
                        return;
                    }
                }
                else
                {
                    if (isChange)
                    {
                        if (CrossConnectivity.Current.IsConnected)
                        {

                            string check_order_date = Library.KEY_CHECK_ORDER_DATE;

                            HttpClient httpClientGet = new System.Net.Http.HttpClient();
                            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, Library.URL + "/checkfutureorder/" + check_order_date + "/" + SelectedPatient.ID);
                            HttpResponseMessage response = await httpClientGet.SendAsync(request);
                            // jarray= await response.Content.ReadAsStringAsync();
                            var data = await response.Content.ReadAsStringAsync();
                            if (data != "\"NULL\"" && data != string.Empty)
                            {

                                List<string> alertMsg = new List<string>();


                                if (isChangeTher)
                                {
                                    alertMsg.Add("Therapeutic Condition");
                                }
                                if (isChangeAllergy)
                                {
                                    alertMsg.Add("Allergic Condition");
                                }
                                if (isChangeIngredient)
                                {
                                    alertMsg.Add("Ingredient exclusion");
                                }

                                if (isChangeDietTexture)
                                {
                                    alertMsg.Add("Diet Texture");
                                }
                                if (isChangeMealType)
                                {
                                    alertMsg.Add("Cuisine Choice");
                                }

                                var msgArray = alertMsg.ToArray();
                                var msgStr = string.Join(",", msgArray);
                                msgStr = msgStr.Replace(",", " and ");

                                var result = await DependencyService.Get<INotify>().ShowAlert("Preference Changed!!", $"Patient’s {msgStr} has been changed. Do you want to delete the future order of this patient?", "Yes", "No", "Cancel");
                                if (result == "Yes")
                                {
                                    dynamic p = new JObject();

                                    p.orderdetailsids = data.Replace("\"", "");
                                    p.system_module = DependencyService.Get<ILocalize>().GetDeviceName();
                                    p.work_station_IP = DependencyService.Get<ILocalize>().GetIpAddress();

                                    string json = JsonConvert.SerializeObject(p);

                                    var httpClient = new HttpClient();

                                    var msg = await httpClient.PostAsync($"{Library.URL}/DeleteunprocessOrder", new StringContent(json, Encoding.UTF8, "application/json"));
                                    var contents = await msg.Content.ReadAsStringAsync();
                                    if (!string.IsNullOrEmpty(contents))
                                        await PageDialog.DisplayAlertAsync("Delete", $"Total Orders deleted : {contents}", "OK");


                                }
                                else if (result == "Cancel")
                                {
                                    IsPageEnabled = false;
                                    return;
                                }



                            }

                        }
                        else
                        {
                            IsPageEnabled = false;
                            await PageDialog.DisplayAlertAsync("Error!!", "Unable to change patient settings during offline mode. Please undo the changes and try again", "OK");
                            return;


                        }
                    }
                }

                #endregion

                var navParam = new NavigationParameters();
                navParam.Add("Patient", SelectedPatient);
                navParam.Add("Allergies", Allergies.Where(x => x.IsChecked).ToList());
                navParam.Add("Ingredients", Ingredients.Where(x => x.IsChecked).ToList());
                navParam.Add("Therapeutics", Therapeutics.Where(x => x.IsChecked).ToList());
                navParam.Add("DietTextures", DietTextures.Where(x => x.IsChecked).ToList());
                navParam.Add("Cuisines", Cuisines.Where(x => x.IsChecked).ToList());
                navParam.Add("Other", OthersRadio.Where(x => x.IsChecked).FirstOrDefault());
                navParam.Add("Othercheckbox", OthersChecBox.Where(x => x.IsChecked).ToList());

                await NavigationService.NavigateAsync(nameof(MealOrderPage), navParam);

                IsPageEnabled = false;
            }
        }

        private bool CompareStrings(string strOld, List<string> listNew)
        {
            bool isChange = false;

            string[] strArr = strOld.Split(',');

            if (strOld != string.Empty || (listNew != null && listNew.Count > 0))
            {
                if (strArr.Count() != listNew.Count)
                {
                    isChange = true;
                }
                else
                {
                    foreach (string s in strArr)
                    {
                        if (!listNew.Contains(s))
                        {
                            isChange = true;
                            break;
                        }
                    }
                }
            }
            return isChange;
        }

        private async Task UpdatePatientInfo()
        {
            IsPageEnabled = true;

            string isAllergy = string.Empty;
            var selectedAllergies = Allergies.Where(x => x.IsChecked);

            foreach (var item in selectedAllergies)
            {
                isAllergy += item.ID + ",";
            }

            isAllergy = isAllergy.TrimEnd(',');

            dynamic p = new JObject();
            p.halal = SelectedPatient.ishalal  ? 1 : 0;
            p.isallergies = isAllergy;
            p.isdiabetic = 1;
            p.isveg = SelectedPatient.isveg  ? 1 : 0;
            p.patientid = SelectedPatient.ID.ToString();

            string stringPayload = JsonConvert.SerializeObject(p);

            var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");


            using (var httpClient = new System.Net.Http.HttpClient())
            {
                var httpResponse = new System.Net.Http.HttpResponseMessage();
                // Do the actual request and await the response


                // httpResponse = new Uri(URL + "/" + Library.METHODE_UPDATE_ORDER); //replace your Url
                httpResponse = await httpClient.PostAsync(Library.URL + "/setpatientprofile", httpContent);


                // display a message jason conversion
                //var message2 = new MessageDialog(httpResponse.ToString());
                //await message2.ShowAsync();
                //var httpResponse = await httpClient.PostAsync(URL + "/" + Library.METHODE_SAVEORDER, httpContent);

                // If the response contains content we want to read it!
                if (httpResponse.Content != null)
                {
                    var responseContent = await httpResponse.Content.ReadAsStringAsync();
                    if (responseContent == "true")
                    {
                        await PageDialog.DisplayAlertAsync("Alert!!", "Updated Patient Information", "OK");
                        await NavigationService.GoBackAsync();
                    }
                }
            }

            IsPageEnabled = false;
        }
        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
            base.OnNavigatedFrom(parameters);
            IsPageEnabled = false;
        }
        public override void OnNavigatingTo(INavigationParameters parameters)
        {
            base.OnNavigatingTo(parameters);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
        }

        public override void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);


            if (parameters.ContainsKey("PatientInfo"))
            {

                OthersRadio = new ObservableCollection<mstr_others_master>();
                OthersChecBox = new ObservableCollection<mstr_others_master>();
                Allergies = new ObservableCollection<mstr_allergies_master>();
                Ingredients = new ObservableCollection<mstr_ingredient>();
                Therapeutics = new ObservableCollection<mstr_therapeutic>();
                DietTextures = new ObservableCollection<mstr_diet_texture>();
                Cuisines = new ObservableCollection<mstr_meal_type>();


                SelectedPatient = parameters["PatientInfo"] as mstr_patient_info;

                SelectedPatient.PropertyChanged += SelectedPatient_PropertyChanged;
                SelectedPatient.FluidInfo = string.IsNullOrEmpty(SelectedPatient.FluidInfo) ? "NA" : SelectedPatient.FluidInfo;

                if (string.IsNullOrEmpty(SelectedPatient.Allergies) || SelectedPatient.Allergies == "NA" || SelectedPatient.Allergies == "0")
                {
                    IsFAGeneral = RadioButtonList[1];
                }
                else
                {
                    IsFAGeneral = RadioButtonList[0];
                }

                var Others = _OthersRepo.QueryTable().OrderBy(x => x.others_name);
                foreach (var other in Others.Where(x => x.status_id == 0).Take(8))
                {
                    other.PropertyChanged += Other_PropertyChanged;
                    OthersRadio.Add(other);
                }

                foreach (var item in Others.Where(x => x.status_id == 1))
                {
                    OthersChecBox.Add(item);
                }

                var allergies = _AllergyRepo.QueryTable().OrderBy(y => y.allergies_name);
                foreach (var item in allergies)
                {
                    if (!string.IsNullOrEmpty(SelectedPatient.Allergies))
                    {
                        var foodAllergies = SelectedPatient.Allergies.Split(',');
                        foreach (var id in foodAllergies)
                        {
                            var allergyID = Convert.ToInt32(id);
                            if (item.ID == allergyID)
                            {
                                item.IsChecked = true;
                            }
                        }
                    }
                    Allergies.Add(item);
                }



                var ingredients = _ingredientRepo.QueryTable().Where(x => x.status_id == 1).OrderBy(y => y.ingredient_name);
                foreach (var item in ingredients)
                {
                    if (!string.IsNullOrEmpty(SelectedPatient.Ingredient))
                    {
                        var _Ingredient = SelectedPatient.Ingredient.Split(',');
                        foreach (var name in _Ingredient)
                        {
                            if (item.ingredient_name == name)
                            {
                                item.IsChecked = true;
                            }
                        }
                    }
                    Ingredients.Add(item);
                }

                var therapeutics = _therapeuticsRepo.QueryTable().Where(x => x.status_id == 1).OrderBy(y => y.TH_code);
                foreach (var therapeutic in therapeutics)
                {
                    if (!string.IsNullOrEmpty(SelectedPatient.Therapeutic))
                    {
                        var _Therapeutics = SelectedPatient.Therapeutic.Split(',');
                        foreach (var th_code in _Therapeutics)
                        {
                            if (therapeutic.TH_code == th_code)
                            {
                                therapeutic.IsChecked = true;
                            }
                        }
                    }
                    therapeutic.PropertyChanged += Therapeutic_PropertyChanged;
                    Therapeutics.Add(therapeutic);
                }

                var textures = _dietTextureRepo.QueryTable().Where(x => x.status_id == 1).OrderBy(y => y.diet_texture_name);
                foreach (var item in textures)
                {

                    if (!string.IsNullOrEmpty(SelectedPatient.Diet_Texture))
                    {
                        var _textures = SelectedPatient.Diet_Texture.Split(',');
                        foreach (var name in _textures)
                        {
                            if (item.diet_texture_name == name)
                            {
                                item.IsChecked = true;
                            }
                        }
                    }
                    DietTextures.Add(item);
                }

                InitializeMealType(SelectedPatient);
            }

        }

        private void SelectedPatient_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "ishalal")
            {
                var patient = sender as mstr_patient_info;
                Cuisines = new ObservableCollection<mstr_meal_type>();
                InitializeMealType(patient);
            }
        }

        private void InitializeMealType(mstr_patient_info patient)
        {

            var mealTypes = _mealTypeRepo.QueryTable().Where(x => x.status_id == 1).OrderBy(y => y.meal_type_name);
            foreach (var mealType in mealTypes)
            {
                if (Convert.ToBoolean(patient.ishalal) && mealType.ID==1)
                    continue;

                if (!string.IsNullOrEmpty(SelectedPatient.Meal_Type))
                {
                    var _mealTypesname = SelectedPatient.Meal_Type.Split(',');
                    foreach (var _mealTypename in _mealTypesname)
                    {
                        if (mealType.meal_type_name == _mealTypename)
                        {
                            mealType.IsChecked = true;
                        }
                    }
                }

                Cuisines.Add(mealType);
            }
        }

        private void Other_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "IsChecked")
            {
                var checkedData = sender as mstr_others_master;
                if (checkedData.IsChecked)
                {
                    if (checkedData.others_name.Contains("NBM"))
                        IsNoMealEnable = false;
                    else
                        IsNoMealEnable = true;

                    var checkedQuery = OthersRadio.Where(x => x.IsChecked == true && x.others_name != checkedData.others_name);
                    if (checkedQuery.Any())
                    {
                        checkedQuery.First().IsChecked = false;
                    }
                }
            }
        }

        private async void Therapeutic_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {

            if (e.PropertyName == "IsChecked")
            {
                var checkedTH = sender as mstr_therapeutic;
                if (checkedTH.IsChecked)
                {

                    var checkedQuery = Therapeutics.Where(x => x.IsChecked == true && !string.IsNullOrEmpty(x.TH_Condition)
                                        && x.TH_Condition == checkedTH.TH_Condition && x.TH_code != checkedTH.TH_code);

                    if (checkedQuery.Any())
                    {
                        var str1 = $"You have already selected {checkedQuery.First().TH_Condition} option , Do you want to remove {checkedQuery.FirstOrDefault().TH_code} option.";

                        var response = await PageDialog.DisplayAlertAsync("Alert!!", str1, "YES", "NO");
                        if (response)
                        {

                            var previous = Therapeutics.Where(x => x.TH_code == checkedQuery.FirstOrDefault().TH_code).FirstOrDefault();
                            previous.IsChecked = false;
                        }
                        else
                            checkedTH.IsChecked = false;
                    }
                }
            }
        }
    }
}
