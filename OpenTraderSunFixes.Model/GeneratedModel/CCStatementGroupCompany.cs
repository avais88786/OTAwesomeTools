namespace OpenTraderSunFixes.Model.GeneratedModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CCStatementGroupCompany")]
    public partial class CCStatementGroupCompany
    {
        public int CCStatementGroupId { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CompanyId { get; set; }

        public virtual CCStatementGroup CCStatementGroup { get; set; }
    }
}
