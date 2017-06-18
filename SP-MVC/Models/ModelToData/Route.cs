namespace SP_MVC.Models.ModelToData
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
            RouteCars = new HashSet<RouteCar>();
        }

        [Display(Name = "��� ��������")]
        public int RouteId { get; set; }

        [Display(Name = "��� ��")]
        public int TechProcId { get; set; }

        [Display(Name = "�������� ��")]
        public string NameTechProc { get; set; }

        [Display(Name = "��� ������������")]
        public int NameOfDeveloper { get; set; }

        [Display(Name = "����������� ������")]
        public string DetailsDesignation { get; set; }

        [Display(Name = "��� ������")]
        public string DetailsName { get; set; }

        [Display(Name = "��������������� ��������")]
        public virtual TechnologicalProcess TechnologicalProcess { get; set; }

        [Display(Name = "���������� �����")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RouteCar> RouteCars { get; set; }
    }
}
