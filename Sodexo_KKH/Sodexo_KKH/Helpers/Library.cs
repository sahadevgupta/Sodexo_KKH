using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sodexo_KKH.Helpers
{
    public class Library
    {
        //Patient's information
        // public static string KEY_SERVER_IP = "www.touch2orderqaws.sodexonet.com";
        public static string KEY_SERVER_IP = "epinetuat/";
        //  public static string KEY_SERVER_IP = "172.25.1.29/";

        // public static string KEY_SERVER_LOCATION = "Sodexo_Service_prasad";
        //  public static string KEY_SERVER_LOCATION = "sodexo_test_services"; //check  
        //public static string KEY_SERVER_LOCATION = "";
        public static string KEY_SERVER_LOCATION = "t2o_kkh_service"; //"t2O_cac_services";
                                                                      // public static string KEY_SERVER_LOCATION = "SodexoService";

        // public static string KEY_http = "https://";
        public static string KEY_http = "http://";
        //sodexo wcf service touch2orderuat.sodexonet.com  //

        //http://touch2orderuat.sodexonet.com
        //https://www.touch2orderws.sodexonet.com/Sodexo.svc/ latest
        //public static string URL = Library.KEY_http+Lo Library.KEY_SERVER_IP+"/SodexoService/sodexo.svc"; https://www.touch2orderqaws.sodexonet.com/Sodexo.svc/


        // public static string DB_PATH = Path.Combine(Path.Combine(ApplicationData.Current.LocalFolder.Path, "SODEXO.sqlite"));//DataBase Name  
        //user informations


        //WCF service methods
        public static string METHODE_SHOWPATIENTMEALDETAILSBYID = "ShowpatientmealdetailsById";
        public static string METHODE_GETDELIVEREDDATA = "GetDelivereddata";
        public static string METHODE_SETDELIVEREDSTATUS = "SetDeliveredStatus";
        public static string METHODE_GETREMARKSDETAIL = "Remarksdetails";
        public static string METHODE_CHECKORDERTAKEN = "checkordertaken";
        public static string METHODE_UPDATE_ORDER = "updateorder";
        public static string METHODE_CHECKORDER = "checkorder";
        public static string METHODE_CHECKFIRSTORDER = "checkfirstorder";
        public static string METHODE_SAVEORDER = "SaveOrder";
        public static string METHODE_GETALLPATIENT = "PullpatientData";
        public static string METHODE_SEARCHBYWARDNO = "Searchbywardno";
        public static string METHODE_SEARCHBYPATIENTNAME = "Searchbypatientname";
        public static string METHODE_BEDMEALCLASSMAPPING = "bedmealclassmapping";
        public static string METHODE_DISPLAYBEDCLASS = "Displaybedclass";
        public static string METHODE_DISPLAYMEALCLASS = "Displaymealclass";
        public static string METHODE_ALLERGENTDIETLIST = "AllergentDietList";
        public static string METHODE_DISPLAYBEDDETAILS = "DisplayBedDetails";
        public static string METHODE_DISPLAYDIET_TYPE = "Displaydiet_type";
        public static string METHODE_GETALLDIETTEXTURE = "GetAllDietTexture";
        //public static string METHODE_FLUIDlIST = "Fluidlist";
        public static string METHODE_INGREDIENTLIST = "IngredientList";
        public static string METHODE_DISPLAYMEAL_OPTION = "Displaymeal_option";
        public static string METHODE_MEALTIMELIST = "MealTimeDetails";
        public static string METHODE_DISPLAYMEALTYPE = "DisplayMealType";
        public static string METHODE_NENU_MASETER = "SetMenuDetailsWithImg";
        public static string METHODE_NENUITEMDETAILS = "MenuItemDetailsWithImg";
        public static string METHODE_MENUITEMCATEGORYDETAILS = "MenuItemCategorydetails";
        public static string METHODE_OTHERSMASTERDETAILS = "OthersMasterdetails";
        //  public static string METHODE_PATIENTDETAILS = "Patientdetails";
        public static string METHODE_THERAPEUTICDETAILS = "Therapeuticdetails";
        public static string METHODE_DISPLAYWARDDETAILS = "DisplayWardDetails";
        public static string METHODE_USERLOGIN = "UserLogin";
        public static string METHODE_CYCLEDETAILS = "Cycledetailsmaster";
        public static string METHODE_Cancel_order = "Cancel_order";
        public static string METHODE_DisplayPaymentModeDetails = "DisplayPaymentModeDetails";
        public static string METHODE_DisplayLanguageDetails = "DisplayLanguageDetails ";
        // public static string METHODE_CaregiverMenuItems = "CaregiverMenuItems";
        public static string METHODE_QRVERIFIED = "QRVerified";
        public static string METHODE_CAREGIVERMENUITEMS = "CaregiverMenuItems";
        public static string METHODE_GETMEALORDERSTATUS = "GetMealOrderStatus";
        public static string METHODE_GETUSERROLEBYUSERNAMEMOBILE = "GetUserRoleByUserNameMobile";
        public static string METHODE_GETALLFLUIDCONSISTENCY = "GetAllFluidConsistency";
        public static string METHODE_THERAPEUTICCONDITIONDETAILS = "TherapeuticConditiondetails";

        // End of WCF service...........................................................


        // DisplayLanguage
        private const string DisplayLanguageKey = "display_language_key";
        private static readonly string DisplayLanguageDefault = "English";

        public static string DisplayLanguage
        {
            get
            {
                return AppSettings.GetValueOrDefault(DisplayLanguageKey, DisplayLanguageDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(DisplayLanguageKey, value);
            }
        }
        // DisplayLanguage end



        //public string LoadSetting(string key)
        //{


        //        return AppSettings.GetValueOrDefault(key, "");


        //}
        //public void SaveSetting(string key, string value)
        //{
        //         AppSettings.AddOrUpdateValue(key, value);
        //  // ApplicationData.Current.LocalSettings.Values[key] = value;
        //}


        // KEY_Selected_Language
        private const string Selected_Language_KEY = "Selected_Language_KEY";
        private static readonly string KEY_Selected_Language_Default = "English";

        public static string KEY_Selected_Language
        {
            get
            {
                return AppSettings.GetValueOrDefault(Selected_Language_KEY, KEY_Selected_Language_Default);
            }
            set
            {
                AppSettings.AddOrUpdateValue(Selected_Language_KEY, value);
            }
        }
        // KEY_Selected_Language end

        // KEY_USER_ID
        private const string USER_ID_KEY = "KEY_USER_ID";

        public static string KEY_USER_ID
        {
            get
            {
                return AppSettings.GetValueOrDefault(USER_ID_KEY, "");
            }
            set
            {
                AppSettings.AddOrUpdateValue(USER_ID_KEY, value);
            }
        }
        // KEY_USER_ID end

        // KEY_USER_NAME
        private const string USER_NAME_KEY = "USER_NAME_KEY";

        public static string KEY_USER_NAME
        {
            get
            {
                return AppSettings.GetValueOrDefault(USER_NAME_KEY, "");
            }
            set
            {
                AppSettings.AddOrUpdateValue(USER_NAME_KEY, value);
            }
        }
        // KEY_USER_NAME end

        // KEY_USER_PWD
        private const string USER_PWD_KEY = "USER_PWD_KEY";

        public static string KEY_USER_PWD
        {
            get
            {
                return AppSettings.GetValueOrDefault(USER_PWD_KEY, "");
            }
            set
            {
                AppSettings.AddOrUpdateValue(USER_PWD_KEY, value);
            }
        }
        // KEY_USER_PWD end

        // KEY_USER_ROLE
        private const string USER_ROLE_KEY = "USER_ROLE_KEY";

        public static string KEY_USER_ROLE
        {
            get
            {
                return AppSettings.GetValueOrDefault(USER_ROLE_KEY, "");
            }
            set
            {
                AppSettings.AddOrUpdateValue(USER_ROLE_KEY, value);
            }
        }
        // KEY_USER_ROLE end

        // KEY_USER_FIRST_NAME
        private const string USER_FIRST_NAME_KEY = "USER_FIRST_NAME_KEY";

        public static string KEY_USER_FIRST_NAME
        {
            get
            {
                return AppSettings.GetValueOrDefault(USER_FIRST_NAME_KEY, "");
            }
            set
            {
                AppSettings.AddOrUpdateValue(USER_FIRST_NAME_KEY, value);
            }
        }
        // KEY_USER_FIRST_NAME end

        // KEY_USER_LAST_NAME
        private const string USER_LAST_NAME_KEY = "USER_LAST_NAME_KEY";

        public static string KEY_USER_LAST_NAME
        {
            get
            {
                return AppSettings.GetValueOrDefault(USER_LAST_NAME_KEY, "");
            }
            set
            {
                AppSettings.AddOrUpdateValue(USER_LAST_NAME_KEY, value);
            }
        }
        // KEY_USER_LAST_NAME end

        // KEY_ROLL_TYPE
        private const string ROLL_TYPE_KEY = "ROLL_TYPE_KEY";

        public static string KEY_ROLL_TYPE
        {
            get
            {
                return AppSettings.GetValueOrDefault(ROLL_TYPE_KEY, "");
            }
            set
            {
                AppSettings.AddOrUpdateValue(ROLL_TYPE_KEY, value);
            }
        }
        // KEY_ROLL_TYPE end

        // KEY_USER_STATUS
        private const string USER_STATUS_KEY = "USER_STATUS_KEY";

        public static string KEY_USER_STATUS
        {
            get
            {
                return AppSettings.GetValueOrDefault(USER_STATUS_KEY, "");
            }
            set
            {
                AppSettings.AddOrUpdateValue(USER_STATUS_KEY, value);
            }
        }
        // KEY_USER_STATUS end

        // KEY_USER_CREATED_BY
        private const string USER_CREATED_BY_KEY = "USER_CREATED_BY_KEY";

        public static string KEY_USER_CREATED_BY
        {
            get
            {
                return AppSettings.GetValueOrDefault(USER_CREATED_BY_KEY, "");
            }
            set
            {
                AppSettings.AddOrUpdateValue(USER_CREATED_BY_KEY, value);
            }
        }
        // KEY_USER_CREATED_BY end

        // KEY_USER_SiteCode
        private const string USER_SiteCode_KEY = "USER_SiteCode_KEY";

        public static string KEY_USER_SiteCode
        {
            get
            {
                return AppSettings.GetValueOrDefault(USER_SiteCode_KEY, "");
            }
            set
            {
                AppSettings.AddOrUpdateValue(USER_SiteCode_KEY, value);
            }
        }
        // KEY_USER_SiteCode end

        // KEY_USER_ccode
        private const string USER_ccode_KEY = "USER_ccode_KEY";

        public static string KEY_USER_ccode
        {
            get
            {
                return AppSettings.GetValueOrDefault(USER_ccode_KEY, "");
            }
            set
            {
                AppSettings.AddOrUpdateValue(USER_ccode_KEY, value);
            }
        }
        // KEY_USER_ccode end

        // KEY_USER_regcode
        private const string USER_regcode_KEY = "USER_regcode_KEY";

        public static string KEY_USER_regcode
        {
            get
            {
                return AppSettings.GetValueOrDefault(USER_regcode_KEY, "");
            }
            set
            {
                AppSettings.AddOrUpdateValue(USER_regcode_KEY, value);
            }
        }
        // KEY_USER_regcode end

        // KEY_USER_siteid
        private const string USER_siteid_KEY = "USER_siteid_KEY";

        public static string KEY_USER_siteid
        {
            get
            {
                return AppSettings.GetValueOrDefault(USER_siteid_KEY, "");
            }
            set
            {
                AppSettings.AddOrUpdateValue(USER_siteid_KEY, value);
            }
        }
        // KEY_USER_siteid end

        // KEY_USER_roleid
        private const string USER_roleid_KEY = "USER_roleid_KEY";

        public static string KEY_USER_roleid
        {
            get
            {
                return AppSettings.GetValueOrDefault(USER_roleid_KEY, "");
            }
            set
            {
                AppSettings.AddOrUpdateValue(USER_roleid_KEY, value);
            }
        }
        // KEY_USER_roleid end


        // KEY_USER_feedback_link
        private const string USER_Feedback_Link_KEY = "USER_Feedback_Link_KEY";

        public static string KEY_USER_feedback_link
        {
            get
            {
                return AppSettings.GetValueOrDefault(USER_Feedback_Link_KEY, "");
            }
            set
            {
                AppSettings.AddOrUpdateValue(USER_Feedback_Link_KEY, value);
            }
        }
        // KEY_USER_feedback_link end

        // KEY_USER_language_id
        private const string USER_Language_ID_KEY = "USER_Language_ID_KEY";

        public static string KEY_USER_language_id
        {
            get
            {
                return AppSettings.GetValueOrDefault(USER_Language_ID_KEY, "");
            }
            set
            {
                AppSettings.AddOrUpdateValue(USER_Language_ID_KEY, value);
            }
        }
        // KEY_USER_language_id end

        // KEY_USER_payment_mode_ids
        private const string USER_Payment_Mode_ID_KEY = "USER_Payment_Mode_ID_KEY";

        public static string KEY_USER_payment_mode_ids
        {
            get
            {
                return AppSettings.GetValueOrDefault(USER_Payment_Mode_ID_KEY, "");
            }
            set
            {
                AppSettings.AddOrUpdateValue(USER_Payment_Mode_ID_KEY, value);
            }
        }
        // KEY_USER_payment_mode_ids end

        // KEY_SYNC_NOTIFICATION
        private const string SYNC_NOTIFICATION_KEY = "SYNC_NOTIFICATION_KEY";

        public static string KEY_SYNC_NOTIFICATION
        {
            get
            {
                return AppSettings.GetValueOrDefault(SYNC_NOTIFICATION_KEY, "");
            }
            set
            {
                AppSettings.AddOrUpdateValue(SYNC_NOTIFICATION_KEY, value);
            }
        }
        // KEY_SYNC_NOTIFICATION end

        // KEY_PATIENT_WARDTYPENAME
        private const string PATIENT_WARDTYPENAME_KEY = "PATIENT_WARDTYPENAME_KEY";

        public static string KEY_PATIENT_WARDTYPENAME
        {
            get
            {
                return AppSettings.GetValueOrDefault(PATIENT_WARDTYPENAME_KEY, "");
            }
            set
            {
                AppSettings.AddOrUpdateValue(PATIENT_WARDTYPENAME_KEY, value);
            }
        }
        // KEY_PATIENT_WARDTYPENAME end

        // KEY_PATIENT_BF
        private const string PATIENT_BF_KEY = "PATIENT_BF_KEY";

        public static string KEY_PATIENT_BF
        {
            get
            {
                return AppSettings.GetValueOrDefault(PATIENT_BF_KEY, "");
            }
            set
            {
                AppSettings.AddOrUpdateValue(PATIENT_BF_KEY, value);
            }
        }
        // KEY_PATIENT_BF end

        // KEY_PATIENT_LH
        private const string PATIENT_LH_KEY = "display_language_key";

        public static string KEY_PATIENT_LH
        {
            get
            {
                return AppSettings.GetValueOrDefault(DisplayLanguageKey, "");
            }
            set
            {
                AppSettings.AddOrUpdateValue(DisplayLanguageKey, value);
            }
        }
        // KEY_PATIENT_LH end

        // KEY_PATIENT_DN
        private const string PATIENT_DN_KEY = "PATIENT_DN_KEY";

        public static string KEY_PATIENT_DN
        {
            get
            {
                return AppSettings.GetValueOrDefault(PATIENT_DN_KEY, "");
            }
            set
            {
                AppSettings.AddOrUpdateValue(PATIENT_DN_KEY, value);
            }
        }
        // KEY_PATIENT_DN end

        // KEY_PATIENT_ID_HISTORY
        private const string PATIENT_ID_HISTORY_KEY = "PATIENT_ID_HISTORY_KEY";

        public static string KEY_PATIENT_ID_HISTORY
        {
            get
            {
                return AppSettings.GetValueOrDefault(PATIENT_ID_HISTORY_KEY, "");
            }
            set
            {
                AppSettings.AddOrUpdateValue(PATIENT_ID_HISTORY_KEY, value);
            }
        }
        // KEY_PATIENT_ID_HISTORY end

        // KEY_PATIENT_ID
        private const string PATIENT_ID_KEY = "PATIENT_ID_KEY";

        public static string KEY_PATIENT_ID
        {
            get
            {
                return AppSettings.GetValueOrDefault(PATIENT_ID_KEY, "");
            }
            set
            {
                AppSettings.AddOrUpdateValue(PATIENT_ID_KEY, value);
            }
        }
        // KEY_PATIENT_ID end

        // KEY_PATIENT_CATEGORY
        private const string PATIENT_CATEGORY_KEY = "PATIENT_CATEGORY_KEY";

        public static string KEY_PATIENT_CATEGORY
        {
            get
            {
                return AppSettings.GetValueOrDefault(PATIENT_CATEGORY_KEY, "");
            }
            set
            {
                AppSettings.AddOrUpdateValue(PATIENT_CATEGORY_KEY, value);
            }
        }
        // KEY_PATIENT_CATEGORY end

        // KEY_PATIENT_AGE_ID
        private const string PATIENT_AGE_ID_KEY = "PATIENT_AGE_ID_KEY";

        public static string KEY_PATIENT_AGE_ID
        {
            get
            {
                return AppSettings.GetValueOrDefault(PATIENT_AGE_ID_KEY, "");
            }
            set
            {
                AppSettings.AddOrUpdateValue(PATIENT_AGE_ID_KEY, value);
            }
        }
        // KEY_PATIENT_AGE_ID end

        // KEY_PATIENT_BED_ID
        private const string PATIENT_BED_ID_KEY = "PATIENT_BED_ID_KEY";

        public static string KEY_PATIENT_BED_ID
        {
            get
            {
                return AppSettings.GetValueOrDefault(PATIENT_BED_ID_KEY, "");
            }
            set
            {
                AppSettings.AddOrUpdateValue(PATIENT_BED_ID_KEY, value);
            }
        }
        // KEY_PATIENT_BED_ID end

        // KEY_PATIENT_BED_CLASS_ID
        private const string PATIENT_BED_CLASS_ID_KEY = "PATIENT_BED_CLASS_ID_KEY";

        public static string KEY_PATIENT_BED_CLASS_ID
        {
            get
            {
                return AppSettings.GetValueOrDefault(PATIENT_BED_CLASS_ID_KEY, "");
            }
            set
            {
                AppSettings.AddOrUpdateValue(PATIENT_BED_CLASS_ID_KEY, value);
            }
        }
        // KEY_PATIENT_BED_CLASS_ID end

        // KEY_PATIENT_BED_CLASS_NAME
        private const string PATIENT_BED_CLASS_NAME_KEY = "PATIENT_BED_CLASS_NAME_KEY";

        public static string KEY_PATIENT_BED_CLASS_NAME
        {
            get
            {
                return AppSettings.GetValueOrDefault(PATIENT_BED_CLASS_NAME_KEY, "");
            }
            set
            {
                AppSettings.AddOrUpdateValue(PATIENT_BED_CLASS_NAME_KEY, value);
            }
        }
        // KEY_PATIENT_BED_CLASS_NAME end

        // KEY_PATIENT_MEAL_CLASS_NAME
        private const string PATIENT_MEAL_CLASS_NAME_KEY = "PATIENT_MEAL_CLASS_NAME_KEY";

        public static string KEY_PATIENT_MEAL_CLASS_NAME
        {
            get
            {
                return AppSettings.GetValueOrDefault(PATIENT_MEAL_CLASS_NAME_KEY, "");
            }
            set
            {
                AppSettings.AddOrUpdateValue(PATIENT_MEAL_CLASS_NAME_KEY, value);
            }
        }
        // KEY_PATIENT_MEAL_CLASS_NAME end

        // KEY_PATIENT_CREATED_BY
        private const string PATIENT_CREATED_BY_KEY = "PATIENT_CREATED_BY_KEY";

        public static string KEY_PATIENT_CREATED_BY
        {
            get
            {
                return AppSettings.GetValueOrDefault(PATIENT_CREATED_BY_KEY, "");
            }
            set
            {
                AppSettings.AddOrUpdateValue(PATIENT_CREATED_BY_KEY, value);
            }
        }
        // KEY_PATIENT_CREATED_BY end

        // KEY_PATIENT_DOCTOR_COMMENT
        private const string PATIENT_DOCTOR_COMMENT_KEY = "PATIENT_DOCTOR_COMMENT_KEY";

        public static string KEY_PATIENT_DOCTOR_COMMENT
        {
            get
            {
                return AppSettings.GetValueOrDefault(PATIENT_DOCTOR_COMMENT_KEY, "");
            }
            set
            {
                AppSettings.AddOrUpdateValue(PATIENT_DOCTOR_COMMENT_KEY, value);
            }
        }
        // KEY_PATIENT_DOCTOR_COMMENT end

        // KEY_PATIENT_GENERAL_COMMENT
        private const string PATIENT_GENERAL_COMMENT_KEY = "PATIENT_GENERAL_COMMENT_KEY";

        public static string KEY_PATIENT_GENERAL_COMMENT
        {
            get
            {
                return AppSettings.GetValueOrDefault(PATIENT_GENERAL_COMMENT_KEY, "");
            }
            set
            {
                AppSettings.AddOrUpdateValue(PATIENT_GENERAL_COMMENT_KEY, value);
            }
        }
        // KEY_PATIENT_GENERAL_COMMENT end

        // KEY_PATIENT_IS_HALAL
        private const string PATIENT_IS_HALAL_KEY = "PATIENT_IS_HALAL_KEY";

        public static string KEY_PATIENT_IS_HALAL
        {
            get
            {
                return AppSettings.GetValueOrDefault(PATIENT_IS_HALAL_KEY, "");
            }
            set
            {
                AppSettings.AddOrUpdateValue(PATIENT_IS_HALAL_KEY, value);
            }
        }
        // KEY_PATIENT_IS_HALAL end

        // KEY_PATIENT_IS_VEG
        private const string PATIENT_IS_VEG_KEY = "PATIENT_IS_VEG_KEY";

        public static string KEY_PATIENT_IS_VEG
        {
            get
            {
                return AppSettings.GetValueOrDefault(PATIENT_IS_VEG_KEY, "");
            }
            set
            {
                AppSettings.AddOrUpdateValue(PATIENT_IS_VEG_KEY, value);
            }
        }
        // KEY_PATIENT_IS_VEG end

        // KEY_ORDER_DATE
        private const string ORDER_DATE_KEY = "ORDER_DATE_KEY";

        public static string KEY_ORDER_DATE
        {
            get
            {
                return AppSettings.GetValueOrDefault(ORDER_DATE_KEY, "");
            }
            set
            {
                AppSettings.AddOrUpdateValue(ORDER_DATE_KEY, value);
            }
        }
        // KEY_ORDER_DATE end

        // KEY_PATIENT_AGE
        private const string PATIENT_AGE_KEY = "PATIENT_AGE_KEY";

        public static string KEY_PATIENT_AGE
        {
            get
            {
                return AppSettings.GetValueOrDefault(PATIENT_AGE_KEY, "");
            }
            set
            {
                AppSettings.AddOrUpdateValue(PATIENT_AGE_KEY, value);
            }
        }
        // KEY_PATIENT_AGE end

        // KEY_PATIENT_NAME
        private const string PATIENT_NAME_KEY = "PATIENT_NAME_KEY";

        public static string KEY_PATIENT_NAME
        {
            get
            {
                return AppSettings.GetValueOrDefault(PATIENT_NAME_KEY, "");
            }
            set
            {
                AppSettings.AddOrUpdateValue(PATIENT_NAME_KEY, value);
            }
        }
        // KEY_PATIENT_NAME end

        // KEY_PATIENT_RACE
        private const string PATIENT_RACE_KEY = "PATIENT_RACE_KEY";

        public static string KEY_PATIENT_RACE
        {
            get
            {
                return AppSettings.GetValueOrDefault(PATIENT_RACE_KEY, "");
            }
            set
            {
                AppSettings.AddOrUpdateValue(PATIENT_RACE_KEY, value);
            }
        }
        // KEY_PATIENT_RACE end

        // KEY_PATIENT_PREFERED_SERVER
        private const string PATIENT_PREFERED_SERVER_KEY = "PATIENT_PREFERED_SERVER_KEY";

        public static string KEY_PATIENT_PREFERED_SERVER
        {
            get
            {
                return AppSettings.GetValueOrDefault(PATIENT_PREFERED_SERVER_KEY, "");
            }
            set
            {
                AppSettings.AddOrUpdateValue(PATIENT_PREFERED_SERVER_KEY, value);
            }
        }
        // KEY_PATIENT_PREFERED_SERVER end

        // KEY_PATIENT_SITE_CODE
        private const string PATIENT_SITE_CODE_KEY = "PATIENT_SITE_CODE_KEY";

        public static string KEY_PATIENT_SITE_CODE
        {
            get
            {
                return AppSettings.GetValueOrDefault(PATIENT_SITE_CODE_KEY, "");
            }
            set
            {
                AppSettings.AddOrUpdateValue(PATIENT_SITE_CODE_KEY, value);
            }
        }
        // KEY_PATIENT_SITE_CODE end

        // KEY_PATIENT_WARD_BED
        private const string PATIENT_WARD_BED_KEY = "PATIENT_WARD_BED_KEY";

        public static string KEY_PATIENT_WARD_BED
        {
            get
            {
                return AppSettings.GetValueOrDefault(PATIENT_WARD_BED_KEY, "");
            }
            set
            {
                AppSettings.AddOrUpdateValue(PATIENT_WARD_BED_KEY, value);
            }
        }
        // KEY_PATIENT_WARD_BED end

        // KEY_PATIENT_WARD_ID
        private const string PATIENT_WARD_ID_KEY = "PATIENT_WARD_ID_KEY";

        public static string KEY_PATIENT_WARD_ID
        {
            get
            {
                return AppSettings.GetValueOrDefault(PATIENT_WARD_ID_KEY, "");
            }
            set
            {
                AppSettings.AddOrUpdateValue(PATIENT_WARD_ID_KEY, value);
            }
        }
        // KEY_PATIENT_WARD_ID end

        // KEY_PATIENT_WARD_TYPE_ID
        private const string PATIENT_WARD_TYPE_ID_KEY = "PATIENT_WARD_TYPE_ID_KEY";

        public static string KEY_PATIENT_WARD_TYPE_ID
        {
            get
            {
                return AppSettings.GetValueOrDefault(PATIENT_WARD_TYPE_ID_KEY, "");
            }
            set
            {
                AppSettings.AddOrUpdateValue(PATIENT_WARD_TYPE_ID_KEY, value);
            }
        }
        // KEY_PATIENT_WARD_TYPE_ID end

        // KEY_PATIENT_ALLERGIES
        private const string PATIENT_ALLERGIES_KEY = "PATIENT_ALLERGIES_KEY";

        public static string KEY_PATIENT_ALLERGIES
        {
            get
            {
                return AppSettings.GetValueOrDefault(PATIENT_ALLERGIES_KEY, "");
            }
            set
            {
                AppSettings.AddOrUpdateValue(PATIENT_ALLERGIES_KEY, value);
            }
        }
        // KEY_PATIENT_ALLERGIES end

        // KEY_PATIENT_ALLERGIES_ID
        private const string PATIENT_ALLERGIES_ID_KEY = "PATIENT_ALLERGIES_ID_KEY";

        public static string KEY_PATIENT_ALLERGIES_ID
        {
            get
            {
                return AppSettings.GetValueOrDefault(PATIENT_ALLERGIES_ID_KEY, "");
            }
            set
            {
                AppSettings.AddOrUpdateValue(PATIENT_ALLERGIES_ID_KEY, value);
            }
        }
        // KEY_PATIENT_ALLERGIES_ID end

        // KEY_PATIENT_DISPOSABLE_TRAY
        private const string PATIENT_DISPOSABLE_TRAY_KEY = "PATIENT_DISPOSABLE_TRAY_KEY";

        public static string KEY_PATIENT_DISPOSABLE_TRAY
        {
            get
            {
                return AppSettings.GetValueOrDefault(PATIENT_DISPOSABLE_TRAY_KEY, "");
            }
            set
            {
                AppSettings.AddOrUpdateValue(PATIENT_DISPOSABLE_TRAY_KEY, value);
            }
        }
        // KEY_PATIENT_DISPOSABLE_TRAY end

        // KEY_PATIENT_AGE_NAME
        private const string PATIENT_AGE_NAME_KEY = "PATIENT_AGE_NAME_KEY";

        public static string KEY_PATIENT_AGE_NAME
        {
            get
            {
                return AppSettings.GetValueOrDefault(PATIENT_AGE_NAME_KEY, "");
            }
            set
            {
                AppSettings.AddOrUpdateValue(PATIENT_AGE_NAME_KEY, value);
            }
        }
        // KEY_PATIENT_AGE_NAME end

        // KEY_PATIENT_NRIC
        private const string PATIENT_NRIC_KEY = "PATIENT_NRIC_KEY";

        public static string KEY_PATIENT_NRIC
        {
            get
            {
                return AppSettings.GetValueOrDefault(PATIENT_NRIC_KEY, "");
            }
            set
            {
                AppSettings.AddOrUpdateValue(PATIENT_NRIC_KEY, value);
            }
        }
        // KEY_PATIENT_NRIC end

        // KEY_PATIENT_is_diabetic
        private const string PATIENT_Is_Diabetic_KEY = "PATIENT_Is_Diabetic_KEY";

        public static string KEY_PATIENT_is_diabetic
        {
            get
            {
                return AppSettings.GetValueOrDefault(PATIENT_Is_Diabetic_KEY, "");
            }
            set
            {
                AppSettings.AddOrUpdateValue(PATIENT_Is_Diabetic_KEY, value);
            }
        }
        // KEY_PATIENT_is_diabetic end

        // KEY_PATIENT_ther
        private const string PATIENT_THERAPEUTIC_KEY = "PATIENT_THERAPEUTIC_KEY";

        public static string KEY_PATIENT_ther
        {
            get
            {
                return AppSettings.GetValueOrDefault(PATIENT_THERAPEUTIC_KEY, "");
            }
            set
            {
                AppSettings.AddOrUpdateValue(PATIENT_THERAPEUTIC_KEY, value);
            }
        }
        // KEY_PATIENT_ther
        private const string PATIENT_Ingrediant_KEY = "PATIENT_Ingrediant_KEY";

        public static string KEY_Ingrediant_KEY
        {
            get
            {
                return AppSettings.GetValueOrDefault(PATIENT_Ingrediant_KEY, "");
            }
            set
            {
                AppSettings.AddOrUpdateValue(PATIENT_Ingrediant_KEY, value);
            }
        }
        // KEY_PATIENT_ther end

        // KEY_USER_currency
        private const string USER_CURRENCY_KEY = "USER_CURRENCY_KEY";

        public static string KEY_USER_currency
        {
            get
            {
                return AppSettings.GetValueOrDefault(USER_CURRENCY_KEY, "");
            }
            set
            {
                AppSettings.AddOrUpdateValue(USER_CURRENCY_KEY, value);
            }
        }
        // KEY_USER_currency end

        // KEY_USER_adjusttime
        private const string USER_ADJUST_TIME_KEY = "USER_ADJUST_TIME_KEY";

        public static string KEY_USER_adjusttime
        {
            get
            {
                return AppSettings.GetValueOrDefault(USER_ADJUST_TIME_KEY, "");
            }
            set
            {
                AppSettings.AddOrUpdateValue(USER_ADJUST_TIME_KEY, value);
            }
        }
        // KEY_USER_adjusttime end

        // KEY_langchangedfrommealpage
        private const string LANGUAGE_CHANGE_FROM_MEAL_PAGE = "no";

        public static string KEY_langchangedfrommealpage
        {
            get
            {
                return AppSettings.GetValueOrDefault(LANGUAGE_CHANGE_FROM_MEAL_PAGE, "");
            }
            set
            {
                AppSettings.AddOrUpdateValue(LANGUAGE_CHANGE_FROM_MEAL_PAGE, value);
            }
        }
        // KEY_langchangedfrommealpage end

        // KEY_MEAL_CLASS
        private const string MEAL_CLASS_KEY = "MEAL_CLASS_KEY";

        public static string KEY_MEAL_CLASS
        {
            get
            {
                return AppSettings.GetValueOrDefault(MEAL_CLASS_KEY, "");
            }
            set
            {
                AppSettings.AddOrUpdateValue(MEAL_CLASS_KEY, value);
            }
        }
        // KEY_MEAL_CLASS end

        // KEY_MEAL_CLASS_ID
        private const string MEAL_CLASS_ID_KEY = "MEAL_CLASS_ID_KEY";

        public static string KEY_MEAL_CLASS_ID
        {
            get
            {
                return AppSettings.GetValueOrDefault(MEAL_CLASS_ID_KEY, "");
            }
            set
            {
                AppSettings.AddOrUpdateValue(MEAL_CLASS_ID_KEY, value);
            }
        }
        // KEY_MEAL_CLASS_ID end

        // KEY_MEAL_OPTION
        private const string MEAL_OPTION_KEY = "MEAL_OPTION_KEY";

        public static string KEY_MEAL_OPTION
        {
            get
            {
                return AppSettings.GetValueOrDefault(MEAL_OPTION_KEY, "");
            }
            set
            {
                AppSettings.AddOrUpdateValue(MEAL_OPTION_KEY, value);
            }
        }
        // KEY_MEAL_OPTION end

        // KEY_DIET_TYPE
        private const string DIET_TYPE_KEY = "DIET_TYPE_KEY";

        public static string KEY_DIET_TYPE
        {
            get
            {
                return AppSettings.GetValueOrDefault(DIET_TYPE_KEY, "");
            }
            set
            {
                AppSettings.AddOrUpdateValue(DIET_TYPE_KEY, value);
            }
        }
        // KEY_DIET_TYPE end

        // KEY_DIET_TEXTURE
        private const string DIET_TEXTURE_KEY = "DIET_TEXTURE_KEY";

        public static string KEY_DIET_TEXTURE
        {
            get
            {
                return AppSettings.GetValueOrDefault(DIET_TEXTURE_KEY, "");
            }
            set
            {
                AppSettings.AddOrUpdateValue(DIET_TEXTURE_KEY, value);
            }
        }
        // KEY_DIET_TEXTURE end

        // KEY_FLUID_INFO
        private const string FLUID_INFO_KEY = "FLUID_INFO_KEY";

        public static string KEY_FLUID_INFO
        {
            get
            {
                return AppSettings.GetValueOrDefault(FLUID_INFO_KEY, "");
            }
            set
            {
                AppSettings.AddOrUpdateValue(FLUID_INFO_KEY, value);
            }
        }
        // KEY_FLUID_INFO end

        // KEY_MEAL_OPTION_NAME
        private const string MEAL_OPTION_NAME_KEY = "MEAL_OPTION_NAME_KEY";

        public static string KEY_MEAL_OPTION_NAME
        {
            get
            {
                return AppSettings.GetValueOrDefault(MEAL_OPTION_NAME_KEY, "");
            }
            set
            {
                AppSettings.AddOrUpdateValue(MEAL_OPTION_NAME_KEY, value);
            }
        }
        // KEY_MEAL_OPTION_NAME end

        // KEY_DIET_TYPE_NAME
        private const string DIET_TYPE_NAME_KEY = "DIET_TYPE_NAME_KEY";

        public static string KEY_DIET_TYPE_NAME
        {
            get
            {
                return AppSettings.GetValueOrDefault(DIET_TYPE_NAME_KEY, "");
            }
            set
            {
                AppSettings.AddOrUpdateValue(DIET_TYPE_NAME_KEY, value);
            }
        }
        // KEY_DIET_TYPE_NAME end

        // KEY_MEAL_REMARKS
        private const string MEAL_REMARKS_KEY = "MEAL_REMARKS_KEY";

        public static string KEY_MEAL_REMARKS
        {
            get
            {
                return AppSettings.GetValueOrDefault(MEAL_REMARKS_KEY, "");
            }
            set
            {
                AppSettings.AddOrUpdateValue(MEAL_REMARKS_KEY, value);
            }
        }
        // KEY_MEAL_REMARKS end

        // KEY_MEAL_REMARKS_CONTENT
        private const string MEAL_REMARKS_CONTENT_KEY = "MEAL_REMARKS_CONTENT_KEY";

        public static string KEY_MEAL_REMARKS_CONTENT
        {
            get
            {
                return AppSettings.GetValueOrDefault(MEAL_REMARKS_CONTENT_KEY, "");
            }
            set
            {
                AppSettings.AddOrUpdateValue(MEAL_REMARKS_CONTENT_KEY, value);
            }
        }
        // KEY_MEAL_REMARKS_CONTENT end

        // KEY_IS_LATE_ORDERED
        private const string IS_LATE_ORDERED_KEY = "IS_LATE_ORDERED_KEY";

        public static string KEY_IS_LATE_ORDERED
        {
            get
            {
                return AppSettings.GetValueOrDefault(IS_LATE_ORDERED_KEY, "");
            }
            set
            {
                AppSettings.AddOrUpdateValue(IS_LATE_ORDERED_KEY, value);
            }
        }
        // KEY_IS_LATE_ORDERED end

        // KEY_MEAL_TIME_ID
        private const string MEAL_TIME_ID_KEY = "MEAL_TIME_ID_KEY";

        public static string KEY_MEAL_TIME_ID
        {
            get
            {
                return AppSettings.GetValueOrDefault(MEAL_TIME_ID_KEY, "");
            }
            set
            {
                AppSettings.AddOrUpdateValue(MEAL_TIME_ID_KEY, value);
            }
        }
        // KEY_MEAL_TIME_ID end

        // KEY_IS_Confinement
        private const string IS_Confinement_KEY = "IS_Confinement_KEY";

        public static string KEY_IS_Confinement
        {
            get
            {
                return AppSettings.GetValueOrDefault(IS_Confinement_KEY, "");
            }
            set
            {
                AppSettings.AddOrUpdateValue(IS_Confinement_KEY, value);
            }
        }
        // KEY_IS_Confinement end

        // KEY_IS_CARE_GIVER
        private const string IS_CARE_GIVER_KEY = "IS_CARE_GIVER_KEY";

        public static string KEY_IS_CARE_GIVER
        {
            get
            {
                return AppSettings.GetValueOrDefault(IS_CARE_GIVER_KEY, "");
            }
            set
            {
                AppSettings.AddOrUpdateValue(IS_CARE_GIVER_KEY, value);
            }
        }
        // KEY_IS_CARE_GIVER end

        // KEY_MAIN_TAB_SELECTION
        private const string MAIN_TAB_SELECTION_KEY = "MAIN_TAB_SELECTION_KEY";

        public static string KEY_MAIN_TAB_SELECTION
        {
            get
            {
                return AppSettings.GetValueOrDefault(MAIN_TAB_SELECTION_KEY, "");
            }
            set
            {
                AppSettings.AddOrUpdateValue(MAIN_TAB_SELECTION_KEY, value);
            }
        }
        // KEY_MAIN_TAB_SELECTION end

        // KEY_ITEM_BUTTON_SELECTION
        private const string ITEM_BUTTON_SELECTION_KEY = "ITEM_BUTTON_SELECTION_KEY";

        public static string KEY_ITEM_BUTTON_SELECTION
        {
            get
            {
                return AppSettings.GetValueOrDefault(ITEM_BUTTON_SELECTION_KEY, "");
            }
            set
            {
                AppSettings.AddOrUpdateValue(ITEM_BUTTON_SELECTION_KEY, value);
            }
        }
        // KEY_ITEM_BUTTON_SELECTION end

        // KEY_NEEL_BY_MOUTH
        private const string NEEL_BY_MOUTH_KEY = "NEEL_BY_MOUTH_KEY";

        public static string KEY_NEEL_BY_MOUTH
        {
            get
            {
                return AppSettings.GetValueOrDefault(NEEL_BY_MOUTH_KEY, "");
            }
            set
            {
                AppSettings.AddOrUpdateValue(NEEL_BY_MOUTH_KEY, value);
            }
        }
        // KEY_NEEL_BY_MOUTH end

        // KEY_ORDER_ID
        private const string ORDER_ID_KEY = "ORDER_ID_KEY";

        public static string KEY_ORDER_ID
        {
            get
            {
                return AppSettings.GetValueOrDefault(ORDER_ID_KEY, "");
            }
            set
            {
                AppSettings.AddOrUpdateValue(ORDER_ID_KEY, value);
            }
        }
        // KEY_ORDER_ID end

        // KEY_CHECK_ORDER_DATE
        private const string CHECK_ORDER_DATE_KEY = "CHECK_ORDER_DATE_KEY";

        public static string KEY_CHECK_ORDER_DATE
        {
            get
            {
                return AppSettings.GetValueOrDefault(CHECK_ORDER_DATE_KEY, "");
            }
            set
            {
                AppSettings.AddOrUpdateValue(CHECK_ORDER_DATE_KEY, value);
            }
        }
        // KEY_CHECK_ORDER_DATE end

        // KEY_selected_values
        private const string SELECTED_VALUES_KEY = "SELECTED_VALUES_KEY";

        public static string KEY_selected_values
        {
            get
            {
                return AppSettings.GetValueOrDefault(SELECTED_VALUES_KEY, "");
            }
            set
            {
                AppSettings.AddOrUpdateValue(SELECTED_VALUES_KEY, value);
            }
        }
        // KEY_selected_values end

        // last_mastersynctime
        private const string last_mastersynctime_key = "last_mastersynctime_key";

        public static string last_mastersynctime
        {
            get
            {
                return AppSettings.GetValueOrDefault(last_mastersynctime_key, "");
            }
            set
            {
                AppSettings.AddOrUpdateValue(last_mastersynctime_key, value);
            }
        }
        // last_mastersynctime end

        // last_mealssynctime
        private const string last_mealssynctime_key = "last_mealssynctime_key";

        public static string last_mealssynctime
        {
            get
            {
                return AppSettings.GetValueOrDefault(last_mealssynctime_key, "");
            }
            set
            {
                AppSettings.AddOrUpdateValue(last_mealssynctime_key, value);
            }
        }
        // last_mealssynctime end


        private static ISettings AppSettings => CrossSettings.Current;


    }
}
