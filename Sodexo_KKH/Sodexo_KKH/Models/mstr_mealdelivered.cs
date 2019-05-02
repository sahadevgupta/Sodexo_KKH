using System;
using System.Collections.Generic;
using System.Text;

namespace Sodexo_KKH.Models
{
    class mstr_mealdelivered
    {

        public int OrderedID { get; set; }
        public String date { get; set; }
        public String Ward { get; set; }
        public String Bed { get; set; }
        public String Name { get; set; }
        public String MealTime { get; set; }
        public String OrderBy { get; set; }
        public String Guest { get; set; }
        public String pateint_id { get; set; }
        public Boolean is_verifed { get; set; }
        public String status { get; set; }
        public Boolean is_checked { get; set; }
        public Boolean istrue { get; set; }
        public mstr_mealdelivered()
        {
        }


    }
}
