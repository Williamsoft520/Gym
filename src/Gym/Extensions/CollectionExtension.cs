using System.Collections.Generic;

namespace System
{
    /// <summary>
    /// 表示为集合实例的扩展。
    /// </summary>
    public static class CollectionExtension
    {
        #region Merge

        /// <summary>
        /// 若指定键不存在字典中，则将该键值对添加到字典中；否则不进行任何操作。
        /// </summary>
        /// <typeparam name="TKey">字典中键的类型。</typeparam>
        /// <typeparam name="TValue">字典中值的类型。</typeparam>
        /// <param name="dictionary">被扩展的IDictionary实例。</param>
        /// <param name="key">用作要添加元素的键的对象。</param>
        /// <param name="value">用作要添加元素的值的对象。</param>
        /// <returns>若键已存在，则为 true；否则为 false。</returns>
        public static bool AddIfNotContains<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue value)
        {
            if (!dictionary.ContainsKey(key))
            {
                dictionary.Add(key, value);
                return true;
            }
            return false;
        }

        /// <summary>
        /// 合并指定键中相同的值，若该键不存在，则抛出 <see cref="KeyNotFoundException" /> 异常。
        /// </summary>
        /// <typeparam name="TKey">字典中键的类型</typeparam>
        /// <param name="dictionary">被扩展的IDictionary实例。</param>
        /// <param name="key">用作要合并的元素的键的对象。</param>
        /// <param name="value">作为要合并的值。</param>
        /// <exception cref="ArgumentNullException">key</exception>
        /// <exception cref="KeyNotFoundException">字典中的键无法找到。</exception>
        public static void Merge<TKey>(this IDictionary<TKey, object> dictionary, TKey key, object value)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key), "指定的键不能使 null 值。");
            }

            if (!dictionary.ContainsKey(key))
            {
                throw new KeyNotFoundException("无法找到键 {0}。".StringFormat(key));
            }
            dictionary[key] = string.Concat(dictionary[key], value);
        }

        /// <summary>
        /// 若指定字典中的键存在，则将值进行合并；否则将该键值对添加到字典中。
        /// </summary>
        /// <typeparam name="TKey">字典中键的类型</typeparam>
        /// <param name="dictionary">被扩展的IDictionary实例。</param>
        /// <param name="key">用作要添加或合并元素的键的对象。</param>
        /// <param name="value">用作要添加或合并元素的值。</param>
        /// <exception cref="ArgumentNullException">key</exception>
        public static void AddOrMerge<TKey>(this IDictionary<TKey, object> dictionary, TKey key, object value)
        {
            if (!dictionary.AddIfNotContains(key, value))
            {
                dictionary.Merge(key, value);
            }
        }
        #endregion

        #region GetOrDefault
        /// <summary>
        /// 获取字典中的值并转换成期望值，当指定字典中不存在指定键时，返回默认类型的默认值。
        /// </summary>
        /// <typeparam name="TKey">字典中键的类型</typeparam>
        /// <typeparam name="TValue">字典中值的类型</typeparam>
        /// <param name="dictionary"><see cref="IDictionary{TKey, TValue}"/>类的实例扩展。</param>
        /// <param name="key">在字典中存在的键。</param>
        /// <param name="defaultValue">当字典键中不存在时设置的默认值。</param>
        /// <returns>若字典中的键存在，则返回指定字典值的指定类型，否则返回指定类型的默认值。</returns>
        public static TValue GetOrDefault<TKey, TValue>(this IDictionary<TKey, object> dictionary, TKey key, TValue defaultValue)
        {
            object value;
            if (dictionary.TryGetValue(key, out value))
            {
                return value.To(defaultValue);
            }

            return defaultValue;
        }

        /// <summary>
        /// 获取字典中的值并转换成期望值，当指定字典中不存在指定键时，返回默认类型的默认值。
        /// </summary>
        /// <typeparam name="TKey">字典中键的类型</typeparam>
        /// <typeparam name="TValue">字典中值的类型</typeparam>
        /// <param name="dictionary"><see cref="IDictionary{TKey, TValue}"/>类的实例扩展。</param>
        /// <param name="key">在字典中存在的键。</param>
        /// <returns>若字典中的键存在，则返回指定字典值的指定类型，否则返回指定类型的默认值。</returns>
        public static TValue GetOrDefault<TKey, TValue>(this IDictionary<TKey, object> dictionary, TKey key) => dictionary.GetOrDefault(key, default(TValue));        
        #endregion

        #region ForEach
        /// <summary>
        /// 对当前的集合进行遍历。
        /// </summary>
        /// <typeparam name="T">遍历的类型。</typeparam>
        /// <param name="enumerable">当前集合的实例扩展。</param>
        /// <param name="action">在遍历中的操作委托。该委托接受一个参数，表示当前遍历的对象。</param>
        /// <exception cref="System.ArgumentNullException">action</exception>
        /// <example>
        ///   <c>list.ForEach(item=&gt;
        /// {
        /// //to do...
        /// });</c>
        /// </example>
        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }
            foreach (var item in enumerable)
            {
                action(item);
            }
        }
        #endregion


        #region Join
        /// <summary>
        /// 串联类型为 System.String 的 System.Collections.Generic.IEnumerable`1 构造集合的成员，其中在每个成员之间使用指定的分隔符。
        /// </summary>
        /// <typeparam name="T">指定的数据类型。</typeparam>
        /// <param name="values">一个包含多个连接对象的集合。</param>
        /// <param name="seperator">将用作分隔符的字符串。只有当值具有多个元素时，分隔符才包含在返回的字符串中。</param>
        /// <returns>
        /// 一个由 values 的成员组成的字符串，这些成员以 separator 字符串分隔。
        /// </returns>
        public static string Join<T>(this IEnumerable<T> values, string seperator) => string.Join(seperator, values);

        #endregion
        


    }
}
