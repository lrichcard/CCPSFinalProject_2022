//using CCPSAPPS.Models;
//using Microsoft.AspNetCore.Mvc;
//using ApplicationDbContext = CCPSAPPS.Data.ApplicationDbContext;

//namespace CCPSAPPS.Controllers
//{
//    public class HeureDeClasseController : Controller
//    {
//        private readonly ApplicationDbContext _db;

//        public HeureDeClasseController(ApplicationDbContext db)
//        {
//            _db = db;
//        }

//        // GET: HeureDeClasseController
//        public ActionResult Index()
//        {
//            IEnumerable<HeuresDeClass> heureDeClasse = _db.HeureDeClasses;
//            return View(heureDeClasse);
            
//        }

//        //// GET: HeureDeClasseController/Details/5
//        //public ActionResult Details(int id)
//        //{
//        //    return View();
//        //}

//        //// GET: HeureDeClasseController/Create
//        //public ActionResult Create()
//        //{
//        //    return View();
//        //}

//        //// POST: HeureDeClasseController/Create
//        //[HttpPost]
//        //[ValidateAntiForgeryToken]
//        //public ActionResult Create(IFormCollection collection)
//        //{
//        //    try
//        //    {
//        //        return RedirectToAction(nameof(Index));
//        //    }
//        //    catch
//        //    {
//        //        return View();
//        //    }
//        //}

//        //// GET: HeureDeClasseController/Edit/5
//        //public ActionResult Edit(int id)
//        //{
//        //    return View();
//        //}

//        //// POST: HeureDeClasseController/Edit/5
//        //[HttpPost]
//        //[ValidateAntiForgeryToken]
//        //public ActionResult Edit(int id, IFormCollection collection)
//        //{
//        //    try
//        //    {
//        //        return RedirectToAction(nameof(Index));
//        //    }
//        //    catch
//        //    {
//        //        return View();
//        //    }
//        //}

//        //// GET: HeureDeClasseController/Delete/5
//        //public ActionResult Delete(int id)
//        //{
//        //    return View();
//        //}

//        //// POST: HeureDeClasseController/Delete/5
//        //[HttpPost]
//        //[ValidateAntiForgeryToken]
//        //public ActionResult Delete(int id, IFormCollection collection)
//        //{
//        //    try
//        //    {
//        //        return RedirectToAction(nameof(Index));
//        //    }
//        //    catch
//        //    {
//        //        return View();
//        //    }
//        //}
//    }
//}
