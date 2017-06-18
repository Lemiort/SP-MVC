using Microsoft.SharePoint.Client;
using SP_MVC.Models.ModelToData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Display(Name = "Название предприятия")]
        public string CompanyName { get { return routeCar.CompanyName; } }

        [Display(Name = "Разработал")]
        public string DeveloperName { get { return _users.Where(user => user.Id == routeCar.Developer).First()["Title"].ToString(); } }

        [Display(Name = "Проверил")]
        public string CheckedName { get { return _users.Where(user => user.Id == routeCar.Checked).First()["Title"].ToString(); } }

        [Display(Name = "Согласовано")]
        public string AgreedName { get { return _users.Where(user => user.Id == routeCar.Agreed).First()["Title"].ToString(); } }

        [Display(Name = "Утвердил")]
        public string ApprovedName { get { return _users.Where(user => user.Id == routeCar.Approved).First()["Title"].ToString(); } }

        [Display(Name = "Нормконтроллер")]
        public string NormСontrollerName { get { return _users.Where(user => user.Id == routeCar.NormСontroller).First()["Title"].ToString(); } }

        public Route Route { get { return routeCar.Route; }  }
    }
}