namespace OpenTraderSunFixes.Model.GeneratedModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CCOpenPremiumType")]
    public partial class CCOpenPremiumType
    {
        public CCOpenPremiumType()
        {
            CCTransaction = new HashSet<CCTransaction>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CCOpenPremiumTypeId { get; set; }

        [Required]
        [StringLength(30)]
        public string Description { get; set; }

        public virtual ICollection<CCTransaction> CCTransaction { get; set; }
    }
}
