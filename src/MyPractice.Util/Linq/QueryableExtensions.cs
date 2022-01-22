using MyPractice.Utility.Application.Services.Dto;
using Abp.Application.Services.Dto;
using Abp.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Abp.Linq.Extensions;
using System.Linq.Dynamic.Core;

namespace MyPractice.Utility.Linq
{
    public static class QueryableExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        public static IQueryable<T> ApplySortingAndPageBy<T>(this IQueryable<T> query, IPagedResultRequestPlus input)
        {
            if (input is ISortedResultRequest sortInput)
            {
                if (!sortInput.Sorting.IsNullOrWhiteSpace())
                {
                    query = query.OrderBy(sortInput.Sorting);
                }
            }

            if (input is IEasyPagedResultRequest pagedInput)
            {
                query = query.PageBy(pagedInput);
            }
            return query;
        }
        /// <summary>
        ///用于使用<see cref="IEasyPagedResultRequest"/>对象分页。
        /// </summary>
        /// <param name="query">可查询以应用分页</param>
        /// <param name="pagedResultRequest">对象实现<参见cref="IPagedResultRequestDto"/>接口</param>
        public static IQueryable<T> PageBy<T>(this IQueryable<T> query, IEasyPagedResultRequest pagedResultRequest)
        {
            return query.PageBy((pagedResultRequest.PageNumber - 1) * pagedResultRequest.MaxResultCount, pagedResultRequest.MaxResultCount);
        }
    }
}
