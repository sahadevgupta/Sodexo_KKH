using SQLite;

namespace Sodexo_KKH.Interfaces
{
    public interface IDBInterface
    {
        SQLiteConnection GetConnection();
        void InitializeDB();
    }
}
