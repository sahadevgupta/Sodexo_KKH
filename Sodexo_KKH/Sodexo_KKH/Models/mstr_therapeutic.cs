using Newtonsoft.Json;
using Prism.Mvvm;
using SQLite;

namespace Sodexo_KKH.Models
{
    public class mstr_therapeutic : BindableBase
    {
        //Creating table
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int UID { get; set; }
        [JsonProperty("ID")]
        public int ID { get; set; }
        // public int tableid { get; set; }
        [JsonProperty("TH_Code")]
        public string TH_code { get; set; }
        [JsonProperty("Description")]
        public string TH_description { get; set; }
        [JsonProperty("status_id")]
        public int status_id { get; set; }
        [JsonProperty("sitecode")]
        public string site_code { get; set; }
        public bool required_menu_ref { get; set; }
        [JsonProperty("THCondition")]
        public string TH_Condition { get; set; }

        private bool _isChecked;
        [Ignore]
        [JsonIgnore]
        public bool IsChecked
        {
            get { return this._isChecked; }
            set { SetProperty(ref _isChecked, value); }
        }

    }
}
