namespace OpenTraderSunFixes.Model.GeneratedModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RiskReference")]
    public partial class RiskReference
    {
        [Key]
        [Column(Order = 0)]
        public int RiskReferenceId { get; set; }

        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RiskId { get; set; }

        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ReferenceTypeId { get; set; }

        [Column(Order = 3)]
        [StringLength(50)]
        public string Reference { get; set; }

        public DateTime? LastUpdateDateTime { get; set; }

        public int? LastUpdateLogonUserId { get; set; }

        [ForeignKey("RiskId")]
        public virtual Risk Risk { get; set; }
    }
}
