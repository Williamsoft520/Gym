namespace System.Collections.Generic
{
    /// <summary>
    /// 表示分页集合的默认实例。
    /// </summary>
    /// <typeparam name="T">被分页的类型。</typeparam>
    public class PagedCollection<T> : IPagedCollection<T>
    {
        IEnumerable<T> _pagedList;
        /// <summary>
        /// 初始化 <see cref="PagedCollection{T}"/> 类的新实例。
        /// </summary>
        /// <param name="pagedList">被分页过的集合。</param>
        /// <param name="count">集合的总记录数。</param>
        public PagedCollection(IEnumerable<T> pagedList,int count)
        {
            _pagedList = pagedList;
            this.Count = count;
        }

        /// <summary>
        /// 获取或设置分页的当前页数。
        /// </summary>
        public long CurrentPage { get; set; } = 1;

        /// <summary>
        /// 获取或设置分页时每一页呈现的数据量。
        /// </summary>
        public long ItemsPerPage { get; set; } = 10;

        /// <summary>
        /// 获取分页的总页码数。
        /// </summary>
        public long TotalPages { get; private set; }

        /// <summary>
        /// 获取当前分页的项集合。
        /// </summary>
        public IEnumerable<T> Items => _pagedList;

        /// <summary>
        /// 获取总记录数。
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// 表示对分页总页数的计算方式。
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void ComputePages()
        {
            this.TotalPages = this.Count / this.ItemsPerPage;
            if (this.Count % this.ItemsPerPage != 0)
            {
                this.TotalPages += 1;
            }
        }

        /// <summary>
        /// Gets the enumerator.
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            return _pagedList.GetEnumerator();
        }

        /// <summary>
        /// Gets the enumerator.
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            yield return _pagedList;
        }
    }
}
