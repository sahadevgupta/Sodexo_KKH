using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Sodexo_KKH.Models
{
    class mstr_menu_master
    {
        //Creating table
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int UID { get; set; }
        public int ID { get; set; }
      //  public int tableid { get; set; }
        public string menu_code { get; set; }
        public string menu_name { get; set; }
     
        public string menu_description { get; set; }
        public int meal_class_id { get; set; }
        public string meal_class_ids { get; set; }
        public int age_id { get; set; }
        public string menu_days { get; set; }
        //...................................
        public bool Confinement { get; set; }
        public int diet_id { get; set; }
        public string menu_image { get; set; }
        public byte[] ImageData { get; set; }
        public int status_id { get; set; }
        public string site_code { get; set; }
        public string TH_Code { get; set; }
        public string ingredient_name { get; set; }
        public string menu_time_name { get; set; }
        public string menu_time_ids { get; set; }
        public string MealType { get; set; }
        public string menu_item_name { get; set; }
        public string cycle_ides { get; set; }
        public string menu_item_ides { get; set; }
        public string cycle_name { get; set; }

        public string wardtypename { get; set; }


        public string menu_name_local_language { get; set; }

        public string menu_item_name_local_language { get; set; }

        public string btnname { get; set; }

        public string btncolor { get; set; }
        public int country_id { get; set; }
        public int region_id { get; set; }
        public int site_id { get; set; }

        //   public byte[] ImageData { get;  set; }

        // public int ID { get; set; }

        //public string MealType { get; set; }

        public bool is_veg{ get; set; }
        public bool is_halal{ get; set; }


        public mstr_menu_master()
        {

        }
        //public mstr_menu_master(int Para1, string Para2, string Para3, string Para4, int Para5, int Para6, string Para7, bool Para8, int Para9, string Para10,byte[] Para11, int Para12, string Para13, string Para14, string Para15, string Para16, string Para17,string Para18,string Para19,string Para20,string Para21,string Para22,string Para23)
        //{
        //    tableid = Para1;
        //    menu_code = Para2;
        //    menu_name = Para3;
        //    menu_item_description = Para4;
        //    meal_class_id = Para5;
        //    age_id = Para6;
        //    menu_days = Para7;
        //    Confinement = Para8;
        //    diet_id = Para9;
        //    menu_image = Para10;
        //    Item_Image = Para11;
        //    status_id = Para12;
        //    site_code = Para13;
        //    TH_Code = Para14;
        //    ingredient_name = Para15;
        //    meal_time_name = Para16;
        //    MealType = Para17;
        //    menu_item_name = Para18;
        //    ward_type = Para19;
        //    cycle_ides = Para20;
        //    cycle_name = Para21;
        //    menu_name_local_language = Para22;
        //    menu_item_name_local_language = Para23;
        //}

        // Inserting into mstr_menu_master
        //public void Insert(int Para1, string Para2, string Para3, string Para4, int Para5, int Para6, string Para7, bool Para8, int Para9, string Para10,byte[] Para11, int Para12, string Para13, string Para14, string Para15, string Para16,string Para17,String Para18,string Para19,string Para20,string Para21,string Para22,string Para23)
        //{
        //    DatabaseHelperClass Db_Helper = new DatabaseHelperClass();//Creating object for DatabaseHelperClass.cs from ViewModel/DatabaseHelperClass.cs  
        //    try
        //    {
        //        Db_Helper.Insert_INTO_mstr_menu_master(new mstr_menu_master(Para1, Para2, Para3, Para4, Para5, Para6, Para7, Para8, Para9, Para10, Para11, Para12, Para13, Para14, Para15, Para16,Para17,Para18,Para19,Para20,Para21, Para22, Para23));
        //    }
        //    catch (Exception e)
        //    {

        //    }
        //}
    }
}
