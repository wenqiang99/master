using System;
using System.Collections.Generic;
using System.Text;

namespace MyPractice.Util.Base.PagingQuery
{
    /// <summary>
    /// 分页查询输入Dto
    /// </summary>
    public class PagedInputDto
    {
        /// <summary>
        /// 每页显示的行数
        /// </summary>
        public int PageSize { get; set; } = 10;

        /// <summary>
        /// 页数
        /// </summary>
        public int CurrentPage { get; set; } = 1;
    }
}
