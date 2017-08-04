using System.Collections;
using System.Collections.Generic;

namespace System
{
    /// <summary>
    /// 表示被分页的集合。
    /// </summary>
    /// <typeparam name="T">分页对象类型。</typeparam>
    public class PagedCollection<T> :IPagedCollection<T>
    {
        IEnumerable<T> _pagedItems;

        /// <summary>
        /// 初始化 <see cref="PagedCollection{T}"/> 类的新实例。
        /// </summary>
        /// <param name="pagedItems">已经被分页好的集合对象。</param>
        /// <param name="page">当前所属的页码。</param>
        /// <param name="itemsPerPage">每一页希望呈现的数据量。</param>
        /// <param name="records">总记录数。</param>
        public PagedCollection(IEnumerable<T> pagedItems, int page, int itemsPerPage, int records)
        {
            _pagedItems = pagedItems;
            this.CurrentPage = page;
            this.ItemsPerPage = itemsPerPage;
            this.Count = records;
        }
        /// <summary>
        /// 获取当前页码。
        /// </summary>
        public int CurrentPage
        {
            get;private set;
        }
        
        /// <summary>
        /// 获取每一页呈现的数据量。
        /// </summary>
        public int ItemsPerPage
        {
            get; private set;
        }
        /// <summary>
        /// 获取总记录数。
        /// </summary>
        public int Count
        {
            get; private set;
        }

        /// <summary>
        /// 获取已分页的集合。
        /// </summary>
        public IEnumerable<T> Items
        {
            get { return _pagedItems; }
        }

        /// <summary>
        /// 计算总页数。
        /// </summary>
        /// <returns>被计算好的总页数。</returns>
        public int CalculateTotalPages()
        {
            if (this.Count % this.ItemsPerPage == 0)
            {
                return this.Count / ItemsPerPage;
            }
            return Count / ItemsPerPage + 1;
        }
        /// <summary>
        /// 获取一个遍历构造器。
        /// </summary>
        /// <returns>分页的数据集合。</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return _pagedItems.GetEnumerator();
        }
        /// <summary>
        /// 获取一个遍历器。
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            yield return _pagedItems;
        }
    }
}
