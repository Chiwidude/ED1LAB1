using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Laboratorio1.DBContext;
using System.Net;

namespace Laboratorio1.Controllers
{
    public class JugadorController : Controller
    {
        public DefaultConnection db = DefaultConnection.getInstance;

        // GET: Jugador
        public ActionResult Index()
        {
            return View(db.Jugadores.ToList());
        }

        // GET: Jugador/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Jugador/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Jugador/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include ="Nombre,Apellido,Club,Posicion,Salario")]Models.Jugador jugador)
        {
            if (ModelState.IsValid)
            {
                jugador.JugadorID = ++db.IdActual;
                db.Jugadores.Add(jugador);
                return RedirectToAction("Index");
            }
            return View(jugador);
        }

        // GET: Jugador/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Models.Jugador jugador = db.Jugadores.Find(x => x.JugadorID == id);
            if (jugador == null)
            {
                return HttpNotFound();
            }

            return View(jugador);
        }

        // POST: Jugador/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "JugadorID, Apellido, Nombre, Club, Posicion, Salario")]Models.Jugador jugador)
        {
            if (ModelState.IsValid)
            {
                Models.Jugador modifiedJugador = db.Jugadores.Find(x => x.JugadorID == jugador.JugadorID);

                if (modifiedJugador == null)
                {
                    return HttpNotFound();
                }

                modifiedJugador.Club = jugador.Club;
                modifiedJugador.Salario = jugador.Salario;
                return View(modifiedJugador);
            }

            return RedirectToAction("Index");
        }

        // GET: Jugador/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Jugador/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
