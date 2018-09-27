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
            return View();
        }

        public ActionResult Create()
        {

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
    }
}