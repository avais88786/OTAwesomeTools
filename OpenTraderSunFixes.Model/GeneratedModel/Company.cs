namespace OpenTraderSunFixes.Model.GeneratedModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Company")]
    public partial class Company
    {
        public Company()
        {
           // Company1 = new HashSet<Company>();
        }

        public int CompanyId { get; set; }

        public DateTime LastUpdated { get; set; }

        public int CrmCompanyId { get; set; }

        public int ParentCompanyId { get; set; }

        public int RootCompanyId { get; set; }

        public int AddressId { get; set; }

        public int CompanyTypeId { get; set; }

        public int LanguageId { get; set; }

        [Required]
        [StringLength(50)]
        public string CompanyCode { get; set; }

        [Required]
        [StringLength(50)]
        public string CompanyRef { get; set; }

        [Required]
        [StringLength(200)]
        public string CompanyName { get; set; }

        [Required]
        [StringLength(500)]
        public string AltCompanyName { get; set; }

        public bool IsLloyds { get; set; }

        public bool Enabled { get; set; }

        //public virtual ICollection<Company> Company1 { get; set; }

        //public virtual Company Company2 { get; set; }

        public virtual OpenCompany OpenCompany { get; set; }

        [ForeignKey("ParentCompanyId")]
        public virtual Company ParentCompany { get; set; }
    }
}
