namespace OpenTraderSunFixes.Model.GeneratedModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CCTransactionItem")]
    public partial class CCTransactionItem
    {
        public int CCTransactionItemId { get; set; }

        public int CCTransactionId { get; set; }

        public int CCCategoryTypeId { get; set; }

        public int CCSubCategoryTypeId { get; set; }

        public int CompanyId { get; set; }

        public decimal Amount { get; set; }

        public int CreatorUserId { get; set; }

        public int CreatorCompanyId { get; set; }

        public DateTime CreationDate { get; set; }

        public int LastUpdateUserId { get; set; }

        public DateTime LastUpdatedDate { get; set; }

        public decimal? Rate { get; set; }

        public virtual CCCategoryType CCCategoryType { get; set; }

        public virtual CCSubCategoryType CCSubCategoryType { get; set; }

        public virtual CCTransaction CCTransaction { get; set; }
    }
}
