using Sodexo_KKH.Models;
using Sodexo_KKH.Repos;
using SQLite;

namespace Sodexo_KKH.Services
{
    public class MealOrderLocalManager : IMealOrderLocalManager
    {
        IGenericRepo<mstr_meal_order_local> _orderLocalRepo;
        public MealOrderLocalManager(IGenericRepo<mstr_meal_order_local> orderLocalRepo)
        {
            _orderLocalRepo = orderLocalRepo;
        }

        public TableQuery<mstr_meal_order_local> GetTable()
        {
            return _orderLocalRepo.QueryTable();
        }
    }
}
