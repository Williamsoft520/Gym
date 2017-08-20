using System.Collections.Generic;
using System.Linq;

namespace System
{
    /// <summary>
    /// 表示对 Linq 的扩展。
    /// </summary>
    public static class LinqExtension
    {
        /// <summary> 
        /// 对当前已排序的结果进行分页。
        /// </summary>
        /// <typeparam name="T">可以被分页的实体类型。</typeparam>
        /// <param name="source">被扩展的IOrderedQueryable对象。</param>
        /// <param name="page">当前页码。</param>
        /// <param name="itemPerPage">每页呈现的数据量。</param>
        /// <returns>被分页的TEntity集合</returns>
        public static IPagedCollection<T> Paged<T>(this IOrderedQueryable<T> source, int page, int itemPerPage)            
        {
            var pagedList = source.Skip((page - 1) * itemPerPage).Take(itemPerPage);

            return new PagedCollection<T>(pagedList.ToList(), source.Count()) { CurrentPage = page, ItemsPerPage = itemPerPage };
        }

        /// <summary>
        /// 对当前集合进行分页。
        /// </summary>
        /// <typeparam name="T">可以被分页数据类型</typeparam>
        /// <param name="list">当前集合实例。</param>
        /// <param name="page">当前页码。</param>
        /// <param name="itemPerPage">每页呈现的数据量。</param>
        /// <returns>被分页的集合。</returns>
        public static IPagedCollection<T> Paged<T>(this IOrderedEnumerable<T> list, int page, int itemPerPage)
        {
            var pagedList = list.Skip((page - 1) * itemPerPage).Take(itemPerPage);
            return new PagedCollection<T>(pagedList.AsEnumerable(), list.Count()) { CurrentPage = page, ItemsPerPage = itemPerPage };
        }
    }
}
