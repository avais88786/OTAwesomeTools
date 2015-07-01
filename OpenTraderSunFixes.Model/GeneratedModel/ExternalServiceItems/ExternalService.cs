namespace OpenTraderSunFixes.Model.GeneratedModel.ExternalServiceItems
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ExternalService")]
    public partial class ExternalService
    {
        public ExternalService()
        {
            ExternalServiceVersionings = new HashSet<ExternalServiceVersioning>();
        }

        public int ExternalServiceId { get; set; }

        [Required]
        [StringLength(300)]
        public string Url { get; set; }

        [StringLength(300)]
        public string SoapAction { get; set; }

        public int? ExternalServiceTransformId { get; set; }

        public virtual ExternalServiceTransform ExternalServiceTransform { get; set; }

        public virtual ICollection<ExternalServiceVersioning> ExternalServiceVersionings { get; set; }

        public virtual imarketExternalService imarketExternalService { get; set; }
    }
}
