namespace SP_MVC.Models.ModelToData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TechProcProd.Transition")]
    public partial class Transition
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Transition()
        {
            Operations = new HashSet<Operation>();
        }

        [Display(Name = "��� ��������")]
        public int TransitionId { get; set; }

        [Display(Name = "����� ��������")]
        public int TransitionNumber { get; set; }

        [Display(Name = "�������� �����")]
        public string Keyword { get; set; }

        [Display(Name = "��� ��������")]
        public string TransitionType { get; set; }

        [Display(Name = "��������")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Operation> Operations { get; set; }
    }
}
