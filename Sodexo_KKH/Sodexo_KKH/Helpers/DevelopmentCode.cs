using Sodexo_KKH.Interfaces;
using Sodexo_KKH.Models;
using SQLite;
using System.Linq;
using Xamarin.Forms;

namespace Sodexo_KKH.Helpers
{
    public static class DevelopmentCode
    {
        public static void CreateTables()
        {
            SQLiteConnection conn = DependencyService.Get<IDBInterface>().GetConnection();
            var PatientInfo = conn.GetTableInfo(nameof(Patient));
            if (!PatientInfo.Any())
            {
                conn.CreateTable<Patient>();
            }
            var PatienttherapeuticInfo = conn.GetTableInfo(nameof(opt_patient_meal_therapeutic_details));
            if (!PatienttherapeuticInfo.Any())
            {
                conn.CreateTable<opt_patient_meal_therapeutic_details>();
            }
            var PatientMealOthInfo = conn.GetTableInfo(nameof(opt_patient_meal_other_details));
            if (!PatientMealOthInfo.Any())
            {
                conn.CreateTable<opt_patient_meal_other_details>();
            }
            var PatientIngInfo = conn.GetTableInfo(nameof(opt_patient_meal_ingredient_details));
            if (!PatientIngInfo.Any())
            {
                conn.CreateTable<opt_patient_meal_ingredient_details>();
            }
            var PatientMealInfo = conn.GetTableInfo(nameof(opt_patient_meal_details));
            if (!PatientMealInfo.Any())
            {
                conn.CreateTable<opt_patient_meal_details>();
            }
            var OrderDetailInfo = conn.GetTableInfo(nameof(opt_meal_order_details));
            if (!OrderDetailInfo.Any())
            {
                conn.CreateTable<opt_meal_order_details>();
            }
            var OrderInfo = conn.GetTableInfo(nameof(opt_meal_order));
            if (!OrderInfo.Any())
            {
                conn.CreateTable<opt_meal_order>();
            }
            var WardDetailInfo = conn.GetTableInfo(nameof(mstr_ward_details));
            if (!WardDetailInfo.Any())
            {
                conn.CreateTable<mstr_ward_details>();
            }
            var MstrtherapeuticInfo = conn.GetTableInfo(nameof(mstr_therapeutic));
            if (!MstrtherapeuticInfo.Any())
            {
                conn.CreateTable<mstr_therapeutic>();
            }
            var MstrPatientInfo = conn.GetTableInfo(nameof(mstr_patient_info));
            if (!MstrPatientInfo.Any())
            {
                conn.CreateTable<mstr_patient_info>();
            }
            var OtherMstrInfo = conn.GetTableInfo(nameof(mstr_others_master));
            if (!OtherMstrInfo.Any())
            {
                conn.CreateTable<mstr_others_master>();
            }
            var MstrMenuInfo = conn.GetTableInfo(nameof(mstr_menu_master));
            if (!MstrMenuInfo.Any())
            {
                conn.CreateTable<mstr_menu_master>();
            }
            var ItemCategoryInfo = conn.GetTableInfo(nameof(mstr_menu_item_category));
            if (!ItemCategoryInfo.Any())
            {
                conn.CreateTable<mstr_menu_item_category>();
            }
            var MenuItemInfo = conn.GetTableInfo(nameof(mstr_menu_item));
            if (!MenuItemInfo.Any())
            {
                conn.CreateTable<mstr_menu_item>();
            }
            var MealtimeInfo = conn.GetTableInfo(nameof(mstr_meal_time));
            if (!MealtimeInfo.Any())
            {
                conn.CreateTable<mstr_meal_time>();
            }
            var MealTypeInfo = conn.GetTableInfo(nameof(mstr_meal_type));
            if (!MealTypeInfo.Any())
            {
                conn.CreateTable<mstr_meal_type>();
            }
            var MealOptInfo = conn.GetTableInfo(nameof(mstr_meal_option));
            if (!MealOptInfo.Any())
            {
                conn.CreateTable<mstr_meal_option>();
            }
            var MstrIngInfo = conn.GetTableInfo(nameof(mstr_ingredient));
            if (!MstrIngInfo.Any())
            {
                conn.CreateTable<mstr_ingredient>();
            }
            var MstrDietTypeInfo = conn.GetTableInfo(nameof(mstr_diet_type));
            if (!MstrDietTypeInfo.Any())
            {
                conn.CreateTable<mstr_diet_type>();
            }
            var DietTextureInfo = conn.GetTableInfo(nameof(mstr_diet_texture));
            if (!DietTextureInfo.Any())
            {
                conn.CreateTable<mstr_diet_texture>();
            }
            var FluidMstrInfo = conn.GetTableInfo(nameof(mstr_fluid_master));
            if (!FluidMstrInfo.Any())
            {
                conn.CreateTable<mstr_fluid_master>();
            }
            var BedDetailsInfo = conn.GetTableInfo(nameof(mstr_bed_details));
            if (!BedDetailsInfo.Any())
            {
                conn.CreateTable<mstr_bed_details>();
            }
            var AllergiesMstrInfo = conn.GetTableInfo(nameof(mstr_allergies_master));
            if (!AllergiesMstrInfo.Any())
            {
                conn.CreateTable<mstr_allergies_master>();
            }
            var BedClassInfo = conn.GetTableInfo(nameof(mstr_bedclass));
            if (!BedClassInfo.Any())
            {
                conn.CreateTable<mstr_bedclass>();
            }
            var MealClassInfo = conn.GetTableInfo(nameof(mstr_mealclass));
            if (!MealClassInfo.Any())
            {
                conn.CreateTable<mstr_mealclass>();
            }
            var OrderLocalInfo = conn.GetTableInfo(nameof(mstr_meal_order_local));
            if (!OrderLocalInfo.Any())
            {
                conn.CreateTable<mstr_meal_order_local>();
            }
            var BedMealMappingInfo = conn.GetTableInfo(nameof(mstr_bed_meal_class_mapping));
            if (!BedMealMappingInfo.Any())
            {
                conn.CreateTable<mstr_bed_meal_class_mapping>();
            }
            var MstrRemarksInfo = conn.GetTableInfo(nameof(mstr_remarks));
            if (!MstrRemarksInfo.Any())
            {
                conn.CreateTable<mstr_remarks>();
            }
            var CycledetailsInfo = conn.GetTableInfo(nameof(mstr_Cycledetails));
            if (!CycledetailsInfo.Any())
            {
                conn.CreateTable<mstr_Cycledetails>();
            }
            var PaymentModeInfo = conn.GetTableInfo(nameof(mstr_payment_mode));
            if (!PaymentModeInfo.Any())
            {
                conn.CreateTable<mstr_payment_mode>();
            }
            var MealDeliveryInfo = conn.GetTableInfo(nameof(meal_delivery_status));
            if (!MealDeliveryInfo.Any())
            {
                conn.CreateTable<meal_delivery_status>();
            }
        }
    }
}
