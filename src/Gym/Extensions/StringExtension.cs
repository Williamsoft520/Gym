using System.Text;
using System.Text.RegularExpressions;

namespace System
{
    /// <summary>
    /// 表示提供对 <see cref="String"/> 实例的扩展。
    /// </summary>
    public static class StringExtension
    {
        #region IsNullOrEmpty
        /// <summary>
        /// 判断当前的字符串是 null 还是 System.String.Empty 字符串。
        /// </summary>
        /// <param name="value">当前的字符串对象。</param>
        /// <example><code>var flag="text".IsNullOrEmpty();// return false;</code></example>
        /// <returns>如果 value 参数为 null 或空字符串 ("")，则为 true；否则为 false。</returns>
        public static bool IsNullOrEmpty(this string value) => string.IsNullOrEmpty(value);
        #endregion

        #region IsNullOrWhiteSpace
        /// <summary>
        /// 判断当前的字符串是 null, System.String.Empty 字符串还是空白字符。
        /// </summary>
        /// <example>
        /// <code>
        /// var flag="text".IsNullOrWhiteSpace();// return false;
        /// var flag=" ".IsNullOrWhiteSpace();// return true;
        /// </code>
        /// </example>
        /// <param name="value">当前的字符串对象。</param>
        /// <returns>如果 value 参数为 null ，空字符串 ("")或空白字符串，则为 true；否则为 false。</returns>
        public static bool IsNullOrWhiteSpace(this string value) => string.IsNullOrWhiteSpace(value);
        #endregion

        #region IsMatch
        /// <summary>
        /// 判断当前字符串是否与指定模式所匹配。其他高级模式匹配功能请使用 <see cref="Regex"/> 相关实例。
        /// </summary>
        /// <param name="value">表示当前需要进行模式匹配的字符串。</param>
        /// <param name="pattern">表示进行模式匹配方式的字符串形式。</param>
        /// <returns>如果匹配，返回 true；否则返回 false。</returns>
        /// <seealso cref="Regex"/>
        public static bool IsMatch(this string value, string pattern) => Regex.IsMatch(value, pattern);
        #endregion

        #region StringFormat
        /// <summary>
        ///  将当前字符串中的格式项替换为指定数组中相应对象的字符串表示形式。
        /// </summary>
        /// <param name="format">当前的字符串对象。</param>
        /// <param name="args">字符串format 的一个副本，其中格式项已替换为 args 中相应对象的字符串表示形式。</param>
        /// <example>
        /// <code>
        /// var formatString="这是{0}的示例".StringFormat("自定义数据"); // 输出 这是自定义数据的示例
        /// //同等于
        /// var formatString=string.StringFormat("这是{0}的示例","自定义数据");
        ///
        /// //同样支持多个参数
        /// var formatString="{0} + {1} = {2}".StringFormat(1,2,3); // 输出 1 + 2 = 3
        /// </code>
        /// </example>
        /// <returns>字符串 format 的一个副本，其中格式项已替换为 args 中相应对象的字符串表示形式。</returns>
        public static string StringFormat(this string format, params object[] args) => string.Format(format, args);

        /// <summary>
        /// 将当前字符串中的格式项替换为指定对象的字符串表示形式。
        /// </summary>
        /// <param name="format">一种带有格式的字符串。</param>
        /// <param name="arg0">符合格式化字符串副本所需替换的对象。</param>
        /// <returns>字符串format 的一个副本，其中格式项已替换为 arg0 中相应对象的字符串表示形式。</returns>
        /// <exception cref="ArgumentNullException">当前字符串对象是 null。</exception>
        /// <exception cref="FormatException">无效的格式化字符串或格式化字符串中的下标不是0.</exception>
        public static string StringFormat(this string format, object arg0) => string.Format(format, arg0);

