using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace MyPractice.Controllers
{
    public abstract class MyPracticeControllerBase: AbpController
    {
        protected MyPracticeControllerBase()
        {
            LocalizationSourceName = MyPracticeConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
