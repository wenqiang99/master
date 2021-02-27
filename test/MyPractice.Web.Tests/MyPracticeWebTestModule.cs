using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MyPractice.EntityFrameworkCore;
using MyPractice.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace MyPractice.Web.Tests
{
    [DependsOn(
        typeof(MyPracticeWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class MyPracticeWebTestModule : AbpModule
    {
        public MyPracticeWebTestModule(MyPracticeEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MyPracticeWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(MyPracticeWebMvcModule).Assembly);
        }
    }
}