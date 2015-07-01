namespace OpenTraderSunFixes.Model.GeneratedModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CCAcountingPeriodStatus
    {
        public CCAcountingPeriodStatus()
        {
            CCAccountingPeriod = new HashSet<CCAccountingPeriod>();
        }

        [Key]
        public int CCAccountingPeriodStatusId { get; set; }

        [Required]
        [StringLength(50)]
        public string Description { get; set; }

        public virtual ICollection<CCAccountingPeriod> CCAccountingPeriod { get; set; }
    }
}
