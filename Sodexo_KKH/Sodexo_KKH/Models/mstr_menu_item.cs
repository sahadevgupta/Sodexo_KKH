using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Sodexo_KKH.Models
{
    class mstr_menu_item
    {
       

        //Creating table
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int UID { get; set; }
        [JsonProperty("ID")]
        public int ID { get; set; }
       // public int tableid { get; set; }
        public string menu_item_code { get; set; }
        public string menu_item_name { get; set; }
        public string menu_item_description { get; set; }
        public int meal_type_id { get; set; }
        public string meal_item_name { get; set; }
        public string menu_image { get; set; }
        [JsonProperty("ImageData")]
        public byte[] ImageData { get; set; }
        public bool is_vegitarian { get; set; }
        public bool is_halal { get; set; }
        public int menu_item_category_id { get; set; }
        public int status_id { get; set; }
        public string site_code { get; set; }
        public string TH_Code { get; set; }
        public string ingredient_name { get; set; }
        public string mealTime_names { get; set; }
        public string mealTime_ids { get; set; }

        public string allergies { get; set; }
        public string meal_class_name { get; set; }
        public string ward_type_name { get; set; }

        public string amount { get; set; }

        public string is_visitor { get; set; }  
        public string menu_item_name_local_language { get; set; }

        public string btnname { get; set; }
        public string  btncolor { get; set; }
        [JsonProperty("meal_type_name")]
        public string meal_type_name { get; set; }
        public int country_id { get; set; }
        public int region_id { get; set; }
        public int site_id { get; set; }
      public string Therapeutic_ids { get; set; }

        public string diet_texture_ids { get; set; }
        public string texture_names { get; set; }
        [JsonProperty("is_fullfeeds")]
        public bool is_fullfeeds { get; set; }
        [JsonProperty("is_clearfeeds")]
        public bool is_clearfeeds { get; set; }
        [JsonProperty("is_TA")]
        public bool is_TA { get; set; }

        [JsonProperty("is_InfantDiet")]
        public bool is_InfantDiet { get; set; }

        
        [JsonProperty("meal_type_ids")]
        public string meal_type_ids { get; set; }
       
    }
}
