using Superheros.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Superheros.Controllers
{
    public class SuperheroController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Superhero
        public ActionResult Index()
        {
            return View(db.Superheroes.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,AlterEgo,PrimaryAbility,SecondaryAbility,CatchPhrase")] Superhero superhero)
        {
            if (ModelState.IsValid)
            {
                db.Superheroes.Add(superhero);
                db.SaveChanges();
                return RedirectToAction("index");
            }
            ViewBag.Name = new SelectList(db.Superheroes, "ID", "Name", superhero.Name);
            return View(superhero);
        }
        public ActionResult Details(int id)
        {
            var heros = db.Superheroes.Where(h => h.ID == id).FirstOrDefault();
            return View(heros);
        }

        public ActionResult Edit(int id)
        {
            var heros = db.Superheroes.Where(h => h.ID == id).FirstOrDefault();
            return View(heros);
        }
        //public ActionResult Delete(int id)
        //{

        //}
    }
}