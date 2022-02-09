using CCPSAPPS.Models;
using Microsoft.AspNetCore.Mvc;
using ApplicationDbContext = CCPSAPPS.Data.ApplicationDbContext;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace CCPSAPPS.Controllers
{
    public class infoCours{
        string Categorie;
}

    public class EtudiantGradueController : Controller
    {
        private readonly ApplicationDbContext _db;

        public EtudiantGradueController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Gradue> etduantGradue = _db.Gradues;
            return View(etduantGradue);
        }

        private List<InfoPersonne> Personnes()
        {
            //instaciation de la classe Info personne cree dans le folder Models
            var pers = new List<InfoPersonne>();

            //toutes les informations de la table personne
            IEnumerable<Personne> per = _db.Personnes;

            //iteration dans la personne pour remplire la liste information sur personne
            foreach (var x in per)
            {
                //recuperation des information's d'une personne
                var nomComplet = x.Prenom + " " + x.Nom + " :<->:Tel: " + x.Telephone1;

                //remplire la liste
                pers.Add(new InfoPersonne() { PersonneId = x.PersonneId, NomCompletEtTelephone = nomComplet });

            }

            return pers;
        }

        //Setting the classe categories data
        List<string> cat = new List<string>();
        List<InfoListeCours> cours = new List<InfoListeCours>();
        private List<InfoListeCours> Maliste()
        {
            //instaciation de la classe Info personne cree dans le folder Models
  

            //toutes les informations de la table personne
            IEnumerable<Class> cour = _db.Classes;

            //iteration dans la personne pour remplire la liste information sur personne
            

            foreach (var y in cour)
            {

                cat.Add(y.Categorie);
                Console.WriteLine(y.Categorie);
                //remplire la liste
                cours.Add(new InfoListeCours() { Categorie = "Hello" });


            }

            
            return cours;
        }

        //Get - Create
        public IActionResult Create()
        {
            //passing personne data to create view 
            ViewBag.PersonneSelectedList = new SelectList(Personnes(), "PersonneId", "NomCompletEtTelephone");


            //passing cours Categorie data to create view
            ViewBag.ListeCours = cours;







            return View();
        }

        //Post- Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Gradue etudiantGradue)
        {
            _db.Gradues.Add(etudiantGradue);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
        //show a simple record using its id
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var etduantGradue = _db.Gradues.Find(id);
            if (etduantGradue == null)
            {
                return NotFound();
            }
            return View(etduantGradue);
        }

        // GET: /Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Gradue etduantGradue = _db.Gradues.Find(id);
            if (etduantGradue == null)
            {
                return NotFound();
            }
            return View(etduantGradue);
        }


        // POST: /Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gradue etduantGradue = _db.Gradues.Find(id);

            _db.Gradues.Remove(etduantGradue);
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
            var etudiantGradue = _db.Gradues.Find(id);
            if (etudiantGradue == null)
            {
                return NotFound();
            }
            return View(etudiantGradue);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Gradue etudiantGradue)
        {
            _db.Gradues.Update(etudiantGradue);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
