namespace OpenTraderSunFixes.Model.GeneratedModel.ExternalServiceItems
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ExternalServiceVersioning")]
    public partial class ExternalServiceVersioning
    {
        [Key]
        public int ExternalServiceVersionId { get; set; }

        public int ExternalServiceItemId { get; set; }

        public int? ExternalServiceId { get; set; }

        public int OpenRatingEngineId { get; set; }

        public bool IsLive { get; set; }

        public virtual ExternalService ExternalService { get; set; }
    }
}
