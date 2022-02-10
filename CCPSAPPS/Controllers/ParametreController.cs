using CCPSAPPS.Models;
using Microsoft.AspNetCore.Mvc;
using ApplicationDbContext = CCPSAPPS.Data.ApplicationDbContext;
namespace CCPSAPPS.Controllers
{
    public class ParametreController : Controller
    {

        private readonly ApplicationDbContext _db;

        public ParametreController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Parametre> parame = _db.Parametres;
            return View(parame);
        }
        //Get - Create
        public IActionResult Create()
        {

            return View();
        }

        //Post- Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Parametre parame)
        {
            _db.Parametres.Add(parame);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        //Show a simple record using its ID
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var parame = _db.Parametres.Find(id);
            if (parame == null)
            {
                return NotFound();
            }
            return View(parame);
        }


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var parame = _db.Parametres.Find(id);
            if (parame == null)
            {
                return NotFound();
            }
            return View(parame);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Parametre parame)
        {
            _db.Parametres.Update(parame);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }


        // GET: /Delete
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            Parametre parame = _db.Parametres.Find(id);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            if (parame == null)
            {
                return NotFound();
            }
            return View(parame);
        }


        // POST: /Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Parametre parame = _db.Parametres.Find(id);
            _db.Parametres.Remove(parame);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}