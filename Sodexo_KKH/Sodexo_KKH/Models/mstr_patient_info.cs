using Newtonsoft.Json;
using Prism.Mvvm;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sodexo_KKH.Models
{
    public class mstr_patient_info : BindableBase
    {
        //Creating table
        [SQLite.PrimaryKey, SQLite.AutoIncrement]


        public int UID { get; set; }

        public string Allergies { get; set; }
        public string BF { get; set; }
        public string bed_name { get; set; }
        public int bed_no { get; set; }
        public string DN { get; set; }
        public string admission_date { get; set; }
        public int ID { get; set; }
        public string gender { get; set; }
      //  public int tableid { get; set; }//P_Id
        public string LH { get; set; }
        public string ModifiedDate { get; set; }
        public string Patientname { get; set; }
        public string patientname_dup { get; set; }
        public string patient_race { get; set; }
        public string category { get; set; }



        private bool _is_halal;

        public bool is_halal
        {
            get { return this._is_halal; }
            set { SetProperty(ref _is_halal, value); }
        }




        private string _ishalal_tab;

        public string ishalal_tab
        {
            get { return this._ishalal_tab; }
            set { SetProperty(ref _ishalal_tab, value); }
        }



        private string _isveg_tab;

        public string isveg_tab
        {
            get { return this._isveg_tab; }
            set { SetProperty(ref _isveg_tab, value); }
        }

        private bool _is_veg;

        public bool is_veg
        {
            get { return this._is_veg; }
            set { SetProperty(ref _is_veg, value); }
        }
        public string ward_name { get; set; }
        public int ward_no { get; set; }
        public string ward_bed { get; set; }
        public string meal_order_date { get; set; }
        public string Last_Order_by { get; set; }

        public string wardtypename { get; set; }

        public string Religion { get; set; }
        public string Birthdate { get; set; }

      
        public string Preferredserver { get; set; }

        public string sequenceno { get; set; }

        public string Therapeutic { get; set; }


        private string _fluidInfo;

        public string FluidInfo
        {
            get { return this._fluidInfo; }
            set { SetProperty(ref _fluidInfo, value); }
        }
        public string Ingredient { get; set; }


        public int meal_order_id { get; set; }

        public string is_care_giver { get; set; }
        public string caregiverno { get; set; }

        public string is_diabetic { get; set; }

        public string Bed_Class_Name { get; set; }

        public string Patient_Age { get; set; }
        public string Age_Name { get; set; }
        public string Discharge_Date { get; set; }
        public string NRIC { get; set; }
        public string Bed_ID { get; set; }
        public string Bed_Class_ID { get; set; }
        public string Age_ID { get; set; }
        public string Doctorcomment { get; set; }
       public string Generalcomment { get; set; }

        public string Ward_ID { get; set; }

        public string Site_Code { get; set; }


        private string _ishalal;

        public string ishalal
        {
            get { return this._ishalal; }
            set { SetProperty(ref _ishalal, value); }
        }

        private string _isveg;

        public string isveg
        {
            get { return this._isveg; }
            set { SetProperty(ref _isveg, value); }
        }
        [JsonProperty("Therapeutic_Condition")]
        public string Therapeutic_Condition { get; set; }
       
        [JsonProperty("Diet_Texture")]
        public string Diet_Texture { get; set; }

        [JsonProperty("Meal_Type")]
        public string Meal_Type { get; set; }

        //public mstr_patient_info(string Para1, string Para2, string Para3, int Para4, string Para5, string Para6, string Para7, int Para8, string Para9, string Para10, string Para11, string Para12, string Para13, string Para14, bool Para15, bool Para16, string Para17, int Para18, string Para19, string Para20, string Para21,string Para22,string Para23,string Para24,string Para25,string Para26, string Para27, int Para28,string Para29,string Para30)
        //{

        //    Allergies = Para1;
        //    BF = Para2;
        //    bed_name = Para3;
        //    bed_no = Para4;
        //    DN = Para5;
        //    admission_date = Para6;
        //    gender = Para7;
        //    tableid = Para8;
        //    LH = Para9;
        //    ModifiedDate = Para10;
        //    Patientname = Para11;
        //    patientname_dup = Para12;
        //    patient_race = Para13;
        //    category = Para14;
        //    is_halal = Para15;
        //    is_veg = Para16;
        //    ward_name = Para17;
        //    ward_no = Para18;
        //    ward_bed = Para19;
        //    meal_order_date = Para20;
        //    Last_Order_by = Para21;
        //    wardtypename = Para22;
        //    Religion = Para23;
        //    Birthdate = Para24;
        //    Preferredserver = Para25;
        //    sequenceno = Para26;
        //    Therapeutic = Para27;
        //    meal_order_id = Para28;
        //    is_care_giver = Para29;
        //    is_diabetic = Para30;
        //}
        //Inserting into mstr_patient
        //public void Insert(string Para1, string Para2, string Para3, int Para4, string Para5, string Para6, string Para7, int Para8, string Para9, string Para10, string Para11, string Para12, string Para13, string Para14, bool Para15, bool Para16, string Para17, int Para18, string Para19, string Para20, string Para21,string Para22,string Para23,string Para24,string Para25,string Para26,string Para27,int Para28,string Para29,string Para30)
        //{
        //    DatabaseHelperClass Db_Helper = new DatabaseHelperClass();//Creating object for DatabaseHelperClass.cs from ViewModel/DatabaseHelperClass.cs  
        //    try
        //    {
        //        Db_Helper.Insert_INTO_mstr_patient_info(new mstr_patient_info(Para1, Para2, Para3, Para4, Para5, Para6, Para7, Para8, Para9, Para10, Para11, Para12, Para13, Para14, Para15, Para16, Para17, Para18, Para19, Para20,Para21,Para22,Para23,Para24,Para25,Para26,Para27,Para28,Para29,Para30));
        //    }
        //    catch (Exception e)
        //    {

        //    }
        //}
    }
}
