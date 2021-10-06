using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersimosMVC.Controllers
{
    public class AccesoController : Controller
    {
        // GET: Acceso
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string User, string Pass)
        {
            var msjError = "Usuario o contraseña invalida";

            try
            {
                using (Models.MiSistemaEntities db= new Models.MiSistemaEntities())
                {
                    var oUser = (from d in db.usuario
                                 where d.email == User.Trim() && d.password == Pass.Trim()
                                 select d).FirstOrDefault();
                    if (oUser == null)
                    {
                        ViewBag.Error = msjError;
                        return View();
                    }

                    Session["User"] = oUser;
                            
                }

                return RedirectToAction("Index", "Clientes");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }

        }
    }
}