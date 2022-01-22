using MyPractice.Utility.Application.Services.Dto;
using Abp.Application.Services.Dto;
using Abp.Dependency;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Abp.ObjectMapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;

namespace MyPractice.Utility.Application.Services
{
    /// <summary>
    /// 分页查询返回
    /// </summary>
    public static class PagedResultExtensions
    {
        /// <summary>
        /// 单表查询返回
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TPagedResultRequestPlus"></typeparam>
        /// <param name="query"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        public static PagedResultDto<T> PagedResult<T, TPagedResultRequestPlus>(this IQueryable<T> query, TPagedResultRequestPlus input)
        {
            var totalCount = query.Count();//总数
            if (input is ISortedResultRequest sortInput)
            {
                if (!sortInput.Sorting.IsNullOrWhiteSpace())
                {
                    query = query.OrderBy(sortInput.Sorting);//排序
                }
            }
            if (input is IEasyPagedResultRequest pagedInput)
            {
                if (!pagedInput.NoPage)
                    query = query.PageBy((pagedInput.PageNumber - 1) * pagedInput.MaxResultCount, pagedInput.MaxResultCount);//分页
            }
            return new PagedResultDto<T>(totalCount, query.ToList());
        }
        /// <summary>
        /// 单表查询返回
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TPagedResultRequestPlus"></typeparam>
        /// <param name="query"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        public static PagedResultDto<T> PagedResultDto<S, T>(this IQueryable<S> query, IPagedResultRequestPlus input)
        {
            var totalCount = query.Count();//总数
            if (input is ISortedResultRequest sortInput)
            {
                if (!sortInput.Sorting.IsNullOrWhiteSpace())
                {
                    query = query.OrderBy(sortInput.Sorting);//排序
                }
            }
            if (input is IEasyPagedResultRequest pagedInput)
            {
                if (!pagedInput.NoPage)
                    query = query.PageBy((pagedInput.PageNumber - 1) * pagedInput.MaxResultCount, pagedInput.MaxResultCount);//分页
            }
            var list = query.ToList();

            var objectMapper = IocManager.Instance.IocContainer.Resolve<IObjectMapper>();
            var dtoList = objectMapper.Map<List<T>>(list);
            return new PagedResultDto<T>(totalCount, dtoList);
        }
    }
}
