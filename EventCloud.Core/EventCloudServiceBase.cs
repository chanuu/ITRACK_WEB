using Abp;

namespace ITRACK
{
    public class ITRACKServiceBase : AbpServiceBase
    {
        public ITRACKServiceBase()
        {
            LocalizationSourceName = ITRACKConsts.LocalizationSourceName;
        }
    }
}