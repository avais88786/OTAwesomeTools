namespace OpenTraderSunFixes.Model.GeneratedModel.ExternalServiceItems
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OpenRatingEngine")]
    public partial class OpenRatingEngine
    {
        public int OpenRatingEngineId { get; set; }

        public int SchemeRiskID { get; set; }

        public int OpenRatingEngineTypeID { get; set; }

        public DateTime? EffectiveDate { get; set; }

        public string EffectiveDateFormatted { 
        get{
                return EffectiveDate.Value.ToString("yyyy-MM-dd HH:mm:ss.fff");
            } 
        }

        public DateTime? SpecifiedEffectiveDate { get; set; }
    }
}