        /// <summary>
        /// 将当前字符串中的格式项替换为指定对象的字符串表示形式。
        /// </summary>
        /// <param name="format">一种带有格式的字符串。</param>
        /// <param name="arg0">第一个符合格式化字符串副本所需替换的对象。</param>
        /// <param name="arg1">第二个符合格式化字符串副本所需替换的对象。</param>
        /// <returns>字符串format 的一个副本，其中格式项已替换为 arg0 和 arg1 中相应对象的字符串表示形式。</returns>
        /// <exception cref="ArgumentNullException">当前字符串对象是 null。</exception>
        /// <exception cref="FormatException">无效的格式化字符串或格式化字符串中的下标不是 0 和 1.</exception>
        public static string StringFormat(this string format, object arg0, object arg1) => string.Format(format, arg0, arg1);

        /// <summary>
        /// 将当前字符串中的格式项替换为指定对象的字符串表示形式。
        /// </summary>
        /// <param name="format">一种带有格式的字符串。</param>
        /// <param name="arg0">第一个符合格式化字符串副本所需替换的对象。</param>
        /// <param name="arg1">第二个符合格式化字符串副本所需替换的对象。</param>
        /// <param name="arg2">第三个符合格式化字符串副本所需替换的对象。</param>
        /// <returns>字符串format 的一个副本，其中格式项已替换为 arg0 、 arg1 和 arg2 中相应对象的字符串表示形式。</returns>
        /// <exception cref="ArgumentNullException">当前字符串对象是 null。</exception>
        /// <exception cref="FormatException">无效的格式化字符串或格式化字符串中的下标不是 0 、1 和 2。</exception>
        public static string StringFormat(this string format, object arg0, object arg1, object arg2) => string.Format(format, arg0, arg1, arg2);
        /// <summary>
        /// 将当前字符串中的格式项替换为指定对象的字符串表示形式。
        /// </summary>
        /// <param name="format">一种带有格式的字符串。</param>
        /// <param name="provider">一种格式化器。</param>
        /// <param name="args">字符串format 的一个副本，其中格式项已替换为 args 中相应对象的字符串表示形式。</param>
        /// <returns>字符串 format 的一个副本，其中格式项已替换为 args 中相应对象的字符串表示形式。</returns>
        public static string StringFormat(this string format, IFormatProvider provider, params object[] args) => string.Format(provider, format, args);
        #endregion

