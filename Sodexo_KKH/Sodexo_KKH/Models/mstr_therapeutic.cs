using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sodexo_KKH.Models
{
    class mstr_therapeutic
    {
        //Creating table
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int UID { get; set; }
        public int ID { get; set; }
       // public int tableid { get; set; }
        public string TH_code { get; set; }
        public string TH_description { get; set; }
        public int status_id { get; set; }
        public string site_code { get; set; }
        public bool required_menu_ref { get; set; }
        
        public mstr_therapeutic()
        {

        }
        //public mstr_therapeutic(int Para1, String Para2, string Para3, int Para4, string Para5, bool Para6)
        //{
        //    tableid = Para1;
        //    TH_code = Para2;
        //    TH_description = Para3;
        //    status_id = Para4;
        //    site_code = Para5;
        //    required_menu_ref = Para6;

        //}


        // Inserting into mstr_therapeutic
        //public void Insert(int Para1, String Para2, string Para3, int Para4, string Para5, bool Para6)
        //{
        //    DatabaseHelperClass Db_Helper = new DatabaseHelperClass();//Creating object for DatabaseHelperClass.cs from ViewModel/DatabaseHelperClass.cs  
        //    try
        //    {
        //        Db_Helper.Insert_INTO_mstr_therapeutic(new mstr_therapeutic(Para1, Para2, Para3, Para4, Para5, Para6));
        //    }
        //    catch (Exception e)
        //    {

        //    }
        //}
    }
}
