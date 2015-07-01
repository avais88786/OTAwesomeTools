namespace OpenTraderSunFixes.Model.GeneratedModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CCExternalTransactionProcessStatus
    {
        public CCExternalTransactionProcessStatus()
        {
            CCExternalTransactionProcess = new HashSet<CCExternalTransactionProcess>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProcessStatusId { get; set; }

        [Required]
        [StringLength(50)]
        public string Description { get; set; }

        public virtual ICollection<CCExternalTransactionProcess> CCExternalTransactionProcess { get; set; }
    }
}
