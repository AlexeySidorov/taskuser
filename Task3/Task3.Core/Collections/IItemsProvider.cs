using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Task3.Core.Collections
{
    /// <summary>
    /// Represents a provider of collection details.
    /// </summary>
    /// <typeparam name="T">The type of items in the collection.</typeparam>
    public interface ItemsProvider<T>
    {
        /// <summary>
        /// Fetches the total number of items available.
        /// </summary>
        /// <returns></returns>
        Task<int> FetchCount();

        /// <summary>
        /// Fetches a range of items.
        /// </summary>
        /// <param name="startIndex">The start index.</param>
        /// <param name="count">The number of items to fetch.</param>
        /// <returns></returns>
        Task<IList<T>> FetchRange(int startIndex, int count);

        event EventHandler LoadingStart;
        event EventHandler LoadingStop;
        event EventHandler NotLoad;
        event EventHandler<string> Error;
    }
}
