using ClosedXML.Excel;
using SP_MVC.Models;
using SP_MVC.Models.ModelToData;
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
            ViewBag.SomeInfo = context.Materials.Count();
            return View();
        }

        [HttpGet]
        public ActionResult MaterialsList()
        {
            TppContext db = new TppContext();
            IEnumerable<Material> model = db.Materials;
            return View(model);
        }
        
        public ActionResult DeleteMaterial(int id)
        {
            TppContext db = new TppContext();
            db.Materials.Remove(db.Materials.Find(id));
            db.SaveChanges();
            return RedirectToAction("MaterialsList");
        }

        public ActionResult AddMaterial(Material material)
        {
            TppContext db = new TppContext();
            db.Materials.Add(material);
            db.SaveChanges();
            return RedirectToAction("MaterialsList");
        }

        public ActionResult EquipmentList()
        {
            TppContext db = new TppContext();
            IEnumerable<Equipment> model = db.Equipments;
            return View(model);
        }

        
        public ActionResult DeleteEquipment(int id)
        {
            TppContext db = new TppContext();
            db.Equipments.Remove(db.Equipments.Find(id));
            db.SaveChanges();
            return RedirectToAction("EquipmentList");
        }

        public ActionResult AddEquipment(Equipment equipment)
        {
            TppContext db = new TppContext();
            db.Equipments.Add(equipment);
            db.SaveChanges();
            return RedirectToAction("EquipmentList");
        }

        public ActionResult RiggingList()
        {
            TppContext db = new TppContext();
            IEnumerable<Rigging> model = db.Riggings;
            return View(model);
        }

        public ActionResult DeleteRigging(int id)
        {
            TppContext db = new TppContext();
            db.Riggings.Remove(db.Riggings.Find(id));
            db.SaveChanges();
            return RedirectToAction("RiggingList");
        }

        public ActionResult AddRigging(Rigging rigging)
        {
            TppContext db = new TppContext();
            db.Riggings.Add(rigging);
            db.SaveChanges();
            return RedirectToAction("RiggingList");
        }

        public ActionResult TransitionList()
        {
            TppContext db = new TppContext();
            IEnumerable<Transition> model = db.Transitions;
            return View(model);
        }

        public ActionResult DeleteTransition(int id)
        {
            TppContext db = new TppContext();
            db.Transitions.Remove(db.Transitions.Find(id));
            db.SaveChanges();
            return RedirectToAction("TransitionList");
        }

        public ActionResult AddTransition(Transition transition)
        {
            TppContext db = new TppContext();
            db.Transitions.Add(transition);
            db.SaveChanges();
            return RedirectToAction("TransitionList");
        }

        public ActionResult OperationList()
        {
            TppContext db = new TppContext();
            IEnumerable<Operation> model = db.Operations;
            return View(model);
        }

        public ActionResult DeleteOperation(int id)
        {
            TppContext db = new TppContext();
            db.Operations.Remove(db.Operations.Find(id));
            db.SaveChanges();
            return RedirectToAction("OperationList");
        }

        [HttpGet]
        public ActionResult AddOperation()
        {
            OperationViewModel model = new OperationViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult AddOperation(OperationViewModel model)
        {
            TppContext db = new TppContext();
            Transition trans = db.Transitions.Find(model.operation.TransitionId);
            model.operation.Transition = trans;
            Equipment eq = db.Equipments.Find(model.operation.EquipmentId);
            model.operation.Equipment = eq;
            //Rigging rig = db.Riggings.Find(model.operation.RiggingId);
            //model.operation.Rigging = rig;
            //TODO сделать множественное заполнение
            db.Operations.Add(model.operation);
            db.SaveChanges();
            return RedirectToAction("OperationList");
        }

        public ActionResult TechnologicalProcessesList()
        {
            TppContext db = new TppContext();
            IEnumerable<TechnologicalProcess> model = db.TechnologicalProcesses;
            return View(model);
        }


        public ActionResult DeleteTechnologicalProcesses(int id)
        {
            TppContext db = new TppContext();
            db.TechnologicalProcesses.Remove(db.TechnologicalProcesses.Find(id));
            db.SaveChanges();
            return RedirectToAction("TechnologicalProcessesList");
        }

        [HttpPost]
        public ActionResult AddTechnologicalProcesses(TechnologicalProcessesViewModel model)
        {
            TppContext db = new TppContext();
            Material mat = db.Materials.Find(model.tp.MaterialId);
            model.tp.Material = mat;
            ///Operation oper = db.Operations.Find(model.tp.o);
            //model.tp.Operation = oper;
            //TODO
            //сделать множественное заполнение
            db.TechnologicalProcesses.Add(model.tp);
            db.SaveChanges();
            return RedirectToAction("TechnologicalProcessesList");
        }

        public ActionResult RouteList()
        {
            TppContext db = new TppContext();
            IEnumerable<Route> model = db.Routes;
            return View(model);
        }

        public ActionResult DeleteRoute(int id)
        {
            TppContext db = new TppContext();
            db.Routes.Remove(db.Routes.Find(id));
            db.SaveChanges();
            return RedirectToAction("RouteList");
        }

        [HttpPost]
        public ActionResult AddRoute(RouteViewModel model)
        {
            TppContext db = new TppContext();
            TechnologicalProcess tp = db.TechnologicalProcesses.Find(model.route.TechProcId);
            //TODO
            //model.route.TechnologicalProcesses = tp;
            db.Routes.Add(model.route);
            db.SaveChanges();
            return RedirectToAction("RouteList");
        }

        public ActionResult RouteCardList()
        {
            TppContext db = new TppContext();
            IEnumerable<RouteCar> model = db.RouteCars;
            List<RouteCarTableViewModel> model2 = new List<RouteCarTableViewModel>();
            foreach( var  item  in model)
            {
                model2.Add(new RouteCarTableViewModel(item));
            }
            return View(model2);
        }

        public ActionResult DeleteRouteCard(int id)
        {
            TppContext db = new TppContext();
            db.RouteCars.Remove(db.RouteCars.Find(id));
            db.SaveChanges();
            return RedirectToAction("RouteCardList");
        }

        /*[HttpGet]
        public ActionResult AddRouteCard()
        {
            RouteCardViewModel model = new RouteCardViewModel();
            return View(model);
        }*/

        [HttpPost]
        public ActionResult AddRouteCard(RouteCardViewModel model)
        {
            TppContext db = new TppContext();
            Route route = db.Routes.Find(model.rc.RouteId);
            model.rc.Route = route;

            //users dont should be converted to objects

            db.RouteCars.Add(model.rc);
            db.SaveChanges();
            return RedirectToAction("RouteCardList");
        }

        public ActionResult DownloadRouteCard(int id)
        {
            var document = new XLWorkbook("C:\\Users\\Администратор.WIN-RNRNP8DOVU8\\Documents\\MK_-pustoy_shablon.xlsx");
            document.SaveAs("mk.xlsx");

            string filename = "mk.xlsx";
            //string filepath = AppDomain.CurrentDomain.BaseDirectory + "/Path/To/File/" + filename;
            string filepath = filename;
            byte[] filedata = System.IO.File.ReadAllBytes(filepath);
            string contentType = MimeMapping.GetMimeMapping(filepath);

            var cd = new System.Net.Mime.ContentDisposition
            {
                FileName = filename,
                Inline = true,
            };

            Response.AppendHeader("Content-Disposition", cd.ToString());

            return File(filedata, contentType);
        }
    }
}