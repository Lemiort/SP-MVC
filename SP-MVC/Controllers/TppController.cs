﻿using SP_MVC.Models;
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

        public ActionResult TransitionList()
        {
            TppContext db = new TppContext();
            IEnumerable<Transition> model = db.Transition;
            return View(model);
        }

        public ActionResult DeleteTransition(int id)
        {
            TppContext db = new TppContext();
            db.Transition.Remove(db.Transition.Find(id));
            db.SaveChanges();
            return RedirectToAction("TransitionList");
        }

        public ActionResult AddTransition(Transition transition)
        {
            TppContext db = new TppContext();
            db.Transition.Add(transition);
            db.SaveChanges();
            return RedirectToAction("TransitionList");
        }

        public ActionResult OperationList()
        {
            TppContext db = new TppContext();
            IEnumerable<Operation> model = db.Operation;
            return View(model);
        }

        public ActionResult DeleteOperation(int id)
        {
            TppContext db = new TppContext();
            db.Operation.Remove(db.Operation.Find(id));
            db.SaveChanges();
            return RedirectToAction("OperationList");
        }

        /*[HttpGet]
        public ActionResult AddOperation()
        {
            OperationViewModel model = new OperationViewModel();
            return View(model);
        }*/

        [HttpPost]
        public ActionResult AddOperation(OperationViewModel model)
        {
            TppContext db = new TppContext();
            Transition trans = db.Transition.Find(model.operation.TransitionId);
            model.operation.Transition = trans;
            Equipment eq = db.Equipment.Find(model.operation.EquipmentId);
            model.operation.Equipment = eq;
            Rigging rig = db.Rigging.Find(model.operation.RiggingId);
            model.operation.Rigging = rig;
            db.Operation.Add(model.operation);
            db.SaveChanges();
            return RedirectToAction("OperationList");
        }

        public ActionResult TechnologicalProcessesList()
        {
            TppContext db = new TppContext();
            IEnumerable<TechnologicalProcesses> model = db.TechnologicalProcesses;
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
            Material mat = db.Material.Find(model.tp.MaterialId);
            model.tp.Material = mat;
            Operation oper = db.Operation.Find(model.tp.OperationId);
            model.tp.Operation = oper;
            db.TechnologicalProcesses.Add(model.tp);
            db.SaveChanges();
            return RedirectToAction("TechnologicalProcessesList");
        }
    }
}