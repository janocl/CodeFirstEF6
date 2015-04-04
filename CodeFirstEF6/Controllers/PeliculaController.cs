using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CodeFirstEF6.DAL;
using CodeFirstEF6.Models;

namespace CodeFirstEF6.Controllers
{
    public class PeliculaController : Controller
    {
        private CatalogoContext db = new CatalogoContext();

        // GET: Pelicula
        public ActionResult Index()
        {
            return View(db.Peliculas.ToList());
        }

        // GET: Pelicula/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PeliculaViewModel peliculaViewModel = db.Peliculas.Find(id);
            if (peliculaViewModel == null)
            {
                return HttpNotFound();
            }
            return View(peliculaViewModel);
        }

        // GET: Pelicula/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pelicula/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Estreno,Duracion,Rating,Descripcion,Pais,IdGenero")] PeliculaViewModel peliculaViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Peliculas.Add(peliculaViewModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(peliculaViewModel);
        }

        // GET: Pelicula/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PeliculaViewModel peliculaViewModel = db.Peliculas.Find(id);
            if (peliculaViewModel == null)
            {
                return HttpNotFound();
            }
            return View(peliculaViewModel);
        }

        // POST: Pelicula/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Estreno,Duracion,Rating,Descripcion,Pais,IdGenero")] PeliculaViewModel peliculaViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(peliculaViewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(peliculaViewModel);
        }

        // GET: Pelicula/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PeliculaViewModel peliculaViewModel = db.Peliculas.Find(id);
            if (peliculaViewModel == null)
            {
                return HttpNotFound();
            }
            return View(peliculaViewModel);
        }

        // POST: Pelicula/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PeliculaViewModel peliculaViewModel = db.Peliculas.Find(id);
            db.Peliculas.Remove(peliculaViewModel);
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
