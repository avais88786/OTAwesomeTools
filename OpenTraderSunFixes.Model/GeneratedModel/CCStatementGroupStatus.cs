namespace OpenTraderSunFixes.Model.GeneratedModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CCStatementGroupStatus
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CCStatementGroupStatusID { get; set; }

        [Required]
        [StringLength(25)]
        public string Description { get; set; }
    }
}
