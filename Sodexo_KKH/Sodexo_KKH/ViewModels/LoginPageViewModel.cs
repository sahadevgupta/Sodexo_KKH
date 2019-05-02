using Newtonsoft.Json.Linq;
using Plugin.Connectivity;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Sodexo_KKH.Helpers;
using Sodexo_KKH.Resx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

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

        private bool _isPageEnabled;
        public bool IsPageEnabled
        {
            get { return _isPageEnabled; }
            set { SetProperty(ref _isPageEnabled, value); }
        }

        public DelegateCommand LoginCommand => new DelegateCommand(Login);
        
        public LoginPageViewModel(INavigationService navigationService) : base(navigationService)
        {

        }

        internal async Task BindRole()
        {
            //try
            //{
            //    if (!string.IsNullOrEmpty(UserName))
            //    {
            //        // string URL = Library.KEY_http + library.LoadSetting(Library.KEY_SERVER_IP) + "/" + Library.KEY_SERVER_LOCATION + "/sodexo.svc";
            //        string URL = Library.KEY_http + Library.KEY_SERVER_IP + "/" + Library.KEY_SERVER_LOCATION + "/sodexo.svc";

            //        //start progessring
            //        pbar.IsBusy = true;
            //        pbar.IsEnabled = true;
            //        //var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            //        //JArray jarray;
            //        HttpClient httpClient = new System.Net.Http.HttpClient();
            //        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, URL + "/" + Library.METHODE_GETUSERROLEBYUSERNAMEMOBILE + "/" + UserName);

            //        HttpResponseMessage response = await httpClient.SendAsync(request);

            //        var data = await response.Content.ReadAsStringAsync();
            //        //var db = DependencyService.Get<IDBInterface>().GetConnection();
            //        List<string> Mylist = new List<string>();

            //        JArray jarray = JArray.Parse(data);
            //        if (jarray.Count > 0)
            //        {
            //            for (int i = 0; i < jarray.Count; i++)
            //            {
            //                JObject row = JObject.Parse(jarray[i].ToString());
            //                Mylist.Add(row["role"].ToString());
            //            }
            //            //   comboBox.SetBinding(Label.da, binding);
            //            //cmbsearchbyward.DataSource = Mylist;                         
            //        }
            //        else
            //        {
            //            Mylist.Add("Select Role");
            //        }

            //        sr.IsVisible = (jarray.Count > 1) ? true : false;
            //        src.IsVisible = (jarray.Count > 1) ? true : false;

            //        cmbrole.DataSource = Mylist;
            //        cmbrole.SelectedItem = Mylist[0];
            //        username = txtusername.Text;
            //        //stop progessring
            //        //stop progessring
            //        pbar.IsBusy = false;
            //        pbar.IsEnabled = false;
            //    }
            //}
            //catch (Exception excp)
            //{
            //    //stop progessring
            //    pbar.IsBusy = false;
            //    pbar.IsEnabled = false;
            //}
        }

        private void Login()
        {
            bool isInternetConnected = NetworkInterface.GetIsNetworkAvailable();

            // checking if user name and password are not blank      
            //if (txtusername.Text != "" && txtpass.Text != "")
            //{
            //    try
            //    {
            //        if (CrossConnectivity.Current.IsConnected)
            //        {
            //            checkLogin();


            //        }
            //        else
            //        {
            //            //  await  DisplayAlert("Notification", "Do you want store this Number ?", "Yes", "No");
            //            await DisplayAlert("", AppResources.ResourceManager.GetString("msg10", CultureInfo.CurrentCulture), "OK");


            //        }


            //    }
            //    catch (Exception ex)
            //    {
            //        tblkmessage.Text = ex.Message;

            //    }
            //}
            //else
            //{
            //    tblkmessage.Text = AppResources.ResourceManager.GetString("plss");
            //}
        }

        public async void checkLogin()
        {
            //try
            //{
            //    // string URL = Library.KEY_http + library.LoadSetting(Library.KEY_SERVER_IP) + "/" + Library.KEY_SERVER_LOCATION + "/sodexo.svc";
            //    string URL = Library.KEY_http + Library.KEY_SERVER_IP + "/" + Library.KEY_SERVER_LOCATION + "/sodexo.svc";

            //    if (txtusername.Text == null || txtusername.Text == string.Empty)
            //    {
            //        pbar.IsBusy = false;
            //        pbar.IsEnabled = false;
            //        tblkmessage.Text = AppResources.ResourceManager.GetString("msg2w");
            //        return;
            //    }

            //    string userType = string.Empty;
            //    String selected_user_value = cmbrole.SelectedItem.ToString();
            //    //Toast.makeText(LoginActivity.this,"Selection changed",Toast.LENGTH_LONG).show();
            //    if (selected_user_value.Equals("Select Role"))
            //    {
            //        userType = "Select Role";

            //    }
            //    else if (selected_user_value.Equals("Nurse"))
            //    {
            //        userType = "N";
            //    }
            //    else if (selected_user_value.Equals("FSA"))
            //    {
            //        userType = "F";
            //    }
            //    else
            //    {
            //        userType = "NF";
            //    }


            //    //start progessring
            //    pbar.IsBusy = true;
            //    pbar.IsEnabled = true;
            //    //var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            //    //JArray jarray;
            //    String method = "UserLogin";
            //    //HttpClient httpClient = new System.Net.Http.HttpClient();
            //    //HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, URL + "/" + Library.METHODE_USERLOGIN + "/" + txtusername.Text + "/" + txtpass.Text + "/" + userType);

            //    //---------------------------------

            //    var obj = new login();
            //    obj.Name = txtusername.Text;
            //    obj.pass = txtpass.Text;
            //    obj.roleType = userType;

            //    // Serialize our concrete class into a JSON String
            //    var stringPayload = await Task.Run(() => JsonConvert.SerializeObject(obj));

            //    // Wrap our JSON inside a StringContent which then can be used by the HttpClient class
            //    var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");

            //    // display a message jason conversion
            //    //var message1 = new MessageDialog("Data is converted in json.");
            //    //await message1.ShowAsync();

            //    using (var httpClient = new System.Net.Http.HttpClient())
            //    {
            //        var response = new System.Net.Http.HttpResponseMessage();
            //        // Do the actual request and await the response


            //        // httpResponse = new Uri(URL + "/" + Library.METHODE_UPDATE_ORDER); //replace your Url
            //        response = await httpClient.PostAsync(URL + "/" + Library.METHODE_USERLOGIN, httpContent);


            //        // display a message jason conversion
            //        //var message2 = new MessageDialog(httpResponse.ToString());
            //        //await message2.ShowAsync();
            //        //var httpResponse = await httpClient.PostAsync(URL + "/" + Library.METHODE_SAVEORDER, httpContent);

            //        // If the response contains content we want to read it!
            //        if (response.Content != null)
            //        {
            //            var data = await response.Content.ReadAsStringAsync();
            //            if (response.ReasonPhrase == "Bad Request")
            //            {
            //                pbar.IsBusy = false;
            //                pbar.IsEnabled = false;
            //                tblkmessage.Text = AppResources.ResourceManager.GetString("msg2w");
            //                return;
            //            }

            //            if (response.ReasonPhrase == "Not Found")
            //            {
            //                pbar.IsBusy = false;
            //                pbar.IsEnabled = false;
            //                tblkmessage.Text = AppResources.ResourceManager.GetString("msg2w");
            //                return;
            //            }

            //            JArray jarray = JArray.Parse(data);

            //            for (int i = 0; i < jarray.Count; i++)
            //            {

            //                JObject row = JObject.Parse(jarray[i].ToString());
            //                id = row["ID"].ToString();
            //                firstname = row["FirstName"].ToString();
            //                lastname = row["LastName"].ToString();
            //                roletype = row["RoleType"].ToString();
            //                usrrole = row["UserRole"].ToString();
            //                status = row["status"].ToString();
            //                expireday = row["expireday"].ToString();
            //                SiteCode = row["SiteCode"].ToString();
            //                countrycode = row["country_id"].ToString();
            //                siteid = row["site_id"].ToString();
            //                roleid = row["role_Id"].ToString();
            //                regid = row["region_id"].ToString();
            //                language_id = row["language_id"].ToString();
            //                payment_mode_ids = row["payment_mode_ids"].ToString();
            //                feedback_link = row["feedback_link"].ToString();
            //                countrycurrency = row["country_currency"].ToString();
            //                adjusttime = row["AdjustsiteTime"].ToString();

            //            }
            //            //if (id != "0" && firstname != "null")
            //            if (id != "0")
            //            {
            //                // Storing user's detail in application data locally
            //                Library.KEY_USER_ID = id;
            //                Library.KEY_USER_FIRST_NAME = firstname;
            //                Library.KEY_USER_LAST_NAME = lastname;
            //                Library.KEY_ROLL_TYPE = roletype;
            //                Library.KEY_USER_ROLE = usrrole;
            //                Library.KEY_USER_STATUS = status;
            //                Library.KEY_USER_SiteCode = SiteCode;
            //                Library.KEY_USER_ccode = countrycode;

            //                Library.KEY_USER_regcode = regid;

            //                Library.KEY_USER_siteid = siteid;
            //                Library.KEY_USER_roleid = roleid;

            //                Library.KEY_USER_feedback_link = feedback_link;
            //                Library.KEY_USER_language_id = language_id;
            //                Library.KEY_USER_payment_mode_ids = payment_mode_ids;
            //                Library.KEY_USER_currency = countrycurrency;
            //                Library.KEY_USER_adjusttime = adjusttime;


            //                //Storing user name and password also
            //                //Library.KEY_USER_NAME, txtusername.Text);
            //                //  Library.KEY_USER_PWD, txtpass.Password);


            //                //opening patient search page
            //                //opening patient search page
            //                if (usrrole == "FSA" || usrrole == "Nurse" || usrrole == "Nurse+FSA")
            //                {
            //                    if (expireday == "")
            //                    {
            //                        await Navigation.PushAsync(new PatientSearch());
            //                        //var message = new MessageDialog("Password will expire in one day");
            //                        //await message.ShowAsync();
            //                    }
            //                    if (expireday == "100")
            //                    {
            //                        await DisplayAlert("", "Password will expire in one day", "ok");


            //                        await Navigation.PushAsync(new PatientSearch());

            //                    }
            //                    if (expireday == "200")
            //                    {

            //                        await DisplayAlert("", "Password will expire in two days", "");

            //                        await Navigation.PushAsync(new PatientSearch());
            //                    }
            //                    if (expireday == "300")
            //                    {
            //                        await DisplayAlert("", "Password will expire in three days", "");

            //                        await Navigation.PushAsync(new PatientSearch());

            //                    }
            //                    if (expireday == "500")
            //                    {
            //                        //this.Frame.Navigate(typeof(PatientSearch), null);
            //                        await DisplayAlert("", "Password is Expired.", "");

            //                    }
            //                    if (expireday == "600")
            //                    {
            //                        //this.Frame.Navigate(typeof(PatientSearch), null);
            //                        await DisplayAlert("", "This User Is Deactivated, Kindly Contact Admin.", "");

            //                    }


            //                }
            //                else
            //                {
            //                    tblkmessage.Text = AppResources.ResourceManager.GetString("msg22");

            //                }


            //            }
            //            else
            //            {
            //                tblkmessage.Text = AppResources.ResourceManager.GetString("msg2w");
            //                //var dialog = new MessageDialog("Invailid user name or password.");
            //                //await dialog.ShowAsync();
            //            }




            //        }
            //    }









            //    //-----------------------------------

            //    //HttpResponseMessage response = await httpClient.SendAsync(request);


            //    //var response = await client.PostAsync("login", content);
            //    //  var response = await httpClient.GetAsync(URL + "/" + method + "/");
            //    //  HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, URL + "/" + method + "/" + txtusername.Text + "/" + txtpass.Text);
            //    //   var result = response.Content.ReadAsStringAsync().Result;
            //    // jarray= await response.Content.ReadAsStringAsync();

            //    //stop progessring
            //    //stop progessring
            //    pbar.IsBusy = false;
            //    pbar.IsEnabled = false;
            //}
            //catch (Exception excp)
            //{
            //    //stop progessring
            //    pbar.IsBusy = false;
            //    pbar.IsEnabled = false;
            //    await Navigation.PushAsync(new PatientSearch());

            //    // await DisplayAlert("", excp.Message, "ok");

            //}
        }

    }
}
