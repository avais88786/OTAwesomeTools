using OpenTraderSunFixes.Model.GeneratedModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTraderSunFixes.Repository
{
    public interface ICCTransactionRepository:IRepository<CCTransaction>
    {
        IQueryable<CCTransaction> GetByBrokerReference(string brokerReference);

        IQueryable<CCTransaction> GetByPowerPlaceReference(string powerplaceReference);


        CCTransaction GetByRiskId(int RiskId);
    }
}
