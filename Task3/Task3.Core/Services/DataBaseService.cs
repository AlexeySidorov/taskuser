using SQLite;

namespace Task3.Core.Services
{
    public interface IDataBaseService
    {
        /// <summary>
        /// Подключение с базой данных
        /// </summary>
        SQLiteConnection GetConnection(string dbName);
    }
}
