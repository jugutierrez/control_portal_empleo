using control_portal_empleo.App_Start;
using System.Web;
using System.Web.Mvc;

namespace control_portal_empleo
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
           filters.Add(new HandleAntiforgeryTokenErrorAttribute() { ExceptionType = typeof(HttpAntiForgeryException) });
        }
    }
}
