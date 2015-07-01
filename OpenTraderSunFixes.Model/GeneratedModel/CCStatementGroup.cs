namespace OpenTraderSunFixes.Model.GeneratedModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CCStatementGroup")]
    public partial class CCStatementGroup
    {
        public CCStatementGroup()
        {
            CCStatementGroupCompany = new HashSet<CCStatementGroupCompany>();
        }

        public int CCStatementGroupId { get; set; }

        [Required]
        [StringLength(50)]
        public string Description { get; set; }

        public int? AddressId { get; set; }

        public int? StatementPreference { get; set; }

        public int? PaymentPreference { get; set; }

        [StringLength(50)]
        public string Code { get; set; }

        public int? CCStatementGroupStatusID { get; set; }

        public virtual ICollection<CCStatementGroupCompany> CCStatementGroupCompany { get; set; }
    }
}
