using System.IO;
using SQLite;
using Task3.Core.Services;

namespace Task3.Droid.Infrastructure.Services
{
    public class DataBaseService : IDataBaseService
    {
        /// <summary>
        /// Подключение с базой данных
        /// </summary>
        public SQLiteConnection GetConnection(string dbName)
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, dbName);

            if (!File.Exists(path))
                // ReSharper disable once ObjectCreationAsStatement
                new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);

            return new SQLiteConnection(path);
        }
    }
}
