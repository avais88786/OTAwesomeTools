namespace OpenTraderSunFixes.Model.GeneratedModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CCExternalTransactionProcess")]
    public partial class CCExternalTransactionProcess
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CCTransactionId { get; set; }

        public DateTime? LastProcessDate { get; set; }

        public int ProcessStatusId { get; set; }

        [Column(TypeName = "xml")]
        public string ErrorXML { get; set; }

        public int? BatchId { get; set; }

        public DateTime CreatedDate { get; set; }

        public int? TransactionTypeId { get; set; }

        public int FailSend { get; set; }

        public int? LastUpdateLogonUserId { get; set; }

        public virtual CCExternalSunTransactionType CCExternalSunTransactionType { get; set; }

        public virtual CCExternalTransactionProcessStatus CCExternalTransactionProcessStatus { get; set; }

        public virtual CCTransaction CCTransaction { get; set; }
    }
}
