using System.Collections.Generic;
using System.Threading.Tasks;
using Plugin.Connectivity;
using Plugin.Connectivity.Abstractions;
using Task3.Core.Services;

namespace Task3.Droid.Infrastructure.Services
{
    public class ConnectionService : IConnectionService
    {
        /// <summary>
        /// Активно ли соедиение с интернетом
        /// </summary>
        public bool IsConnected => CrossConnectivity.Current.IsConnected;


        /// <summary>
        /// Тип соединения
        /// </summary>
        public IEnumerable<ConnectionType> ConnectionTypes => CrossConnectivity.Current.ConnectionTypes;
        
        /// <summary>
        /// Проверка доступности удаленного адресса
        /// </summary>
        /// <param name="host"></param>
        /// <param name="port"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public async Task<bool> IsConnectedHost(string host, int port = 80, int timeout = 5000)
        {
            return await CrossConnectivity.Current.IsRemoteReachable(host, port, timeout);
        }
    }
}
