namespace SP_MVC
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TechProcProd.Route")]
    public partial class Route
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Route()
        {
            RouteCar = new HashSet<RouteCar>();
        }

        public int RouteId { get; set; }

        public int TechProcId { get; set; }

        public string NameTechProc { get; set; }

        public int NameOfDeveloper { get; set; }

        public string DetailsDesignation { get; set; }

        public string DetailsName { get; set; }

        public virtual TechnologicalProcesses TechnologicalProcesses { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RouteCar> RouteCar { get; set; }
    }
}
