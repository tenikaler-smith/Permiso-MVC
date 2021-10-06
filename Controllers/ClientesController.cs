using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PersimosMVC.Models;

namespace PersimosMVC.Controllers
{
    public class ClientesController : Controller
    {
        private MiSistemaEntities db = new MiSistemaEntities();

        // GET: Clientes
        public ActionResult Index()
        {
            List<Cliente> Cliente = new List<Cliente>();
            Cliente = db.Cliente.ToList();
            return View("Index", Cliente);
        }

        // GET: Clientes/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            CargaListasViewBags();
            return View();
        }

        // POST: Clientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
    
        public ActionResult Create(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Cliente.Add(cliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            CargaListasViewBags();  
            return View(cliente);
        }

        public ActionResult GuardarAjax(Cliente cliente)
        {
            var respDes = 0;
            var id = cliente.IdCliente;

            if (cliente.IdCliente == 0 )
            {
                var ClienteReturn = db.Cliente.Add(cliente);
                db.SaveChanges();

                respDes = 1;
                id = ClienteReturn.IdCliente;
            }
            else{
                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();
                respDes = 2;
            }

            var resp = new { success = respDes, idCliente = id };
            return Json(resp, JsonRequestBehavior.AllowGet);
            //return View(cliente);

        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit (Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                //ManejarError();
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }




        public ActionResult ManejarError()
        {
            return View("ManejarError");
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Cliente cliente = db.Cliente.Find(id);
            db.Cliente.Remove(cliente);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult CallGetDistritoByID(int IdProvincia)
        {
            var Distritos2 = "<option value='0'>Seleccione</option>";

            if (IdProvincia != 0)
            {
                var objSubAreas = db.CatDistritos.Where(x => x.IdProvincia == IdProvincia);

                var Distritos = objSubAreas.Select(a => "<option value='" + a.IdDistrito + "'>" + a.NombreDistrito + "</option>");
                return Content(Distritos2 + (String.Join("", Distritos)));
            }
            else
            {

                return Content(String.Join("", Distritos2));
            }

        }

        public ActionResult CallGetCorregimientoByID(int IdDistrito)
        {

            var corregimiento2 = "<option value='0'>Seleccione</option>";

            if (IdDistrito != 0)
            {
                var objSubAreas = db.CatCorregimientos.Where(x => x.IdDistrito == IdDistrito);



                var corregimiento = objSubAreas.Select(a => "<option value='" + a.IdCorregimiento + "'>" + a.NombreCorregimiento + "</option>");



                return Content(corregimiento2 + (String.Join("", corregimiento)));
            }
            else
            {


                return Content(String.Join("", corregimiento2));
            }

        }


        public void CargaListasViewBags()
        {

            // .Where(x => x.IdCorregimiento == 0),
            ViewBag.ListaCorregimiento = new SelectList(db.CatCorregimientos, "IdCorregimiento", "NombreCorregimiento");
            ViewBag.ListaDistrito = new SelectList(db.CatDistritos, "IdDistrito", "NombreDistrito");
            ViewBag.ListaProvincia = new SelectList(db.CatProvincia, "IdProvincia", "NombreProvincia");
            
        }



    }

}
