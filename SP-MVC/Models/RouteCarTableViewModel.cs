using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SP_MVC.Models
{
    public class RouteCarTableViewModel
    {
        public RouteCar routeCar;

        private IEnumerable<ListItem> _users;

        public RouteCarTableViewModel(RouteCar _rc)
        {
            routeCar = _rc;
            SharepointContext sp = new SharepointContext();
            _users = sp.GetUserCollection();
        }

        public int RouteCarId { get { return routeCar.RouteCarId; } }

        public int RouteId { get { return routeCar.RouteId; } }

        public string CompanyName { get { return routeCar.CompanyName; } }

        public string DeveloperName { get { return _users.Where(user => user.Id == routeCar.Developer).First()["Title"].ToString(); } }

        public string CheckedName { get { return _users.Where(user => user.Id == routeCar.Checked).First()["Title"].ToString(); } }

        public string AgreedName { get { return _users.Where(user => user.Id == routeCar.Agreed).First()["Title"].ToString(); } }

        public string ApprovedName { get { return _users.Where(user => user.Id == routeCar.Approved).First()["Title"].ToString(); } }

        public string NormСontrollerName { get { return _users.Where(user => user.Id == routeCar.NormСontroller).First()["Title"].ToString(); } }

        public Route Route { get { return routeCar.Route; }  }
    }
}