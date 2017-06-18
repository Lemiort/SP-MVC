namespace SP_MVC.Models.ModelToData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TechProcProd.Rigging")]
    public partial class Rigging
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Rigging()
        {
            Operations = new HashSet<Operation>();
        }

        [Display(Name = "��� ��������")]
        public int RiggingId { get; set; }

        [Display(Name = "������������")]
        public string Name { get; set; }

        [Display(Name = "��� �����������")]
        public string TypeOfTool { get; set; }

        [Display(Name = "����������")]
        public int Quantity { get; set; }

        [Display(Name = "��������")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Operation> Operations { get; set; }
    }
}
