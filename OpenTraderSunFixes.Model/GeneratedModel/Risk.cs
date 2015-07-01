namespace OpenTraderSunFixes.Model.GeneratedModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Risk")]
    public partial class Risk
    {
        [Key]
        [Column(Order = 0)]
        public int RiskId { get; set; }

       
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RiskTypeId { get; set; }

        
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ParentRiskId { get; set; }

        
        [Column(Order = 3)]
        [StringLength(100)]
        public string Description { get; set; }

        
        [Column(Order = 4)]
        [StringLength(50)]
        public string ShortDescription { get; set; }

        
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RiskStatusId { get; set; }

        
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AllocatedRiskRoleId { get; set; }

        
        [Column(Order = 7)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AllocatedCompanyId { get; set; }

        
        [Column(Order = 8)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CreatorUserId { get; set; }

        
        [Column(Order = 9)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CreatorCompanyId { get; set; }

        
        [Column(Order = 10)]
        public DateTime CreatedDate { get; set; }

        
        [Column(Order = 11)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LastUpdateUserId { get; set; }

        
        [Column(Order = 12)]
        public DateTime LastUpdatedDate { get; set; }

        
        [Column(Order = 13)]
        public bool Backloaded { get; set; }

        
        [Column(Order = 14)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PreviousRiskId { get; set; }

       
        [Column(Order = 15)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int InsuranceTypeId { get; set; }

        
        [Column(Order = 16)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MainReferenceTypeId { get; set; }

       
        [Column(Order = 17)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TimeZoneId { get; set; }
    }
}
