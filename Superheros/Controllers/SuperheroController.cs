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
            var hero = db.Superheroes.Where(h => h.ID == id).FirstOrDefault();
            return View(hero);
        }

        public ActionResult Edit(int id)
        {
            var hero = db.Superheroes.Where(h => h.ID == id).FirstOrDefault();
            return View(hero);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Superhero superhero)
        {
            var hero = db.Superheroes.Where(h => h.ID == superhero.ID).FirstOrDefault();
            hero.Name = superhero.Name;
            hero.AlterEgo = superhero.AlterEgo;
            hero.PrimaryAbility = superhero.PrimaryAbility;
            hero.SecondaryAbility = superhero.SecondaryAbility;
            hero.CatchPhrase = superhero.CatchPhrase;
            db.SaveChanges();
            var heros = db.Superheroes.ToList();
            return RedirectToAction("Index");
        }
        //public ActionResult Delete(int id)
        //{

        //}
    }
}