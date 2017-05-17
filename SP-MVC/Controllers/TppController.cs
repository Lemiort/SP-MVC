using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SP_MVC.Controllers
{
    public class TppController : Controller
    {
        // GET: Tpp
        public ActionResult Index()
        {
            TppContext context = new TppContext();
            ViewBag.SomeInfo = context.Material.Count();
            return View();
        }

        [HttpGet]
        public ActionResult MaterialsList()
        {
            TppContext db = new TppContext();
            IEnumerable<Material> temp = db.Material;
            return View(temp);
        }

        [HttpPost]
        public ActionResult DeleteMaterial(Material material)
        {
            TppContext db = new TppContext();
            db.Material.Attach(material);
            db.Entry(material).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            IEnumerable<Material> temp = db.Material;
            return View("MaterialList",temp);
        }

    }
}