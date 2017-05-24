using ClosedXML.Excel;
using SP_MVC.Models;
using SP_MVC.Models.ModelToData;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
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
            model.operation.Riggings = new List<Rigging>();
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
            foreach( var item in model.selectedRigging)
            {
                Rigging rig = db.Riggings.Find(int.Parse(item));
                model.operation.Riggings.Add(rig);
            }
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

        [HttpGet]
        public ActionResult AddTechnologicalProcesses()
        {
            TechnologicalProcessesViewModel model = new TechnologicalProcessesViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult AddTechnologicalProcesses(TechnologicalProcessesViewModel model)
        {
            TppContext db = new TppContext();
            Material mat = db.Materials.Find(model.tp.MaterialId);
            model.tp.Material = mat;

            foreach( var item in model.selectedOperations)
            {
                Operation oper = db.Operations.Find(int.Parse(item));
                model.tp.Operations.Add(oper );
            }
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
            model.route.TechnologicalProcess = tp;
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
            TppContext db = new TppContext();
            RouteCar routeCar = db.RouteCars.Find(id);
            RouteCarTableViewModel routeCarView = new RouteCarTableViewModel(routeCar);

            SharepointContext sp = new SharepointContext();
            var users = sp.GetUserCollection();

           
            var document = new XLWorkbook(Server.MapPath("..\\..\\App_Data\\MK_-pustoy_shablon.xlsx"));
            var ws = document.Worksheet(1);


            //date
            /*ws.Cell("AF8").Value = routeCar.Route.TechnologicalProcess.DateStartTechProc.ToShortDateString();
            ws.Cell("AI9").Value = routeCar.Route.TechnologicalProcess.DateStartTechProc.ToShortDateString();
            ws.Cell("AF12").Value = routeCar.Route.TechnologicalProcess.DateStartTechProc.ToShortDateString();*/
            string str = String.Format("{0}.{1}.{2}", DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year);
            ws.Cell("AF8").Value = str;
            ws.Cell("AF9").Value = str;
            ws.Cell("AF12").Value = str;

            //developetr
            ws.Cell("J8").Value = routeCarView.DeveloperName;
            //checker
            ws.Cell("J9").Value = routeCarView.CheckedName;
            //norm contr
            ws.Cell("J12").Value = routeCarView.NormСontrollerName;

            //company name
            ws.Cell("AL8").Value = routeCarView.CompanyName;

            //detail descr
            ws.Cell("BB8").Value = routeCar.Route.DetailsDesignation;

            //detail name
            ws.Cell("AR11").Value = routeCar.Route.DetailsName;

            //mat code
            ws.Cell("F15").Value = routeCar.Route.TechnologicalProcess.MaterialId;

            //mat qantity
            //ws.Cell("CD15").Value = routeCar.Route.TechnologicalProcess.

            //mat name
            //ws.Cell("F13").Value = routeCar.Route.TechnologicalProcess.
            int operCounter = 0;
            int strCounter = 0;
            foreach (var oper in routeCar.Route.TechnologicalProcess.Operations)
            {
                ws.Cell(String.Format("A{0}", strCounter + 19)).Value = String.Format("А{0}", (strCounter + 3).ToString("D2"));
                ws.Cell(String.Format("F{0}", strCounter + 19)).Value = String.Format("{0} {1} {2} {3} {4} {5}",
                    oper.SiteNumber, //shop number
                    oper.SiteNumber,
                    oper.WorkplaceNumber,
                    oper.Name,
                    oper.OperationId,
                    oper.Name
                    );
                strCounter++;
                ws.Cell(String.Format("A{0}", strCounter + 19)).Value = String.Format("Б{0}", (strCounter + 3).ToString("D2"));
                ws.Cell(String.Format("F{0}", strCounter + 19)).Value = String.Format("{0} {1}",
                    oper.Equipment.EquipmentId,
                    oper.Equipment.Name
                    );
                foreach (var rig in oper.Riggings)
                {
                    ws.Cell(String.Format("A{0}", strCounter + 19)).Value = String.Format("Т{0}", (strCounter + 3).ToString("D2"));
                    ws.Cell(String.Format("F{0}", strCounter + 19)).Value = String.Format("{0} {1}",
                       rig.RiggingId,
                       rig.Name
                       );
                    strCounter++;
                }
                operCounter++;
            }

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