using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Sodexo_KKH.Droid.Services;
using Sodexo_KKH.Interfaces;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_droid))]
namespace Sodexo_KKH.Droid.Services
{
    public class SQLite_droid : IDBInterface
    {
        SQLiteConnection conn;
        public SQLiteConnection GetConnection()
        {
            InitializeDB();
            return conn;
        }

        public void InitializeDB()
        {
            string filename = "SODEXO.db3";
            var path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), filename);
            conn = new SQLite.SQLiteConnection(path);
        }

        
    }
}