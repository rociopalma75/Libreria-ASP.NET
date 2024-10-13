using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Parcial1.Models;

namespace Parcial1.Controllers
{
    public class AutorController : Controller
    {
        private LibrosPrestamosEntities db = new LibrosPrestamosEntities();

        // GET: Autor
        public ActionResult Index(bool? mostrarTodos)
        {
            var autor = db.Autor.Include(p => p.Pais).Where(p=>p.estado==true);

            if (mostrarTodos.HasValue && mostrarTodos.Value)
            {
                autor = db.Autor.Include(p=>p.Pais);
            }

            return View(autor.ToList());
        }

        // GET: Autor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Autor autor = db.Autor.Find(id);
            if (autor == null)
            {
                return HttpNotFound();
            }
            return View(autor);
        }

        // GET: Autor/Create
        public ActionResult Create()
        {
            ViewBag.id_pais = new SelectList(db.Pais, "id", "descripcion");
            return View();
        }

        // POST: Autor/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,apellido,id_pais,estado")] Autor autor)
        {
            if (ModelState.IsValid)
            {
                autor.estado = true;
                db.Autor.Add(autor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_pais = new SelectList(db.Pais, "id", "descripcion", autor.id_pais);
            return View(autor);
        }

        // GET: Autor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Autor autor = db.Autor.Find(id);
            if (autor == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_pais = new SelectList(db.Pais, "id", "descripcion", autor.id_pais);
            return View(autor);
        }

        // POST: Autor/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,apellido,id_pais,estado")] Autor autor)
        {
            if (ModelState.IsValid)
            {
                autor.estado = true;
                db.Entry(autor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_pais = new SelectList(db.Pais, "id", "descripcion", autor.id_pais);
            return View(autor);
        }

        // GET: Autor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Autor autor = db.Autor.Find(id);
            if (autor == null)
            {
                return HttpNotFound();
            }
            return View(autor);
        }

        // POST: Autor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Autor autor = db.Autor.Find(id);
            autor.estado = false;
            db.Entry(autor).State = EntityState.Modified;
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
