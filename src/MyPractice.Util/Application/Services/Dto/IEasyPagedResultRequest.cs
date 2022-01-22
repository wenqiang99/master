using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyPractice.Utility.Application.Services.Dto
{
    public interface IEasyPagedResultRequest : ILimitedResultRequest
    {
        /// <summary>
        /// 当前页数
        /// </summary>
        [Range(1, int.MaxValue)]
        int PageNumber { get; set; }
        /// <summary>
        /// 是否不分页，默认要分页
        /// </summary>
        bool NoPage { get; set; }
    }
}
