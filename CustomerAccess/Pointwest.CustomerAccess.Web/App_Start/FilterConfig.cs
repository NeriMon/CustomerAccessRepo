using System.Web;
using System.Web.Mvc;

namespace Pointwest.CustomerAccess.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
