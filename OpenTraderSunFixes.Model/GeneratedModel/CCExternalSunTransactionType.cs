namespace OpenTraderSunFixes.Model.GeneratedModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CCExternalSunTransactionType")]
    public partial class CCExternalSunTransactionType
    {
        public CCExternalSunTransactionType()
        {
            CCExternalTransactionProcess = new HashSet<CCExternalTransactionProcess>();
        }

        [Key]
        public int TransactionTypeId { get; set; }

        [Required]
        [StringLength(50)]
        public string Description { get; set; }

        [Required]
        [StringLength(4)]
        public string Code { get; set; }

        public int ExecutionOrder { get; set; }

        public int AddCountValue { get; set; }

        public virtual ICollection<CCExternalTransactionProcess> CCExternalTransactionProcess { get; set; }
    }
}
