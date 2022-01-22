using MyPractice.Util.Base.PagingQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyPractice.Util.Base.View
{
    /// <summary>
    /// 分页查询结果列表的数据结构
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="Tk"></typeparam>
    public class PagedViewResult<T, Tk> : IViewResult<List<T>> where Tk : PagedInputDto
    {
        /// <summary>
        /// 
        /// </summary>
        public PagedViewResult()
        {
        }

        /// <summary>
        /// ctor
        /// </summary>
        public PagedViewResult(IQueryable<T> input, Tk pagedInputDto)
        {
            Pagination = new PaginationDto
            {
                CurrentPage = pagedInputDto.CurrentPage,
                PageSize = pagedInputDto.PageSize,
                Total = input.Count()
            };

            Result = input.Skip((pagedInputDto.CurrentPage - 1) * pagedInputDto.PageSize).Take(pagedInputDto.PageSize)
                .ToList();
        }

        /// <summary>
        /// 分页数据
        /// </summary>
        public PaginationDto Pagination { get; set; }

        /// <summary>
        /// 结果列表
        /// </summary>
        public List<T> Result { get; set; }

        /// <summary>
        /// 指示操作是否成功
        /// </summary>
        public bool Success { get; set; } = true;

        /// <summary>
        /// 返回附带信息
        /// </summary>
        public string Message { get; set; }
    }
}
