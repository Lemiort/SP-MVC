namespace SP_MVC.Models.ModelToData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TechProcProd.Equipment")]
    public partial class Equipment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Equipment()
        {
            Operations = new HashSet<Operation>();
        }

        [Display(Name ="��� ������������")]
        public int EquipmentId { get; set; }

        [Display(Name = "����� ������")]
        public int DetailNumber { get; set; }

        [Display(Name = "������������")]
        public string Name { get; set; }

        [Display(Name = "����������")]
        public int Quantity { get; set; }

        [Display(Name = "���")]
        public string Department { get; set; }

        [Display(Name = "��������")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Operation> Operations { get; set; }
    }
}
