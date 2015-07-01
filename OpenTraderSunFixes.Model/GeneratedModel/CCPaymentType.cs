namespace OpenTraderSunFixes.Model.GeneratedModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CCPaymentType")]
    public partial class CCPaymentType
    {
        public CCPaymentType()
        {
            CCTransaction = new HashSet<CCTransaction>();
            CCPaymentCategory = new HashSet<CCPaymentCategory>();
        }

        public int CCPaymentTypeId { get; set; }

        [Required]
        [StringLength(50)]
        public string Description { get; set; }

        public bool Enabled { get; set; }

        public virtual ICollection<CCTransaction> CCTransaction { get; set; }

        public virtual ICollection<CCPaymentCategory> CCPaymentCategory { get; set; }
    }
}
