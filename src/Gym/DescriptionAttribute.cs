namespace System
{
    /// <summary>
    /// 表示修饰字段的描述特性。
    /// </summary>
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = false)]
    public class DescriptionAttribute : Attribute
    {
        /// <summary>
        /// 初始化 <see cref="DescriptionAttribute"/> 类的新实例。
        /// </summary>
        public DescriptionAttribute() : this(string.Empty)
        {

        }

        /// <summary>
        /// 初始化 <see cref="DescriptionAttribute"/> 类的新实例。
        /// </summary>
        /// <param name="description">描述信息。</param>
        public DescriptionAttribute(string description)
        {
            this.Description = description;
        }
        /// <summary>
        /// 获取特性的描述。
        /// </summary>
        public string Description { get; private set; } = string.Empty;
    }
}
