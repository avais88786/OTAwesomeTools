namespace OpenTraderSunFixes.Model.GeneratedModel
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<OpenCompany> OpenCompany { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Company>()
            //    .HasMany(e => e.Company1)
            //    .WithRequired(e => e.Company2)
            //    .HasForeignKey(e => e.ParentCompanyId);

            modelBuilder.Entity<Company>()
                .HasOptional(e => e.OpenCompany)
                .WithRequired(e => e.Company);

            modelBuilder.Entity<OpenCompany>()
                .Property(e => e.OGIBrokerReference)
                .IsUnicode(false);
        }
    }
}
