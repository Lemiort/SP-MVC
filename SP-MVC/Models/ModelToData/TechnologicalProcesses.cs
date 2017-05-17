namespace SP_MVC
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TechProcProd.TechnologicalProcesses")]
    public partial class TechnologicalProcesses
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TechnologicalProcesses()
        {
            Route = new HashSet<Route>();
        }

        [Key]
        public int TechProcId { get; set; }

        public string Name { get; set; }

        public int OperationId { get; set; }

        public int MaterialId { get; set; }

        public string TypeByExecution { get; set; }

        public int ActNumber { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime DateStartTechProc { get; set; }

        public virtual Material Material { get; set; }

        public virtual Operation Operation { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Route> Route { get; set; }
    }
}
