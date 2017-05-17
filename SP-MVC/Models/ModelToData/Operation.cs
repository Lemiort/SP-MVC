namespace SP_MVC
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TechProcProd.Operation")]
    public partial class Operation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Operation()
        {
            TechnologicalProcesses = new HashSet<TechnologicalProcesses>();
        }

        public int OperationId { get; set; }

        public string Name { get; set; }

        public int Number { get; set; }

        public int TransitionId { get; set; }

        public string TransitionName { get; set; }

        public int EquipmentId { get; set; }

        public int RiggingId { get; set; }

        public int DepartmentNumber { get; set; }

        public int SiteNumber { get; set; }

        public int WorkplaceNumber { get; set; }

        public virtual Equipment Equipment { get; set; }

        public virtual Rigging Rigging { get; set; }

        public virtual Transition Transition { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TechnologicalProcesses> TechnologicalProcesses { get; set; }
    }
}
