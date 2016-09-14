using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using Abp.Zero.EntityFramework;
using ITRACK.EntityFramework;

namespace ITRACK
{
    [DependsOn(typeof(AbpZeroEntityFrameworkModule), typeof(ITRACKCoreModule))]
    public class ITRACKDataModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = "Default";
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
