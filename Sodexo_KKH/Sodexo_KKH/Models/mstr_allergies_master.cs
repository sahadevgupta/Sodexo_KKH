﻿using Newtonsoft.Json;
using Prism.Mvvm;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sodexo_KKH.Models
{
    public class mstr_allergies_master : BindableBase
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


        private bool _isChecked;
        [Ignore]
        [JsonIgnore]
        public bool IsChecked
        {
            get { return this._isChecked; }
            set { SetProperty(ref _isChecked, value); }
        }



    }
}
