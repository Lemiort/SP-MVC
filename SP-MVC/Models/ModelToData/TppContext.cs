namespace SP_MVC
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TppContext : DbContext
    {
        public TppContext()
            : base("name=TPPModel")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Equipment> Equipment { get; set; }
        public virtual DbSet<Material> Material { get; set; }
        public virtual DbSet<Operation> Operation { get; set; }
        public virtual DbSet<Rigging> Rigging { get; set; }
        public virtual DbSet<Route> Route { get; set; }
        public virtual DbSet<RouteCar> RouteCar { get; set; }
        public virtual DbSet<TechnologicalProcesses> TechnologicalProcesses { get; set; }
        public virtual DbSet<Transition> Transition { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
