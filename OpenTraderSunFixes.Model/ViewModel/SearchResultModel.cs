using OpenTraderSunFixes.Model.GeneratedModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTraderSunFixes.Model.ViewModel
{
    public class SearchResultModel
    {
        private int cCTransactionId;
        [Display(Name="CCTransactionId")]
        public int CCTransactionId
        {
            get { return cCTransactionId; }
            set { cCTransactionId = value; }
        }
        private int riskId;

        [Display(Name = "RiskId")]
        public int RiskId
        {
            get { return riskId; }
            set { riskId = value; }
        }
        private string accountCode;

        [Display(Name = "Account Code")]
        public string AccountCode
        {
            get { return accountCode; }
            set {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    String x = "000000" + value;
                    x = x.Substring((x.Length - 6));
                    accountCode = "IBA" + x;
                }
        }
        private string brokerReference;

        [Display(Name = "Broker Reference")]
        public string BrokerReference
        {
            get { return brokerReference; }
            set { brokerReference = value; }
        }
        private string clientName;

        [Display(Name = "Client Name")]
        public string ClientName
        {
            get { return clientName; }
            set { clientName = value; }
        }
        private string policyReference;

        [Display(Name = "Policy Reference")]
        public string PolicyReference
        {
            get { return policyReference; }
            set { policyReference = value; }
        }
        private decimal memoAmount;

        [Display(Name = "Memo Amount")]
        public decimal MemoAmount
        {
            get { return memoAmount; }
            set { memoAmount = value; }
        }
        private decimal amount;

        [Display(Name = "Amount")]
        public decimal Amount
        {
            get { return amount; }
            set { amount = value; }
        }
        private string journalType;

        [Display(Name = "Journal Type")]
        public string JournalType
        {
            get { return journalType; }
            set { journalType = value; }
        }

        private string generalDescrition6;

        [Display(Name = "General Descr 6")]
        public string GeneralDescrition6
        {
            get { return generalDescrition6; }
            set { generalDescrition6 = value; }
        }
        private decimal totalCommissionRate;

        [Display(Name = "Total Commission Rate")]
        public decimal TotalCommissionRate
        {
            get { return totalCommissionRate; }
            set { totalCommissionRate = value; }
        }
        private decimal brokerCommissionRate;

        [Display(Name = "Broker Commission Rate")]
        public decimal BrokerCommissionRate
        {
            get { return brokerCommissionRate; }
            set { brokerCommissionRate = value; }
        }
        private decimal powerplaceCommissionRate;

        [Display(Name = "Powerplace Commission Rate")]
        public decimal PowerplaceCommissionRate
        {
            get { return powerplaceCommissionRate; }
            set { powerplaceCommissionRate = value; }
        }
        private decimal totalCommissionValue;

        [Required]
        [Display(Name = "Total Commission Value")]
        [Range(int.MinValue, int.MaxValue, ErrorMessage = "Number only please")]
        public decimal TotalCommissionValue
        {
            get { return totalCommissionValue; }
            set { totalCommissionValue = value; }
        }
        private decimal brokerCommissionValue;

        [Display(Name = "Broker Commission Value")]
        public decimal BrokerCommissionValue
        {
            get { return brokerCommissionValue; }
            set { brokerCommissionValue = value; }
        }
        private decimal powerplaceCommissionValue;

        [Display(Name = "Powerplace Commission Value")]
        public decimal PowerplaceCommissionValue
        {
            get { return powerplaceCommissionValue; }
            set { powerplaceCommissionValue = value; }
        }
        private decimal iPTValue;

        [Display(Name = "IPT Amount")]
        public decimal IPTValue
        {
            get { return iPTValue; }
            set { iPTValue = value; }
        }

        private int ccOpenTransactionTypeId;

        public int CCOpenTransactionTypeId
        {
            get { return ccOpenTransactionTypeId; }
            set { ccOpenTransactionTypeId = value; }
        }

        public DateTime? EffectiveDate { get; set; }

        public SearchResultModel(CCTransaction ccTransaction)
        {
            this.CCTransactionId = ccTransaction.CCTransactionId;
            this.RiskId = ccTransaction.RiskId;
            this.AccountCode = ccTransaction.BrokerCompany.ParentCompany.OpenCompany.OpenCompanyID;
            this.BrokerReference = ccTransaction.BrokerReference;
            this.ClientName = ccTransaction.ClientCompany.CompanyName;
            this.PolicyReference = ccTransaction.Reference;
            this.MemoAmount = ccTransaction.CCTransactionItem.FirstOrDefault(cci => cci.CCCategoryTypeId == 4 && cci.CCSubCategoryTypeId == 1).Amount;
            this.Amount = ccTransaction.Amount;
            this.JournalType = null; //handled as custom helper in view
            this.GeneralDescrition6 = ccTransaction.CCOpenPremiumType.Description;
            this.TotalCommissionRate = (decimal)ccTransaction.CCTransactionItem.Where(cci => cci.CCCategoryTypeId == 2).Sum(ccix => ccix.Rate);
            this.BrokerCommissionRate = (decimal)ccTransaction.CCTransactionItem.FirstOrDefault(cci => cci.CCCategoryTypeId == 2 && cci.CCSubCategoryTypeId == 5).Rate; //Broker Commission rate
            this.PowerplaceCommissionRate = (decimal)ccTransaction.CCTransactionItem.FirstOrDefault(cci => cci.CCCategoryTypeId == 2 && cci.CCSubCategoryTypeId == 6).Rate;  //Powerplace commission rate
            this.TotalCommissionValue = ccTransaction.CCTransactionItem.Where(cci => cci.CCCategoryTypeId == 2).Sum(ccix => ccix.Amount);
            this.PowerplaceCommissionValue = ccTransaction.CCTransactionItem.FirstOrDefault(cci => cci.CCCategoryTypeId == 2 && cci.CCSubCategoryTypeId == 6).Amount;
            this.BrokerCommissionValue = ccTransaction.CCTransactionItem.FirstOrDefault(cci => cci.CCCategoryTypeId == 2 && cci.CCSubCategoryTypeId == 5).Amount;
            this.IPTValue = ccTransaction.CCTransactionItem.FirstOrDefault(cci => cci.CCCategoryTypeId == 3 && cci.CCSubCategoryTypeId == 1).Amount;
            this.CCOpenTransactionTypeId = ccTransaction.CCOpenTransactionTypeId;
            this.EffectiveDate = ccTransaction.EffectiveDate;
        }

        public SearchResultModel()
        {
            // TODO: Complete member initialization
        }
       
      

        public static IEnumerable<SearchResultModel> ConvertCCTransactionsToViewModel(IEnumerable<GeneratedModel.CCTransaction> cCTransactionResults)
        {
            List<SearchResultModel> searchResults = new List<SearchResultModel>();
            searchResults.AddRange(ConvertToViewModel(cCTransactionResults).ToList());
            var x = ConvertToViewModel2(cCTransactionResults);
            return searchResults;
        }

        private static SearchResultModel ConvertToViewModel2(IEnumerable<CCTransaction> cCTransactionResults)
        {
            SearchResultModel temp = new SearchResultModel(cCTransactionResults.First());
            return temp;
        }

        private static IEnumerable<SearchResultModel> ConvertToViewModel(IEnumerable<GeneratedModel.CCTransaction> cCTransactionResults)
        {
            foreach (CCTransaction ccTransaction in cCTransactionResults)
            {
                var x = new SearchResultModel(ccTransaction);
                yield return x;// new SearchResultModel(ccTransaction);
            }
                
        }

       
    }
}
