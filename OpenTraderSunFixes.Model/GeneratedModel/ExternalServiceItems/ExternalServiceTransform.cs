namespace OpenTraderSunFixes.Model.GeneratedModel.ExternalServiceItems
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ExternalServiceTransform")]
    public partial class ExternalServiceTransform
    {
        public ExternalServiceTransform()
        {
            ExternalServices = new HashSet<ExternalService>();
        }

        public int ExternalServiceTransformId { get; set; }

        [Required]
        [StringLength(100)]
        public string RequestTransform { get; set; }

        [Required]
        [StringLength(100)]
        public string ResponseTransform { get; set; }

        [Column(TypeName = "xml")]
        public string TransformConfig { get; set; }

        public virtual ICollection<ExternalService> ExternalServices { get; set; }
    }
}
