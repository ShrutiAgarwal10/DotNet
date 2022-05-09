using System.Web;
using System.Web.Mvc;

namespace CustomActionFiltersDemo
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //filters.Add(new MyCustomActionFilterAttribute);
            //filters.Add(new MyNewCustomActionFilterAttribute);
        }
    }
}
