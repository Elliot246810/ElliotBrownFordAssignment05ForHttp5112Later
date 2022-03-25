using System.Web;
using System.Web.Mvc;

namespace ElliotBrownFordAssignment03ForHttp5112
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
