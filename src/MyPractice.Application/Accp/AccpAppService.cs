using Abp.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using MyPractice.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyPractice.Accp
{
    public class AccpAppService : MyPracticeAppServiceBase, IAccpAppService
    {
        private readonly IHubContext<CommonHub> _commonHub;

        public AccpAppService(IHubContext<CommonHub> commonHub)
        {
            _commonHub = commonHub;
        }


        #region SignalR
        [HttpPost]
        public async Task SignalAsyncTest1(string input)
        {
            try
            {
                await _commonHub.Clients.All.SendAsync("ReceiveMessage", "AA2", input);
            }
            catch (Exception ex)
            {
                if (ex is UserFriendlyException)
                    throw ex;
                else
                    throw new UserFriendlyException("系统异常");
            }
        }
        #endregion
    }
}
