namespace Sodexo_KKH.Models
{
    class opt_meal_order
    {
        //Creating table
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int id { get; set; }
        public int patient_id { get; set; }
        public string meal_order_date { get; set; }
        public bool is_care_giver { get; set; }
        public int status_id { get; set; }
        public string site_code { get; set; }


        public opt_meal_order()
        {

        }
        public opt_meal_order(int Para3, string Para4, bool Para5, int Para6, string Para7)
        {
            patient_id = Para3;
            meal_order_date = Para4;
            is_care_giver = Para5;
            status_id = Para6;
            site_code = Para7;

        }
        // Inserting into opt_meal_order
        //public void Insert(int Para3, string Para4, bool Para5, int Para6, string Para7)
        //{
        //    DatabaseHelperClass Db_Helper = new DatabaseHelperClass();//Creating object for DatabaseHelperClass.cs from ViewModel/DatabaseHelperClass.cs  
        //    try
        //    {
        //        Db_Helper.Insert_INTO_opt_meal_order(new opt_meal_order(Para3, Para4, Para5, Para6, Para7));
        //    }
        //    catch (Exception e)
        //    {

        //    }
        //}
    }
}
