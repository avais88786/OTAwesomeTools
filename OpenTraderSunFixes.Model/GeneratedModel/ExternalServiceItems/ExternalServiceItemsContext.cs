namespace OpenTraderSunFixes.Model.GeneratedModel.ExternalServiceItems
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ExternalServiceItemsContext : DbContext
    {
        public ExternalServiceItemsContext()
            : base("name=ExternalServiceItems")
        {
        }

        public virtual DbSet<ExternalService> ExternalServices { get; set; }
        public virtual DbSet<ExternalServiceItem> ExternalServiceItems { get; set; }
        public virtual DbSet<ExternalServiceTransform> ExternalServiceTransforms { get; set; }
        public virtual DbSet<ExternalServiceType> ExternalServiceTypes { get; set; }
        public virtual DbSet<ExternalServiceVersioning> ExternalServiceVersionings { get; set; }
        public virtual DbSet<imarketExternalService> imarketExternalServices { get; set; }
        public virtual DbSet<imarketExternalServiceItem> imarketExternalServiceItems { get; set; }
        public virtual DbSet<imarketResponseType> imarketResponseTypes { get; set; }
        public virtual DbSet<OpenRatingEngine> OpenRatingEngines { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExternalService>()
                .Property(e => e.Url)
                .IsUnicode(false);

            modelBuilder.Entity<ExternalService>()
                .Property(e => e.SoapAction)
                .IsUnicode(false);

            modelBuilder.Entity<ExternalService>()
                .HasOptional(e => e.imarketExternalService)
                .WithRequired(e => e.ExternalService);

            modelBuilder.Entity<ExternalServiceItem>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<ExternalServiceTransform>()
                .Property(e => e.RequestTransform)
                .IsUnicode(false);

            modelBuilder.Entity<ExternalServiceTransform>()
                .Property(e => e.ResponseTransform)
                .IsUnicode(false);

            modelBuilder.Entity<ExternalServiceType>()
                .Property(e => e.Name)
                .IsUnicode(false);

            //modelBuilder.Entity<ExternalServiceType>()
                //.HasMany(e => e.ExternalServiceItems)
                //.WithRequired(e => e.ExternalServiceType)
                //.WillCascadeOnDelete(false);

            modelBuilder.Entity<imarketExternalService>()
                .Property(e => e.AddressAction)
                .IsUnicode(false);

            modelBuilder.Entity<imarketExternalService>()
                .Property(e => e.AddressTo)
                .IsUnicode(false);

            modelBuilder.Entity<imarketResponseType>()
                .Property(e => e.Name)
                .IsUnicode(false);
        }
    }
}
