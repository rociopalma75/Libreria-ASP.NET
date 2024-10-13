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
    public class LibroController : Controller
    {
        private LibrosPrestamosEntities db = new LibrosPrestamosEntities();

        // GET: Libro
        public ActionResult Index(bool? mostrarTodos)
        {
            var libro = db.Libro.Include(l => l.Autor).Include(l => l.Genero).Where(l => l.estado == true);

            if(mostrarTodos.HasValue && mostrarTodos.Value)
            {
                libro = db.Libro.Include(l => l.Autor).Include(l => l.Genero);
            }

            return View(libro.ToList());
        }

        // GET: Libro/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Libro libro = db.Libro.Find(id);
            if (libro == null)
            {
                return HttpNotFound();
            }
            return View(libro);
        }

        // GET: Libro/Create
        public ActionResult Create()
        {
            ViewBag.id_autor = new SelectList(db.Autor, "id", "nombreCompleto");
            ViewBag.id_genero = new SelectList(db.Genero, "id", "descripcion");
            return View();
        }

        // POST: Libro/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,titulo,anio_publicacion,id_autor,id_genero,estado")] Libro libro)
        {
            if (ModelState.IsValid)
            {
                libro.estado = true;
                db.Libro.Add(libro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_autor = new SelectList(db.Autor, "id", "nombre", libro.id_autor);
            ViewBag.id_genero = new SelectList(db.Genero, "id", "descripcion", libro.id_genero);
            return View(libro);
        }

        // GET: Libro/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Libro libro = db.Libro.Find(id);
            if (libro == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_autor = new SelectList(db.Autor, "id", "nombreCompleto", libro.id_autor);
            ViewBag.id_genero = new SelectList(db.Genero, "id", "descripcion", libro.id_genero);
            return View(libro);
        }

        // POST: Libro/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,titulo,anio_publicacion,id_autor,id_genero,estado")] Libro libro)
        {
            if (ModelState.IsValid)
            {
                libro.estado = true;
                db.Entry(libro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_autor = new SelectList(db.Autor, "id", "nombre", libro.id_autor);
            ViewBag.id_genero = new SelectList(db.Genero, "id", "descripcion", libro.id_genero);
            return View(libro);
        }

        // GET: Libro/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Libro libro = db.Libro.Find(id);
            if (libro == null)
            {
                return HttpNotFound();
            }
            return View(libro);
        }

        // POST: Libro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Libro libro = db.Libro.Find(id);
            libro.estado = false;
            db.Entry(libro).State = EntityState.Modified;
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
