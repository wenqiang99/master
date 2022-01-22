using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyPractice.Utility.Application.Services.Dto
{
    public interface IPagedResultRequestPlus : IEasyPagedResultRequest, ISortedResultRequest
    {

    }
}
