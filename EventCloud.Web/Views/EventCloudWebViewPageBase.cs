using Abp.Web.Mvc.Views;

namespace ITRACK.Web.Views
{
    public abstract class ITRACKWebViewPageBase : ITRACKWebViewPageBase<dynamic>
    {

    }

    public abstract class ITRACKWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected ITRACKWebViewPageBase()
        {
            LocalizationSourceName = ITRACKConsts.LocalizationSourceName;
        }
    }
}