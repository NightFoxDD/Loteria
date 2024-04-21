using Loteria.Tables;
using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Essentials;

namespace Loteria
{
    public class DataAccess
    {
        private readonly SQLiteConnection connection;
        public DataAccess (string path)
        {
            connection = new SQLiteConnection(path);
            connection.CreateTable<User>();
            connection.CreateTable<Result>();
        }
        public int Save<T>(T myobject)
        {
            return connection.Insert(myobject);
        }
        public List<T> GetList<T>() where T : new()
        {
            return connection.Table<T>().ToList();
        }
    }
}
