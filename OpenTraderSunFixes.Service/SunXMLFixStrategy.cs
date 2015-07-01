using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using OpenTraderSunFixes.DomainService.Helpers;
using System.IO;

namespace OpenTraderSunFixes.DomainService
{
    public class SunXMLFixStrategy : SunFixStrategy
    {
        public override string GenerateFix(Model.SunFixAttributes sunFixAttributes)
        {
            XmlDocument xmlDoc = ccTransSunRepo.GenerateXML(sunFixAttributes);
            return ProcessXML(xmlDoc.IndentAndBeautify(),sunFixAttributes.AppendChar);
        }


        private string ProcessXML(string generatedXML, char? appendChar)
        {
            if (appendChar == null)
                return generatedXML;

            SSC sunSyntaxXML = XMLSerializer.DeserializeSunXML(generatedXML);
            sunSyntaxXML.ProcessXML_AppendCharacterToTransactionReference(appendChar);
            return XMLSerializer.SerializeSunXML(sunSyntaxXML);
        }

        public override string GenerateXMLFromScript(string scriptToBeExecuted, Model.SunFixAttributes sunFixAttributes)
        {
            var modifiedScript = scriptToBeExecuted.Replace("COMMIT TRANSACTION T1", "");
            XmlDocument xmlDoc = ccTransSunRepo.GenerateXML(modifiedScript, sunFixAttributes);
            return ProcessXML(xmlDoc.IndentAndBeautify(), sunFixAttributes.AppendChar);
        }

        internal override string ConvertTestXMLToLive(System.IO.Stream fileContentStream, Model.SunFixAttributes sunFixAttributes)
        {
            fileContentStream.Position = 0;
            var streamReader = new StreamReader(fileContentStream);
            String XMLfromFile = streamReader.ReadToEnd();
            streamReader.Dispose();
            SSC sunSyntaxXML = XMLSerializer.DeserializeSunXML(XMLfromFile);
            sunSyntaxXML.ProcessXML_ConvertTestXMLToLive(sunFixAttributes.BusinessUnit);
            return XMLSerializer.SerializeSunXML(sunSyntaxXML);
        }

    }
}
