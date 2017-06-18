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
        [Display(Name = "��� ��")]
        [Key]
        public int TechProcId { get; set; }

        [Display(Name = "������������")]
        public string Name { get; set; }

        [Display(Name = "��� ���������")]
        public int MaterialId { get; set; }

        [Display(Name = "��� �� ������ ����������")]
        public string TypeByExecution { get; set; }

        [Display(Name = "����� ����")]
        public int ActNumber { get; set; }

        [Column(TypeName = "datetime2")]
        [Display(Name = "���� ��������� ��")]
        public DateTime DateStartTechProc { get; set; }

        [Display(Name = "��������")]
        public virtual Material Material { get; set; }

        [Display(Name = "��������")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Route> Routes { get; set; }

        [Display(Name = "��������")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Operation> Operations { get; set; }
    }
}
