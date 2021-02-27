using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MyPractice.Configuration;

namespace MyPractice.Web.Host.Startup
{
    [DependsOn(
       typeof(MyPracticeWebCoreModule))]
    public class MyPracticeWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public MyPracticeWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MyPracticeWebHostModule).GetAssembly());
        }
    }
}
