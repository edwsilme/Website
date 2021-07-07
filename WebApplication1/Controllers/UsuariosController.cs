using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class UsuariosController : Controller
    {
        private bdPruebawebEntities db = new bdPruebawebEntities();

        // GET: Usuarios
        public ActionResult Index()
        {
            var tBL_USUARIO = db.TBL_USUARIO.Include(t => t.TBL_ROL);
            return View(tBL_USUARIO.ToList());




        }

        // GET: Usuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_USUARIO tBL_USUARIO = db.TBL_USUARIO.Find(id);
            if (tBL_USUARIO == null)
            {
                return HttpNotFound();
            }
            return View(tBL_USUARIO);
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            ViewBag.idRol = new SelectList(db.TBL_ROL, "id", "nombre");
            return View();
        }

        // POST: Usuarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,email,password,idRol")] TBL_USUARIO tBL_USUARIO)
        {
            if (ModelState.IsValid)
            {
                db.TBL_USUARIO.Add(tBL_USUARIO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idRol = new SelectList(db.TBL_ROL, "id", "nombre", tBL_USUARIO.idRol);
            return View(tBL_USUARIO);
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_USUARIO tBL_USUARIO = db.TBL_USUARIO.Find(id);
            if (tBL_USUARIO == null)
            {
                return HttpNotFound();
            }
            ViewBag.idRol = new SelectList(db.TBL_ROL, "id", "nombre", tBL_USUARIO.idRol);
            return View(tBL_USUARIO);
        }

        // POST: Usuarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,email,password,idRol")] TBL_USUARIO tBL_USUARIO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBL_USUARIO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idRol = new SelectList(db.TBL_ROL, "id", "nombre", tBL_USUARIO.idRol);
            return View(tBL_USUARIO);
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_USUARIO tBL_USUARIO = db.TBL_USUARIO.Find(id);
            if (tBL_USUARIO == null)
            {
                return HttpNotFound();
            }
            return View(tBL_USUARIO);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TBL_USUARIO tBL_USUARIO = db.TBL_USUARIO.Find(id);
            db.TBL_USUARIO.Remove(tBL_USUARIO);
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
    }
}
