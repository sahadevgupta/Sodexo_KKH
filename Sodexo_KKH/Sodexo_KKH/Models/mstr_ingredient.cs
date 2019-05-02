using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sodexo_KKH.Models
{
    class mstr_ingredient
    {
        //Creating table
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int UID { get; set; }
        public int ID { get; set; }
     //   public int tableid { get; set; }
        public string ingredient_name { get; set; }
        public string ingredient_description { get; set; }
        public int status_id { get; set; }
        public string site_code { get; set; }



        public mstr_ingredient()
        {

        }
        //public mstr_ingredient(int Para1, string Para2, string Para3, int Para4, string Para5)
        //{
        //    tableid = Para1;
        //    ingredient_name = Para2;
        //    ingredient_description = Para3;
        //    status_id = Para4;
        //    site_code = Para5;


        //}

        // Inserting into mstr_ingredient
        //public void Insert(int Para1, string Para2, string Para3, int Para4, string Para5)
        //{
        //    DatabaseHelperClass Db_Helper = new DatabaseHelperClass();//Creating object for DatabaseHelperClass.cs from ViewModel/DatabaseHelperClass.cs  
        //    try
        //    {
        //        Db_Helper.Insert_INTO_mstr_ingredient(new mstr_ingredient(Para1, Para2, Para3, Para4, Para5));
        //    }
        //    catch (Exception e)
        //    {

        //    }

        //}
    }
}
