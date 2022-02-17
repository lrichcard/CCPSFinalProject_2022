using CCPSAPPS.Models;
using Microsoft.AspNetCore.Mvc;
using ApplicationDbContext = CCPSAPPS.Data.ApplicationDbContext;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace CCPSAPPS.Controllers
{
    public class SessionController : Controller
    {
        private readonly ApplicationDbContext _db;

        public SessionController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index(int pg = 1)
        {
            IEnumerable<Session> session = _db.Sessions;

            const int pageSize = 50;
            if (pg < 1)
                pg = 1;
            int resCount = session.Count();
            var page = new Pager(resCount, pg, pageSize);

            int recSkip = (pg - 1) * pageSize;
            var data = session.Skip(recSkip).Take(page.PageSize).ToList();

            this.ViewBag.Page = page;

            return View(data);
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
                if (x.Professeur == 1)
                {
                    //recuperation des information's d'une personne
                    var nomComplet = x.Prenom + " " + x.Nom + " :<->:Tel: " + x.Telephone1;

                    //remplire la liste
                    pers.Add(new InfoPersonne() { PersonneId = x.PersonneId, NomCompletEtTelephone = nomComplet });
                }
            }

            return pers;
        }
        private List<InfoClasse> IClasse()
        {
            //instaciation de la classe Info personne cree dans le folder Models
            var clas = new List<InfoClasse>();

            //toutes les informations de la table personne
            IEnumerable<Class> classe = _db.Classes;

            //iteration dans la personne pour remplire la liste information sur personne
            foreach (var x in classe)
            {
                var classDescription = x.NomClasse + " " + x.Description;
               

                    //remplire la liste
                   clas.Add(new InfoClasse() { ClasseId = x.ClasseId, NomClasse =classDescription });
                
            }

            return clas;
        }

        private List<InfoJour> Ijours()
        {
            //instaciation de la classe Info personne cree dans le folder Models
            var jour = new List<InfoJour>();

            //toutes les informations de la table personne
            IEnumerable<JoursDeClass> jours = _db.JoursDeClasses;

            //iteration dans la personne pour remplire la liste information sur personne
            foreach (var x in jours)
            {
             


                //remplire la liste
                jour.Add(new InfoJour() { JourId = x.JourId, NomJour = x.JourDescription });

            }

            return jour;
        }


        private List<InfoHeure> IHeure()
        {
            //instaciation de la classe Info personne cree dans le folder Models
            var heure = new List<InfoHeure>();

            //toutes les informations de la table personne
            IEnumerable<HeuresDeClass> heures = _db.HeureDeClasses;

            //iteration dans la personne pour remplire la liste information sur personne
            foreach (var x in heures)
            {

               

                //remplire la liste
                heure.Add(new InfoHeure() { HeureId = x.HeureID, NomHeure = x.HeureDescription });

            }

            return heure;
        }
        //Get - Create
        public IActionResult Create()
        {


            ViewBag.infoProf = new SelectList(Personnes(), "PersonneId", "NomCompletEtTelephone");
            ViewBag.infoClasse = new SelectList(IClasse(), "ClasseId", "NomClasse");
            ViewBag.infoJour = new SelectList(Ijours(), "NomJour", "NomJour");
            ViewBag.infoHeure = new SelectList(IHeure(), "NomHeure", "NomHeure");



            return View();
        }

        //Post- Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Session session)
        {
            //recupere le nom de l'utilisateur
            var UserName = Environment.UserName;
            session.Byusername = UserName;
            _db.Sessions.Add(session);
          
           // session.Heures = "Heures";
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
            var session = _db.Sessions.Find(id);
            if (session == null)
            {
                return NotFound();
            }
            return View(session);
        }


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var session = _db.Sessions.Find(id);
            if (session == null)
            {
                return NotFound();
            }
            return View(session);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Session session)
        {
            _db.Sessions.Update(session);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }


        // GET: /Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Session session = _db.Sessions.Find(id);
            if (session == null)
            {
                return NotFound();
            }
            return View(session);
        }


        // POST: /Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Session session = _db.Sessions.Find(id);
            _db.Sessions.Remove(session);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}

