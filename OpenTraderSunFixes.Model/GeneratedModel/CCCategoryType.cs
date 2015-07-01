namespace OpenTraderSunFixes.Model.GeneratedModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CCCategoryType")]
    public partial class CCCategoryType
    {
        public CCCategoryType()
        {
            CCTransactionItem = new HashSet<CCTransactionItem>();
        }

        public int CCCategoryTypeId { get; set; }

        [Required]
        [StringLength(50)]
        public string Description { get; set; }

        public bool ComprisesTransactionAmount { get; set; }

        public bool RoundingVictim { get; set; }

        public virtual ICollection<CCTransactionItem> CCTransactionItem { get; set; }
    }
}
