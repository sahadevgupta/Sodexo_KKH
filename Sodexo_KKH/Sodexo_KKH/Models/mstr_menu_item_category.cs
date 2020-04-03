using Newtonsoft.Json;
using Prism.Mvvm;
using SQLite;

namespace Sodexo_KKH.Models
{
    public class mstr_menu_item_category : BindableBase
    {
        //Creating table
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int UID { get; set; }
        public int ID { get; set; }
        //  public int tableid { get; set; }
        public string meal_item_name { get; set; }
        public string meal_item_description { get; set; }
        public int status_id { get; set; }
        public string sitecode { get; set; }
        public string country_id { get; set; }
        public string imgname { get; set; }
        public string selimgname { get; set; }
        public string fcolor { get; set; }
        public string selcolor { get; set; }


        private bool _categoryVisibility;
        [Ignore]
        [JsonIgnore]
        public bool CategoryVisibility
        {
            get { return this._categoryVisibility; }
            set { SetProperty(ref _categoryVisibility, value); }
        }

        private bool _isSelected;
        [Ignore]
        [JsonIgnore]
        public bool isSelected
        {
            get { return this._isSelected; }
            set { SetProperty(ref _isSelected, value); }
        }
    }
}
