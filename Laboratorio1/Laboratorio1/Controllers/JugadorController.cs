using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Laboratorio1.DBContext;
using System.IO;

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
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Jugador/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Jugador/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Jugador/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
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
        
         
        [HttpGet]
        public ActionResult UploadFile()
        {
            return View();
        }
        [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult UploadFile(HttpPostedFileBase File)
            
        {
            string filePath = string.Empty;
            if (File != null)
            {
                string path = Server.MapPath("~/UploadedFiles/");
                filePath = path + Path.GetFileName(File.FileName);
                string extension = Path.GetExtension(File.FileName);
                File.SaveAs(filePath);

                string csvDatos = System.IO.File.ReadAllText(filePath);
                string[] csvDatos_ = csvDatos.Split('\n');
                
                foreach (string fila in csvDatos_)
                {

                    if (!string.IsNullOrEmpty(fila)&& fila !=csvDatos_[0])
                    {
                        db.Jugadores.Add(new Models.Jugador
                        {
                            JugadorID = ++db.IdActual,
                            Club = fila.Split(',')[0],
                            Apellido = fila.Split(',')[1],
                            Nombre = fila.Split(',')[2],
                            Posicion = fila.Split(',')[3],
                            Salario = (int)Convert.ToDouble(fila.Split(',')[4])
                        });
                    }
                }
            }
            return View();
           
        }
    }
}
