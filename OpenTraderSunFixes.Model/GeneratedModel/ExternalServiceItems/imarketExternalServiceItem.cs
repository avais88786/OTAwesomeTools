namespace OpenTraderSunFixes.Model.GeneratedModel.ExternalServiceItems
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("imarketExternalServiceItem")]
    public partial class imarketExternalServiceItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ExternalServiceItemId { get; set; }

        public int? imarketResponseTypeId { get; set; }

        public virtual imarketResponseType imarketResponseType { get; set; }
    }
}
