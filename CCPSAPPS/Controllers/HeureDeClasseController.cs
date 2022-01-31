using CCPSAPPS.Models;
using Microsoft.AspNetCore.Mvc;
using ApplicationDbContext = CCPSAPPS.Data.ApplicationDbContext;

namespace CCPSAPPS.Controllers
{
    public class HeureDeClasseController : Controller
    {
        private readonly ApplicationDbContext _db;

        public HeureDeClasseController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: HeureDeClasseController
        public ActionResult Index()
        {
            IEnumerable<HeuresDeClass> heureDeClasse = _db.HeureDeClasses;
            return View(heureDeClasse);

        }

        //Get - Create
        public IActionResult Create()
        {

            return View();
        }

        //Post- Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(HeuresDeClass heureDeClasse)
        {
            _db.HeureDeClasses.Add(heureDeClasse);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        //show Methode/ Details
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var heureClasse = _db.HeureDeClasses.Find(id);
            if (heureClasse == null)
            {
                return NotFound();
            }
            return View(heureClasse);
        }


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var heureDeClasse = _db.HeureDeClasses.Find(id);
            if (heureDeClasse == null)
            {
                return NotFound();
            }
            return View(heureDeClasse);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(HeuresDeClass heuresDeClass)
        {
            _db.HeureDeClasses.Update(heuresDeClass);
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
            HeuresDeClass heureDeClasse = _db.HeureDeClasses.Find(id);
            if (heureDeClasse == null)
            {
                return NotFound();
            }
            return View(heureDeClasse);
        }



        // POST: /Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HeuresDeClass heureDeClasse = _db.HeureDeClasses.Find(id);
            _db.HeureDeClasses.Remove(heureDeClasse);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
