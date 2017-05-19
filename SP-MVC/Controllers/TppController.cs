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
            IEnumerable<Material> model = db.Material;
            return View(model);
        }
        
        public ActionResult DeleteMaterial(int id)
        {
            TppContext db = new TppContext();
            db.Material.Remove(db.Material.Find(id));
            db.SaveChanges();
            /*IEnumerable<Material> temp = db.Material;
            return View("MaterialsList",temp);*/
            return RedirectToAction("MaterialsList");
        }

        public ActionResult AddMaterial(Material material)
        {
            TppContext db = new TppContext();
            db.Material.Add(material);
            db.SaveChanges();

            /*IEnumerable<Material> temp = db.Material;
            return View("MaterialsList", temp);*/
            return RedirectToAction("MaterialsList");
        }

        public ActionResult EquipmentList()
        {
            TppContext db = new TppContext();
            IEnumerable<Equipment> model = db.Equipment;
            return View(model);
        }

        
        public ActionResult DeleteEquipment(int id)
        {
            TppContext db = new TppContext();
            db.Equipment.Remove(db.Equipment.Find(id));
            db.SaveChanges();
            return RedirectToAction("EquipmentList");
        }

        public ActionResult AddEquipment(Equipment equipment)
        {
            TppContext db = new TppContext();
            db.Equipment.Add(equipment);
            db.SaveChanges();
            return RedirectToAction("EquipmentList");
        }

        public ActionResult RiggingList()
        {
            TppContext db = new TppContext();
            IEnumerable<Rigging> model = db.Rigging;
            return View(model);
        }

        public ActionResult DeleteRigging(int id)
        {
            TppContext db = new TppContext();
            db.Rigging.Remove(db.Rigging.Find(id));
            db.SaveChanges();
            return RedirectToAction("RiggingList");
        }

        public ActionResult AddRigging(Rigging rigging)
        {
            TppContext db = new TppContext();
            db.Rigging.Add(rigging);
            db.SaveChanges();
            return RedirectToAction("RiggingList");
        }
    }
}