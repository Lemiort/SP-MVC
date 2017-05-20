namespace SP_MVC.Models.ModelToData
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TppContext : DbContext
    {
        public TppContext()
            : base("name=TppContext")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Equipment> Equipments { get; set; }
        public virtual DbSet<Material> Materials { get; set; }
        public virtual DbSet<Operation> Operations { get; set; }
        public virtual DbSet<Rigging> Riggings { get; set; }
        public virtual DbSet<Route> Routes { get; set; }
        public virtual DbSet<RouteCar> RouteCars { get; set; }
        public virtual DbSet<TechnologicalProcess> TechnologicalProcesses { get; set; }
        public virtual DbSet<Transition> Transitions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Operation>()
                .HasMany(e => e.Riggings)
                .WithMany(e => e.Operations)
                .Map(m => m.ToTable("RiggingOperations"));

            modelBuilder.Entity<Operation>()
                .HasMany(e => e.TechnologicalProcesses)
                .WithMany(e => e.Operations)
                .Map(m => m.ToTable("TechnologicalProcessesOperations").MapRightKey("TechnologicalProcesses_TechProcId"));
        }
    }
}
