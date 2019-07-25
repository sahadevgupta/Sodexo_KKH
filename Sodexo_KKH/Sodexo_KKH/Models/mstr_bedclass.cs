namespace Sodexo_KKH.Models
{
    public class mstr_bedclass
    {
        //Creating table
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int id { get; set; }
        public int tableid { get; set; }
        public string bedclass_name { get; set; }
        public string bedclass_description { get; set; }
        public int status_id { get; set; }
        public string site_code { get; set; }

        public mstr_bedclass()
        {

        }

        public mstr_bedclass(int Para1, string Para2, string Para3, int Para4, string Para5)
        {
            tableid = Para1;
            bedclass_name = Para2;
            bedclass_description = Para3;
            status_id = Para4;
            site_code = Para5;
        }
    }




    public class mstr_DisplayPaymentModeDetails
    {
        //Creating table
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int UID { get; set; }
        public int ID { get; set; }
        //  public int tableid { get; set; }
        public string payment_mode_name { get; set; }

        public bool status_id { get; set; }


        public mstr_DisplayPaymentModeDetails()
        {

        }

        //public mstr_DisplayPaymentModeDetails(int Para2, string Para3,  bool Para5)
        //{
        //    tableid = Para2;
        //    payment_mode_name = Para3;
        //    status_id = Para5;

        //}
    }




    class mstr_DisplayLanguageDetails
    {
        //Creating table
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int UID { get; set; }
        public int ID { get; set; }
        //  public int tableid { get; set; }
        public byte[] country_flag { get; set; }

        public int country_id { get; set; }
        public string country_name { get; set; }
        public string language_name { get; set; }
        public bool status_id { get; set; }

        public mstr_DisplayLanguageDetails()
        {

        }

        //public mstr_DisplayLanguageDetails(int Para2, byte[] Para3, int Para5,string P1,string lname,bool stid)
        //{
        //    tableid = Para2;
        //    country_flag = Para3;
        //    country_id = Para5;
        //    country_name = P1;
        //    language_name = lname;
        //    status_id = stid;


        //}
    }
}
