using System;
using System.Collections.Generic;
using System.Text;

namespace Sodexo_KKH.Models
{
    class mstr_diet_texture
    {
        //Creating table
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int UID { get; set; }
        public int ID { get; set; }
        //    public int tableid { get; set; }
        public string diet_texture_name { get; set; }
        public string diet_texture_description { get; set; }
        public int status_id { get; set; }
        public string site_code { get; set; }



        public mstr_diet_texture()
        {

        }
    }
}
