namespace SP_MVC.Models.ModelToData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TechProcProd.RouteCar")]
    public partial class RouteCar
    {
        [Display(Name = "Код маршрутной карты")]
        public int RouteCarId { get; set; }

        [Display(Name = "Код маршрута")]
        public int RouteId { get; set; }

        [Display(Name = "Название предприятия")]
        public string CompanyName { get; set; }

        [Display(Name = "Разработал")]
        public int Developer { get; set; }

        [Display(Name = "Проверил")]
        public int Checked { get; set; }

        [Display(Name = "Согласовано")]
        public int Agreed { get; set; }

        [Display(Name = "Утвердил")]
        public int Approved { get; set; }

        [Display(Name = "Нормконтроллер")]
        public int NormСontroller { get; set; }

        [Display(Name = "Маршрут")]
        public virtual Route Route { get; set; }
    }
}
