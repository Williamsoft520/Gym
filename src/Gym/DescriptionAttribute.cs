namespace System
{
    /// <summary>
    /// 表示对象的描述。
    /// </summary>
    [AttributeUsage(AttributeTargets.All,AllowMultiple =false,Inherited =false)]
    public class DescriptionAttribute:Attribute
    {
        /// <summary>
        /// 初始化 <see cref="DescriptionAttribute"/> 类的新实例。
        /// </summary>
        /// <param name="description">对于该对象的任意描述字符串。</param>
        public DescriptionAttribute(string description)
        {
            this.Description = description;
        }

        /// <summary>
        /// 获取指定对象的描述内容。
        /// </summary>
        public string Description { get;private set; }
    }
}