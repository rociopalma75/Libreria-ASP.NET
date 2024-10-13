using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Parcial1.Models;
using PagedList;

namespace Parcial1.Controllers
{
    public class PrestamosController : Controller
    {
        private LibrosPrestamosEntities db = new LibrosPrestamosEntities();

        // GET: Prestamos
        public ActionResult Index(int? id_estado, bool? mostrarTodos, int? page)
        {
            ViewBag.id_estado = new SelectList(db.Estado, "id", "descripcion", id_estado);
            ViewBag.MostrarTodos = mostrarTodos;
            var prestamos = db.Prestamos.Include(p => p.Cliente).Include(p => p.Estado).Include(p => p.Libro).Where(p => p.estado_eliminado == true).OrderBy(p => p.fecha_prestamo).AsQueryable();

            if (mostrarTodos == true)
            {
                prestamos = db.Prestamos.Include(p => p.Cliente).Include(p => p.Estado).Include(p => p.Libro).OrderBy(p => p.fecha_prestamo).AsQueryable();
            }

            if (id_estado != null)
            {
                prestamos = prestamos.Where(p => p.id_estado == id_estado);
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);

            return View(prestamos.ToPagedList(pageNumber, pageSize));
        }


        // GET: Prestamos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prestamos prestamos = db.Prestamos.Find(id);
            if (prestamos == null)
            {
                return HttpNotFound();
            }
            return View(prestamos);
        }

        // GET: Prestamos/Create
        public ActionResult Create()
        {
            ViewBag.id_cliente = new SelectList(db.Cliente, "id", "nombreCompleto");
            ViewBag.id_estado = new SelectList(db.Estado, "id", "descripcion");
            ViewBag.id_libro = new SelectList(db.Libro, "id", "titulo");
            return View();
        }

        // POST: Prestamos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,id_libro,id_cliente,fecha_prestamo,fecha_devolucion, id_estado, estado_eliminado")] Prestamos prestamos)
        {
            if(prestamos.fecha_prestamo > DateTime.Now)
            {
                ModelState.AddModelError("fecha_prestamo", "La fecha no puede ser mayor a la fecha actual");
            }
            
            if (ModelState.IsValid)
            {
                prestamos.estado_eliminado = true;
                db.Prestamos.Add(prestamos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_cliente = new SelectList(db.Cliente, "id", "nombre", prestamos.id_cliente);
            ViewBag.id_estado = new SelectList(db.Estado, "id", "descripcion", prestamos.id_estado);
            ViewBag.id_libro = new SelectList(db.Libro, "id", "titulo", prestamos.id_libro);
            return View(prestamos);
        }

        // GET: Prestamos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prestamos prestamos = db.Prestamos.Find(id);
            if (prestamos == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_cliente = new SelectList(db.Cliente, "id", "nombre", prestamos.id_cliente);
            ViewBag.id_estado = new SelectList(db.Estado, "id", "descripcion", prestamos.id_estado);
            ViewBag.id_libro = new SelectList(db.Libro, "id", "titulo", prestamos.id_libro);
            return View(prestamos);
        }

        // POST: Prestamos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,id_libro,id_cliente,fecha_prestamo,fecha_devolucion, id_estado, estado_eliminado")] Prestamos prestamos)
        {
            if(prestamos.fecha_prestamo > prestamos.fecha_devolucion)
            {
                ModelState.AddModelError("fecha_devolucion", "La fecha de devolución no puede ser menor a la fecha de prestamo");
            }
            if (ModelState.IsValid)
            {
                prestamos.estado_eliminado = true;
                db.Entry(prestamos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_cliente = new SelectList(db.Cliente, "id", "nombre", prestamos.id_cliente);
            ViewBag.id_estado = new SelectList(db.Estado, "id", "descripcion", prestamos.id_estado);
            ViewBag.id_libro = new SelectList(db.Libro, "id", "titulo", prestamos.id_libro);
            return View(prestamos);
        }

        // GET: Prestamos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prestamos prestamos = db.Prestamos.Find(id);
            if (prestamos == null)
            {
                return HttpNotFound();
            }
            return View(prestamos);
        }

        // POST: Prestamos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Prestamos prestamos = db.Prestamos.Find(id);
            prestamos.estado_eliminado = false;
            db.Entry(prestamos).State = EntityState.Modified;
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
