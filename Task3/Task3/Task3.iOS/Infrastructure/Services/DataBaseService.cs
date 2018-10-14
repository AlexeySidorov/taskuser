using System;
using System.IO;
using SQLite;
using Task3.Core.Services;

namespace Task3.iOS.Infrastructure.Services
{
    public class DataBaseService : IDataBaseService
    {
        /// <summary>
        /// Подключение с базой данных
        /// </summary>
        public SQLiteConnection GetConnection(string dbName)
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var libraryPath = Path.Combine(documentsPath, "..", "Library");
            var path = Path.Combine(libraryPath, dbName);
            var conn = new SQLiteConnection(path, SQLiteOpenFlags.ReadWrite);
            return conn;
        }
    }

}
