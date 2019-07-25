using System;

namespace Sodexo_KKH.Models
{
    class opt_patient_meal_details
    {
        //Creating table
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int id { get; set; }
        public int patient_id { get; set; }
        public int bed_class_id { get; set; }
        public int bed_id { get; set; }
        public int ward_type_id { get; set; }
        public int ward_id { get; set; }
        public bool is_veg { get; set; }
        public bool is_halal { get; set; }
        public int allergies_id { get; set; }
        public bool is_disposable_tray { get; set; }
        public int BF { get; set; }
        public int LH { get; set; }
        public int DN { get; set; }
        public int status_id { get; set; }
        public String site_code { get; set; }


        public opt_patient_meal_details()
        {

        }
        public opt_patient_meal_details(int Patient_id, int Bed_class_id, int Bed_id, int Ward_type_id, int Ward_id, bool Is_veg, bool Is_halal, int Allergies_id, bool Is_disposable_tray, int bf, int lh, int dn, int Status_id, String Site_code)
        {


            patient_id = Patient_id;
            bed_class_id = Bed_class_id;
            bed_id = Bed_id;
            ward_type_id = Ward_type_id;
            ward_id = Ward_id;
            is_veg = Is_veg;
            is_halal = Is_halal;
            allergies_id = Allergies_id;
            is_disposable_tray = Is_disposable_tray;
            BF = bf;
            LH = lh;
            DN = dn;
            status_id = Status_id;
            site_code = Site_code;


        }
        // Inserting into opt_patient_meal_details
        //public void Insert(int Patient_id, int Bed_class_id, int Bed_id, int Ward_type_id, int Ward_id, bool Is_veg, bool Is_halal, int Allergies_id, bool Is_disposable_tray, int bf, int lh, int dn, int Status_id, String Site_code)
        //{
        //    DatabaseHelperClass Db_Helper = new DatabaseHelperClass();//Creating object for DatabaseHelperClass.cs from ViewModel/DatabaseHelperClass.cs  
        //    try
        //    {
        //        Db_Helper.Insert_INTO_opt_patient_meal_details(new opt_patient_meal_details(Patient_id, Bed_class_id, Bed_id, Ward_type_id, Ward_id, Is_veg, Is_halal, Allergies_id, Is_disposable_tray,bf,lh,dn, Status_id, Site_code));
        //    }
        //    catch (Exception e)
        //    {

        //    }
        //}
    }
}
