using CCPSAPPS.Models;
using Microsoft.AspNetCore.Mvc;
using ApplicationDbContext = CCPSAPPS.Data.ApplicationDbContext;
namespace CCPSAPPS.Controllers
{
    public class ClasseController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ClasseController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Class> salle = _db.Classes;
            return View(salle);
        }

        //Get - Create
        public IActionResult Create()
        {

            return View();
        }

        //Post- Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Class laclass)
        {
            _db.Classes.Add(laclass);
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
            Class laclasse = _db.Classes.Find(id);
            if (laclasse == null)
            {
                return NotFound();
            }
            return View(laclasse);
        }


        //// POST: /Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Class laclass = _db.Classes.Find(id);
            _db.Classes.Remove(laclass);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var laclasse = _db.Classes.Find(id);
            if (laclasse == null)
            {
                return NotFound();
            }
            return View(laclasse);
        }


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var laclass = _db.Classes.Find(id);
            if (laclass == null)
            {
                return NotFound();
            }
            return View(laclass);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Class laclass)
        {
            _db.Classes.Update(laclass);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }





    }
}
 
