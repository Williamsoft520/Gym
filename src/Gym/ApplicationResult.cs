using System.Collections.Generic;
using System.Linq;

namespace System
{
    /// <summary>
    /// 表示应用程序在执行后的结果。
    /// </summary>
    public class ApplicationResult
    {
        static readonly ApplicationResult _success = new ApplicationResult(true);

        /// <summary>
        /// 初始化 <see cref="ApplicationResult"/> 类的新实例。
        /// </summary>
        /// <param name="success">表示应用程序执行的结果是否成功。</param>
        protected ApplicationResult(bool success)
        {
            this.Succeeded = success;
        }

        /// <summary>
        /// 使用带有错误的字符串数组初始化 <see cref="ApplicationResult"/> 类的新实例。
        /// </summary>
        /// <param name="errors">可选的错误字符串数组。</param>
        public ApplicationResult(params string[] errors)
            : this(errors.AsEnumerable())
        {

        }

        /// <summary>
        /// 使用带有错误的字符串集合初始化 <see cref="ApplicationResult"/> 类的新实例。
        /// </summary>
        /// <param name="errors">错误字符串集合。</param>
        public ApplicationResult(IEnumerable<string> errors)
            : this(false)
        {
            this.Errors = errors;
        }

        /// <summary>
        /// 获取一个布尔值，表示当前的执行是否成功。
        /// </summary>
        /// <value>
        ///   若执行成功，则为 <c>true</c>；否则为 <c>false</c>。
        /// </value>
        public bool Succeeded { get; private set; }

        /// <summary>
        /// 获取一个字符串集合，表示返回的错误信息。
        /// </summary>
        /// <value>
        /// 这是一个集合，包含所有的错误信息。
        /// </value>
        public IEnumerable<string> Errors { get; private set; }

        /// <summary>
        /// 表示当前操作执行成功。
        /// </summary>
        public static ApplicationResult Success => _success;

        /// <summary>
        /// 表示当前操作执行失败。
        /// </summary>
        /// <param name="errors">因导致失败的错误字符串数组。</param>
        /// <returns>当前的 <see cref="ApplicationResult"/> 实例。</returns>
        public static ApplicationResult Failed(params string[] errors) => new ApplicationResult(errors);

        /// <summary>
        /// 表示当前操作执行失败。
        /// </summary>
        /// <param name="errors">因导致失败的错误字符串集合。</param>
        /// <returns>当前的 <see cref="ApplicationResult"/> 实例。</returns>
        public static ApplicationResult Failed(IEnumerable<string> errors)
            => Failed(errors.ToArray());
    }


    /// <summary>
    /// 表示应用程序在执行后的结果并附带自定义对象。
    /// </summary>
    /// <typeparam name="T">一个可在结果返回的数据类型。</typeparam>
    /// <seealso cref="System.ApplicationResult" />
    public class ApplicationResult<T> : ApplicationResult
    {
        /// <summary>
        /// 使用自定义数据初始化 <see cref="ApplicationResult{T}"/> 类的新实例。
        /// </summary>
        /// <param name="data">这是返回的数据。</param>
        protected ApplicationResult(T data)
        {
            this.Data = data;
        }

        /// <summary>
        /// 获取一个泛型的值，表示应用程序成功或失败时所需要的任意数据值。
        /// </summary>
        /// <value>
        /// 任意数据。
        /// </value>
        public T Data { get; private set; }

        /// <summary>
        /// 设置成功或失败时想要在返回时获取的数据。
        /// </summary>
        /// <param name="data">要设置的数据。</param>
        /// <returns><see cref="ApplicationResult{T}"/> 实例。</returns>
        public static ApplicationResult SetData(T data)
            => new ApplicationResult<T>(data);
    }
}
