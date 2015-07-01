namespace OpenTraderSunFixes.Model.GeneratedModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CCExternalBrokerProcess")]
    public partial class CCExternalBrokerProcess
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CompanyId { get; set; }

        public int ProcessStatusId { get; set; }

        public DateTime? SyncRequiredDate { get; set; }

        [Column(TypeName = "xml")]
        public string SyncError { get; set; }

        public bool RulesCreated { get; set; }

        public DateTime? RulesCreatedDate { get; set; }

        public int? RulesCreatedUserId { get; set; }

        [StringLength(50)]
        public string CompanyIdSunStyle { get; set; }

        public virtual CCExternalBrokerProcessStatus CCExternalBrokerProcessStatus { get; set; }
    }
}
