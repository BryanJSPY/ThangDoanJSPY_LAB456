using System.Web;
using System.Web.Mvc;

namespace doanchithang_lab456_1711061719
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
