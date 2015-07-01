namespace OpenTraderSunFixes.Model.GeneratedModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CCExternalTransactionProcessBatch")]
    public partial class CCExternalTransactionProcessBatch
    {
        [Key]
        public int BatchId { get; set; }

        public DateTime StartDate { get; set; }

        public bool Completed { get; set; }
    }
}
