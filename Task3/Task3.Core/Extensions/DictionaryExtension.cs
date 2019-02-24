using System;
using System.Collections.Generic;
using MvvmCross.Platform;

namespace Task3.Core.Extensions
{
    public static class DictionaryExtension
    {
        /// <summary>
        /// KeyByIndex
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dict"></param>
        /// <param name="idx"></param>
        /// <returns></returns>
        public static TKey KeyByIndex<TKey, TValue>(this IDictionary<TKey, TValue> dict, int idx)
        {
            var type = typeof(Dictionary<TKey, TValue>);
            var info = type.GetField("entries", BindingFlags.Instance);

            if (info != null)
            {
                // .NET
                var element = ((Array)info.GetValue(dict)).GetValue(idx);
                return (TKey)element.GetType().GetField("key", BindingFlags.Public | BindingFlags.Instance).GetValue(element);
            }

            // Mono:
            info = type.GetField("keySlots", BindingFlags.Instance);
            return (TKey)((Array)info.GetValue(dict)).GetValue(idx);
        }

        /// <summary>
        /// KeyByIndex
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dict"></param>
        /// <param name="idx"></param>
        /// <returns></returns>
        public static TKey KeyByIndex<TKey, TValue>(this Dictionary<TKey, TValue> dict, int idx)
        {
            var type = typeof(Dictionary<TKey, TValue>);
            var info = type.GetField("entries", BindingFlags.Instance);

            if (info != null)
            {
                // .NET
                var element = ((Array)info.GetValue(dict)).GetValue(idx);
                return (TKey)element.GetType().GetField("key", BindingFlags.Public | BindingFlags.Instance).GetValue(element);
            }

            // Mono:
            info = type.GetField("keySlots", BindingFlags.Instance);
            return (TKey)((Array)info.GetValue(dict)).GetValue(idx);
        }
    }
}
