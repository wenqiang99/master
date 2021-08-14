using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyPractice.Util.Base.PagingQuery
{
    /// <summary>
    /// 分页数据
    /// </summary>
    public class PaginationDto
    {
        /// <summary>
        /// 当前页
        /// </summary>
        [Range(0, int.MaxValue)]
        public int CurrentPage { get; set; }

        /// <summary>
        /// 一页显示的行数
        /// </summary>
        [Range(0, int.MaxValue)]
        public int PageSize { get; set; }

        /// <summary>
        /// 结果总数
        /// </summary>
        [Range(0, int.MaxValue)]
        public int Total { get; set; }
    }
}
