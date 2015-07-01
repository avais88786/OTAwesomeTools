namespace OpenTraderSunFixes.Model.GeneratedModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CCOpenTransactionType")]
    public partial class CCOpenTransactionType
    {
        public CCOpenTransactionType()
        {
            CCTransaction = new HashSet<CCTransaction>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CCOpenTransactionTypeId { get; set; }

        [Required]
        [StringLength(50)]
        public string Description { get; set; }

        public virtual ICollection<CCTransaction> CCTransaction { get; set; }
    }
}
