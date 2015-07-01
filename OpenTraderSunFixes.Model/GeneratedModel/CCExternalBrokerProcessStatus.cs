namespace OpenTraderSunFixes.Model.GeneratedModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CCExternalBrokerProcessStatus
    {
        public CCExternalBrokerProcessStatus()
        {
            CCExternalBrokerProcess = new HashSet<CCExternalBrokerProcess>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProcessStatusId { get; set; }

        [Required]
        [StringLength(50)]
        public string Description { get; set; }

        public virtual ICollection<CCExternalBrokerProcess> CCExternalBrokerProcess { get; set; }
    }
}
