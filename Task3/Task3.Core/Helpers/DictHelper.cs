using System.Collections.Generic;
using System.Linq;
using Task3.Core.Extensions;

namespace Task3.Core.Helpers
{
    public static class DictHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dict"></param>
        /// <returns></returns>
        public static string AllMessage(IDictionary<string, string[]> dict)
        {
            var message = string.Empty;

            for (var index = 0; index < dict.Count; index++)
            {
                var space = index == 0 ? string.Empty : ", ";
                var values = dict[dict.KeyByIndex(index)];

                message = values.Aggregate(message, (current, t) => current + $"{space}{t}");
            }

            return message;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dict"></param>
        /// <returns></returns>
        public static string AllMessage(Dictionary<string, string[]> dict)
        {
            var message = string.Empty;

            for (var index = 0; index < dict.Count; index++)
            {
                var space = index == 0 ? string.Empty : ", ";
                var values = dict[dict.KeyByIndex(index)];

                for (var indexValue = 0; indexValue < values.Count(); indexValue++)
                    message += $"{space}{values[index]}";
            }

            return message;
        }
    }
}
