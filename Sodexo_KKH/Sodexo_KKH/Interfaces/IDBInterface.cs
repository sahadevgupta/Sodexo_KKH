using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sodexo_KKH.Interfaces
{
    public interface IDBInterface
    {
        SQLiteConnection GetConnection();
        void InitializeDB();
    }
}
