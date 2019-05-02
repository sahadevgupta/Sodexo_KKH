using System;
using System.Collections.Generic;
using System.Text;

namespace Sodexo_KKH.Models
{
    class meal_order_status
    {
        public int SrNo { get; set; }
        public string OrderStatus { get; set; }
        public string WardBed { get; set; }
        public string meal_order_date { get; set; }
        public string patient_name { get; set; }

        public meal_order_status()
        {
                
        }
    }
}
