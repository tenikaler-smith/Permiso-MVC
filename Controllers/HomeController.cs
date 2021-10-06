using PersimosMVC.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersimosMVC.Controllers
{
    public class HomeController : Controller
    {
        [AuthorizeUser(idOperacion:1)]
        public ActionResult Index(ClientesController ClientesController)
        {
            return View(ClientesController);
        }

        [AuthorizeUser(idOperacion: 2)]
        public ActionResult About()
        {
            ViewBag.Message = "Acerca de mi Sitio.";

            return View();
        }

        [AuthorizeUser(idOperacion: 3)]
        public ActionResult Contact()
        {
            ViewBag.Message = "Contactenos.";

            return View();
        }
    }
}