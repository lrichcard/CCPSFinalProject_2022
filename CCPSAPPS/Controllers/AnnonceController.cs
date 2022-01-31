using CCPSAPPS.Models;
using Microsoft.AspNetCore.Mvc;
using ApplicationDbContext = CCPSAPPS.Data.ApplicationDbContext;
namespace CCPSAPPS.Controllers
{
    public class AnnonceController : Controller
    {
        private readonly ApplicationDbContext _db;

        public AnnonceController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Annonce> annonce = _db.Annonces;
            return View(annonce);
        }

        //Get - Create
        public IActionResult Create()
        {

            return View();
        }

        //Post- Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Annonce annonce)
        {
            _db.Annonces.Add(annonce);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var annonce = _db.Annonces.Find(id);
            if (annonce == null)
            {
                return NotFound();
            }
            return View(annonce);
        }


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var annonce = _db.Annonces.Find(id);
            if (annonce == null)
            {
                return NotFound();
            }
            return View(annonce);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Annonce annonce)
        {
            _db.Annonces.Update(annonce);
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
            Annonce annonce = _db.Annonces.Find(id);
            if (annonce == null)
            {
                return NotFound();
            }
            return View(annonce);
        }


        // POST: /Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Annonce annonce = _db.Annonces.Find(id);
            _db.Annonces.Remove(annonce);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
