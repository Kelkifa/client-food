using System;
using System.Collections.Generic;
using System.Text;

using SQLite;

namespace Food
{
    class Database
    {
        string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

        string DB_PATH = "food.db";

        public bool CreateDatabase()
        {
            try
            {
                string path = System.IO.Path.Combine(folder, DB_PATH);
                var conection = new SQLiteConnection(path);

                conection.CreateTable<User>();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<User> GetUser()
        {
            try
            {
                string path = System.IO.Path.Combine(folder, DB_PATH);
                var connection = new SQLiteConnection(path);

                return connection.Table<User>().ToList();
            }
            catch { return null;  }
        }
        public bool AddUser(User user)
        {
            try
            {
                string path = System.IO.Path.Combine(folder, DB_PATH);
                var connection = new SQLiteConnection(path);

                bool isRemove = this.RemoveUser();
                if (!isRemove) return false;

                connection.Insert(user);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool RemoveUser()
        {
            try
            {
                string path = System.IO.Path.Combine(folder, DB_PATH);
                var connection = new SQLiteConnection(path);

                int count = connection.DeleteAll<User>();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
