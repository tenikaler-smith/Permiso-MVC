using PersimosMVC.Controllers;
using PersimosMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersimosMVC.Filters
{
    public class VerificaSession : ActionFilterAttribute
    {
        private usuario oUsuario;
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                base.OnActionExecuting(filterContext);

                oUsuario = (usuario)HttpContext.Current.Session["User"];
                if (oUsuario == null)
                {
                   
                        if (filterContext.Controller is AccesoController == false)
                        {
                            filterContext.HttpContext.Response.Redirect("/Acceso/Login");
                        }
                   
                    

                }

            }
            catch (Exception)
            {
                filterContext.Result = new RedirectResult("~/Acceso/Login");
            }

        }
    }
}