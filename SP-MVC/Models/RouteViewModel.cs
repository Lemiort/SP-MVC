using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SP_MVC.Models
{
    public class RouteViewModel
    {
        public Route route { get; set; }
        public IEnumerable<SelectListItem> techProcList { get; set; }
        public IEnumerable<SelectListItem> developerList { get; set; }

        public RouteViewModel()
        {
            route = new Route();

            TppContext bd = new TppContext();
            List<SelectListItem> temp = new List<SelectListItem>();
            foreach (var tp in bd.TechnologicalProcesses)
            {
                temp.Add(new SelectListItem()
                {
                    Text = tp.Name,
                    Value = tp.TechProcId.ToString()
                });
            }
            techProcList = temp;

            temp = new List<SelectListItem>();
            SharepointContext sp = new SharepointContext();
            foreach (var user in sp.GetUserCollection())
            {
                temp.Add(new SelectListItem()
                {
                    Text = user["Title"].ToString(),
                    Value = user.Id.ToString()
                });
            }
            developerList = temp;
        }
    }
}