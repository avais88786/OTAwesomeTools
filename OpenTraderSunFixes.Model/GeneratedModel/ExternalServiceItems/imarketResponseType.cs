namespace OpenTraderSunFixes.Model.GeneratedModel.ExternalServiceItems
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("imarketResponseType")]
    public partial class imarketResponseType
    {
        public imarketResponseType()
        {
            imarketExternalServiceItems = new HashSet<imarketExternalServiceItem>();
        }

        public int imarketResponseTypeId { get; set; }

        [Required]
        [StringLength(300)]
        public string Name { get; set; }

        public virtual ICollection<imarketExternalServiceItem> imarketExternalServiceItems { get; set; }
    }
}
