namespace OpenTraderSunFixes.Model.GeneratedModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CCAccountingPeriod")]
    public partial class CCAccountingPeriod
    {
        public int CCAccountingPeriodId { get; set; }

        public DateTime PeriodFrom { get; set; }

        public DateTime? PeriodTo { get; set; }

        [Required]
        [StringLength(250)]
        public string Description { get; set; }

        public int CCAccountingPeriodStatusId { get; set; }

        public int CreatorUserId { get; set; }

        public int CreatorCompanyId { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime LastUpdatedDate { get; set; }

        public virtual CCAcountingPeriodStatus CCAcountingPeriodStatus { get; set; }
    }
}
