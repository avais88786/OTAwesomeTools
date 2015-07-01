using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTraderSunFixes.DomainService
{
    public class SunTraderFixStrategy : SunFixStrategy
    {
        public override string GenerateFix(Model.SunFixAttributes sunFixAttributes)
        {
        
            return ccTransSunRepo.GenerateScript(sunFixAttributes);

            //throw new NotImplementedException();
        }
    }
}
