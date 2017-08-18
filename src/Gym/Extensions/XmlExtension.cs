using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace System.Xml
{
    /// <summary>
    /// 表示 Xml 相关的扩展。
    /// </summary>
    public static class XmlExtension
    {
        /// <summary>
        /// 对当前的对象实例序列化成符合 xml 格式的字符串形式。
        /// </summary>
        /// <typeparam name="T">可序列化类型。</typeparam>
        /// <param name="instance">可序列化实例。</param>
        /// <param name="namespaces">表示可序列化的命名空间。</param>
        /// <returns>
        /// 若序列化成功，返回符合指定对象的 xml 格式的字符串形式；否则抛出异常。
        /// </returns>
        /// <exception cref="System.InvalidOperationException">序列化当前对象失败。请确保属性的数据类型可以被正确实例化，不支持接口类型。</exception>
        public static string SerializeToXmlString<T>(this T instance,XmlSerializerNamespaces namespaces=null)
        {
            var type = instance.GetType();
            XmlSerializer serializer = new XmlSerializer(type);
            var builder = new StringBuilder();
            using (var xmlWriter = XmlWriter.Create(builder))
            {
                try
                {
                    serializer.Serialize(xmlWriter, instance, namespaces);
                }
                catch (InvalidOperationException ex)
                {
                    throw new InvalidOperationException("序列化当前对象失败。请确保属性的数据类型可以被正确实例化，不支持接口类型。", ex);
                }
                return builder.ToString();
            }
        }
        /// <summary>
        /// 将当前的 Xml 字符串进行反序列化成指定对象。不建议使用自定义的字符串形式，要求 xml 字符串必须与指定对象结构完全相同。
        /// </summary>
        /// <typeparam name="T">可序列化类型。</typeparam>
        /// <param name="xmlString">符合 xml 标准的字符串并且必须和实体的结构大小写字母等都相同。</param>
        /// <returns>
        /// 若成功，返回指定的泛型的实例；否则，抛出异常。
        /// </returns>
        /// <exception cref="System.InvalidOperationException">无法识别有效的 xml 字符串，请确保字符串符合 xml 标准格式</exception>
        public static T DeserializeFromXmlString<T>(this string xmlString)
        {
            var type = typeof(T);
            XmlSerializer serializer = new XmlSerializer(type);
            using (var reader = new StringReader(xmlString))
            {
                using (var xmlReader = XmlReader.Create(reader))
                {
                    try
                    {
                        return serializer.Deserialize(xmlReader).To<T>();
                    }
                    catch (InvalidOperationException ex)
                    {
                        throw new InvalidOperationException("请确保字符串符合 xml 标准格式，同时还应确保 xml 字符串格式符合指定的对象结构。", ex);
                    }
                }
            }
        }

    }
}
