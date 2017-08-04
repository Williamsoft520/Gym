using System.Collections.Generic;

namespace System
{
    /// <summary>
    /// 提供使用分页的集合。
    /// </summary>
    /// <typeparam name="T">分页数据对象。</typeparam>
    public interface IPagedCollection<out T>:IReadOnlyCollection<T>
    {
        /// <summary>
        /// 获取当前页码。
        /// </summary>
        int CurrentPage { get; }
        /// <summary>
        /// 获取每一页所呈现的数据数。
        /// </summary>
        int ItemsPerPage { get; }
        /// <summary>
        /// 获取当前页码的分页数据集合。
        /// </summary>
        IEnumerable<T> Items { get; }
        /// <summary>
        /// 对总页码进行计算。
        /// </summary>
        /// <returns></returns>
        int CalculateTotalPages();
    }
}
