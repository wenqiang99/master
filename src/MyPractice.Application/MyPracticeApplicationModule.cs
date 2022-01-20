using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MyPractice.Authorization;

namespace MyPractice
{
    /// <summary>
    /// 应用模块
    /// </summary>
    [DependsOn(typeof(MyPracticeCoreModule),typeof(AbpAutoMapperModule))]
    public class MyPracticeApplicationModule : AbpModule
    {
        /// <summary>
        /// 预初始化
        /// </summary>
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<MyPracticeAuthorizationProvider>(); //权限
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public override void Initialize()
        {
            var thisAssembly = typeof(MyPracticeApplicationModule).GetAssembly();
            IocManager.RegisterAssemblyByConvention(thisAssembly);
            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                // 扫描程序集以查找从AutoMapper继承的类。
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
