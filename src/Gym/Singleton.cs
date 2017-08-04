namespace System
{
    /// <summary>
    /// 为指定的实例创建有线程安全的单例模式。实例必须有一个公开的，无参数的构造方法，并且能正确的被实例化。
    /// </summary>
    /// <remarks>有关单例模式请参见 https://www.codeproject.com/kb/architecture/genericsingletonpattern.aspx </remarks>
    /// <typeparam name="T">单例的实例。</typeparam>
    public static class Singleton<T>
       where T : class
    {
        static volatile T _instance;
        static object _lock = new object();

        /// <summary>
        /// 为指定对象创建实例。
        /// </summary>
        public static T CreateInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = Activator.CreateInstance<T>();
                    }
                }
            }
            return _instance;
        }
    }
}
