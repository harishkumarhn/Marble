using System.Web;
using System.Web.Mvc;

namespace Marbale.ManagementStudio
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
