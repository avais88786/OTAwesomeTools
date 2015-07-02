namespace OpenTraderSunFixes.Model.GeneratedModel.deletethisafteruse
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ExternalServiceItem")]
    public partial class ExternalServiceItem
    {
        public int ExternalServiceItemId { get; set; }

        public int? SchemeRiskId { get; set; }

        public int ExternalServiceTypeId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
