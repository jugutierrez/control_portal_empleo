using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace control_portal_empleo.Controllers
{
    public class AdministradorController : Controller
    {
        //
        // GET: /Administrador/
        [Authorize(Roles="3")]
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public PartialViewResult GetMenu(int? id)
        {
            if (id == 1)
            { ViewBag.id = 1; }
            else
            { ViewBag.id = 0; }

            return PartialView("_vista_usuarios_pendientes_adm");
        }
    }
}