using System;
using CCPSAPPS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.Rendering;
using ApplicationDbContext = CCPSAPPS.Data.ApplicationDbContext;

namespace CCPSAPPS.Controllers
{

    public class EtudiantCourantController : Controller
    {
        private readonly ApplicationDbContext _db;

        public EtudiantCourantController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index(int pg = 1)
        {
            IEnumerable<EtudiantsCourant> etudiantsCourants = _db.EtudiantsCourants;

            const int pageSize = 50;
            if (pg < 1)
                pg = 1;
            int resCount = etudiantsCourants.Count();
            var page = new Pager(resCount, pg, pageSize);

            int recSkip = (pg - 1) * pageSize;
            var data = etudiantsCourants.Skip(recSkip).Take(page.PageSize).ToList();

            this.ViewBag.Page = page;

            return View(data);
            //return View(etudiantsCourants);
        }


  
        //appelle de la classe InfoPersonne
        private List<InfoPersonne> Personnes()
        {   
            //instaciation de la classe Info personne cree dans le folder Models
            var pers = new List<InfoPersonne>();
            
            //toutes les informations de la table personne
            IEnumerable<Personne> per = _db.Personnes;

            //iteration dans la personne pour remplire la liste information sur personne
            foreach(var x in per)
            { 
                //recuperation des information's d'une personne
                var nomComplet = x.Prenom+" " + x.Nom +" :<->:Tel: "+ x.Telephone1;
                
                //remplire la liste
                pers.Add(new InfoPersonne() { PersonneId = x.PersonneId, NomCompletEtTelephone = nomComplet });
                  
            }
              
            return pers;
        }



        //appelle de la classe InfoSession
        private List<InfoSession> Sessions()
        {
            //instaciation de la classe Info session cree dans le folder Models
            var ses = new List<InfoSession>();

            //toutes les informations de la table personne
            IEnumerable<Session> session = (IEnumerable<Session>)_db.Sessions;

            //iteration dans la personne pour remplire la liste information sur personne
            foreach (var x in session)
            {
                //recuperation des information's d'une personne
                var actif = x.Actif;

                //remplire la liste
                if (x.Actif == 0)
                {
                    ses.Add(new InfoSession() { SessionId = x.SessionId, SessionActif = actif });
                }
            }

            return ses;
        }






        //Get - Create
        public IActionResult Create()
        {
            

            //using ViewBag to pass all the data
            ViewBag.PersonneSelectedList = new SelectList(Personnes(), "PersonneId", "NomCompletEtTelephone");

     
            ViewBag.SessionInfo = new SelectList(Sessions(), "SessionId", "SessionActif");
          
            return View();
        }

        //Post- Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EtudiantsCourant etudiantsCourant)
        {
            var UserName = Environment.UserName;
            etudiantsCourant.CreeParUsername = UserName;

            _db.EtudiantsCourants.Add(etudiantsCourant);
            
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
            var etudiantCourant = _db.EtudiantsCourants.Find(id);
            if (etudiantCourant == null)
            {
                return NotFound();
            }
            return View(etudiantCourant);
        }

        // GET: /Movies/Delete/5
        public ActionResult Delete(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            var etudiantC = _db.EtudiantsCourants.Find(id);
            if (etudiantC == null)
            {
                return NotFound();
            }
            return View(etudiantC);
        }



        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var etudiantC = _db.EtudiantsCourants.Find(id);
            if (etudiantC == null)
            {
                return NotFound();
            }
            return View(etudiantC);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(EtudiantsCourant etudiantC)
        {
            _db.EtudiantsCourants.Update(etudiantC);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }



        // POST: /Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EtudiantsCourant etudiantsCourant = _db.EtudiantsCourants.Find(id);
            _db.EtudiantsCourants.Remove(etudiantsCourant);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
