﻿using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenTraderSunFixes.Controllers;
using OpenTraderSunFixes.DomainService.iMarketReverseTranslations;
using OTOMReverseEngineerXML.AutoMapperProfiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTraderSunFixes.Model.GeneratedModel.Tests.Controllers
{
    [TestClass]
    public class iMarketReverseEngineerTranslationControllerTests
    {
        [TestMethod]
        public void EngineerXmlTest()
        {

            Mapper.Initialize(mapper =>
            {
                BaseConfigurations.AutoMapperOneTimeConfigurations();
                mapper.AddProfile<TradesmanNBRqProfile>();
                mapper.AddProfile<MiniFleetNBRqProfile>();
            });

            var controller = new iMarketReverseEngineerTranslationController(new imarketReverseEngineerTranslationService());
            #region sampleXml
                        var sampleXml = @"<ns:TradesmanAllNBRq xmlns:ns=""http://www.polaris-uk.co.uk/Schema/4/TradesmanAllNBRq""><DateGenerated>2015-08-11</DateGenerated>
			            <TimeGenerated>15:40:14</TimeGenerated>
			            <StartDate>2015-08-11</StartDate>
			            <StartTime>15:40:00</StartTime>
			            <EndDate>2016-08-10</EndDate>
			            <EndTime>23:59:00</EndTime>
			            <BusinessSource>
				            <Code>
					            <Value>B183 002</Value>
					            <ShortDescription>Broker Office</ShortDescription>
				            </Code>
			            </BusinessSource>
			            <SoftwareHouse>
				            <Code>
					            <Value>B82 16</Value>
					            <ShortDescription>Open GI Limited</ShortDescription>
				            </Code>
			            </SoftwareHouse>
			            <Intermediary>
				            <PEMId>A0038900033</PEMId>
				            <CompanyName>TraderQA4</CompanyName>
				            <RiskReference>AVAI004TZ2</RiskReference>
				            <TransactionReference>20454089</TransactionReference>
				            <Contact>
					            <IndividualName>
						            <FirstForename>Avais</FirstForename>
						            <Surname>Dev</Surname>
					            </IndividualName>
					            <WorkTelephoneNo>01234567890</WorkTelephoneNo>
					            <EmailAddress>imarket_broker@opentesting.co.uk</EmailAddress>
				            </Contact>
			            </Intermediary>
			            <PriorInsurer>
				            <Code>
					            <Value>B81 997</Value>
					            <ShortDescription>Unknown</ShortDescription>
				            </Code>
			            </PriorInsurer>
			            <Insured>
				            <CompanyName>V2 ValidQuote </CompanyName>
				            <CompanyStatusCode>
					            <Value>B646 013</Value>
					            <ShortDescription>Company Trading As</ShortDescription>
				            </CompanyStatusCode>
				            <PAYEThresholdInd>
					            <Value>true</Value>
				            </PAYEThresholdInd>
				            <TradingName>
					            <Name>v2 validquote</Name>
				            </TradingName>
				            <Address>
					            <Line1>11 Southfield Street</Line1>
					            <Line2>Worcester</Line2>
					            <Postcode>WR1 1NH</Postcode>
				            </Address>
				            <YearsExperience>4</YearsExperience>
				            <YearBusinessEstablished>1995</YearBusinessEstablished>
				            <Declaration>
					            <LossesInd>
						            <Value>true</Value>
					            </LossesInd>
					            <Losses>
						            <ClaimReportingStatus>
							            <Value>B722 3</Value>
							            <ShortDescription>Not previously notified to insurer</ShortDescription>
						            </ClaimReportingStatus>
						            <OccurrenceDate>2011-06-01</OccurrenceDate>
						            <CauseCode>
							            <Value>B22 A</Value>
							            <ShortDescription>Accident</ShortDescription>
						            </CauseCode>
						            <MonetaryAmount>
							            <Amount>1200.00</Amount>
						            </MonetaryAmount>
						            <LossBreakdown>
							            <CoverCode>
								            <Value>B205 A05</Value>
								            <ShortDescription>Accidental Damage</ShortDescription>
							            </CoverCode>
						            </LossBreakdown>
					            </Losses>
					            <ConvictionsInd>
						            <Value>false</Value>
					            </ConvictionsInd>
					            <BankruptInd>
						            <Value>false</Value>
					            </BankruptInd>
					            <InsuranceInd>
						            <Value>false</Value>
					            </InsuranceInd>
					            <BusinessPremisesInd>
						            <Value>false</Value>
					            </BusinessPremisesInd>
					            <DischargeOfWasteInd>
						            <Value>false</Value>
					            </DischargeOfWasteInd>
					            <HarmfulSubstancesInd>
						            <Value>false</Value>
					            </HarmfulSubstancesInd>
				            </Declaration>
				            <Trade>
					            <Code>
						            <Value>B566 C09</Value>
						            <ShortDescription>Accountancy</ShortDescription>
					            </Code>
					            <MainInd>
						            <Value>true</Value>
					            </MainInd>
					            <NoOfWorkers>12</NoOfWorkers>
					            <TurnoverPercent>100</TurnoverPercent>
				            </Trade>
				            <Turnover>
					            <TurnoverAmount>1200</TurnoverAmount>
					            <Contract>
						            <MonetaryAmount>
							            <MaxAmount>1200</MaxAmount>
						            </MonetaryAmount>
					            </Contract>
					            <Fees>
						            <MaxAmount>1500</MaxAmount>
					            </Fees>
				            </Turnover>
				            <Subsidiary>
					            <SubsidiaryIncludedInd>
						            <Value>false</Value>
					            </SubsidiaryIncludedInd>
					            <CompanyName>asdad</CompanyName>
					            <PAYEThresholdInd>
						            <Value>true</Value>
					            </PAYEThresholdInd>
					            <Address>
						            <Line1>12 Southfield Street</Line1>
						            <Line2>Worcester</Line2>
						            <Postcode>WR1 1NH</Postcode>
					            </Address>
				            </Subsidiary>
			            </Insured>
			            <Policy>
				            <StartDate>2015-08-11</StartDate>
				            <StartTime>15:40:00</StartTime>
				            <EndDate>2016-08-10</EndDate>
				            <EndTime>23:59:00</EndTime>
			            </Policy>
			            <Employee>
				            <NoOfEmployees>12</NoOfEmployees>
				            <Wages>1200</Wages>
				            <EmployeeDetail>
					            <EmploymentTypeCode>
						            <Value>B515 190</Value>
						            <ShortDescription>Bona Fide Sub-Contractor</ShortDescription>
					            </EmploymentTypeCode>
					            <GeneralActivity>
						            <Code>
							            <Value>B520 296</Value>
							            <ShortDescription>Clerical Work</ShortDescription>
						            </Code>
						            <NoOfWorkers>1</NoOfWorkers>
					            </GeneralActivity>
				            </EmployeeDetail>
			            </Employee>
			            <ToolCover>
				            <CoverDetail>
					            <SumInsured>
						            <Amount>1200</Amount>
					            </SumInsured>
					            <Employee>
						            <EmploymentTypeCode>
							            <Value>B515 190</Value>
							            <ShortDescription>Bona Fide Sub-Contractor</ShortDescription>
						            </EmploymentTypeCode>
						            <NoOfEmployees>12</NoOfEmployees>
					            </Employee>
				            </CoverDetail>
			            </ToolCover>
			            <PublicLiabilityCover>
				            <CoverDetail>
					            <SumInsured>
						            <Amount>1200</Amount>
					            </SumInsured>
				            </CoverDetail>
			            </PublicLiabilityCover>
			            <EmployersLiabilityCover>
				            <CoverRequiredInd>
					            <Value>false</Value>
				            </CoverRequiredInd>
			            </EmployersLiabilityCover>
			            <BusinessInterruptionCover>
				            <CoverDetail>
					            <BasisCode>
						            <Value>B506 004</Value>
						            <ShortDescription>Increased Cost of Working</ShortDescription>
					            </BasisCode>
					            <AdditionalCover>
						            <Code>
							            <Value>B205 307</Value>
							            <ShortDescription>Additional Increased Cost Of Working</ShortDescription>
						            </Code>
						            <SumInsured>
							            <Amount>1200</Amount>
						            </SumInsured>
					            </AdditionalCover>
				            </CoverDetail>
			            </BusinessInterruptionCover>
			            <PersonalAccidentCover>
				            <CoverDetail>
					            <CapitalBenefit>
						            <Amount>1800</Amount>
					            </CapitalBenefit>
					            <GroupDetail>
						            <EmploymentTypeCode>
							            <Value>B515 137</Value>
							            <ShortDescription>All Employees And Other Persons</ShortDescription>
						            </EmploymentTypeCode>
					            </GroupDetail>
					            <IndividualDetail>
						            <IndividualName>
							            <TitleCode>
								            <Value>B53 003</Value>
								            <ShortDescription>Mr</ShortDescription>
							            </TitleCode>
							            <FirstForename>Avais</FirstForename>
							            <Surname>Mohamamd</Surname>
						            </IndividualName>
						            <BirthDate>2000-02-15</BirthDate>
					            </IndividualDetail>
				            </CoverDetail>
			            </PersonalAccidentCover>
			            <ContractWorksCover>
				            <CoverDetail>
					            <SumInsured>
						            <Amount>1800</Amount>
					            </SumInsured>
					            <Excess>
						            <Amount>150</Amount>
					            </Excess>
				            </CoverDetail>
			            </ContractWorksCover>
			            <HiredInPlantCover>
				            <CoverDetail>
					            <SumInsured>
						            <Amount>1200</Amount>
					            </SumInsured>
					            <Excess>
						            <Amount>0</Amount>
					            </Excess>
					            <HiringCharges>1500</HiringCharges>
				            </CoverDetail>
			            </HiredInPlantCover>
			            <OwnPlantCover>
				            <CoverDetail>
					            <SumInsured>
						            <Amount>1500</Amount>
					            </SumInsured>
					            <Excess>
						            <Amount>500</Amount>
					            </Excess>
					            <Plant>
						            <Value>1200</Value>
					            </Plant>
				            </CoverDetail>
			            </OwnPlantCover>
			            <ProfessionalIndemnityCover>
				            <CoverDetail>
					            <SumInsured>
						            <Amount>1500</Amount>
					            </SumInsured>
					            <RetroactiveDate>2002-01-21</RetroactiveDate>
					            <Declaration>
						            <RelevantQualificationsInd>
							            <Value>true</Value>
						            </RelevantQualificationsInd>
						            <DesignUndertakenInd>
							            <Value>true</Value>
						            </DesignUndertakenInd>
						            <Activity>
							            <Code>
								            <Value>B520 298</Value>
								            <ShortDescription>Computer Hardware Design</ShortDescription>
							            </Code>
						            </Activity>
						            <PropertyManagementInd>
							            <Value>true</Value>
						            </PropertyManagementInd>
						            <TaxationAdviceInd>
							            <Value>true</Value>
						            </TaxationAdviceInd>
						            <YearsExperienceInd>
							            <Value>true</Value>
						            </YearsExperienceInd>
					            </Declaration>
					            <Accreditation>
						            <Code>
							            <Value>B502 34</Value>
							            <ShortDescription>AAT</ShortDescription>
						            </Code>
					            </Accreditation>
				            </CoverDetail>
			            </ProfessionalIndemnityCover>
			            <TravelCover>
				            <CoverDetail>
					            <LocationCode>
						            <Value>B657 022</Value>
						            <ShortDescription>Europe</ShortDescription>
					            </LocationCode>
					            <NoOfPersonDays>12</NoOfPersonDays>
				            </CoverDetail>
			            </TravelCover>
			            <AdditionalCover>
				            <Code>
					            <Value>B205 X98</Value>
					            <ShortDescription>Business Equipment</ShortDescription>
				            </Code>
				            <SumInsured>
					            <Amount>1200</Amount>
				            </SumInsured>
			            </AdditionalCover>
		            </ns:TradesmanAllNBRq>";
            #endregion 

            var result = controller.EngineerXml(sampleXml, "OpenGI.MVC.BusinessLines.ViewModels.ViewModels.Tradesman.TradesmanDataCapture");
            Console.WriteLine(result);

        }
    }
}
