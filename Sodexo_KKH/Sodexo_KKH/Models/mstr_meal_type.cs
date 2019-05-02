using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sodexo_KKH.Models
{
    class mstr_meal_type
    {
        //Creating table
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int UID { get; set; }
        public int ID { get; set; }
        public int tableid { get; set; }
        public string meal_type_code { get; set; }
        public string meal_type_name { get; set; }
        public string meal_type_description { get; set; }
        public int status_id { get; set; }
        public string site_code { get; set; }



        public mstr_meal_type()
        {

        }
        public mstr_meal_type(int Para1, string Para2, string Para3, string Para4, int Para5, string Para6)
        {
            tableid = Para1;
            meal_type_code = Para2;
            meal_type_name = Para3;
            meal_type_description = Para4;
            status_id = Para5;
            site_code = Para6;


        }

        // Inserting into mstr_meal_option
        //public void Insert(int Para1, string Para2, string Para3, string Para4, int Para5, string Para6)
        //{
        //    DatabaseHelperClass Db_Helper = new DatabaseHelperClass();//Creating object for DatabaseHelperClass.cs from ViewModel/DatabaseHelperClass.cs  
        //    try
        //    {
        //        Db_Helper.Insert_INTO_mstr_meal_type(new mstr_meal_type(Para1, Para2, Para3, Para4, Para5, Para6));
        //    }
        //    catch (Exception e)
        //    {

        //    }

        //}
    }
}
