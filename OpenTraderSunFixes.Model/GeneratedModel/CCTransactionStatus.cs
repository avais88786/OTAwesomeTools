namespace OpenTraderSunFixes.Model.GeneratedModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CCTransactionStatus
    {
        public CCTransactionStatus()
        {
            CCTransaction = new HashSet<CCTransaction>();
        }

        public int CCTransactionStatusId { get; set; }

        [Required]
        [StringLength(50)]
        public string Description { get; set; }

        public virtual ICollection<CCTransaction> CCTransaction { get; set; }
    }
}
