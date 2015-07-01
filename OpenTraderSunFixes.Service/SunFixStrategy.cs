using OpenTraderSunFixes.Model;
using OpenTraderSunFixes.Repository;
using OpenTraderSunFixes.Repository.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTraderSunFixes.DomainService
{
    public abstract class SunFixStrategy
    {
        protected ISunRepository ccTransSunRepo;
        public SunFixStrategy()
        {
            ccTransSunRepo = new SunRepository(new SunDBContext()); 
        }

        public abstract string GenerateFix(SunFixAttributes sunFixAttributes);

        public virtual string GenerateXMLFromScript(string scriptToBeExecuted, Model.SunFixAttributes sunFixAttributes) { throw new NotSupportedException("Method called on wrong class"); }

        internal virtual string ConvertTestXMLToLive(System.IO.Stream fileContentStream, Model.SunFixAttributes sunFixAttributes) { throw new NotSupportedException("Method called on wrong class"); }
    }

}
