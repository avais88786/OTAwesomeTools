namespace OpenTraderSunFixes.Model.GeneratedModel.ExternalServiceItems
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ExternalServiceType")]
    public partial class ExternalServiceType
    {
        public ExternalServiceType()
        {
            //ExternalServiceItems = new HashSet<ExternalServiceItem>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ExternalServiceTypeId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        //public virtual ICollection<ExternalServiceItem> ExternalServiceItems { get; set; }
    }
}
