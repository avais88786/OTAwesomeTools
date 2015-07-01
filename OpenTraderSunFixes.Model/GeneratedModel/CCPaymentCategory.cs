namespace OpenTraderSunFixes.Model.GeneratedModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CCPaymentCategory")]
    public partial class CCPaymentCategory
    {
        public CCPaymentCategory()
        {
            CCPaymentType = new HashSet<CCPaymentType>();
        }

        public int CCPaymentCategoryId { get; set; }

        [Required]
        [StringLength(50)]
        public string Description { get; set; }

        [Required]
        [StringLength(250)]
        public string Comments { get; set; }

        public virtual ICollection<CCPaymentType> CCPaymentType { get; set; }
    }
}
