namespace SP_MVC.Models.ModelToData
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
            Riggings = new HashSet<Rigging>();
            TechnologicalProcesses = new HashSet<TechnologicalProcess>();
        }

        [Display(Name = "Код операции")]
        public int OperationId { get; set; }

        [Display(Name = "Наименование")]
        public string Name { get; set; }

        [Display(Name = "Номер")]
        public int Number { get; set; }

        [Display(Name = "Код перехода")]
        public int TransitionId { get; set; }

        [Display(Name = "Название перехода")]
        public string TransitionName { get; set; }

        [Display(Name = "Код оборудования")]
        public int EquipmentId { get; set; }

        [Display(Name = "Номер цеха")]
        public int DepartmentNumber { get; set; }

        [Display(Name = "Номер участка")]
        public int SiteNumber { get; set; }

        [Display(Name = "Номер рабочего места")]
        public int WorkplaceNumber { get; set; }

        [Display(Name = "Оборудование")]
        public virtual Equipment Equipment { get; set; }

        [Display(Name = "Переход")]
        public virtual Transition Transition { get; set; }

        [Display(Name = "Операции")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rigging> Riggings { get; set; }

        [Display(Name = "Технологические процессы")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TechnologicalProcess> TechnologicalProcesses { get; set; }
    }
}
