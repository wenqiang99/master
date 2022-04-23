using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services;
using Abp.Dependency;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using System.IO;
using Abp.AspNetCore.SignalR.Hubs;
using Abp.RealTime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Abp.Auditing;
using Castle.Core.Logging;

namespace MyPractice.Common
{
    #region Hub
    public class CommonHub : AbpCommonHub   
    {
        public IAbpSession AbpSession { get; set; }
        public Castle.Core.Logging.ILogger Logger { get; set; }

        public CommonHub(
            IOnlineClientManager onlineClientManager,
            IClientInfoProvider clientInfoProvider) :
            base(onlineClientManager, (IOnlineClientInfoProvider)clientInfoProvider)
        {
        }
       

        public async Task SendMessage(string user, string message)
        {
            var connectId = this.Context.ConnectionId;
            var userName = this.Context.User.Identity.Name;
            //var userId = this.Context.UserIdentifier;
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
        //public async Task SendMessage2(string message)
        //{
        //    await Clients.All.InvokeAsync("getMessage", string.Format("User {0}: {1}", AbpSession.UserId, message));
        //}
        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
            Logger.Debug("A client connected to MyChatHub: " + Context.ConnectionId);
        }
        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await base.OnDisconnectedAsync(exception);
            Logger.Debug("A client disconnected from MyChatHub: " + Context.ConnectionId);
        }
    }
    #endregion
}
