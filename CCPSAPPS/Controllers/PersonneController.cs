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
       

        //public IActionResult Index(int pg=1)
        //{
        //    IEnumerable<Personne> personne = _db.Personnes;

        //    const int pageSize = 50;
        //    if (pg < 1)
        //        pg = 1;
        //    int resCount = personne.Count();
        //    var page = new Pager(resCount, pg, pageSize);

        //    int recSkip = (pg - 1) * pageSize;
        //    var data = personne.Skip(recSkip).Take(page.PageSize).ToList();

        //    this.ViewBag.Page = page;

        //    return View(data);

        //   // return View(personne);

        //}

        ////Get - Create
        //public IActionResult Create()
        //{

        //    return View();
        //}

        ////Post- Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Create(Personne personne)
        //{
        //    _db.Personnes.Add(personne);
        //    _db.SaveChanges();

        //    return RedirectToAction("Index");
        //}


        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    var personne = _db.Personnes.Find(id);
        //    if (personne == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(personne);
        //}


        ////[HttpPost]
        ////[ValidateAntiForgeryToken]
        //public ActionResult Update(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    var personne = _db.Personnes.Find(id);
        //    if (personne == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(personne);
        //}


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Update(Personne personne)
        //{
        //    _db.Personnes.Update(personne);
        //    _db.SaveChanges();

        //    return RedirectToAction("Index");
        //}


        //// GET: /Movies/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    Personne personne = _db.Personnes.Find(id);
        //    if (personne == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(personne);
        //}


        //// POST: /Movies/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Personne personne = _db.Personnes.Find(id);
        //    _db.Personnes.Remove(personne);
        //    _db.SaveChanges();
        //    return RedirectToAction("Index");
        //}


        public IActionResult Index()
        {
            IEnumerable<Personne> objPersonneList = _db.Personnes.ToList();
            //return View(objPersonneList);
            return View("Create");
        }

        //GET Action Methode
        public IActionResult Create()
        {
            return View();
        }

        //Post Action Methode
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Personne obj)
        {
            if (ModelState.IsValid)
            {
                bool b = Convert.ToBoolean(obj.AdminStaff);
                ViewBag.statut = obj.Statut;
                ViewBag.adminStaff = obj.AdminStaff;

                if (ViewBag.statut == "Etudiant")
                {
                    if (ViewBag.adminStaff == true)
                    {
                        obj.Etudiant = 1;
                        obj.Statut = "Etudiant et Staff";
                        _db.Personnes.Add(obj);
                        _db.SaveChanges();
                        return RedirectToAction("Index", "AjouterEtudiantDansClasse");
                    }
                    else
                    {
                        obj.Etudiant = 1;
                        obj.Statut = "Etudiant";
                        _db.Personnes.Add(obj);
                        _db.SaveChanges();
                        return RedirectToAction("Index", "AjouterEtudiantDansClasse");
                    }
                }

                else if (ViewBag.statut == "Professeur")
                {
                    if (ViewBag.adminStaff == true)
                    {
                        obj.Professeur = 1;
                        obj.Statut = "Professeur et Staff";
                        _db.Personnes.Add(obj);
                        _db.SaveChanges();
                        return RedirectToAction("Create");
                    }
                    else
                    {
                        obj.Professeur = 1;
                        obj.Statut = "Professeur";
                        obj.AdminStaff = false;
                        _db.Personnes.Add(obj);
                        _db.SaveChanges();
                        return RedirectToAction("Create");
                    }
                }
                else if (obj.Etudiant == 0 && obj.Professeur == 0)
                {
                    obj.Etudiant = 0;
                    obj.Professeur = 0;
                    obj.Statut = "Staff";
                    _db.Personnes.Add(obj);
                    _db.SaveChanges();
                    return RedirectToAction("Create");
                }
            }

            return View(obj);

        }

        //GET Action Methode
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var personneFromDb = _db.Personnes.Find(id);
            //var personneFromDbFirst = _db.Personnes.FirstOrDefault(u=>u.personneID== id);
            //var personneFromDbSingle = _db.Personnes.SingleOrDefault(u=>u.personneID== id);
            if (personneFromDb == null)
            {
                return NotFound();
            }

            return View(personneFromDb);
        }

        //Post Action Methode
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Personne obj)
        {
            if (ModelState.IsValid)
            {
                _db.Personnes.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj);

        }

        //GET Action Methode
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var personneFromDb = _db.Personnes.Find(id);
            //var personneFromDbFirst = _db.Personnes.FirstOrDefault(u=>u.personneID== id);
            //var personneFromDbSingle = _db.Personnes.SingleOrDefault(u=>u.personneID== id);
            if (personneFromDb == null)
            {
                return NotFound();
            }

            return View(personneFromDb);
        }

        //Post Action Methode
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Personnes.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Personnes.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
 