using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;

namespace ITRACK
{
    [DependsOn(typeof(ITRACKCoreModule), typeof(AbpAutoMapperModule))]
    public class ITRACKApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
