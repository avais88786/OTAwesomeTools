namespace OpenTraderSunFixes.Model.GeneratedModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CCSubCategoryType")]
    public partial class CCSubCategoryType
    {
        public CCSubCategoryType()
        {
            CCTransactionItem = new HashSet<CCTransactionItem>();
        }

        public int CCSubCategoryTypeId { get; set; }

        [Required]
        [StringLength(50)]
        public string Description { get; set; }

        public virtual ICollection<CCTransactionItem> CCTransactionItem { get; set; }
    }
}
