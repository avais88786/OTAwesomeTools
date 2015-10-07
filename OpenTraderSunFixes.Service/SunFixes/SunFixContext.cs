using OpenTraderSunFixes.Model;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OpenTraderSunFixes.DomainService
{
    public class SunFixContext
    {
        private SunFixStrategy _sunFixStrategy;

        public SunFixContext(SunFixType sunFixType,IContainer _container)
        {
          
            _sunFixStrategy = _container.GetInstance<SunFixStrategy>(sunFixType.ToString());
        }

        public string GenerateFix(SunFixAttributes sunFixAttributes)
        {
            StructureMap.Container container = new Container();
            return _sunFixStrategy.GenerateFix(sunFixAttributes);
        }

        public string ProcessGeneratedScript(string scriptToBeExecuted, Model.SunFixAttributes sunFixAttributes)
        {
            return _sunFixStrategy.GenerateXMLFromScript(scriptToBeExecuted, sunFixAttributes);
        }

        internal string ConvertTestXMLToLive(System.IO.Stream fileContentStream, Model.SunFixAttributes sunFixAttributes)
        {
            return _sunFixStrategy.ConvertTestXMLToLive(fileContentStream, sunFixAttributes);
        }
    }
}
