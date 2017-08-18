namespace System.Collections.Generic
{
    /// <summary>
    /// 提供可用分页逻辑表示的元素强类型。
    /// </summary>
    /// <typeparam name="T">元素类型。</typeparam>
    public interface IPagedCollection<out T>:IReadOnlyCollection<T>
    {
        /// <summary>
        /// 获取分页的当前页数。
        /// </summary>
        long CurrentPage { get; }
        /// <summary>
        /// 获取分页时每一页呈现的数据量。
        /// </summary>
        long ItemsPerPage { get; }
        /// <summary>
        /// 获取分页的总页码数。
        /// </summary>
        long TotalPages { get; }

        /// <summary>
        /// 获取当前分页的项集合。
        /// </summary>
        IEnumerable<T> Items { get; }

        /// <summary>
        /// 表示对分页总页数的计算方式。
        /// </summary>
        void ComputePages();
    }
}
