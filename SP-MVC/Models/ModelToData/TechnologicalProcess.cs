namespace SP_MVC.Models.ModelToData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TechProcProd.TechnologicalProcesses")]
    public partial class TechnologicalProcess
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TechnologicalProcess()
        {
            Routes = new HashSet<Route>();
            Operations = new HashSet<Operation>();
        }

        [Key]
        public int TechProcId { get; set; }

        public string Name { get; set; }

        public int MaterialId { get; set; }

        public string TypeByExecution { get; set; }

        public int ActNumber { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime DateStartTechProc { get; set; }

        public virtual Material Material { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Route> Routes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Operation> Operations { get; set; }
    }
}
