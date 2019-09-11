using DocApp.HelperClasses;
using System.Web;
using System.Web.Mvc;

namespace DocApp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //filters.Add(new CusAuthAttribute());
        }
    }
}