        #region ToBase64
        /// <summary>
        /// 将当前字符串转换为其用 Base64 数字编码的等效字符串表示形式。
        /// </summary>
        /// <param name="value">需要转换的字符串。</param>
        /// <param name="encoding">字符编码对象。若为null，则使用 UTF-8 代码页的编码。</param>
        /// <returns>
        /// 字符串 value 的一个副本，将使用指定的字符串格式对其进行 Base64 编码。
        /// </returns>
        /// <exception cref="ArgumentNullException">value - 请确保当前的字符串对象不是 null 值。</exception>
        /// <exception cref="NotSupportedException">当前指定字符串不支持对 Base64 编码的转换。</exception>
        public static string ToBase64String(this string value, Encoding encoding = null)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value), "请确保当前的字符串对象不是 null 值。");
            }

            try
            {
                byte[] buffer = value.ToBytes(encoding);
                return Convert.ToBase64String(buffer);

            }
            catch (Exception ex)
            {
                throw new NotSupportedException("当前的字符串形式不支持 Base64 格式进行编码，请查看内部异常获取更多信息。", ex);
            }
        }
        #endregion

        #region FromBase64
        /// <summary>
        /// 将当前字符串（它将二进制数据编码为 Base64 数字）转换为等效的字符串。
        /// </summary>
        /// <param name="value">符合 Base64 编码格式的字符串。</param>
        /// <param name="encoding">字符编码对象。若为 null，则使用 UTF-8 代码页的编码。</param>
        /// <returns>
        /// 符合给定 Base64 编码格式的等效字符串。
        /// </returns>
        /// <exception cref="ArgumentNullException">value - 请确保当前的字符串对象不是 null 值。</exception>
        /// <exception cref="NotSupportedException">当前指定字符串不支持对 Base64 编码的转换。</exception>
        public static string FromBase64String(this string value, Encoding encoding = null)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value), "请确保当前的字符串对象不是 null 值。");
            }

            try
            {
                byte[] buffer = Convert.FromBase64String(value);
                return buffer.FromBytes(encoding);
            }
            catch (Exception ex)
            {
                throw new NotSupportedException("当前字符串不是有效的 Base64 编码形式，请查看内部异常获取更多信息。", ex);
            }
        }
        #endregion

        #region ToBytes
        /// <summary>
        /// 将当前字符串转换成指定编码格式的字节数组形式。
        /// </summary>
        /// <param name="value">当前操作的字符串。</param>
        /// <param name="encoding">字符编码对象。若为 null，则使用 UTF-8 编码格式。</param>
        /// <returns>等效于字符串的字节数组。</returns>
        public static byte[] ToBytes(this string value, Encoding encoding = null)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            return encoding.Utf8IfNull().GetBytes(value);
        }
        #endregion

        #region FromBytes
        /// <summary>
        /// 从指定的字节数组中恢复成等效的字符串形式。
        /// </summary>
        /// <param name="bytes">字节数组。</param>
        /// <param name="encoding">字符编码对象。若为 null，则使用 UTF-8 编码格式。</param>
        /// <returns>等效于字节数组的字符串。</returns>
        public static string FromBytes(this byte[] bytes,Encoding encoding = null)
        {
            if (bytes == null)
            {
                throw new ArgumentNullException(nameof(bytes));
            }

            return encoding.Utf8IfNull().GetString(bytes, 0, bytes.Length);
        }
        #endregion

        //#region Deserialize
        ///// <summary>
        ///// 将当前的 Xml 字符串进行反序列化成指定对象。不建议使用自定义的字符串形式，要求 xml 字符串必须与指定对象结构完全相同。
        ///// </summary>
        ///// <typeparam name="T">可序列化类型。</typeparam>
        ///// <param name="xmlString">符合 xml 标准的字符串并且必须和实体的结构大小写字母等都相同。</param>
        ///// <returns>
        ///// 若成功，返回指定的泛型的实例；否则，抛出异常。
        ///// </returns>
        ///// <exception cref="System.InvalidOperationException">无法识别有效的 xml 字符串，请确保字符串符合 xml 标准格式</exception>
        //public static T DeserializeFromXml<T>(this string xmlString)
        //{
        //    var type = typeof(T);

        //    XmlSerializer serializer = new XmlSerializer(type);
        //    var bytes = Encoding.UTF8.GetBytes(xmlString);
        //    using (var reader = new StringReader(xmlString))
        //    {
        //        using (var xmlReader = XmlReader.Create(reader))
        //        {
        //            try
        //            {
        //                return serializer.Deserialize(xmlReader).To<T>();
        //            }
        //            catch (InvalidOperationException ex)
        //            {
        //                throw new InvalidOperationException("请确保字符串符合 xml 标准格式，同时还应确保 xml 字符串格式符合指定的对象结构。", ex);
        //            }
        //        }
        //    }
        //}
        //#endregion

        //#region Serialize
        ///// <summary>
        ///// 对当前的对象实例序列化成符合 xml 格式的字符串形式。
        ///// </summary>
        ///// <typeparam name="T">可序列化类型。</typeparam>
        ///// <param name="instance">可序列化实例。</param>
        ///// <returns>
        ///// 若序列化成功，返回符合指定对象的 xml 格式的字符串形式；否则抛出异常。
        ///// </returns>
        ///// <exception cref="System.InvalidOperationException">序列化当前对象失败。请确保属性的数据类型可以被正确实例化，不支持接口类型。</exception>
        //public static string SerializeToXml<T>(this T instance)
        //{
        //    var type = instance.GetType();
        //    XmlSerializer serializer = new XmlSerializer(type);
        //    var builder = new StringBuilder();
        //    using (var xmlWriter = XmlWriter.Create(builder))
        //    {
        //        try
        //        {
        //            serializer.Serialize(xmlWriter, instance);
        //        }
        //        catch (InvalidOperationException ex)
        //        {
        //            throw new InvalidOperationException("序列化当前对象失败。请确保属性的数据类型可以被正确实例化，不支持接口类型。", ex);
        //        }
        //        return builder.ToString();
        //    }
        //}
        //#endregion


        //#region v2.0
        ///// <summary>
        ///// 获取 app.config/web.config 的 ConnectionStrings 节点中以当前字符串作为 name 的 connectionString 属性的值。
        ///// </summary>
        ///// <param name="value">ConnectionStrings 节点中符合 name 的值。</param>
        ///// <returns>符合当前字符串的 name 的 connectionString 属性的值。</returns>
        //public static string ConnectionString(this string value)
        //{
        //    return ConfigurationManager.ConnectionStrings[value].ConnectionString;
        //}

        ///// <summary>
        ///// 获取 app.config/web.config 的 AppSettings 节点中以当前字符串作为 key 的 value 属性的值。
        ///// </summary>
        ///// <param name="value">AppSettings 节点中符合 key 的值。</param>
        ///// <returns>符合当前字符串的 key 的 value 属性的值。</returns>
        //public static string AppSetting(this string value)
        //{
        //    return ConfigurationManager.AppSettings[value];
        //}

        ///// <summary>
        ///// 获取 app.config/web.config 的 AppSettings 节点中以当前字符串作为 key 的 value 属性的值。
        ///// </summary>
        ///// <param name="value">AppSettings 节点中符合 key 的值。</param>
        ///// <returns>符合当前字符串的 key 的 value 属性的值。</returns>
        //public static T AppSetting<T>(this string value)
        //{
        //    return value.AppSetting().To<T>();
        //}
        //#endregion

        #region Utf8IfNull
        /// <summary>
        /// 获取一个编码值，若编码为 null 时，将使用 UTF-8 作为默认编码。
        /// </summary>
        /// <param name="encoding">扩展的 <see cref="Encoding"/> 实例。</param>
        /// <returns>若指定编码是 null，则使用 utf-8 作为编码值，否则为指定的编码值。</returns>
        public static Encoding Utf8IfNull(this Encoding encoding) => encoding ?? Encoding.UTF8;
        #endregion

        #region Substring
        /// <summary>
        /// 从此实例检索子字符串。子字符串从指定的字符位置开始且具有指定的长度，并在末尾追加指定字符串。
        /// </summary>
        /// <param name="value">当前字符串。</param>
        /// <param name="startIndex">此实例中子字符串的起始字符位置（从零开始）。</param>
        /// <param name="length">子字符串中的字符数。</param>
        /// <param name="append">在末尾追加的字符串。</param>
        /// <returns>与此实例中在 length 处开头、长度为 startIndex 的子字符串等效的一个字符串；如果 System.String.Empty 等于此实例的长度且
        ///     startIndex 为零，则为 length。
        ///     </returns>
        public static string Substring(this string value, int startIndex, int length, string append)
        {
            if (value.Length < length)
            {
                throw new ArgumentOutOfRangeException(value, "指定的长度超过了当前字符串长度");
            }

            return "{0}{1}".StringFormat(value.Substring(startIndex, length), append);
        }


        /// <summary>
        /// 从此实例检索子字符串。子字符串在指定的字符位置开始并一直到该字符串的末尾，并在末尾追加指定字符串。
        /// </summary>
        /// <param name="value">当前字符串。</param>
        /// <param name="startIndex">此实例中子字符串的起始字符位置（从零开始）。</param>
        /// <param name="append">在末尾追加的字符串。</param>
        /// <returns>与此实例中在 length 处开头、长度为 startIndex 的子字符串等效的一个字符串；如果 System.String.Empty 等于此实例的长度且
        ///     startIndex 为零，则为 length。
        ///     </returns>
        public static string Substring(this string value,int startIndex,string append)
        {
            return value.Substring(startIndex, value.Length, append);
        }
        #endregion
    }
}
