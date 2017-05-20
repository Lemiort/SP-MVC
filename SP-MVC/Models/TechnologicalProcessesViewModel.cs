using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SP_MVC.Models
{
    public class TechnologicalProcessesViewModel
    {
        public TechnologicalProcesses tp { get; set; }
        public IEnumerable<SelectListItem> materialList { get; set; }
        public IEnumerable<SelectListItem> operationList { get; set; }

        public TechnologicalProcessesViewModel()
        {
            tp = new TechnologicalProcesses();

            TppContext bd = new TppContext();
            List<SelectListItem> temp = new List<SelectListItem>();
            foreach (var mat in bd.Material)
            {
                temp.Add(new SelectListItem()
                {
                    Text = mat.Name,
                    Value = mat.MaterialId.ToString()
                });
            }
            materialList = temp;
            temp = new List<SelectListItem>();
            foreach (var oper in bd.Operation)
            {
                temp.Add(new SelectListItem()
                {
                    Text = oper.Name,
                    Value = oper.OperationId.ToString()
                });
            }
            operationList = temp;
        }
    }
}