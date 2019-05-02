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
        public int ID { get; set; }
       // public int tableid { get; set; }
        public string menu_item_code { get; set; }
        public string menu_item_name { get; set; }
        public string menu_item_description { get; set; }
        public int meal_type_id { get; set; }
        public string meal_item_name { get; set; }
        public string menu_image { get; set; }
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
        public string meal_type_name { get; set; }
        public int country_id { get; set; }
        public int region_id { get; set; }
        public int site_id { get; set; }
      public string Therapeutic_ids { get; set; }

        public string diet_texture_ids { get; set; }
        public string texture_names { get; set; }

        //  public byte[] ImageData { get; set; }
        //    public int ID { get; set; }

        public mstr_menu_item()
        {

        }
        //public mstr_menu_item(int Para1, string Para2, string Para3, string Para4, int Para5, string Para6, string Para7, byte[] Para8, bool Para9, bool Para10, int Para11, int Para12, string Para13, string Para14, string Para15, string Para16,string Para17,string Para18,string Para19, string Para20, string Para21,string Para22,string Para23)
        //{
        //    tableid = Para1;
        //    menu_item_code = Para2;
        //    menu_item_name = Para3;
        //    menu_item_description = Para4;
        //    meal_type_id = Para5;
        //    meal_item_name = Para6;
        //    menu_image = Para7;
        //    Item_Image = Para8;
        //    is_vegitarian = Para9;
        //    is_halal = Para10;
        //    menu_item_category_id = Para11;
        //    status_id = Para12;
        //    site_code = Para13;
        //    TH_Code = Para14;
        //    ingredient_name = Para15;
        //    meal_time_name = Para16;
        //    allergies = Para17;
        //    meal_class_name = Para18;
        //    ward_type_name = Para19;
        //    amount = Para20;
        //    is_visitor = Para21;
        //    meal_item_name_loc = Para22;
        //    meal_type_name = Para23;
        //}

        // Inserting into mstr_menu_item
        //public void Insert(int Para1, string Para2, string Para3, string Para4, int Para5, string Para6, string Para7, byte[] Para8, bool Para9, bool Para10, int Para11, int Para12, string Para13, string Para14, string Para15, string Para16,string Para17, string Para18, string Para19,string Para20,string Para21,string Para22,string Para23)
        //{
        //    DatabaseHelperClass Db_Helper = new DatabaseHelperClass();//Creating object for DatabaseHelperClass.cs from ViewModel/DatabaseHelperClass.cs  
        //    try
        //    {
        //        Db_Helper.Insert_INTO_mstr_menu_item(new mstr_menu_item(Para1, Para2, Para3, Para4, Para5, Para6, Para7, Para8, Para9, Para10, Para11,Para12, Para13, Para14, Para15, Para16,Para17,Para18,Para19,Para20,Para21,Para22,Para23));
        //    }
        //    catch (Exception e)
        //    {

        //    }

        //}
    }
}
