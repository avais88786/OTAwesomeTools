﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 12.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace OpenTraderSunFixes.Repository.Templates
{
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using OpenTraderSunFixes.Model.GeneratedModel;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\Users\Avaisuddin\OneDrive\GitHubRepository\SunFixes\OpenTraderSunFixes.Repository\Templates\SunContraTransaction.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "12.0.0.0")]
    public partial class SunContraTransaction : SunContraTransactionBase
    {
        public CCTransaction ccTransaction;
        public DateTime? ccTransactionDateTimeNeeded;

        public SunContraTransaction(CCTransaction ccTransaction,DateTime? postingDate)
        {
            this.ccTransaction = ccTransaction;
            this.ccTransactionDateTimeNeeded = postingDate;

        }


#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write("\r\nSET NOCOUNT ON\r\nBEGIN\r\n \r\n\tDECLARE\t@Contra_CCTransactionStatusId INT\t\t\t\t= 1\t-- " +
                    "Selected for Payment\r\n\tDECLARE\t@Contra_CCAccountingPeriodId INT\t\t\t\t= 0\t-- Not Sp" +
                    "ecified\r\n\tDECLARE\t@Contra_LogonUserId INT\t\t\t\t\t\t= 4\t-- Batch User (Countrywide)\r\n" +
                    "\tDECLARE\t@Contra_CompanyId INT\t\t\t\t\t\t= 3\t-- Countrywide\r\n\tDECLARE\t@Contra_CCOpenT" +
                    "ransactionTypeId INT\t\t\t\t= 3\t-- Account Adjustment\r\n \r\n\tDECLARE @New_CCTransactio" +
                    "nStatusId INT\t\t\t\t\t= 1\t-- Selected for Payment\r\n\tDECLARE @New_CCPaymentType INT\t\t" +
                    "\t\t\t\t= 4 \t-- Direct Debit\r\n\tDECLARE\t@New_CCAccountingPeriodId INT\t\t\t\t\t= 0\t-- Not " +
                    "Specified\r\n\tDECLARE\t@New_LogonUserId INT\t\t\t\t\t\t= 4\t-- Batch User (Countrywide)\r\n\t" +
                    "DECLARE\t@New_CompanyId INT\t\t\t\t\t\t= 3\t-- Countrywide\r\n\tDECLARE\t@New_CCOpenTransact" +
                    "ionTypeId INT\t\t\t\t= 3\t-- Account Adjustment\r\n \r\n\tDECLARE @GrossPremium_CCCategory" +
                    "TypeId INT\t\t\t\t= 4 \t-- Gross Premium\r\n\tDECLARE @GrossPremium_CCSubCategoryTypeId " +
                    "INT\t\t\t\t= 1 \t-- None\r\n\tDECLARE @IPT_CCCategoryTypeId INT\t\t\t\t\t= 3 \t-- Tax\r\n\tDECLAR" +
                    "E @IPT_CCSubCategoryTypeId INT\t\t\t\t\t= 1 \t-- None\r\n\tDECLARE @BrokerCommission_CCCa" +
                    "tegoryTypeId INT\t\t\t\t= 2 \t-- Commission\r\n\tDECLARE @BrokerCommission_CCSubCategory" +
                    "TypeId INT\t\t\t= 5 \t-- Broker\r\n\tDECLARE @WholesalerCommission_CCCategoryTypeId INT" +
                    "\t\t\t= 2 \t-- Commission\r\n\tDECLARE @WholesalerCommission_CCSubCategoryTypeId INT\t\t\t" +
                    "= 6 \t-- Wholesaler\r\n\tDECLARE @Tax_CCCategoryTypeId INT\t\t\t\t\t= 3 \t-- Tax\r\n\tDECLARE" +
                    " @Tax_CCSubCategoryTypeId INT\t\t\t\t\t= 1 \t-- None\r\n \r\n\tDECLARE @UF_CCOpenPremiumTyp" +
                    "eId INT\t\t\t\t\t= 3 \t-- Underwriting Fee\r\n\tDECLARE @UF_OpenSectionPremiumTypeId INT\t" +
                    "\t\t\t= 56 \t-- Underwriting Fee\r\n\tDECLARE @UF_CommissionTypeId_Commission INT\t\t\t\t= " +
                    "1 \t-- Commission\r\n\tDECLARE @UF_CommissionTypeId_Brokerage INT\t\t\t\t= 3 \t-- Brokera" +
                    "ge\r\n \r\n \r\n \r\n    DECLARE @TransactionDate DATETIME \r\n \r\n\t-----------------------" +
                    "------------------------------------------------------------------------\r\n\t-- ST" +
                    "EP 1: Compile list of all contra transactions ----------------------------------" +
                    "----------\r\n\t-------------------------------------------------------------------" +
                    "----------------------------\r\n\tDECLARE @ContraTransactions TABLE\r\n\t(\r\n\t\ti INT PR" +
                    "IMARY KEY IDENTITY,\r\n\t\tCCTransactionId INT NOT NULL\r\n\t)\r\n \r\n\t--DECLARE @ContraUF" +
                    "Transactions TABLE\r\n\t--(\r\n\t--\ti INT PRIMARY KEY IDENTITY,\r\n\t--\tCCTransactionId I" +
                    "NT NOT NULL\r\n\t--)\r\n \r\n\tINSERT INTO @ContraTransactions(CCTransactionId) VALUES (" +
                    "");
            
            #line 59 "C:\Users\Avaisuddin\OneDrive\GitHubRepository\SunFixes\OpenTraderSunFixes.Repository\Templates\SunContraTransaction.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ccTransaction.CCTransactionId));
            
            #line default
            #line hidden
            this.Write(")\r\n\tSET @TransactionDate = \'");
            
            #line 60 "C:\Users\Avaisuddin\OneDrive\GitHubRepository\SunFixes\OpenTraderSunFixes.Repository\Templates\SunContraTransaction.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ccTransactionDateTimeNeeded));
            
            #line default
            #line hidden
            this.Write("\'\t\r\n \r\n--\tINSERT INTO @ContraUFTransactions(CCTransactionId)\r\n--select CCTransact" +
                    "ionId from @ContraTransactions\r\n\t--SELECT\tu_cct.CCTransactionId\r\n\t--FROM\tCCTrans" +
                    "action cct\r\n\t--JOIN\t@ContraTransactions ct\r\n\t--\tON\tct.CCTransactionId = cct.CCTr" +
                    "ansactionId\r\n\t--JOIN\tCCTransaction u_cct\r\n\t--\tON\tu_cct.RiskId = cct.RiskId\r\n\t--\t" +
                    "AND\tu_cct.CCOpenPremiumTypeId = 3 -- Underwriting Fee\r\n\t--\tAND\tu_cct.HasBeenReve" +
                    "rsed = 0\r\n\t--\tAND\tu_cct.ReversesCCTransactionId IS NULL\r\n --select * from @Contr" +
                    "aUFTransactions\r\n\t--------------------------------------------------------------" +
                    "---------------------------------\r\n\t-- STEP 2: Create contras for these transact" +
                    "ions ----------------------------------------------\r\n\t--------------------------" +
                    "---------------------------------------------------------------------\r\n \r\n\t-- ST" +
                    "EP 2a: Main Transactions\r\n\t-----------------------------------------------------" +
                    "------------------------------------------\t\r\n\tINSERT INTO CCTransaction(\r\n\t\tRisk" +
                    "Id, \r\n\t\tCCTransactionStatusId, \r\n\t\tCCPaymentTypeId, \r\n\t\tCCAccountingPeriodId, \r\n" +
                    "\t\tAmount, \r\n\t\tReference, \r\n\t\tPaymentDate, \r\n\t\tEffectiveDate, \r\n\t\tProcessDate, \r\n" +
                    "\t\tCurrencyId, \r\n\t\tCreatorUserId, \r\n\t\tCreatorCompanyId, \r\n\t\tCreationDate, \r\n\t\tLas" +
                    "tUpdateUserId, \r\n\t\tLastUpdatedDate,\r\n\t\tSettlementDate, \r\n\t\tComments, \r\n\t\tCCOpenT" +
                    "ransactionTypeId, \r\n\t\tBrokerCompanyId, \r\n\t\tInsurerCompanyId, \r\n\t\tClientCompanyId" +
                    ", \r\n\t\tBrokerReference, \r\n\t\tCCOpenPremiumTypeId, \r\n\t\tHasBeenReversed, \r\n\t\tReverse" +
                    "sCCTransactionId\r\n\t)\r\n\tSELECT\r\n\t\tcct.RiskId,\t\t\t\t\t\t\t-- RiskId \r\n\t\t@Contra_CCTrans" +
                    "actionStatusId,\t\t-- CCTransactionStatusId \r\n\t\tcct.CCPaymentTypeId,\t\t\t\t-- CCPayme" +
                    "ntTypeId \r\n\t\t@Contra_CCAccountingPeriodId,\t\t-- CCAccountingPeriodId \r\n\t\tcct.Amou" +
                    "nt * -1,\t\t\t\t\t-- Amount \r\n\t\tcct.Reference,\t\t\t\t\t\t-- Reference \r\n\t\tNULL,\t\t\t\t\t\t\t\t-- " +
                    "PaymentDate \r\n\t\t@TransactionDate,--  cct.EffectiveDate,\t\t\t\t\t-- EffectiveDate \r\n\t" +
                    "\tcct.ProcessDate,--  GETDATE(),\t\t\t\t\t\t\t-- ProcessDate \r\n\t\tcct.CurrencyId,\t\t\t\t\t\t--" +
                    " CurrencyId \r\n\t\t@Contra_LogonUserId,\t\t\t\t-- CreatorUserId \r\n\t\t@Contra_CompanyId,\t" +
                    "\t\t\t\t-- CreatorCompanyId \r\n\t\tcct.CreationDate,-- GETDATE(),\t\t\t\t\t\t\t-- CreationDate" +
                    " \r\n\t\t@Contra_LogonUserId,\t\t\t\t-- LastUpdateUserId \r\n\t\tcct.LastUpdatedDate,-- GETD" +
                    "ATE(),\t\t\t\t\t\t\t-- LastUpdatedDate\r\n\t\tNULL,\t\t\t\t\t\t\t\t-- SettlementDate \r\n\t\t\'Contra Ma" +
                    "in\',\t\t\t\t\t\t-- Comments \r\n\t\t@Contra_CCOpenTransactionTypeId,\t-- CCOpenTransactionT" +
                    "ypeId \r\n\t\tcct.BrokerCompanyId,\t\t\t\t-- BrokerCompanyId \r\n\t\tcct.InsurerCompanyId,\t\t" +
                    "\t\t-- InsurerCompanyId \r\n\t\tcct.ClientCompanyId,\t\t\t\t-- ClientCompanyId \r\n\t\tcct.Bro" +
                    "kerReference,\t\t\t\t-- BrokerReference \r\n\t\tcct.CCOpenPremiumTypeId,\t\t\t-- CCOpenPrem" +
                    "iumTypeId \r\n\t\t0,\t\t\t\t\t\t\t\t\t-- HasBeenReversed \r\n\t\tcct.CCTransactionId\t\t\t\t\t-- Rever" +
                    "sesCCTransactionId\r\n\tFROM\t@ContraTransactions ct\r\n\tJOIN\tCCTransaction cct\r\n\t\tON\t" +
                    "cct.CCTransactionId = ct.CCTransactionId\r\n declare @newCCTransId int = Scope_Ide" +
                    "ntity()\r\n \r\n\t-- STEP 2b: Underwriting Fee Transactions\r\n\t-----------------------" +
                    "------------------------------------------------------------------------\r\n\t--INS" +
                    "ERT INTO CCTransaction(\r\n\t--\tRiskId, \r\n\t--\tCCTransactionStatusId, \r\n\t--\tCCPaymen" +
                    "tTypeId, \r\n\t--\tCCAccountingPeriodId, \r\n\t--\tAmount, \r\n\t--\tReference, \r\n\t--\tPaymen" +
                    "tDate, \r\n\t--\tEffectiveDate, \r\n\t--\tProcessDate, \r\n\t--\tCurrencyId, \r\n\t--\tCreatorUs" +
                    "erId, \r\n\t--\tCreatorCompanyId, \r\n\t--\tCreationDate, \r\n\t--\tLastUpdateUserId, \r\n\t--\t" +
                    "LastUpdatedDate,\r\n\t--\tSettlementDate, \r\n\t--\tComments, \r\n\t--\tCCOpenTransactionTyp" +
                    "eId, \r\n\t--\tBrokerCompanyId, \r\n\t--\tInsurerCompanyId, \r\n\t--\tClientCompanyId, \r\n\t--" +
                    "\tBrokerReference, \r\n\t--\tCCOpenPremiumTypeId, \r\n\t--\tHasBeenReversed, \r\n\t--\tRevers" +
                    "esCCTransactionId\r\n\t--)\r\n\t--SELECT\r\n\t--\tcct.RiskId,\t\t\t\t\t\t-- RiskId \r\n\t--\t@Contra" +
                    "_CCTransactionStatusId,\t-- CCTransactionStatusId \r\n\t--\tcct.CCPaymentTypeId,\t\t\t--" +
                    " CCPaymentTypeId \r\n\t--\t@Contra_CCAccountingPeriodId,\t-- CCAccountingPeriodId \r\n\t" +
                    "--\tcct.Amount * -1,\t\t\t\t-- Amount \r\n\t--\tcct.Reference,\t\t\t\t\t-- Reference \r\n\t--\tNUL" +
                    "L,\t\t\t\t\t\t\t-- PaymentDate \r\n\t--\tcct.EffectiveDate,\t\t\t\t-- EffectiveDate \r\n\t--\tGETDA" +
                    "TE(),\t\t\t\t\t\t-- ProcessDate \r\n\t--\tcct.CurrencyId,\t\t\t\t\t-- CurrencyId \r\n\t--\t@Contra_" +
                    "LogonUserId,\t\t\t-- CreatorUserId \r\n\t--\t@Contra_CompanyId,\t\t\t\t-- CreatorCompanyId " +
                    "\r\n\t--\tGETDATE(),\t\t\t\t\t\t-- CreationDate \r\n\t--\t@Contra_LogonUserId,\t\t\t-- LastUpdate" +
                    "UserId \r\n\t--\tGETDATE(),\t\t\t\t\t\t-- LastUpdatedDate\r\n\t--\tNULL,\t\t\t\t\t\t\t-- SettlementDa" +
                    "te \r\n\t--\t\'Contra Underwriting Fee\',\t\t-- Comments \r\n\t--\t@Contra_CCOpenTransaction" +
                    "TypeId,-- CCOpenTransactionTypeId \r\n\t--\tcct.BrokerCompanyId,\t\t\t-- BrokerCompanyI" +
                    "d \r\n\t--\tcct.InsurerCompanyId,\t\t\t-- InsurerCompanyId \r\n\t--\tcct.ClientCompanyId,\t\t" +
                    "\t-- ClientCompanyId \r\n\t--\tcct.BrokerReference,\t\t\t-- BrokerReference \r\n\t--\tcct.CC" +
                    "OpenPremiumTypeId,\t\t-- CCOpenPremiumTypeId \r\n\t--\t0,\t\t\t\t\t\t\t\t-- HasBeenReversed \r\n" +
                    "\t--\tcct.CCTransactionId\t\t\t\t-- ReversesCCTransactionId\r\n\t--FROM\t@ContraUFTransact" +
                    "ions ct\r\n\t--JOIN\tCCTransaction cct\r\n\t--\tON\tcct.CCTransactionId = ct.CCTransactio" +
                    "nId\r\n \r\n    \r\n\r\n \r\n\t------------------------------------------------------------" +
                    "-----------------------------------\r\n\t-- STEP 3: Update the old transactions to " +
                    "show that they have been reversed -------------------\r\n\t------------------------" +
                    "-----------------------------------------------------------------------\t\t\r\n\t--UP" +
                    "DATE\tCCTransaction\r\n\t--SET\t\tHasBeenReversed = 1\r\n\t--WHERE\tCCTransactionId IN (\r\n" +
                    "\t--\tSELECT\tCCTransactionId \r\n\t--\tFROM\t@ContraTransactions \r\n\t--\tUNION\r\n\t--\tSELEC" +
                    "T\tCCTransactionId\r\n\t--\tFROM\t@ContraUFTransactions\r\n\t--)\r\n \r\n\t-------------------" +
                    "----------------------------------------------------------------------------\r\n\t-" +
                    "- STEP 4: Create contras for all transaction items -----------------------------" +
                    "--------------\r\n\t---------------------------------------------------------------" +
                    "--------------------------------\r\n\tINSERT INTO CCTransactionItem(\r\n\t\tCCTransacti" +
                    "onId,\r\n\t\tCCCategoryTypeId,\r\n\t\tCCSubCategoryTypeId,\r\n\t\tCompanyId,\r\n\t\tAmount,\r\n\t\tC" +
                    "reatorUserId,\r\n\t\tCreatorCompanyId,\r\n\t\tCreationDate,\r\n\t\tLastUpdateUserId,\r\n\t\tLast" +
                    "UpdatedDate,\r\n\t\tRate\r\n\t)\r\n\tSELECT\r\n\t\tcct.CCTransactionId,\t\t-- CCTransactionId\r\n\t" +
                    "\tccti.CCCategoryTypeId,\t\t-- CCCategoryTypeId\r\n\t\tccti.CCSubCategoryTypeId,\t-- CCS" +
                    "ubCategoryTypeId\r\n\t\tccti.CompanyId,\t\t\t\t-- CompanyId\r\n\t\tccti.Amount * -1,\t\t\t-- Am" +
                    "ount\r\n\t\t@Contra_LogonUserId,\t\t-- CreatorUserId\r\n\t\t@Contra_CompanyId,\t\t\t-- Creato" +
                    "rCompanyId\r\n\t\tGETDATE(),\t\t\t\t\t-- CreationDate\r\n\t\t@Contra_LogonUserId,\t\t-- LastUpd" +
                    "ateUserId\r\n\t\tGETDATE(),\t\t\t\t\t-- LastUpdatedDate\r\n\t\tccti.Rate\t\t\t\t\t-- Rate\r\n\tFROM\t@" +
                    "ContraTransactions ct\r\n\tJOIN\tCCTransactionItem ccti\r\n\t\tON\tccti.CCTransactionId =" +
                    " ct.CCTransactionId\r\n\tJOIN\tCCTransaction cct\r\n\t\tON\tcct.ReversesCCTransactionId =" +
                    " ccti.CCTransactionId\r\n\tUNION\r\n\tSELECT\r\n\t\tcct.CCTransactionId,\t\t-- CCTransaction" +
                    "Id\r\n\t\tccti.CCCategoryTypeId,\t\t-- CCCategoryTypeId\r\n\t\tccti.CCSubCategoryTypeId,\t-" +
                    "- CCSubCategoryTypeId\r\n\t\tccti.CompanyId,\t\t\t\t-- CompanyId\r\n\t\tccti.Amount * -1,\t\t\t" +
                    "-- Amount\r\n\t\t@Contra_LogonUserId,\t\t-- CreatorUserId\r\n\t\t@Contra_CompanyId,\t\t\t-- C" +
                    "reatorCompanyId\r\n\t\tGETDATE(),\t\t\t\t\t-- CreationDate\r\n\t\t@Contra_LogonUserId,\t\t-- La" +
                    "stUpdateUserId\r\n\t\tGETDATE(),\t\t\t\t\t-- LastUpdatedDate\r\n\t\tccti.Rate\t\t\t\t\t-- Rate\r\n\tF" +
                    "ROM\t@ContraTransactions ct\r\n\tJOIN\tCCTransactionItem ccti\r\n\t\tON\tccti.CCTransactio" +
                    "nId = ct.CCTransactionId\r\n\tJOIN\tCCTransaction cct\r\n\t\tON\tcct.ReversesCCTransactio" +
                    "nId = ccti.CCTransactionId\r\n \r\n\r\n--GO\r\n \r\n\t-------------------------------------" +
                    "----------------------------------------------------------\r\n\t-- STEP 5: Create t" +
                    "he new CCExternalTransactionProcess to be picked up by Sun -----------------\r\n\t-" +
                    "--------------------------------------------------------------------------------" +
                    "--------------\r\n\tDECLARE @i INT = 1\r\n\tDECLARE @ContraContraMain INT\r\n\tSELECT\t@Co" +
                    "ntraContraMain = COUNT(*) FROM @ContraTransactions\r\n \r\n\tWHILE @i <= @ContraContr" +
                    "aMain\r\n\tBEGIN\r\n \r\n\t\tDECLARE @Contra_CCTransactionId INT\r\n \r\n\t\tSELECT\t@Contra_CCT" +
                    "ransactionId = cct.CCTransactionId\r\n\t\tFROM\t@ContraTransactions ct\r\n\t\tJOIN\tCCTran" +
                    "saction cct\r\n\t\t\tON\tcct.ReversesCCTransactionId = ct.CCTransactionId\r\n\t\tWHERE\tct." +
                    "i = @i\r\n \r\n\t\tIF (@Contra_CCTransactionId IS NOT NULL)\r\n\t\tBEGIN\r\n\t\t\tEXEC dbo.usp_" +
                    "open_acc_updTransactionStatus @Contra_CCTransactionId, 1, \'\'\r\n\t\tEND\r\n \r\n\t\tSET @i" +
                    " = @i + 1\r\n \r\n\tEND\r\n\r\n\tselect @newCCTransId\r\nEND");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
    #region Base class
    /// <summary>
    /// Base class for this transformation
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "12.0.0.0")]
    public class SunContraTransactionBase
    {
        #region Fields
        private global::System.Text.StringBuilder generationEnvironmentField;
        private global::System.CodeDom.Compiler.CompilerErrorCollection errorsField;
        private global::System.Collections.Generic.List<int> indentLengthsField;
        private string currentIndentField = "";
        private bool endsWithNewline;
        private global::System.Collections.Generic.IDictionary<string, object> sessionField;
        #endregion
        #region Properties
        /// <summary>
        /// The string builder that generation-time code is using to assemble generated output
        /// </summary>
        protected System.Text.StringBuilder GenerationEnvironment
        {
            get
            {
                if ((this.generationEnvironmentField == null))
                {
                    this.generationEnvironmentField = new global::System.Text.StringBuilder();
                }
                return this.generationEnvironmentField;
            }
            set
            {
                this.generationEnvironmentField = value;
            }
        }
        /// <summary>
        /// The error collection for the generation process
        /// </summary>
        public System.CodeDom.Compiler.CompilerErrorCollection Errors
        {
            get
            {
                if ((this.errorsField == null))
                {
                    this.errorsField = new global::System.CodeDom.Compiler.CompilerErrorCollection();
                }
                return this.errorsField;
            }
        }
        /// <summary>
        /// A list of the lengths of each indent that was added with PushIndent
        /// </summary>
        private System.Collections.Generic.List<int> indentLengths
        {
            get
            {
                if ((this.indentLengthsField == null))
                {
                    this.indentLengthsField = new global::System.Collections.Generic.List<int>();
                }
                return this.indentLengthsField;
            }
        }
        /// <summary>
        /// Gets the current indent we use when adding lines to the output
        /// </summary>
        public string CurrentIndent
        {
            get
            {
                return this.currentIndentField;
            }
        }
        /// <summary>
        /// Current transformation session
        /// </summary>
        public virtual global::System.Collections.Generic.IDictionary<string, object> Session
        {
            get
            {
                return this.sessionField;
            }
            set
            {
                this.sessionField = value;
            }
        }
        #endregion
        #region Transform-time helpers
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void Write(string textToAppend)
        {
            if (string.IsNullOrEmpty(textToAppend))
            {
                return;
            }
            // If we're starting off, or if the previous text ended with a newline,
            // we have to append the current indent first.
            if (((this.GenerationEnvironment.Length == 0) 
                        || this.endsWithNewline))
            {
                this.GenerationEnvironment.Append(this.currentIndentField);
                this.endsWithNewline = false;
            }
            // Check if the current text ends with a newline
            if (textToAppend.EndsWith(global::System.Environment.NewLine, global::System.StringComparison.CurrentCulture))
            {
                this.endsWithNewline = true;
            }
            // This is an optimization. If the current indent is "", then we don't have to do any
            // of the more complex stuff further down.
            if ((this.currentIndentField.Length == 0))
            {
                this.GenerationEnvironment.Append(textToAppend);
                return;
            }
            // Everywhere there is a newline in the text, add an indent after it
            textToAppend = textToAppend.Replace(global::System.Environment.NewLine, (global::System.Environment.NewLine + this.currentIndentField));
            // If the text ends with a newline, then we should strip off the indent added at the very end
            // because the appropriate indent will be added when the next time Write() is called
            if (this.endsWithNewline)
            {
                this.GenerationEnvironment.Append(textToAppend, 0, (textToAppend.Length - this.currentIndentField.Length));
            }
            else
            {
                this.GenerationEnvironment.Append(textToAppend);
            }
        }
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void WriteLine(string textToAppend)
        {
            this.Write(textToAppend);
            this.GenerationEnvironment.AppendLine();
            this.endsWithNewline = true;
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void Write(string format, params object[] args)
        {
            this.Write(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void WriteLine(string format, params object[] args)
        {
            this.WriteLine(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Raise an error
        /// </summary>
        public void Error(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Raise a warning
        /// </summary>
        public void Warning(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            error.IsWarning = true;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Increase the indent
        /// </summary>
        public void PushIndent(string indent)
        {
            if ((indent == null))
            {
                throw new global::System.ArgumentNullException("indent");
            }
            this.currentIndentField = (this.currentIndentField + indent);
            this.indentLengths.Add(indent.Length);
        }
        /// <summary>
        /// Remove the last indent that was added with PushIndent
        /// </summary>
        public string PopIndent()
        {
            string returnValue = "";
            if ((this.indentLengths.Count > 0))
            {
                int indentLength = this.indentLengths[(this.indentLengths.Count - 1)];
                this.indentLengths.RemoveAt((this.indentLengths.Count - 1));
                if ((indentLength > 0))
                {
                    returnValue = this.currentIndentField.Substring((this.currentIndentField.Length - indentLength));
                    this.currentIndentField = this.currentIndentField.Remove((this.currentIndentField.Length - indentLength));
                }
            }
            return returnValue;
        }
        /// <summary>
        /// Remove any indentation
        /// </summary>
        public void ClearIndent()
        {
            this.indentLengths.Clear();
            this.currentIndentField = "";
        }
        #endregion
        #region ToString Helpers
        /// <summary>
        /// Utility class to produce culture-oriented representation of an object as a string.
        /// </summary>
        public class ToStringInstanceHelper
        {
            private System.IFormatProvider formatProviderField  = global::System.Globalization.CultureInfo.InvariantCulture;
            /// <summary>
            /// Gets or sets format provider to be used by ToStringWithCulture method.
            /// </summary>
            public System.IFormatProvider FormatProvider
            {
                get
                {
                    return this.formatProviderField ;
                }
                set
                {
                    if ((value != null))
                    {
                        this.formatProviderField  = value;
                    }
                }
            }
            /// <summary>
            /// This is called from the compile/run appdomain to convert objects within an expression block to a string
            /// </summary>
            public string ToStringWithCulture(object objectToConvert)
            {
                if ((objectToConvert == null))
                {
                    throw new global::System.ArgumentNullException("objectToConvert");
                }
                System.Type t = objectToConvert.GetType();
                System.Reflection.MethodInfo method = t.GetMethod("ToString", new System.Type[] {
                            typeof(System.IFormatProvider)});
                if ((method == null))
                {
                    return objectToConvert.ToString();
                }
                else
                {
                    return ((string)(method.Invoke(objectToConvert, new object[] {
                                this.formatProviderField })));
                }
            }
        }
        private ToStringInstanceHelper toStringHelperField = new ToStringInstanceHelper();
        /// <summary>
        /// Helper to produce culture-oriented representation of an object as a string
        /// </summary>
        public ToStringInstanceHelper ToStringHelper
        {
            get
            {
                return this.toStringHelperField;
            }
        }
        #endregion
    }
    #endregion
}
