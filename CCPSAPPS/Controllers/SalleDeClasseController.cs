using CCPSAPPS.Models;
using Microsoft.AspNetCore.Mvc;
using ApplicationDbContext = CCPSAPPS.Data.ApplicationDbContext;
namespace CCPSAPPS.Controllers
{
    public class SalleDeClasseController : Controller
    {
        private readonly ApplicationDbContext _db;

        public SalleDeClasseController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<SalleDeClass> salle = _db.SalleDeClasses;
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
        public IActionResult Create(SalleDeClass salleClasse)
        {
            _db.SalleDeClasses.Add(salleClasse);
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
            SalleDeClass salleDeClass = _db.SalleDeClasses.Find(id);
            if (salleDeClass == null)
            {
                return NotFound();
            }
            return View(salleDeClass);
        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var salleClass = _db.SalleDeClasses.Find(id);
            if (salleClass == null)
            {
                return NotFound();
            }
            return View(salleClass);
        }


        // POST: /Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SalleDeClass salleDeClass = _db.SalleDeClasses.Find(id);
            _db.SalleDeClasses.Remove(salleDeClass);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var salleClasse = _db.SalleDeClasses.Find(id);
            if (salleClasse == null)
            {
                return NotFound();
            }
            return View(salleClasse);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(SalleDeClass salleClasse)
        {
            _db.SalleDeClasses.Update(salleClasse);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }





    }
}
