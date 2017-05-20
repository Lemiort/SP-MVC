using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SP_MVC.Models
{
    public class RouteCardViewModel
    {
        public RouteCar rc { get; set; }
        public IEnumerable<SelectListItem> routesList { get; set; }
        public IEnumerable<SelectListItem> usersList { get; set; }

        public RouteCardViewModel()
        {
            rc = new RouteCar();

            TppContext bd = new TppContext();
            List<SelectListItem> temp = new List<SelectListItem>();
            foreach (var route in bd.Route)
            {
                temp.Add(new SelectListItem()
                {
                    Text = route.RouteId.ToString(),
                    Value = route.RouteId.ToString()
                });
            }
            routesList = temp;

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
            usersList = temp;
        }
    }
}