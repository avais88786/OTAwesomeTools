using OpenTraderSunFixes.Model.GeneratedModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTraderSunFixes.Repository
{
    public class CCTransactionRepository : EFRepository<CCTransaction>,ICCTransactionRepository//,IDisposable
    {
        public CCTransactionRepository(DbContext dbContext) : base(dbContext) { }

        public IQueryable<CCTransaction> GetByBrokerReference(string brokerReference)
        {
            return dbSet.Where(c => c.BrokerReference.Equals(brokerReference, StringComparison.CurrentCultureIgnoreCase));
        }

        public IQueryable<CCTransaction> GetByPowerPlaceReference(string powerplaceReference)
        {
            return dbSet.Where(c => c.Reference.Equals(powerplaceReference, StringComparison.CurrentCultureIgnoreCase));
        }


        //Implement if IDisposable is implemented
        public void Dispose()
        {
            if (dbContext != null)
            {
                dbContext.Dispose();
                dbContext = null;
            }
        }

        CCTransaction ICCTransactionRepository.GetByRiskId(int RiskId)
        {
            return dbSet.FirstOrDefault(cc => cc.RiskId == RiskId);
        }

    }
}
