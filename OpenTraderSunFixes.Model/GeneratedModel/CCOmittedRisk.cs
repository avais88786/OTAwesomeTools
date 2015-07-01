namespace OpenTraderSunFixes.Model.GeneratedModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CCOmittedRisk")]
    public partial class CCOmittedRisk
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RiskId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string Comments { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime OmmissionDateTime { get; set; }
    }
}
