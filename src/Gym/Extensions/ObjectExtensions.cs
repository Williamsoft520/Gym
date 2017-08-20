using System.Reflection;

namespace System
{
    /// <summary>
    /// 表示为 Object 的扩展。
    /// </summary>
    public static class ObjectExtensions
    {
        #region To
        /// <summary>
        /// 将当前对象转换成指定泛型的类型，可以指定一个默认值，当转换不成功将返回指定默认值。
        /// </summary>
        /// <example>
        /// <c>
        /// string a="1";
        /// var b = a.To&lt;bool>(); // 输出 false
        /// var c =a.To&lt;boo>(true); 输出 true
        /// </c>
        /// </example>
        /// <typeparam name="T">支持对 <see cref="IConvertible"/> 的实例类型。</typeparam>
        /// <param name="value">支持数据类型转换的对象。</param>
        /// <param name="defaultValue">表示数据类型转换失败时返回的默认值。 </param>
        /// <returns>若数据类型转换成功，则返回泛型的指定类型的值；否则返回指定的默认值。</returns>
        public static T To<T>(this object value, T defaultValue)
        {
            try
            {
                return value.To<T>();
            }
            catch
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// 将当前对象转换成指定泛型的类型。若转换失败，将抛出异常。
        /// </summary>
        /// <typeparam name="T">转换的实例类型。</typeparam>
        /// <param name="value">支持数据类型转换的对象。</param>
        /// <returns>成功进行数据类型转换的值。</returns>
        /// <exception cref="ArgumentNullException">value - 当前对象不能是 null 值。</exception>
        /// <exception cref="InvalidCastException">
        /// 为可空类型进行类型转换失败，请确保要转换的类型支持可空类型。
        /// or
        /// 给定的值无法被成功转换
        /// </exception>
        public static T To<T>(this object value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value), "当前对象不能是 null 值。");
            }

            var type = typeof(T);

            if (value.GetType() == type)//同一个类型不需要转换
            {
                return (T)value;
            }


            if (type.GetTypeInfo().IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))//可空类型转换
            {
                try
                {
                    return (T)Convert.ChangeType(value, Nullable.GetUnderlyingType(type));
                }
                catch
                {
                    throw new InvalidCastException("为可空类型进行类型转换失败，请确保要转换的类型支持可空类型。");
                }
            }

            try
            {
                return (T)Convert.ChangeType(value, typeof(T));
            }
            catch(Exception ex)
            {
                throw new InvalidCastException("指定的转换无效。", ex);
            }
        }
        #endregion
    }
}
