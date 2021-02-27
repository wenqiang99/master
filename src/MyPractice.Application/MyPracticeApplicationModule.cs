using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MyPractice.Authorization;

namespace MyPractice
{
    [DependsOn(
        typeof(MyPracticeCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class MyPracticeApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<MyPracticeAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(MyPracticeApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
