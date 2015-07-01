using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OpenTraderSunFixes.Model
{
    public class SunFixAttributes //: IValidatableObject
    {
        public int CCTransactionId { get; set; }
        public SunTransactionType TransactionType { get; set; }
        public string BusinessUnit { get; set; }
        public DateTime? PostingDate { get; set; }
        public bool PremiumsEdited { get; set; }

        
        [Range(int.MinValue, int.MaxValue, ErrorMessage = "Memo Amount Number only please")]
        public double MemoAmountNew { get; set; }
        public double CCAmountNew { get; set; }

        [Range(int.MinValue, int.MaxValue, ErrorMessage = "Number only please")]
        public double TotalCommNew { get; set; }
        public double PowerplaceCommNew { get; set; }
        public double BrokerCommNew { get; set; }
        public double IPTNew { get; set; }
        public char? AppendChar { get; set; }

        public int maxReturn = 1;
        public int resendProcessing = 0;
        public SunFixType SunFixType { get; set; }

        public decimal TotalCommissionRate { get; set; }
        public decimal BrokerCommissionRate { get; set; }
        public decimal PowerplaceCommissionRate { get; set; }

        public SunFixAttributes()
        {

        }

        public SunFixAttributes(int CCTransactionId, SunTransactionType TransactionType, string BusinessUnit, DateTime? PostingDate, bool PremiumsEdited, double MemoAmountNew, double ccAmountNew,double PowerplaceCommNew, double BrokerCommNew, double IPTNew,SunFixType sunFixType ,char? AppendChar)
        {
            // TODO: Complete member initialization
            this.CCTransactionId = CCTransactionId;
            this.TransactionType = TransactionType;
            this.BusinessUnit = BusinessUnit;
            this.PostingDate = PostingDate;
            this.PremiumsEdited = PremiumsEdited;
            this.MemoAmountNew = MemoAmountNew;
            this.CCAmountNew = ccAmountNew;
            this.PowerplaceCommNew = PowerplaceCommNew;
            this.BrokerCommNew = BrokerCommNew;
            this.TotalCommNew = BrokerCommNew + PowerplaceCommNew;
            this.IPTNew = IPTNew;
            this.SunFixType = sunFixType;
            this.AppendChar = AppendChar;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            
            throw new NotImplementedException();
        }
    }
}
