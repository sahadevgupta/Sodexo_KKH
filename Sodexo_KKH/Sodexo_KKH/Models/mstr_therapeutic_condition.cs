using System;
using System.Collections.Generic;
using System.Text;

namespace Sodexo_KKH.Models
{
    public class mstr_therapeutic_condition
    {
        //Creating table
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int UID { get; set; }
        public int ID { get; set; }
        // public int tableid { get; set; }
        public string TH_Conditions { get; set; }
        public string StdRem { get; set; }
        public string OptRem { get; set; }
        public string role { get; set; }
        public string selectedTherapeuticCodes { get; set; }
        public string selectedTherapeuticIDs { get; set; }
        public string site_ids { get; set; }

        //...................................
        public int status_id { get; set; }
        public int site_id { get; set; }
        public string site { get; set; }
        public string site_code { get; set; }
        public int CreatedBy { get; set; }
        public int OptRemID { get; set; }
        public int country_id { get; set; }
        public int region_id { get; set; }

        public mstr_therapeutic_condition()
        {

        }
    }
}
