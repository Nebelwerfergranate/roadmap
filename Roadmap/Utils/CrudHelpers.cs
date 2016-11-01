using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;

namespace Roadmap.Utils
{
    public enum SortDirections
    {
        up,
        down
    }

    public class PagingDefinition
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int Total { get; set; }
        public string Sort { get; set; }
        public SortDirections Direction { get; set; }

        public PagingDefinition()
        {
            Page = 1;
            PageSize = int.MaxValue;
        }
    }

    public static class CrudHelpers
    {
        public static PagingDefinition GetPaging(this HttpContextBase httpContext)
        {
            PagingDefinition res = new PagingDefinition();

            //ASCRUDGetItemsModel parameters = AjaxModel.GetParameters(httpContext);

            //res.Page = parameters.page;
            //res.PageSize = parameters.pageSize;

            //if (parameters.sort != null && parameters.direction != null)
            //{
            //    char[] separator = new char[] { ',' };
            //    var sorts = parameters.sort.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            //    var directions = parameters.direction.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            //    res.Sort = sorts.Length > 0 ? sorts[0] : "";

            //    if (directions.Length > 0 && directions[0] == "down")
            //    {
            //        res.Direction = SortDirections.down;
            //    }
            //    else
            //    {
            //        res.Direction = SortDirections.up;
            //    }
            //}
            //else
            //{
            //    res.Sort = "Id";
            //    res.Direction = SortDirections.up;
            //}

            return res;
        }

        public static IQueryable<TData> Paging<TData>(this IOrderedQueryable<TData> target, int itemsPerPage, ref int currentPage, out int total)
        {
            total = target.Count();

            itemsPerPage = itemsPerPage <= 0 ? 1 : itemsPerPage;


            if ((currentPage - 1) * itemsPerPage >= total)
            {
                currentPage = (total / itemsPerPage) - 1;
            }

            if (currentPage <= 0)
            {
                currentPage = 1;
            }

            return target
                .Skip(itemsPerPage * (currentPage - 1))
                .Take(itemsPerPage);
        }

        public static IOrderedQueryable<TSource> OrderBy<TSource, TKey>(this IQueryable<TSource> source, Expression<Func<TSource, TKey>> keySelector, SortDirections direction)
        {
            if (direction == SortDirections.up)
            {
                return source.OrderBy(keySelector);
            }
            else
            {
                return source.OrderByDescending(keySelector);
            }
        }
    }
}