namespace OpenTraderSunFixes.Model.GeneratedModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CCTransaction")]
    public partial class CCTransaction
    {
        public CCTransaction()
        {
            CCTransactionItem = new HashSet<CCTransactionItem>();
        }

        public int CCTransactionId { get; set; }

        public int RiskId { get; set; }

        public int CCTransactionStatusId { get; set; }

        public int CCPaymentTypeId { get; set; }

        public int CCAccountingPeriodId { get; set; }

        
        public decimal Amount { get; set; }

        [Required]
        [StringLength(50)]
        public string Reference { get; set; }

        public DateTime? PaymentDate { get; set; }

        public DateTime? EffectiveDate { get; set; }

        public DateTime? ProcessDate { get; set; }

        public int CurrencyId { get; set; }

        public int CreatorUserId { get; set; }

        public int CreatorCompanyId { get; set; }

        public DateTime CreationDate { get; set; }

        public int LastUpdateUserId { get; set; }

        public DateTime LastUpdatedDate { get; set; }

        public DateTime? SettlementDate { get; set; }

        [StringLength(250)]
        public string Comments { get; set; }

        public int CCOpenTransactionTypeId { get; set; }

        public int BrokerCompanyId { get; set; }

        public int InsurerCompanyId { get; set; }

        public int ClientCompanyId { get; set; }

        [Required]
        [StringLength(50)]
        public string BrokerReference { get; set; }

        public int? CCOpenPremiumTypeId { get; set; }

        public bool HasBeenReversed { get; set; }

        public int? ReversesCCTransactionId { get; set; }

        private string accountCode;
        [NotMapped]
        public string AccountCode
        {
            get
            {
                return "IBA000000" + accountCode;
            }
            set
            {
                accountCode = value;
            }
        }

        public virtual CCExternalTransactionProcess CCExternalTransactionProcess { get; set; }

        public virtual CCOpenPremiumType CCOpenPremiumType { get; set; }

        public virtual CCOpenTransactionType CCOpenTransactionType { get; set; }

        public virtual CCPaymentType CCPaymentType { get; set; }

        public virtual CCTransactionStatus CCTransactionStatus { get; set; }

        public virtual ICollection<CCTransactionItem> CCTransactionItem { get; set; }

        [ForeignKey("BrokerCompanyId")]
        public virtual Company BrokerCompany { get; set; }

        [ForeignKey("ClientCompanyId")]
        public virtual Company ClientCompany { get; set; }
    }
}
