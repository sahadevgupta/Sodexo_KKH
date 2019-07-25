﻿using Newtonsoft.Json;
using Sodexo_KKH.Interfaces;
using Sodexo_KKH.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Sodexo_KKH.Helpers
{
    public static class MasterSync
    {
        private static string URL = Library.KEY_http + Library.KEY_SERVER_IP + "/" + Library.KEY_SERVER_LOCATION + "/sodexo.svc";
        public async static Task SyncMaster()
        {
            await Sync_mstr_mealclass();
            await Sync_mstr_bed_meal_class_mapping();
            await Sync_mstr_allergies_master();
            await Sync_mstr_bed_details();
            await Sync_mstr_diet_type();
            await Sync_mstr_diet_texture();
            await Sync_mstr_fluid_master();
            await Sync_mstr_ingredient();
            await Sync_mstr_allergies_master();
            await Sync_mstr_remarks();
            await Sync_mstr_meal_type();
            await Sync_mstr_Cycledetails();
            await Sync_mstr_ward_details();
            await Sync_mstr_meal_time();
            await Sync_mstr_displaypayment();
            await Sync_mstr_menu_item_category();
            await Sync_mstr_therapeutic();
            await Sync_mstr_others_master();
            await Sync_mstr_meal_option();
            await Sync_mstr_flag();
            // await Sync_mstr_patient_info();
            await Sync_mstr_therapeutic_condition();

        }

        private async static Task Sync_mstr_therapeutic_condition()
        {
            try
            {
                HttpClient httpClient = new System.Net.Http.HttpClient();
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, URL + "/" + Library.METHODE_THERAPEUTICCONDITIONDETAILS + "/" + Library.KEY_USER_ccode);
                HttpResponseMessage response = await httpClient.SendAsync(request);
                List<mstr_therapeutic_condition> jarray = JsonConvert.DeserializeObject<List<mstr_therapeutic_condition>>(await response.Content.ReadAsStringAsync());

                using (var dbConn = DependencyService.Get<IDBInterface>().GetConnection())
                {
                    dbConn.DropTable<mstr_therapeutic_condition>();
                    dbConn.CreateTable<mstr_therapeutic_condition>();
                    dbConn.InsertAll(jarray);
                    dbConn.Commit();
                };
            }
            catch (Exception excp)
            {

            }
        }

        public async static Task Sync_mstr_patient_info()
        {
            try
            {
                mstr_patient_info patient_info = new mstr_patient_info();
                HttpClient httpClient = new System.Net.Http.HttpClient();
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, URL + "/" + Library.METHODE_GETALLPATIENT + "/" + Library.KEY_USER_SiteCode);
                HttpResponseMessage response = await httpClient.SendAsync(request);

                List<mstr_patient_info> jarray = JsonConvert.DeserializeObject<List<mstr_patient_info>>(await response.Content.ReadAsStringAsync());
                using (var dbConn = DependencyService.Get<IDBInterface>().GetConnection())
                {
                    dbConn.DropTable<mstr_patient_info>();
                    dbConn.CreateTable<mstr_patient_info>();
                    // dbConn.BeginTransaction();
                    foreach (var item in jarray)
                    {
                        item.ward_bed = item.ward_name + "-" + item.bed_name;
                        item.ID = item.ID;

                        if (string.Equals(item.is_care_giver, "true", StringComparison.CurrentCultureIgnoreCase))
                            item.Patientname = item.Patientname + ' ' + "(Care Giver)";

                    }
                    dbConn.InsertAll(jarray);
                    dbConn.Commit();
                };
            }
            catch (Exception)
            {
            }
        }

        private async static Task Sync_mstr_flag()
        {
            try
            {

                HttpClient httpClient = new System.Net.Http.HttpClient();
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, URL + "/" + Library.METHODE_DisplayLanguageDetails);
                HttpResponseMessage response = await httpClient.SendAsync(request);
                // jarray= await response.Content.ReadAsStringAsync();
                List<mstr_DisplayLanguageDetails> jarray = JsonConvert.DeserializeObject<List<mstr_DisplayLanguageDetails>>(await response.Content.ReadAsStringAsync());

                using (var dbConn = DependencyService.Get<IDBInterface>().GetConnection())
                {
                    dbConn.DropTable<mstr_DisplayLanguageDetails>();
                    dbConn.CreateTable<mstr_DisplayLanguageDetails>();

                    foreach (var item in jarray)
                    {
                        byte[] toBytes = item.country_flag;
                        //var toBytes = (item.country_flag == null ? null : aa.ToObject<byte[]>());
                        item.country_flag = toBytes;
                        dbConn.Insert(item);
                        //   dbhelper.Insert_INTO_flag(new mstr_DisplayLanguageDetails(Convert.ToInt32(row["ID"].ToString()), toBytes, Convert.ToInt32(row["country_id"].ToString()), row["country_name"].ToString(), row["language_name"].ToString(), Convert.ToBoolean(row["status_id"].ToString())));
                    }

                    //  searchbtn1();
                    //  StackPanel_Tapped(new object(), new TappedRoutedEventArgs());

                    //var message = new MessageDialog(loader.GetString("msg7").ToString());
                    //await message.ShowAsync();
                };
            }
            catch (Exception excp)
            {
            }
        }

        private async static Task Sync_mstr_meal_option()
        {
            try
            {
                HttpClient httpClient = new System.Net.Http.HttpClient();
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, URL + "/" + Library.METHODE_DISPLAYMEAL_OPTION + "/" + Library.KEY_USER_ccode);
                HttpResponseMessage response = await httpClient.SendAsync(request);
                List<mstr_meal_option> jarray = JsonConvert.DeserializeObject<List<mstr_meal_option>>(await response.Content.ReadAsStringAsync());

                using (var dbConn = DependencyService.Get<IDBInterface>().GetConnection())
                {
                    dbConn.DropTable<mstr_meal_option>();
                    dbConn.CreateTable<mstr_meal_option>();
                    dbConn.InsertAll(jarray);
                    dbConn.Commit();
                };
            }
            catch (Exception excp)
            {
            }
        }

        private async static Task Sync_mstr_others_master()
        {
            try
            {
                HttpClient httpClient = new System.Net.Http.HttpClient();
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, URL + "/" + Library.METHODE_OTHERSMASTERDETAILS + "/" + Library.KEY_USER_ccode);
                HttpResponseMessage response = await httpClient.SendAsync(request);
                List<mstr_others_master> jarray = JsonConvert.DeserializeObject<List<mstr_others_master>>(await response.Content.ReadAsStringAsync());

                using (var dbConn = DependencyService.Get<IDBInterface>().GetConnection())
                {
                    dbConn.DropTable<mstr_others_master>();
                    dbConn.CreateTable<mstr_others_master>();
                    dbConn.InsertAll(jarray);
                    dbConn.Commit();
                };
            }
            catch (Exception excp)
            {
            }
        }

        private async static Task Sync_mstr_therapeutic()
        {
            try
            {
                HttpClient httpClient = new System.Net.Http.HttpClient();
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, URL + "/" + Library.METHODE_THERAPEUTICDETAILS + "/" + Library.KEY_USER_ccode);
                HttpResponseMessage response = await httpClient.SendAsync(request);
                List<mstr_therapeutic> jarray = JsonConvert.DeserializeObject<List<mstr_therapeutic>>(await response.Content.ReadAsStringAsync());

                using (var dbConn = DependencyService.Get<IDBInterface>().GetConnection())
                {
                    dbConn.DropTable<mstr_therapeutic>();
                    dbConn.CreateTable<mstr_therapeutic>();
                    dbConn.InsertAll(jarray);
                    dbConn.Commit();
                };
            }
            catch (Exception excp)
            {

            }
        }

        private async static Task Sync_mstr_menu_item_category()
        {
            try
            {
                HttpClient httpClient = new System.Net.Http.HttpClient();
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, URL + "/" + Library.METHODE_MENUITEMCATEGORYDETAILS + "/" + Library.KEY_USER_ccode);
                HttpResponseMessage response = await httpClient.SendAsync(request);
                // jarray= await response.Content.ReadAsStringAsync();
                List<mstr_menu_item_category> jarray = JsonConvert.DeserializeObject<List<mstr_menu_item_category>>(await response.Content.ReadAsStringAsync());

                using (var dbConn = DependencyService.Get<IDBInterface>().GetConnection())
                {
                    dbConn.DropTable<mstr_menu_item_category>();
                    dbConn.CreateTable<mstr_menu_item_category>();
                    dbConn.InsertAll(jarray);
                    dbConn.Commit();
                };
            }
            catch (Exception excp)
            {
                // stop progressring


            }
        }

        private async static Task Sync_mstr_displaypayment()
        {
            try
            {
                HttpClient httpClient = new System.Net.Http.HttpClient();
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, URL + "/" + Library.METHODE_DisplayPaymentModeDetails);
                HttpResponseMessage response = await httpClient.SendAsync(request);
                // jarray= await response.Content.ReadAsStringAsync();
                List<mstr_DisplayPaymentModeDetails> jarray = JsonConvert.DeserializeObject<List<mstr_DisplayPaymentModeDetails>>(await response.Content.ReadAsStringAsync());

                using (var dbConn = DependencyService.Get<IDBInterface>().GetConnection())
                {
                    dbConn.DropTable<mstr_DisplayPaymentModeDetails>();
                    dbConn.CreateTable<mstr_DisplayPaymentModeDetails>();
                    dbConn.InsertAll(jarray);
                    dbConn.Commit();
                };
            }
            catch (Exception excp)
            {

            }
        }

        private async static Task Sync_mstr_meal_time()
        {
            try
            {
                HttpClient httpClient = new System.Net.Http.HttpClient();
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, URL + "/" + Library.METHODE_MEALTIMELIST);
                HttpResponseMessage response = await httpClient.SendAsync(request);
                // jarray= await response.Content.ReadAsStringAsync();
                List<mstr_meal_time> jarray = JsonConvert.DeserializeObject<List<mstr_meal_time>>(await response.Content.ReadAsStringAsync());

                using (var dbConn = DependencyService.Get<IDBInterface>().GetConnection())
                {
                    dbConn.DropTable<mstr_meal_time>();
                    dbConn.CreateTable<mstr_meal_time>();
                    dbConn.InsertAll(jarray);
                    dbConn.Commit();
                };

                //loading items in ward combobox
                // FillCombobox2();
                // stop progressring
                // display the previous state of selection
                //orderdtpicker.Date = new DateTime(seldate.DayOfYear, seldate.Month, seldate.Day);
                //cmbsearchbyward.SelectedIndex = selward;
                //cmbsearchbypatient.SelectedIndex = selbed;

                //   FillCombobox2();

            }
            catch (Exception excp)
            {
                // stop progressring
                //   FillCombobox2();
            }
        }

        private async static Task Sync_mstr_ward_details()
        {
            try
            {
                HttpClient httpClient = new System.Net.Http.HttpClient();
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, URL + "/" + Library.METHODE_DISPLAYWARDDETAILS + "/" + Library.KEY_USER_ccode + "/" + Library.KEY_USER_regcode + "/" + Library.KEY_USER_siteid + "/0");
                HttpResponseMessage response = await httpClient.SendAsync(request);
                List<mstr_ward_details> jarray = JsonConvert.DeserializeObject<List<mstr_ward_details>>(await response.Content.ReadAsStringAsync());

                using (var dbConn = DependencyService.Get<IDBInterface>().GetConnection())
                {
                    dbConn.DropTable<mstr_ward_details>();
                    dbConn.CreateTable<mstr_ward_details>();

                    foreach (var item in jarray)
                    {
                        string cont_id = item.country_id.ToString();
                        string rgn_id = item.region_id.ToString();
                        string st_id = item.site_id.ToString();

                        if (Library.KEY_USER_ccode == cont_id && Library.KEY_USER_regcode == "nil" || Convert.ToInt16(Library.KEY_USER_regcode) == 0 || Library.KEY_USER_regcode == rgn_id && Library.KEY_USER_siteid == "nil" || Convert.ToInt32(Library.KEY_USER_siteid) == 0 || Library.KEY_USER_siteid == st_id)
                            dbConn.Insert(item);
                    }
                };
            }
            catch (Exception excp)
            {
            }
        }

        private async static Task Sync_mstr_Cycledetails()
        {
            try
            {

                HttpClient httpClient = new System.Net.Http.HttpClient();
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, URL + "/" + Library.METHODE_CYCLEDETAILS + "/" + Library.KEY_USER_ccode + "/" + Library.KEY_USER_regcode + "/" + Library.KEY_USER_siteid + "/0");
                HttpResponseMessage response = await httpClient.SendAsync(request);
                // jarray= await response.Content.ReadAsStringAsync();
                var data = await response.Content.ReadAsStringAsync();
                //JArray jarray = JArray.Parse(data);
                List<mstr_Cycledetails> jarray = JsonConvert.DeserializeObject<List<mstr_Cycledetails>>(await response.Content.ReadAsStringAsync());
                using (var dbConn = DependencyService.Get<IDBInterface>().GetConnection())
                {
                    dbConn.DropTable<mstr_Cycledetails>();
                    dbConn.CreateTable<mstr_Cycledetails>();
                    foreach (var item in jarray)
                    {
                        string todate = "";
                        string fromdate = "";
                        string formattedto = "";
                        string formatedfrom = "";
                        try
                        {
                            // DateTime dt1= DateTime.ParseExact(row["tdate"].ToString(), "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                            DateTime dt1 = DateTime.ParseExact(item.todate.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            formattedto = dt1.ToString("yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
                            todate = String.Format("{0:yyyy-MM-dd 00:00:00.000}", dt1);
                            DateTime dt2 = DateTime.ParseExact(item.fromdate.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            formatedfrom = dt2.ToString("yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
                            fromdate = String.Format("{0:yyyy-MM-dd 00:00:00.000}", dt2);
                            // fromdate = row["fdate"].ToString();
                            DateTime to = Convert.ToDateTime(todate);
                            DateTime from = Convert.ToDateTime(fromdate);

                            formattedto = to.ToString("yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
                            formatedfrom = from.ToString("yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
                        }
                        catch (Exception)
                        {
                        }

                        string cont_id = item.country_id.ToString();
                        string rgn_id = item.region_id.ToString();
                        string st_id = item.site_id.ToString();

                        // Filtering data based on
                        //                    if (country_id1 == cont_id && (region_id1 == nil || region_id1 == 0 || region_id1 == rgn_id) && (site_id1 == nil || site_id1 == 0 || site_id1 == st_id))
                        if (Library.KEY_USER_ccode == cont_id && Library.KEY_USER_regcode == "nil" || Convert.ToInt16(Library.KEY_USER_regcode) == 0 || Library.KEY_USER_regcode == rgn_id && Library.KEY_USER_siteid == "nil" || Convert.ToInt32(Library.KEY_USER_siteid) == 0 || Library.KEY_USER_siteid == st_id)
                        {
                            item.formattedto = formattedto;
                            item.formattedfrom = formatedfrom;
                            item.todate = todate;
                            item.fromdate = fromdate;
                            dbConn.Insert(item);
                            //     dbhelper.Insert_INTO_mstr_Cycledetails(new mstr_Cycledetails(Convert.ToInt32(row["ID"].ToString()), row["cycle_name"].ToString(), row["cycle_description"].ToString(), row["cycle_type"].ToString(), row["fromdate"].ToString(), todate, row["sitecode"].ToString(), Convert.ToInt32(row["status_id"].ToString()), formattedto, formatedfrom, Convert.ToInt32(row["Cycle_id"].ToString())));
                        }
                    }
                    dbConn.Commit();
                };
                //var message = new MessageDialog(loader.GetString("msg8").ToString());
                //await message.ShowAsync();
                //myring.IsActive = false;
                //myring.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            }
            catch (Exception excp)
            {
            }
        }

        private async static Task Sync_mstr_meal_type()
        {
            try
            {
                HttpClient httpClient = new System.Net.Http.HttpClient();
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, URL + "/" + Library.METHODE_DISPLAYMEALTYPE + "/" + Library.KEY_USER_ccode);
                HttpResponseMessage response = await httpClient.SendAsync(request);
                // jarray= await response.Content.ReadAsStringAsync();
                List<mstr_meal_type> jarray = JsonConvert.DeserializeObject<List<mstr_meal_type>>(await response.Content.ReadAsStringAsync());

                using (var dbConn = DependencyService.Get<IDBInterface>().GetConnection())
                {
                    dbConn.DropTable<mstr_meal_type>();
                    dbConn.CreateTable<mstr_meal_type>();
                    dbConn.InsertAll(jarray);
                    dbConn.Commit();
                };

                //loading items in ward combobox
                // FillCombobox2();

                // stop progressring
                // display the previous state of selection
                //orderdtpicker.Date = new DateTime(seldate.DayOfYear, seldate.Month, seldate.Day);
                //cmbsearchbyward.SelectedIndex = selward;
                //cmbsearchbypatient.SelectedIndex = selbed;

                //   FillCombobox2();
            }
            catch (Exception excp)
            {
                // stop progressring
                //   FillCombobox2();
            }
        }

        private async static Task Sync_mstr_remarks()
        {
            try
            {
                HttpClient httpClient = new System.Net.Http.HttpClient();
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, URL + "/" + Library.METHODE_GETREMARKSDETAIL + "/" + Library.KEY_USER_ccode);
                HttpResponseMessage response = await httpClient.SendAsync(request);
                // jarray= await response.Content.ReadAsStringAsync();
                List<mstr_remarks> jarray = JsonConvert.DeserializeObject<List<mstr_remarks>>(await response.Content.ReadAsStringAsync());

                using (var dbConn = DependencyService.Get<IDBInterface>().GetConnection())
                {
                    dbConn.DropTable<mstr_remarks>();
                    dbConn.CreateTable<mstr_remarks>();
                    dbConn.InsertAll(jarray);
                    dbConn.Commit();
                };
            }
            catch (Exception excp)
            {
            }
        }

        private async static Task Sync_mstr_ingredient()
        {
            try
            {
                HttpClient httpClient = new System.Net.Http.HttpClient();
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, URL + "/" + Library.METHODE_INGREDIENTLIST + "/" + Library.KEY_USER_ccode);
                HttpResponseMessage response = await httpClient.SendAsync(request);
                // jarray= await response.Content.ReadAsStringAsync();
                List<mstr_ingredient> jarray = JsonConvert.DeserializeObject<List<mstr_ingredient>>(await response.Content.ReadAsStringAsync());

                using (var dbConn = DependencyService.Get<IDBInterface>().GetConnection())
                {
                    dbConn.DropTable<mstr_ingredient>();
                    dbConn.CreateTable<mstr_ingredient>();
                    dbConn.InsertAll(jarray);
                    dbConn.Commit();
                };
            }
            catch (Exception excp)
            {
            }
        }

        private async static Task Sync_mstr_fluid_master()
        {
            try
            {

                HttpClient httpClient = new System.Net.Http.HttpClient();
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, URL + "/" + Library.METHODE_GETALLFLUIDCONSISTENCY + "/" + Library.KEY_USER_ccode);
                HttpResponseMessage response = await httpClient.SendAsync(request);
                // jarray= await response.Content.ReadAsStringAsync();
                List<mstr_fluid_master> jarray = JsonConvert.DeserializeObject<List<mstr_fluid_master>>(await response.Content.ReadAsStringAsync());


                using (var dbConn = DependencyService.Get<IDBInterface>().GetConnection())
                {
                    dbConn.DropTable<mstr_fluid_master>();
                    dbConn.CreateTable<mstr_fluid_master>();
                    dbConn.InsertAll(jarray);
                    dbConn.Commit();
                };

            }
            catch (Exception)
            {
            }
        }

        private async static Task Sync_mstr_diet_texture()
        {
            try
            {
                HttpClient httpClient = new System.Net.Http.HttpClient();
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, URL + "/" + Library.METHODE_GETALLDIETTEXTURE + "/" + Library.KEY_USER_ccode);
                HttpResponseMessage response = await httpClient.SendAsync(request);
                // jarray= await response.Content.ReadAsStringAsync();
                List<mstr_diet_texture> jarray = JsonConvert.DeserializeObject<List<mstr_diet_texture>>(await response.Content.ReadAsStringAsync());

                using (var dbConn = DependencyService.Get<IDBInterface>().GetConnection())
                {
                    dbConn.DropTable<mstr_diet_texture>();
                    dbConn.CreateTable<mstr_diet_texture>();
                    dbConn.InsertAll(jarray);
                    dbConn.Commit();
                };
            }
            catch (Exception excp)
            {
            }
        }

        private async static Task Sync_mstr_diet_type()
        {
            try
            {
                HttpClient httpClient = new System.Net.Http.HttpClient();
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, URL + "/" + Library.METHODE_DISPLAYDIET_TYPE + "/" + Library.KEY_USER_ccode);
                HttpResponseMessage response = await httpClient.SendAsync(request);
                // jarray= await response.Content.ReadAsStringAsync();
                List<mstr_diet_type> jarray = JsonConvert.DeserializeObject<List<mstr_diet_type>>(await response.Content.ReadAsStringAsync());

                using (var dbConn = DependencyService.Get<IDBInterface>().GetConnection())
                {
                    dbConn.DropTable<mstr_diet_type>();
                    dbConn.CreateTable<mstr_diet_type>();
                    dbConn.InsertAll(jarray);
                    dbConn.Commit();
                };
            }
            catch (Exception excp)
            {
            }
        }

        private async static Task Sync_mstr_bed_details()
        {
            try
            {

                HttpClient httpClient = new System.Net.Http.HttpClient();
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, URL + "/" + Library.METHODE_DISPLAYBEDDETAILS + "/" + Library.KEY_USER_ccode + "/" + Library.KEY_USER_regcode + "/" + Library.KEY_USER_siteid + "/0");
                HttpResponseMessage response = await httpClient.SendAsync(request);
                // jarray= await response.Content.ReadAsStringAsync();
                List<mstr_bed_details> jarray = JsonConvert.DeserializeObject<List<mstr_bed_details>>(await response.Content.ReadAsStringAsync());


                using (var dbConn = DependencyService.Get<IDBInterface>().GetConnection())
                {
                    dbConn.DropTable<mstr_bed_details>();
                    dbConn.CreateTable<mstr_bed_details>();

                    foreach (var item in jarray)
                    {

                        string cont_id = item.country_id.ToString();
                        string rgn_id = item.region_id;
                        string st_id = item.site_id.ToString();

                        // Filtering data based on

                        //                    if (country_id1 == cont_id && (region_id1 == nil || region_id1 == 0 || region_id1 == rgn_id) && (site_id1 == nil || site_id1 == 0 || site_id1 == st_id))
                        if (Library.KEY_USER_ccode == cont_id && Library.KEY_USER_regcode == "nil" || Convert.ToInt16(Library.KEY_USER_regcode) == 0 || Library.KEY_USER_regcode == rgn_id && Library.KEY_USER_siteid == "nil" || Convert.ToInt32(Library.KEY_USER_siteid) == 0 || Library.KEY_USER_siteid == st_id)
                        {
                            dbConn.Insert(item);
                            // dbhelper.Insert_INTO_Mstr_bed_details(new mstr_bed_details(Convert.ToInt32(row["ID"].ToString()), row["bed_no"].ToString(), Convert.ToInt32(row["ward_id"].ToString()), Convert.ToInt32(row["bedclass_id"].ToString()), Convert.ToInt32(row["status_id"].ToString()), row["site_code"].ToString()));

                        }
                    }
                    dbConn.Commit();
                }
            }
            catch (Exception excp)
            {
            }
        }

        private async static Task Sync_mstr_allergies_master()
        {
            try
            {
                HttpClient httpClient = new System.Net.Http.HttpClient();
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, URL + "/" + Library.METHODE_ALLERGENTDIETLIST + "/" + Library.KEY_USER_ccode);
                HttpResponseMessage response = await httpClient.SendAsync(request);
                // jarray= await response.Content.ReadAsStringAsync();
                List<mstr_allergies_master> jarray = JsonConvert.DeserializeObject<List<mstr_allergies_master>>(await response.Content.ReadAsStringAsync());

                using (var dbConn = DependencyService.Get<IDBInterface>().GetConnection())
                {
                    dbConn.DropTable<mstr_allergies_master>();
                    dbConn.CreateTable<mstr_allergies_master>();
                    dbConn.InsertAll(jarray);
                    dbConn.Commit();
                };
            }
            catch (Exception excp)
            {
            }
        }

        private async static Task Sync_mstr_bed_meal_class_mapping()
        {
            try
            {
                HttpClient httpClient = new System.Net.Http.HttpClient();
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, URL + "/" + Library.METHODE_BEDMEALCLASSMAPPING + "/" + Library.KEY_USER_ccode + "/" + Library.KEY_USER_regcode + "/" + Library.KEY_USER_siteid + "/0");
                HttpResponseMessage response = await httpClient.SendAsync(request);

                List<mstr_bed_meal_class_mapping> jarray = JsonConvert.DeserializeObject<List<mstr_bed_meal_class_mapping>>(await response.Content.ReadAsStringAsync());

                using (var dbConn = DependencyService.Get<IDBInterface>().GetConnection())
                {
                    dbConn.DropTable<mstr_bed_meal_class_mapping>();
                    dbConn.CreateTable<mstr_bed_meal_class_mapping>();

                    foreach (var item in jarray)
                    {
                        string cont_id = item.country_id.ToString();
                        string rgn_id = item.region_id;
                        string st_id = item.site_id.ToString();

                        // Filtering data based on
                        //                    if (country_id1 == cont_id && (region_id1 == nil || region_id1 == 0 || region_id1 == rgn_id) && (site_id1 == nil || site_id1 == 0 || site_id1 == st_id))
                        if (Library.KEY_USER_ccode == cont_id && Library.KEY_USER_regcode == "nil" || Convert.ToInt16(Library.KEY_USER_regcode) == 0 || Library.KEY_USER_regcode == rgn_id && Library.KEY_USER_siteid == "nil" || Convert.ToInt32(Library.KEY_USER_siteid) == 0 || Library.KEY_USER_siteid == st_id)
                        {
                            dbConn.Insert(item);
                            // dbhelper.Insert_INTO_mstr_bed_meal_class_mapping(new mstr_bed_meal_class_mapping(Convert.ToInt32(row["ID"].ToString()), Convert.ToInt32(row["bed_class_id"].ToString()), row["bed_class_Name"].ToString(), Convert.ToInt32(row["meal_class_id"].ToString()), row["meal_class_Name"].ToString(), false, Convert.ToInt32(row["status_id"].ToString()), 1));
                        }
                    }
                    dbConn.Commit();
                };
            }
            catch (Exception excp)
            {
            }
        }

        private async static Task Sync_mstr_mealclass()
        {
            try
            {
                HttpClient httpClient = new System.Net.Http.HttpClient();
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, URL + "/" + Library.METHODE_DISPLAYMEALCLASS + "/" + Library.KEY_USER_ccode + "/" + Library.KEY_USER_regcode + "/" + Library.KEY_USER_siteid + "/0");
                HttpResponseMessage response = await httpClient.SendAsync(request);
                // jarray= await response.Content.ReadAsStringAsync();
                List<mstr_mealclass> jarray = JsonConvert.DeserializeObject<List<mstr_mealclass>>(await response.Content.ReadAsStringAsync());

                using (var dbConn = DependencyService.Get<IDBInterface>().GetConnection())
                {
                    dbConn.DropTable<mstr_mealclass>();
                    dbConn.CreateTable<mstr_mealclass>();

                    foreach (var item in jarray)
                    {
                        string cont_id = item.country_id.ToString();
                        string rgn_id = item.region_id;
                        string st_id = item.site_id.ToString();

                        // Filtering data based on
                        //                    if (country_id1 == cont_id && (region_id1 == nil || region_id1 == 0 || region_id1 == rgn_id) && (site_id1 == nil || site_id1 == 0 || site_id1 == st_id))
                        if (Library.KEY_USER_ccode == cont_id && Library.KEY_USER_regcode == "nil" || Convert.ToInt16(Library.KEY_USER_regcode) == 0 || Library.KEY_USER_regcode == rgn_id && Library.KEY_USER_siteid == "nil" || Convert.ToInt32(Library.KEY_USER_siteid) == 0 || Library.KEY_USER_siteid == st_id)
                            dbConn.Insert(item);
                    }
                    dbConn.Commit();
                }
            }
            catch (Exception excp)
            {
            }
        }
        public async static Task Sync_mstr_menu_item()
        {
            try
            {
                HttpClient httpClient = new System.Net.Http.HttpClient();
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, URL + "/" + Library.METHODE_NENUITEMDETAILS + "/" + Library.KEY_USER_ccode + "/" + Library.KEY_USER_regcode + "/" + Library.KEY_USER_siteid + "/0");
                HttpResponseMessage response = await httpClient.SendAsync(request);
                // jarray= await response.Content.ReadAsStringAsync();
                List<mstr_menu_item> jarray = JsonConvert.DeserializeObject<List<mstr_menu_item>>(await response.Content.ReadAsStringAsync());

                using (var dbConn = DependencyService.Get<IDBInterface>().GetConnection())
                {
                    dbConn.DropTable<mstr_menu_item>();
                    dbConn.CreateTable<mstr_menu_item>();
                    dbConn.BeginTransaction();

                    foreach (var item in jarray)
                    {
                        ///  byte[] toBytes = item.ImageData;
                        string cont_id = item.country_id.ToString();
                        string rgn_id = item.region_id.ToString();
                        string st_id = item.site_id.ToString();

                        // Filtering data based on

                        //                    if (country_id1 == cont_id && (region_id1 == nil || region_id1 == 0 || region_id1 == rgn_id) && (site_id1 == nil || site_id1 == 0 || site_id1 == st_id))
                        if (Library.KEY_USER_ccode == cont_id && Library.KEY_USER_regcode == "nil" || Convert.ToInt16(Library.KEY_USER_regcode) == 0 || Library.KEY_USER_regcode == rgn_id && Library.KEY_USER_siteid == "nil" || Convert.ToInt32(Library.KEY_USER_siteid) == 0 || Library.KEY_USER_siteid == st_id)
                        {
                            // item.ImageData = toBytes;
                            // item.meal_item_name = ss;
                            dbConn.Insert(item);
                            //var byteItems = row["ImageData"].ToString().Split(',').Select(z => byte.Parse(row["ImageData"].ToString()).ToArray();
                            //  dbhelper.Insert_INTO_mstr_menu_item(new mstr_menu_item(Convert.ToInt32(row["ID"].ToString()), row["menu_item_code"].ToString(), row["menu_item_name"].ToString(), row["menu_item_description"].ToString(), Convert.ToInt32(row["meal_type_id"].ToString()), ss, row["menu_image"].ToString(), toBytes, Convert.ToBoolean(row["is_vegitarian"].ToString()), Convert.ToBoolean(row["is_halal"].ToString()), Convert.ToInt32(row["menu_item_category_id"].ToString()), Convert.ToInt32(row["status_id"].ToString()), row["sitecode"].ToString(), row["TH_Code"].ToString(), row["ingredient_name"].ToString(), row["mealTime_names"].ToString(), row["allergies"].ToString(), row["meal_class_name"].ToString(), row["ward_type_name"].ToString(), row["amount"].ToString(), row["is_visitor"].ToString(), row["menu_item_name_local_language"].ToString(), row["meal_type_name"].ToString()));
                        }
                    }
                    dbConn.Commit();
                    // Loading menu items in listview after sync
                    //fillMenu_items();
                    // stop progressring
                    //var message = new MessageDialog(loader.GetString("msg8").ToString());
                    //await message.ShowAsync();
                    //menuvis.Visibility = Visibility.Collapsed;
                    //myring.IsActive = false;
                    //myring.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                };
            }
            catch (Exception excp)
            {
            }
        }
        public async static Task Sync_mstr_menu_master()
        {
            try
            {
                HttpClient httpClient = new System.Net.Http.HttpClient();
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, URL + "/" + Library.METHODE_NENU_MASETER + "/" + Library.KEY_USER_ccode + "/" + Library.KEY_USER_regcode + "/" + Library.KEY_USER_siteid + "/0");
                HttpResponseMessage response = await httpClient.SendAsync(request);
                // jarray= await response.Content.ReadAsStringAsync();
                List<mstr_menu_master> jarray = JsonConvert.DeserializeObject<List<mstr_menu_master>>(await response.Content.ReadAsStringAsync());

                using (var dbConn = DependencyService.Get<IDBInterface>().GetConnection())
                {
                    dbConn.DropTable<mstr_menu_master>();
                    dbConn.CreateTable<mstr_menu_master>();
                    dbConn.BeginTransaction();

                    foreach (var item in jarray)
                    {
                        //  byte[] toBytes = item.ImageData;
                        //var toBytes = (item.ImageData == null ? null : aa.ToObject<byte[]>());
                        string cont_id = item.country_id.ToString();
                        string rgn_id = item.region_id.ToString();
                        string st_id = item.site_id.ToString();

                        // Filtering data based on

                        //                    if (country_id1 == cont_id && (region_id1 == nil || region_id1 == 0 || region_id1 == rgn_id) && (site_id1 == nil || site_id1 == 0 || site_id1 == st_id))
                        if (Library.KEY_USER_ccode == cont_id && Library.KEY_USER_regcode == "nil" || Convert.ToInt16(Library.KEY_USER_regcode) == 0 || Library.KEY_USER_regcode == rgn_id && Library.KEY_USER_siteid == "nil" || Convert.ToInt32(Library.KEY_USER_siteid) == 0 || Library.KEY_USER_siteid == st_id)
                        {
                            dbConn.Insert(item);
                            // dbhelper.Insert_INTO_mstr_menu_master(new mstr_menu_master(Convert.ToInt32(row["ID"].ToString()), row["menu_code"].ToString(), row["menu_name"].ToString(), row["menu_description"].ToString(), Convert.ToInt32(row["meal_class_id"].ToString()), Convert.ToInt32(row["age_id"].ToString()), row["menu_days"].ToString(), Convert.ToBoolean(row["Confinement"].ToString()), Convert.ToInt32(row["diet_id"].ToString()), row["menu_image"].ToString(), toBytes, Convert.ToInt32(row["status_id"].ToString()), row["site_code"].ToString(), "", "", row["menu_time_name"].ToString(), row["MealType"].ToString(), row["menu_item_name"].ToString(), row["wardtypename"].ToString(), row["cycle_ides"].ToString(), row["cycle_name"].ToString(), row["menu_name_local_language"].ToString(), row["menu_item_name_local_language"].ToString()));
                        }
                    }
                    dbConn.Commit();
                    // stop progressring
                    //myring.IsActive = false;
                    //myring.Visibility = Windows.UI.Xaml.Visibility.Collapsed;

                };
            }
            catch (Exception)
            {
            }
        }
    }
}