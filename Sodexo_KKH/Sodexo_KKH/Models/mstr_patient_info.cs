using Newtonsoft.Json;
using Prism.Mvvm;

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

        private bool _ishalal_tab;

        public bool ishalal_tab
        {
            get { return this._ishalal_tab; }
            set { SetProperty(ref _ishalal_tab, value); }
        }

        private bool _isveg_tab;

        public bool isveg_tab
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

        public bool is_care_giver { get; set; }
        public string caregiverno { get; set; }

        public bool is_diabetic { get; set; }

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


        private bool _ishalal;
        public bool ishalal
        {
            get { return this._ishalal; }
            set { SetProperty(ref _ishalal, value); }
        }

        private bool _isveg;

        public bool isveg
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
        
    }
}
