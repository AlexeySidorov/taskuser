using Object = Java.Lang.Object;

namespace Task3.Droid.Infrastructure.Converters
{
    public static class ConvertJavaObject
    {
        /// <summary>
        /// Конвертировать T в Java.Lang.Object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Object ConvertObjectToJavaObject<T>(T obj)
        {
            return new JavaObjectWrapper<T>() { Obj = obj };
        }

        /// <summary>
        /// Cast
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T Cast<T>(this Object obj) where T : class
        {
            var propertyInfo = obj.GetType().GetProperty("Instance");
            return propertyInfo?.GetValue(obj, null) as T;
        }
    }

    public class JavaObjectWrapper<T> : Object
    {
        public T Obj { get; set; }
    }
}