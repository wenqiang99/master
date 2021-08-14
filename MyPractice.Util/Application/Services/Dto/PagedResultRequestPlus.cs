using System;
using System.Collections.Generic;
using System.Text;

namespace ABBMASWeld.Utility.Application.Services.Dto
{
    /// <summary>
    /// 列表查询条件扩展方法
    /// </summary>
    public class PagedResultRequestPlus : IPagedResultRequestPlus
    {
        /// <summary>
        /// 页最大数
        /// </summary>
        public int MaxResultCount { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public string Sorting { get; set; }
        /// <summary>
        /// 分页控件选择页数
        /// </summary>
        public int PageNumber { get; set; }
        /// <summary>
        /// 是否不分页，默认要分页
        /// </summary>
        public bool NoPage { get; set; }
        public PagedResultRequestPlus()
        {
            MaxResultCount = 10;
            PageNumber = 1;
        }
    }
}
