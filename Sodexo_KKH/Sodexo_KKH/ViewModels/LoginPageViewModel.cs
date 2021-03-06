﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Plugin.Connectivity;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using Rg.Plugins.Popup.Extensions;
using Sodexo_KKH.Helpers;
using Sodexo_KKH.Models;
using Sodexo_KKH.PopUpControl;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Sodexo_KKH.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set { SetProperty(ref _userName, value); }
        }
        private string _password;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }
        private string _errorText;
        public string ErrorText
        {
            get { return _errorText; }
            set { SetProperty(ref _errorText, value); }
        }

        private List<string> _roleList;
        public List<string> RoleList
        {
            get { return _roleList; }
            set { SetProperty(ref _roleList, value); }
        }


        private string _selectedRole;
        public string SelectedRole
        {
            get { return this._selectedRole; }
            set { SetProperty(ref _selectedRole, value); }
        }


        private bool _isRolePickerVisible;
        public bool IsRolePickerVisible
        {
            get { return this._isRolePickerVisible; }
            set { SetProperty(ref _isRolePickerVisible, value); }
        }
        private bool _enableSubmitButton;
        public bool EnableSubmitButton
        {
            get { return _enableSubmitButton; }
            set { SetProperty(ref _enableSubmitButton, value); }
        }

        public INavigation navigation;

        #region reCAPTCHA

        private string _captcha;

        public string Captcha
        {
            get { return this._captcha; }
            set { SetProperty(ref _captcha, value); }
        }

        private string _captchaInput;

        public string CaptchaInput
        {
            get { return this._captchaInput; }
            set { SetProperty(ref _captchaInput, value); }
        }

        List<string> _colors = new List<string>();

        private Color _backgroundColor;
        public Color BackgroundColor
        {
            get { return _backgroundColor; }
            set { SetProperty(ref _backgroundColor, value); }
        }
        Random _random;
        ColorTypeConverter _colorConverter;
        #endregion



        public DelegateCommand ReloadCommand => new DelegateCommand(ReloadCAPTCHA);


        public LoginPageViewModel(INavigationService navigationService, IPageDialogService pageDialog) : base(navigationService, pageDialog)
        {
            App.pageDialog = pageDialog;

           

        }
        private void ReloadCAPTCHA()
        {
            ChangeBackgroundColor();
            Captcha = GetUniqueKey(6);
        }


        public static string GetUniqueKey(int size)
        {
            char[] chars =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
            byte[] data = new byte[size];
            using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
            {
                crypto.GetBytes(data);
            }
            StringBuilder result = new StringBuilder(size);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length)]).Append(" ");
            }
            return result.ToString();
        }

        void GetColorList()
        {
            _colors = new List<string>();
            var temp = new List<string>();
            foreach (var field in typeof(Color).GetFields(BindingFlags.Static | BindingFlags.Public))
            {

                if (field != null && !String.IsNullOrEmpty(field.Name) && !field.Name.Contains("White"))
                    temp.Add(field.Name);
            }
            for (int i = 0; i < temp.Count; i++)
            {
                var ranColor = (Color)_colorConverter.ConvertFromInvariantString(temp[i]);
                var sum = (ranColor.R + ranColor.G + ranColor.B) * 255;
                if (sum < 382)
                {
                    _colors.Add(temp[i]);
                }
            }


        }
        void ChangeBackgroundColor()
        {
            int Index = _random.Next(1, _colors.Count);
            BackgroundColor = (Color)_colorConverter.ConvertFromInvariantString(_colors[Index]);
            //BackgroundColor = Color.FromHex(ToHex(ranColor));
        }
        public static string ToHex(Color color)
        {
            int red = (int)(color.R * 255);
            int green = (int)(color.G * 255);
            int blue = (int)(color.B * 255);
            string hex = red.ToString("X2") + green.ToString("X2") + blue.ToString("X2");
            return hex;
        }


        internal async Task<List<string>> BindRole()
        {
            if (!string.IsNullOrEmpty(UserName))
            {
                if (CrossConnectivity.Current.IsConnected)
                {
                    try
                    {
                        RoleList = new List<string>();
                        IsPageEnabled = true;

                        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, Library.URL + "/" + Library.METHODE_GETUSERROLEBYUSERNAMEMOBILE + "/" + UserName);

                        HttpClient httpClient = new System.Net.Http.HttpClient();
                        HttpResponseMessage response = await httpClient.SendAsync(request);

                        var data = await response.Content.ReadAsStringAsync();
                        JArray jarray = JArray.Parse(data);

                        if (jarray.Count > 0)
                        {
                            bool isLogin = Convert.ToBoolean(jarray[0].Value<string>("is_log_in"));
                            if (isLogin)
                            {
                                IsPageEnabled = false;
                                EnableSubmitButton = false;
                                IsRolePickerVisible = false;
                                await PageDialog.DisplayAlertAsync("Locked!!", "User already logged in different device.!!", "Ok");

                                return null;
                            }

                            List<string> templist = new List<string>();
                            for (int i = 0; i < jarray.Count; i++)
                            {
                                JObject row = JObject.Parse(jarray[i].ToString());
                                templist.Add(row["role"].ToString());
                            }
                            if (templist.Count > 1)
                                IsRolePickerVisible = true;
                            else
                                IsRolePickerVisible = false;


                            IsPageEnabled = false;
                            RoleList = new List<string>(templist);
                            SelectedRole = RoleList.First();
                            return RoleList;
                            //   comboBox.SetBinding(Label.da, binding);
                            //cmbsearchbyward.DataSource = Mylist;                         
                        }
                        else
                        {
                            IsRolePickerVisible = false;
                            IsPageEnabled = false;
                            return RoleList;
                        }

                    }
                    catch (Exception)
                    {
                        IsPageEnabled = false;
                        await PageDialog.DisplayAlertAsync("Alert!!", "Server is not accessible, please check internet connection.", "OK");
                        return null;

                    }
                }
                else
                {
                    await PageDialog.DisplayAlertAsync("Alert!!", "Server is not accessible, please check internet connection.", "OK");
                    return null;
                }

            }
            else
            {
                IsPageEnabled = false;
                return null;
            }
        }

        public async Task Login(bool isLDap = false)
        {
            bool isInternetConnected = NetworkInterface.GetIsNetworkAvailable();
            var str = Captcha.Replace(" ", string.Empty);
            // checking if user name and password are not blank      
            if (!string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(Password) && str.Equals(CaptchaInput))
            {
                try
                {
                    if (CrossConnectivity.Current.IsConnected)
                        await checkLogin(isLDap);
                    else
                        await PageDialog.DisplayAlertAsync("Server is not accessible, please check internet connection.", "Alert!!", "OK");
                }
                catch (Exception ex)
                {
                    ErrorText = ex.Message;

                }
            }
            else
            {
                if (!str.Equals(CaptchaInput))
                {
                    ErrorText = "Incorrect CAPTCHA";
                    ReloadCAPTCHA();
                    CaptchaInput = string.Empty;
                }
                else
                    ErrorText = "Please enter user name and password.";
            }

        }

        public async Task checkLogin(bool isLDap)
        {
            try
            {

                string userType = string.Empty;

                if (SelectedRole.Equals("Select Role"))
                {
                    userType = "Select Role";

                }
                else if (SelectedRole.Equals("Nurse"))
                {
                    userType = "N";
                }
                else if (SelectedRole.Equals("FSA"))
                {
                    userType = "F";
                }
                else
                {
                    userType = "NF";
                }


                //start progessring
                IsPageEnabled = true;
                //var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
                //JArray jarray;
                String method = "UserLogin";
                //HttpClient httpClient = new System.Net.Http.HttpClient();
                //HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, URL + "/" + Library.METHODE_USERLOGIN + "/" + txtusername.Text + "/" + txtpass.Text + "/" + userType);

                //---------------------------------

                var obj = new login();
                obj.Name = UserName;
                obj.pass = Password;
                obj.roleType = userType;
                if (isLDap)
                {
                    obj.isLDap = 1;
                }
                // Serialize our concrete class into a JSON String
                var stringPayload = await Task.Run(() => JsonConvert.SerializeObject(obj));

                // Wrap our JSON inside a StringContent which then can be used by the HttpClient class
                var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");

                // display a message jason conversion
                //var message1 = new MessageDialog("Data is converted in json.");
                //await message1.ShowAsync();

                using (var httpClient = new System.Net.Http.HttpClient())
                {
                    var response = await httpClient.PostAsync(Library.URL + "/" + Library.METHODE_USERLOGIN, httpContent);


                    if (response.Content != null)
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        if (response.ReasonPhrase == "Bad Request")
                        {
                            IsPageEnabled = false;
                            ErrorText = "Invalid user name or password.";
                            EnableSubmitButton = false;
                            return;
                        }

                        if (response.ReasonPhrase == "Not Found")
                        {
                            IsPageEnabled = false;
                            ErrorText = "Invalid user name or password.";
                            EnableSubmitButton = false;
                            return;
                        }

                        JArray jarray = JArray.Parse(data);
                        string status = jarray[0].Value<string>("status");
                        string expireday = jarray[0].Value<string>("expireday");
                        bool isLogin = Convert.ToBoolean(jarray[0].Value<string>("is_login"));
                        if (status == "Lock" || expireday == "700")
                        {
                            IsPageEnabled = false;
                            EnableSubmitButton = false;
                            await PageDialog.DisplayAlertAsync("Locked!!", "Due to Five Times Consecutive Attempts, Your Account has been locked.!!", "Ok");
                            return;
                        }
                        if (isLogin)
                        {
                            IsPageEnabled = false;
                            EnableSubmitButton = false;
                            await PageDialog.DisplayAlertAsync("Locked!!", "User already logged in different device.!!", "Ok");

                            return;
                        }


                        for (int i = 0; i < jarray.Count; i++)
                        {

                            JObject row = JObject.Parse(jarray[i].ToString());
                            string id = row["ID"].ToString();
                            if (id != "0")
                            {
                                // Storing user's detail in application data locally
                                Library.KEY_USER_ID = id;
                                Library.KEY_USER_FIRST_NAME = row["FirstName"].ToString();
                                Library.KEY_USER_LAST_NAME = row["LastName"].ToString();
                                Library.KEY_ROLL_TYPE = row["RoleType"].ToString();
                                Library.KEY_USER_ROLE = row["UserRole"].ToString();
                                Library.KEY_USER_STATUS = row["status"].ToString();
                                Library.KEY_USER_SiteCode = row["SiteCode"].ToString();
                                Library.KEY_USER_ccode = row["country_id"].ToString();

                                Library.KEY_USER_regcode = row["region_id"].ToString();

                                Library.KEY_USER_siteid = row["site_id"].ToString();
                                Library.KEY_USER_roleid = row["role_Id"].ToString();

                                Library.KEY_USER_feedback_link = row["feedback_link"].ToString();
                                Library.KEY_USER_language_id = row["language_id"].ToString();
                                Library.KEY_USER_payment_mode_ids = row["payment_mode_ids"].ToString();
                                Library.KEY_USER_currency = row["country_currency"].ToString();
                                Library.KEY_USER_adjusttime = row["AdjustsiteTime"].ToString();

                                if (Library.KEY_USER_ROLE == "FSA" || Library.KEY_USER_ROLE == "Nurse" || Library.KEY_USER_ROLE == "Nurse+FSA")
                                {
                                    CreateDB();

                                    if (expireday == "")
                                    {
                                        await NavigateToHome(Library.URL, httpClient, id);
                                    }
                                    else if (expireday == "100")
                                    {
                                        await PageDialog.DisplayAlertAsync("Alert!!", "Password will expire in one day", "ok");

                                        await NavigateToHome(Library.URL, httpClient, id);
                                       
                                    }
                                    else if (expireday == "200")
                                    {

                                        await PageDialog.DisplayAlertAsync("Alert!!", "Password will expire in two days", "OK");
                                        await NavigateToHome(Library.URL, httpClient, id);
                                    }
                                    else if (expireday == "300")
                                    {
                                        await PageDialog.DisplayAlertAsync("Alert!!", "Password will expire in three days", "OK");
                                        await NavigateToHome(Library.URL, httpClient, id);

                                    }
                                    else if (expireday == "400")
                                    {
                                        var termsPopup = new TermsConditionPopup();
                                        termsPopup.Disappearing += async(s, e) => 
                                        {
                                            if (termsPopup.isAccepted)
                                            {
                                                IsPageEnabled = true;


                                                dynamic p = new JObject();
                                                p.UserId = Library.KEY_USER_ID;

                                                var Payload = JsonConvert.SerializeObject(p);
                                                var httpMSgClient = new System.Net.Http.HttpClient();
                                                // Wrap our JSON inside a StringContent which then can be used by the HttpClient class
                                                var Content = new StringContent(Payload, Encoding.UTF8, "application/json");

                                                var msgResponse = await httpMSgClient.PostAsync(Library.URL + "/" + "TermsConditions", Content);
                                                await NavigateToHome(Library.URL, httpMSgClient, id);

                                                IsPageEnabled = false;
                                            }
                                        };
                                        await navigation.PushPopupAsync(termsPopup,true);
                                    }
                                    else if (expireday == "500")
                                    {
                                        //this.Frame.Navigate(typeof(PatientSearch), null);
                                        await PageDialog.DisplayAlertAsync("Alert!!", "Password is Expired.", "OK");

                                    }
                                    else if (expireday == "600")
                                    {
                                        //this.Frame.Navigate(typeof(PatientSearch), null);
                                        await PageDialog.DisplayAlertAsync("Alert!!", "This User Is Deactivated, Kindly Contact Admin.", "OK");

                                    }
                                    else
                                    {
                                        await PageDialog.DisplayAlertAsync("Alert!!", "Unknown Error.", "OK");
                                    }


                                }
                                else
                                {
                                    ErrorText = "Only FSA and Nurse can login in tablet.";

                                }


                            }
                            else
                                ErrorText = "Invalid user name or password.";
                        }

                    }
                }

                //-----------------------------------

                //HttpResponseMessage response = await httpClient.SendAsync(request);


                //var response = await client.PostAsync("login", content);
                //  var response = await httpClient.GetAsync(URL + "/" + method + "/");
                //  HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, URL + "/" + method + "/" + txtusername.Text + "/" + txtpass.Text);
                //   var result = response.Content.ReadAsStringAsync().Result;
                // jarray= await response.Content.ReadAsStringAsync();

                //stop progessring
                //stop progessring
                IsPageEnabled = false;
            }
            catch (Exception excp)
            {
                await PageDialog.DisplayAlertAsync("Alert!!", excp.Message, "OK");
                IsPageEnabled = false;
                // await Navigation.PushAsync(new PatientSearch());

                // await DisplayAlert("", excp.Message, "ok");

            }
        }

        private async Task NavigateToHome(string URL, HttpClient httpClient, string id)
        {
            await Task.Run(async() =>
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, URL + "/updatelogtrue/" + id);
                await httpClient.SendAsync(request);
            });


            Device.BeginInvokeOnMainThread(async() =>
            {
                await NavigationService.NavigateAsync("app:///HomeMasterDetailPage");
            });
            
            await SessionManager.Instance.StartTrackSessionAsync();
        }

        private void CreateDB()
        {
            Helpers.DevelopmentCode.CreateTables();
        }

        public override void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);

            RoleList = new List<string> { "Select Role" };
            _colorConverter = new ColorTypeConverter();
            _random = new Random();
            GetColorList();
            ChangeBackgroundColor();
            Captcha = GetUniqueKey(6);
        }
    }
}
