using System;

namespace Sodexo_KKH.Models
{
    class opt_meal_order_details
    {
        //Creating table
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int id { get; set; }
        public int meal_time_id { get; set; }
        public int meal_type_id { get; set; }
        public int meal_option_id { get; set; }
        public int meal_menu_juice_item_id { get; set; }
        public int meal_diet_id { get; set; }
        public int meal_entree_id { get; set; }
        public int meal_beverage_id { get; set; }
        public int meal_desert_id { get; set; }
        public int remark_id { get; set; }
        public String meal_remark { get; set; }
        public int status_id { get; set; }
        public String site_code { get; set; }


        public opt_meal_order_details()
        {

        }
        public opt_meal_order_details(int P1, int P2, int P3, int P4, int P5, int P6, int P7, int P8, int P9, String Remark, int Status_id, String Site_code)
        {

            meal_time_id = P1;
            meal_type_id = P2;
            meal_option_id = P3;
            meal_menu_juice_item_id = P4;
            meal_diet_id = P5;
            meal_entree_id = P6;
            meal_beverage_id = P7;
            meal_desert_id = P8;
            remark_id = P9;
            meal_remark = Remark;
            status_id = Status_id;
            site_code = Site_code;


        }
        // Inserting into opt_meal_order_details
        //public void Insert(int P1, int P2, int P3, int P4, int P5, int P6, int P7, int P8, int P9, String Remark, int Status_id, String Site_code)
        //{
        //    DatabaseHelperClass Db_Helper = new DatabaseHelperClass();//Creating object for DatabaseHelperClass.cs from ViewModel/DatabaseHelperClass.cs  
        //    try
        //    {
        //        Db_Helper.Insert_INTO_opt_meal_order_details(new opt_meal_order_details(P1, P2, P3, P4, P5, P6, P7, P8, P9, Remark, Status_id, Site_code));
        //    }
        //    catch (Exception e)
        //    {

        //    }
        //}
    }
}
