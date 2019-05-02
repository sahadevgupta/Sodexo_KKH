using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sodexo_KKH.Models
{
    class mstr_meal_order_local
    {

        //Creating table
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int autoid { get; set; }

        public int age_id { get; set; }
        public int ward_id { get; set; }
        public int ward_type_id { get; set; }//optional
        public int bed_id { get; set; }
        public int allergies_id { get; set; }
        public Boolean is_vegitarian { get; set; }
        public Boolean is_halal { get; set; }
        public Boolean disposable_tray { get; set; }
        public int order_id { get; set; }
        public string order_date { get; set; }
        public string order_no { get; set; }
        public Boolean is_care_giver { get; set; }
        public string site_code { get; set; }
        public int createdby { get; set; }
        public int P_id { get; set; }//patient_table_id
        public int BF { get; set; }//breakfast place order=1, NBM=3,deliverd=2
        public int LH { get; set; }//lunch  place order=1, NBM=3,deliverd=2
        public int DN { get; set; } //dinner  place order=1, NBM=3,deliverd=2
        public string Therapeutic_ids { get; set; }
        public string ingredeint_ids { get; set; }
        public string other_ids { get; set; }
        public int meal_time_id { get; set; }
        public int meal_type_id { get; set; }
        public int meal_soup_id { get; set; }
        public int meal_option_id { get; set; }
        public int meal_menu_juice_item_id { get; set; }
        public int meal_diet_id { get; set; }
        public int meal_entree_id { get; set; }
        public int meal_beverage_id { get; set; }
        public int meal_desert_id { get; set; }
        public int remark_id { get; set; }
        public string meal_remark { get; set; }
        
        public int ID { get; set; }
        public string adult_child { get; set; }
        public int bedclass_id { get; set; }//optional
        public string bedclass_name { get; set; }
        public string doctor_comment { get; set; }
        public string general_comment { get; set; }
        public string patient_age { get; set; }
        public int patient_id { get; set; }
        public string patient_name { get; set; }
        public string patient_race { get; set; }
        public string preferred_server { get; set; }
        public string ward_bed { get; set; }

        public bool isdietician { get; set; }
        public bool is_staff { get; set; }
        public string staff_name { get; set; }
        public string dietician_comment { get; set; }
        public int Is_Late_Ordered { get; set; }

        public string role { get; set; }
        public string orderstatus { get; set; }


        public int mode_of_payment { get; set; }
        public string payment_remark { get; set; }



        public string Diet_Texture { get; set; }
        public string Fluid_Consistency { get; set; }
        public string allergies_ids { get; set; }
        public int caregiverentree { get; set; }
        public string caregiverlist { get; set; }
        public int fluid { get; set; }
        public int meal_class_id { get; set; }
        public int role_Id { get; set; }
        public int therapeutic_condition_id { get; set; }
        public int therapeutic_id { get; set; }
        public string system_module { get; set; }
        public string work_station_IP { get; set; }
    

       


        public mstr_meal_order_local()
        {

        }
        public mstr_meal_order_local(int Para1, int Para2, int Para3, int Para4, int Para5, bool Para6, bool Para7, bool Para8, int Para9, string Para10, string Para11, bool Para12, string Para13, int Para14, int Para15, int Para16, int Para17, int Para18, string Para19, string Para20, string Para21, int Para22, int Para23, int Para24, int Para25, int Para26, int Para27, int Para28, int Para29, int Para30, int Para31, string Para32, int Para33, string Para34, int Para35, string Para36, string Para37, string Para38, string Para39, int Para40, string Para41, string Para42, string Para43, string Para44, bool Para45, bool Para46, string Para47, string Para48, int Para49,int Para50,string Para51,string Para52,string Para53, string Para54,int Para55)
        {

            age_id = Para1;
            ward_id = Para2;
            ward_type_id = Para3;
            bed_id = Para4;
            allergies_id = Para5;
            is_vegitarian = Para6;
            is_halal = Para7;
            disposable_tray = Para8;
            order_id = Para9;
            order_date = Para10;
            order_no = Para11;
            is_care_giver = Para12;
            site_code = Para13;
            createdby = Para14;
            P_id = Para15;
            BF = Para16;
            LH = Para17;
            DN = Para18;
            Therapeutic_ids = Para19;
            ingredeint_ids = Para20;
            other_ids = Para21;
            meal_time_id = Para22;
            meal_type_id = Para23;
            meal_soup_id = Para24;
            meal_option_id = Para25;
            meal_menu_juice_item_id = Para26;
            meal_diet_id = Para27;
            meal_entree_id = Para28;
            meal_beverage_id = Para29;
            meal_desert_id = Para30;
            remark_id = Para31;
            meal_remark = Para32;

            ID = Para33;
            adult_child = Para34;
            bedclass_id = Para35;
            bedclass_name = Para36;
            doctor_comment = Para37;
            general_comment = Para38;
            patient_age = Para39;
            patient_id = Para40;
            patient_name = Para41;
            patient_race = Para42;
            preferred_server = Para43;
            ward_bed = Para44;

            isdietician = Para45;
            is_staff = Para46;
            staff_name = Para47;
            dietician_comment = Para48;
            Is_Late_Ordered = Para49;
            mode_of_payment = Para50;
            payment_remark = Para51;

            allergies_ids = Para52;
            Diet_Texture = Para53;
            Fluid_Consistency = Para54;
            role_Id = Para55;
        }
        
    }
}