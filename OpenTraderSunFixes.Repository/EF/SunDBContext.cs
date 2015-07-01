namespace OpenTraderSunFixes.Repository.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using OpenTraderSunFixes.Model.GeneratedModel;
using OpenTraderSunFixes.Model;
    
    public partial class SunDBContext : DbContext
    {
        public SunDBContext()
            //: base("name=DefaultConnectionString")
               : base(Global.ConnectionString)
        {
        }

        public virtual DbSet<CCAccountingPeriod> CCAccountingPeriod { get; set; }
        public virtual DbSet<CCAcountingPeriodStatus> CCAcountingPeriodStatus { get; set; }
        public virtual DbSet<CCCategoryType> CCCategoryType { get; set; }
        public virtual DbSet<CCExternalBrokerProcess> CCExternalBrokerProcess { get; set; }
        public virtual DbSet<CCExternalBrokerProcessStatus> CCExternalBrokerProcessStatus { get; set; }
        public virtual DbSet<CCExternalSunTransactionType> CCExternalSunTransactionType { get; set; }
        public virtual DbSet<CCExternalTransactionProcess> CCExternalTransactionProcess { get; set; }
        public virtual DbSet<CCExternalTransactionProcessBatch> CCExternalTransactionProcessBatch { get; set; }
        public virtual DbSet<CCExternalTransactionProcessStatus> CCExternalTransactionProcessStatus { get; set; }
        public virtual DbSet<CCOmittedRisk> CCOmittedRisk { get; set; }
        public virtual DbSet<CCOpenPremiumType> CCOpenPremiumType { get; set; }
        public virtual DbSet<CCOpenTransactionType> CCOpenTransactionType { get; set; }
        public virtual DbSet<CCPaymentCategory> CCPaymentCategory { get; set; }
        public virtual DbSet<CCPaymentType> CCPaymentType { get; set; }
        public virtual DbSet<CCStatementGroup> CCStatementGroup { get; set; }
        public virtual DbSet<CCStatementGroupCompany> CCStatementGroupCompany { get; set; }
        public virtual DbSet<CCStatementGroupStatus> CCStatementGroupStatus { get; set; }
        public virtual DbSet<CCStatusCategory> CCStatusCategory { get; set; }
        public virtual DbSet<CCSubCategoryType> CCSubCategoryType { get; set; }
        public virtual DbSet<CCTransaction> CCTransaction { get; set; }
        public virtual DbSet<CCTransactionItem> CCTransactionItem { get; set; }
        public virtual DbSet<CCTransactionStatus> CCTransactionStatus { get; set; }
        public virtual DbSet<Risk> Risk { get; set; }
        public virtual DbSet<RiskReference> RiskReference { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<OpenCompany> OpenCompany { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer <SunDBContext> (null);

            modelBuilder.Entity<CCAccountingPeriod>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<CCAcountingPeriodStatus>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<CCAcountingPeriodStatus>()
                .HasMany(e => e.CCAccountingPeriod)
                .WithRequired(e => e.CCAcountingPeriodStatus)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CCCategoryType>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<CCCategoryType>()
                .HasMany(e => e.CCTransactionItem)
                .WithRequired(e => e.CCCategoryType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CCExternalBrokerProcess>()
                .Property(e => e.CompanyIdSunStyle)
                .IsUnicode(false);

            modelBuilder.Entity<CCExternalBrokerProcessStatus>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<CCExternalBrokerProcessStatus>()
                .HasMany(e => e.CCExternalBrokerProcess)
                .WithRequired(e => e.CCExternalBrokerProcessStatus)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CCExternalSunTransactionType>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<CCExternalSunTransactionType>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<CCExternalTransactionProcessStatus>()
                .HasMany(e => e.CCExternalTransactionProcess)
                .WithRequired(e => e.CCExternalTransactionProcessStatus)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CCOmittedRisk>()
                .Property(e => e.Comments)
                .IsUnicode(false);

            modelBuilder.Entity<CCOpenPremiumType>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<CCOpenTransactionType>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<CCOpenTransactionType>()
                .HasMany(e => e.CCTransaction)
                .WithRequired(e => e.CCOpenTransactionType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CCPaymentCategory>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<CCPaymentCategory>()
                .Property(e => e.Comments)
                .IsUnicode(false);

            modelBuilder.Entity<CCPaymentCategory>()
                .HasMany(e => e.CCPaymentType)
                .WithMany(e => e.CCPaymentCategory)
                .Map(m => m.ToTable("CCPaymentTypeCategory").MapLeftKey("CCPaymentCategoryId").MapRightKey("CCPaymentTypeId"));

            modelBuilder.Entity<CCPaymentType>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<CCPaymentType>()
                .HasMany(e => e.CCTransaction)
                .WithRequired(e => e.CCPaymentType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CCStatementGroup>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<CCStatementGroup>()
                .Property(e => e.Code)
                .IsFixedLength();

            modelBuilder.Entity<CCStatementGroup>()
                .HasMany(e => e.CCStatementGroupCompany)
                .WithRequired(e => e.CCStatementGroup)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CCStatementGroupStatus>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<CCStatusCategory>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<CCStatusCategory>()
                .Property(e => e.Comments)
                .IsUnicode(false);

            modelBuilder.Entity<CCSubCategoryType>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<CCSubCategoryType>()
                .HasMany(e => e.CCTransactionItem)
                .WithRequired(e => e.CCSubCategoryType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CCTransaction>()
                .Property(e => e.Amount)
                .HasPrecision(28, 2);

            modelBuilder.Entity<CCTransaction>()
                .Property(e => e.Reference)
                .IsUnicode(false);

            modelBuilder.Entity<CCTransaction>()
                .Property(e => e.Comments)
                .IsUnicode(false);

            modelBuilder.Entity<CCTransaction>()
                .Property(e => e.BrokerReference)
                .IsUnicode(false);

            modelBuilder.Entity<CCTransaction>()
                .HasOptional(e => e.CCExternalTransactionProcess)
                .WithRequired(e => e.CCTransaction);

            modelBuilder.Entity<CCTransaction>()
                .HasMany(e => e.CCTransactionItem)
                .WithRequired(e => e.CCTransaction)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CCTransactionItem>()
                .Property(e => e.Amount)
                .HasPrecision(28, 2);

            modelBuilder.Entity<CCTransactionItem>()
                .Property(e => e.Rate)
                .HasPrecision(18, 10);

            modelBuilder.Entity<CCTransactionStatus>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<CCTransactionStatus>()
                .HasMany(e => e.CCTransaction)
                .WithRequired(e => e.CCTransactionStatus)
                .WillCascadeOnDelete(false);

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

            //modelBuilder.Entity<RiskReference>()
            //    .HasRequired(r => r.Risk)
            //    .WithOptional();
                

        }
    }
}
