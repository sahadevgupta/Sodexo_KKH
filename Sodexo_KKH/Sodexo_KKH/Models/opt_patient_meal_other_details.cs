using System;

namespace Sodexo_KKH.Models
{
    class opt_patient_meal_other_details
    {
        //Creating table
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int id { get; set; }
        public int patient_id { get; set; }
        public int other_id { get; set; }
        public int status_id { get; set; }
        public String site_code { get; set; }


        public opt_patient_meal_other_details()
        {

        }
        public opt_patient_meal_other_details(int Patient_id, int Other_id, int Status_id, String Site_code)
        {

            patient_id = Patient_id;
            other_id = Other_id;
            status_id = Status_id;
            site_code = Site_code;


        }
        // Inserting into opt_patient_meal_order_details
        //public void Insert(int Patient_id, int Other_id, int Status_id, String Site_code)
        //{
        //    DatabaseHelperClass Db_Helper = new DatabaseHelperClass();//Creating object for DatabaseHelperClass.cs from ViewModel/DatabaseHelperClass.cs  
        //    try
        //    {
        //        Db_Helper.Insert_INTO_opt_patient_meal_other_details(new opt_patient_meal_other_details(Patient_id, Other_id, Status_id, Site_code));
        //    }
        //    catch (Exception e)
        //    {

        //    }
        //}
    }
}
