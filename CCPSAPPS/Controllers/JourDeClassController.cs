//using CCPSAPPS.Data;
using CCPSAPPS.Models;
using Microsoft.AspNetCore.Mvc;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
using ApplicationDbContext = CCPSAPPS.Data.ApplicationDbContext;

namespace CCPSAPPS.Controllers
{
    public class JourDeClassController : Controller

    {
        private readonly ApplicationDbContext _db;

        public JourDeClassController(ApplicationDbContext db)
        {
            _db = db;
        }



        //show all the data
        public IActionResult Index()
        {
            IEnumerable<JoursDeClass> jourClass = _db.JoursDeClasses;
            return View(jourClass);
        }


        //Get - Create
        public IActionResult Create()
        {

            return View();
        }

        //Post- Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(JoursDeClass jourClass)
        {
            _db.JoursDeClasses.Add(jourClass);
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
            JoursDeClass jourClass = _db.JoursDeClasses.Find(id);
            if (jourClass == null)
            {
                return NotFound();
            }
            return View(jourClass);
        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var jourClass = _db.JoursDeClasses.Find(id);
            if (jourClass == null)
            {
                return NotFound();
            }
            return View(jourClass);
        }


        // POST: /Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JoursDeClass jourClass = _db.JoursDeClasses.Find(id);
            _db.JoursDeClasses.Remove(jourClass);
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
            var jourClass = _db.JoursDeClasses.Find(id);
            if (jourClass == null)
            {
                return NotFound();
            }
            return View(jourClass);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(JoursDeClass jourClass)
        {
            _db.JoursDeClasses.Update(jourClass);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        



    }
}
