namespace OpenTraderSunFixes.Model.GeneratedModel.deletethisafteruse
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model11")
        {
        }

        public virtual DbSet<ExternalServiceItem> ExternalServiceItems { get; set; }
        public virtual DbSet<OpenRatingEngine> OpenRatingEngines { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExternalServiceItem>()
                .Property(e => e.Name)
                .IsUnicode(false);
        }
    }
}
