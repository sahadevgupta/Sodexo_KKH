using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sodexo_KKH.Models
{
    public class meal_delivery_status
    {
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int id { get; set; }
        public string date { get; set; }
        public string Ward { get; set; }

        public string Bed { get; set; }
        public string PatientNRIC { get; set; }

        public string MealTime { get; set; }
        public string OrderBy { get; set; }
        public string pateint_id { get; set; }
        public string orderedID { get; set; }
       
        public string is_verifed { get; set; }

        public string iscaregiver { get; set; }
        public string status { get; set; }

        public meal_delivery_status()
        {

        }


        //public meal_delivery_status(string Para1, string Para2, string Para3, string Para4, string Para5, string Para6,string Para7,string Para8,string Para9,string Para10,string Para11)
        //{
        //    date = Para1;
        //    Ward = Para2;
        //    Bed = Para3;
        //    PatientNRIC = Para4;
        //    MealTime = Para5;
        //    OrderBy = Para6;
        //    pateint_id = Para7;
        //    orderedID = Para8;
        //    is_verifed = Para9;
        //    iscaregiver = Para10;
        //    status = Para11;
           
        //}
    }


    public class menuitems
    {
       
        public int ID { get; set; }
        public string ImageData { get; set; }
        public string menu_item_name { get; set; }

        public string menu_item_description { get; set; }
        public string btncolor { get; set; }
    }


    public class mstr_caregiver_mealorder_details
    {
        public string menu_item_name { get; set; }
        public double amount { get; set; }
        public int mode_of_payment { get; set; }
        public string paymentmodename { get; set; }

        public mstr_caregiver_mealorder_details()
        {

        }
    }

    class mstr_payment_mode
    {
        //Creating table
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int UID { get; set; }
        public int ID { get; set; }
        public string payment_mode_name { get; set; }
        public bool status_id { get; set; }

        public mstr_payment_mode()
        {

        }
    }
}