using System.Collections.Generic;
using System.Threading.Tasks;
using Plugin.Connectivity.Abstractions;

namespace Task3.Core.Services
{
    public interface IConnectionService
    {
        /// <summary>
        /// Активно ли соедиение с интернетом
        /// </summary>
        bool IsConnected { get; }

        /// <summary>
        /// Тип соединения
        /// </summary>
        IEnumerable<ConnectionType> ConnectionTypes { get; }

        /// <summary>
        /// Проверка доступности удаленного адресса
        /// </summary>
        /// <param name="host"></param>
        /// <param name="port"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        Task<bool> IsConnectedHost(string host, int port = 80, int timeout = 5000);
    }
}
