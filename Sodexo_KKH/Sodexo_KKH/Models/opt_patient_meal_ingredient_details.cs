using System;

namespace Sodexo_KKH.Models
{
    class opt_patient_meal_ingredient_details
    {
        //Creating table
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int id { get; set; }
        public int patient_id { get; set; }
        public int ingredient_id { get; set; }
        public int status_id { get; set; }
        public String site_code { get; set; }


        public opt_patient_meal_ingredient_details()
        {

        }
        public opt_patient_meal_ingredient_details(int Patient_id, int Ingredient_id, int Status_id, String Site_code)
        {
            patient_id = Patient_id;
            ingredient_id = Ingredient_id;
            status_id = Status_id;
            site_code = Site_code;


        }
        // Inserting into opt_patient_meal_ingredient_details
        //public void Insert(int Patient_id, int Ingredient_id, int Status_id, String Site_code)
        //{
        //    DatabaseHelperClass Db_Helper = new DatabaseHelperClass();//Creating object for DatabaseHelperClass.cs from ViewModel/DatabaseHelperClass.cs  
        //    try
        //    {
        //        Db_Helper.Insert_INTO_opt_patient_meal_ingredient_details(new opt_patient_meal_ingredient_details(Patient_id, Ingredient_id, Status_id, Site_code));
        //    }
        //    catch (Exception e)
        //    {

        //    }
        //}
    }
}
