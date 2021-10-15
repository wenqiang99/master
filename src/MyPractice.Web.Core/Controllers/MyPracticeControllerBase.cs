using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Identity;
using MyPractice.Authorization.Users;
using System;
using System.Threading.Tasks;

namespace MyPractice.Controllers
{
    public abstract class MyPracticeControllerBase: AbpController
    {
        public UserManager UserManager { get; set; }
        protected MyPracticeControllerBase()
        {
            LocalizationSourceName = MyPracticeConsts.LocalizationSourceName;
        }
        protected virtual Task<User> GetCurrentUserAsync()
        {
            var user = UserManager.FindByIdAsync(AbpSession.GetUserId().ToString());
            if (user == null)
            {
                throw new Exception("There is no current user!");
            }

            return user;
        }
        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
