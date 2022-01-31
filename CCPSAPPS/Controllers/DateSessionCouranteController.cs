using CCPSAPPS.Models;
using Microsoft.AspNetCore.Mvc;
using ApplicationDbContext = CCPSAPPS.Data.ApplicationDbContext;
namespace CCPSAPPS.Controllers
{
    public class DateSessionCouranteController : Controller
    {
        private readonly ApplicationDbContext _db;

        public DateSessionCouranteController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<DatesSessionCourante> datesSessions = _db.DatesSessionCourantes;
            return View(datesSessions);
        }

        //Get - Create
        public IActionResult Create()
        {

            return View();
        }

        //Post- Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DatesSessionCourante datesSessionCourante)
        {
            _db.DatesSessionCourantes.Add(datesSessionCourante);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var datesSessionCourante = _db.DatesSessionCourantes.Find(id);
            if (datesSessionCourante == null)
            {
                return NotFound();
            }
            return View(datesSessionCourante);
        }


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var datesSessionCourante = _db.DatesSessionCourantes.Find(id);
            if (datesSessionCourante == null)
            {
                return NotFound();
            }
            return View(datesSessionCourante);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(DatesSessionCourante datesSessionCourante)
        {
            _db.DatesSessionCourantes.Update(datesSessionCourante);
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
            DatesSessionCourante datesSessionCourante = _db.DatesSessionCourantes.Find(id);
            if (datesSessionCourante == null)
            {
                return NotFound();
            }
            return View(datesSessionCourante);
        }


        // POST: /Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DatesSessionCourante datesSessionCourante = _db.DatesSessionCourantes.Find(id);
            _db.DatesSessionCourantes.Remove(datesSessionCourante);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
