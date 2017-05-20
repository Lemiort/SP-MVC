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
        public int RouteCarId { get; set; }

        public int RouteId { get; set; }

        public string CompanyName { get; set; }

        public int Developer { get; set; }

        public int Checked { get; set; }

        public int Agreed { get; set; }

        public int Approved { get; set; }

        public int NormСontroller { get; set; }

        public virtual Route Route { get; set; }
    }
}
