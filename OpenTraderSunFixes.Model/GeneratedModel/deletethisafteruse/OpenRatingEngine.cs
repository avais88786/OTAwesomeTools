namespace OpenTraderSunFixes.Model.GeneratedModel.deletethisafteruse
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

        public DateTime? SpecifiedEffectiveDate { get; set; }
    }
}
