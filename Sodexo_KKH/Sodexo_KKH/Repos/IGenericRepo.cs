using System.Collections.Generic;
using SQLite;

namespace Sodexo_KKH.Repos
{
    public interface IGenericRepo<T>
    {
        void Delete(string id);
        void Insert(T a);
        void InsertAll(IEnumerable<T> a);
        void InsertOrReplace(T a);
        TableQuery<T> QueryTable();
        void Update(T a);
    }
}