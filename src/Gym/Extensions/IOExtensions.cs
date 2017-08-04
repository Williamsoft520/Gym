namespace System.IO
{
    /// <summary>
    /// 对 IO 流的扩展实例。
    /// </summary>
    public static class IOExtensions
    {
        /// <summary>
        /// 若指定的目录不存在，则尝试创建一个新目录。
        /// </summary>
        /// <param name="directory"><see cref="DirectoryInfo"/> 的扩展实例。</param>
        /// <exception cref="IOException">无法正确地在指定目录创建一个新目录。</exception>
        public static void CreateIfNotExist(this DirectoryInfo directory)
        {
            if (!directory.Exists)
            {
                directory.Create();
            }
        }
        /// <summary>
        /// 若指定的文件不存在，则尝试创建一个新文件。
        /// </summary>
        /// <param name="file"><see cref="FileInfo"/> 的扩展实例。</param>
        public static void CreateIfNotExist(this FileInfo file)
        {
            if (!file.Exists)
            {
                file.Create();
            }
        }
    }
}
