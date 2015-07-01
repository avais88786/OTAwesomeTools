namespace OpenTraderSunFixes.Model.GeneratedModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OpenCompany")]
    public partial class OpenCompany
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CompanyID { get; set; }

        [StringLength(50)]
        public string OpenCompanyID { get; set; }

        public int? RestrictPO { get; set; }

        public decimal? MPRAmount { get; set; }

        public int? AllowAllSchemes { get; set; }

        [StringLength(50)]
        public string GroupReference { get; set; }

        [StringLength(50)]
        public string Telephone { get; set; }

        [StringLength(50)]
        public string Fax { get; set; }

        [StringLength(50)]
        public string Web { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string BrokerNetRef { get; set; }

        [StringLength(50)]
        public string BranchNumber { get; set; }

        [StringLength(50)]
        public string ABICode { get; set; }

        public int? StatementPreference { get; set; }

        public int? PaymentPreference { get; set; }

        public int? BrokerAllowRestrictPremiumOverride { get; set; }

        [StringLength(50)]
        public string SalesLedgerAccountCode { get; set; }

        public bool? UseOpenWord { get; set; }

        public int? SaveDocuments { get; set; }

        public bool? ExtranetOnly { get; set; }

        public int? SaveBatchedDocuments { get; set; }

        public int? SaveViewedDocuments { get; set; }

        public bool? ROI { get; set; }

        [StringLength(50)]
        public string AccountsEmail { get; set; }

        public bool? CreditControl { get; set; }

        [StringLength(50)]
        public string SysAdminEmail { get; set; }

        public int? OpenProductProviderTypeId { get; set; }

        public bool? VehicleLookupEnabled { get; set; }

        [StringLength(50)]
        public string OGIBrokerReference { get; set; }

        public virtual Company Company { get; set; }
    }
}
