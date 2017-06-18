namespace SP_MVC.Models.ModelToData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TechProcProd.Material")]
    public partial class Material
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Material()
        {
            TechnologicalProcesses = new HashSet<TechnologicalProcess>();
        }

        [Display(Name = "��� ���������")]
        public int MaterialId { get; set; }

        [Display(Name = "���������")]
        public string Assortment { get; set; }

        [Display(Name = "��������")]
        public string Name { get; set; }

        [Display(Name = "�����")]
        public string Stamp { get; set; }

        [Display(Name = "����������� ���������")]
        public string DesignOfStandard { get; set; }

        [Display(Name = "��������������� ��������")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TechnologicalProcess> TechnologicalProcesses { get; set; }
    }
}
