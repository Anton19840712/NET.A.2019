using System.Web;
using System.Web.Mvc;

namespace NET.A._2019.Gridushko._24
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
