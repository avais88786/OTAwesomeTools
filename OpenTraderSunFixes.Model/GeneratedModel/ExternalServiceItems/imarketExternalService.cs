namespace OpenTraderSunFixes.Model.GeneratedModel.ExternalServiceItems
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("imarketExternalService")]
    public partial class imarketExternalService
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ExternalServiceId { get; set; }

        [StringLength(300)]
        public string AddressAction { get; set; }

        [StringLength(300)]
        public string AddressTo { get; set; }

        public virtual ExternalService ExternalService { get; set; }
    }
}
