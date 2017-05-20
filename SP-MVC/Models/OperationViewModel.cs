using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SP_MVC.Models
{
    public class OperationViewModel
    {
        public Operation operation { get; set; }
        public IEnumerable<SelectListItem> equipmentList { get; set; }
        public IEnumerable<SelectListItem> transitionList { get; set; }
        public IEnumerable<SelectListItem> riggingList { get; set; }

        public OperationViewModel()
        {
            operation = new Operation();

            TppContext bd = new TppContext();
            List<SelectListItem> temp = new List<SelectListItem>();
            foreach(var eq in bd.Equipment)
            {
                temp.Add(new SelectListItem()
                {
                    Text = eq.Name,
                    Value = eq.EquipmentId.ToString()
                });
            }
            equipmentList = temp;
            temp = new List<SelectListItem>();
            foreach (var tr in bd.Transition)
            {
                temp.Add(new SelectListItem()
                {
                    Text = tr.Keyword,
                    Value = tr.TransitionId.ToString()
                });
            }
            transitionList = temp;

            temp = new List<SelectListItem>();
            foreach (var rig in bd.Rigging)
            {
                temp.Add(new SelectListItem()
                {
                    Text = rig.Name,
                    Value = rig.RiggingId.ToString()
                });
            }
            riggingList = temp;
        }

    }
}