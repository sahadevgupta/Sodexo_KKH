using Sodexo_KKH.Models;
using SQLite;

namespace Sodexo_KKH.Services
{
    public interface IMealOrderLocalManager
    {
        TableQuery<mstr_meal_order_local> GetTable();
    }
}