using CCPSAPPS.Models;
using Microsoft.AspNetCore.Mvc;
using ApplicationDbContext = CCPSAPPS.Data.ApplicationDbContext;

namespace CCPSAPPS.Controllers
{
    public class PersonneController : Controller
    {
        private readonly ApplicationDbContext _db;

        public PersonneController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index(int pg=1)
        {
            IEnumerable<Personne> personne = _db.Personnes;

            const int pageSize = 10;
            if (pg < 1)
                pg = 1;
            int resCount = personne.Count();
            var page = new Page(resCount, pg, pageSize);

            int recSkip = (pg - 1) * pageSize;
            var data = personne.Skip(recSkip).Take(page.PageSize).ToList();
            
            this.ViewBag.Page = page;

            return View(data);
            
           // return View(personne);

        }

        //Get - Create
        public IActionResult Create()
        {

            return View();
        }

        //Post- Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Personne personne)
        {
            _db.Personnes.Add(personne);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var personne = _db.Personnes.Find(id);
            if (personne == null)
            {
                return NotFound();
            }
            return View(personne);
        }


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var personne = _db.Personnes.Find(id);
            if (personne == null)
            {
                return NotFound();
            }
            return View(personne);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Personne personne)
        {
            _db.Personnes.Update(personne);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }


        // GET: /Movies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Personne personne = _db.Personnes.Find(id);
            if (personne == null)
            {
                return NotFound();
            }
            return View(personne);
        }


        // POST: /Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Personne personne = _db.Personnes.Find(id);
            _db.Personnes.Remove(personne);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
