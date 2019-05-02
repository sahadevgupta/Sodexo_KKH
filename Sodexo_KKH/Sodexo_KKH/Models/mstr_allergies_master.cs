using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sodexo_KKH.Models
{
    class mstr_allergies_master
    {
        //Creating table
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int UID { get; set; }
        public int ID { get; set; }
     //   public int tableid { get; set; }
        public string allergies_name { get; set; }
        public string allergies_code { get; set; }
        public string allergies_description { get; set; }
        public int status_id { get; set; }
        public string site_code { get; set; }



        public mstr_allergies_master()
        {

        }
        //public mstr_allergies_master(int Para1, string Para2, string Para3, string Para4, int Para5, string Para6)
        //{
        //    tableid = Para1;
        //    allergies_name = Para2;
        //    allergies_code = Para3;
        //    allergies_description = Para4;
        //    status_id = Para5;
        //    site_code = Para6;


        //}

        // Inserting into mstr_allergies_master
        //public void Insert(int Para1, string Para2, string Para3, string Para4, int Para5, string Para6)
        //{
        //    DatabaseHelperClass Db_Helper = new DatabaseHelperClass();//Creating object for DatabaseHelperClass.cs from ViewModel/DatabaseHelperClass.cs  
        //    try
        //    {
        //        Db_Helper.Insert_INTO_mstr_allergies_master(new mstr_allergies_master(Para1, Para2, Para3, Para4, Para5, Para6));
        //    }
        //    catch (Exception e)
        //    {

        //    }

        //}
    }
    }
