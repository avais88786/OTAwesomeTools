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
    using OpenTraderSunFixes.Model;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\Users\Avaisuddin\OneDrive\GitHubRepository\SunFixes\OpenTraderSunFixes.Repository\Templates\SunChangedPremiumsTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "12.0.0.0")]
    public partial class SunChangedPremiumsTemplate : SunChangedPremiumsTemplateBase
    {
#line hidden
        public SunFixAttributes sunFixAttributes;
        public SunChangedPremiumsTemplate(SunFixAttributes sunFixAttr)
        {
            this.sunFixAttributes = sunFixAttr;
        }

        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write(@"

DECLARE	@Contra_CCTransactionStatusId INT				= 1	-- Selected for Payment
DECLARE	@Contra_CCAccountingPeriodId INT				= 0	-- Not Specified
DECLARE	@Contra_LogonUserId INT						= 4	-- Batch User (Countrywide)
DECLARE	@Contra_CompanyId INT						= 3	-- Countrywide
DECLARE	@Contra_CCOpenTransactionTypeId INT				= 3	-- Account Adjustment

DECLARE @OriginalCCTransactionId INT =  ");
            
            #line 15 "C:\Users\Avaisuddin\OneDrive\GitHubRepository\SunFixes\OpenTraderSunFixes.Repository\Templates\SunChangedPremiumsTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(sunFixAttributes.CCTransactionId));
            
            #line default
            #line hidden
            this.Write(" -- ORIGINAL TRANSaCTIONID HERE\r\nDECLARE @NewCCTransactionId INT --new cctransId\r" +
                    "\nDECLARE @NewCCAmount DECIMAL(28,10) = ");
            
            #line 17 "C:\Users\Avaisuddin\OneDrive\GitHubRepository\SunFixes\OpenTraderSunFixes.Repository\Templates\SunChangedPremiumsTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(sunFixAttributes.CCAmountNew));
            
            #line default
            #line hidden
            this.Write(" -- CC Amount Here\r\nDECLARE @NewMemoAmount DECIMAL(28,10) = ");
            
            #line 18 "C:\Users\Avaisuddin\OneDrive\GitHubRepository\SunFixes\OpenTraderSunFixes.Repository\Templates\SunChangedPremiumsTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(sunFixAttributes.MemoAmountNew));
            
            #line default
            #line hidden
            this.Write(" -- Memo Amount Here\r\nDECLARE @NewTaxAmount DECIMAL(28,10) = ");
            
            #line 19 "C:\Users\Avaisuddin\OneDrive\GitHubRepository\SunFixes\OpenTraderSunFixes.Repository\Templates\SunChangedPremiumsTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(sunFixAttributes.IPTNew));
            
            #line default
            #line hidden
            this.Write(" -- Tax amount here\r\nDECLARE @NewBrokerCommissionAmount DECIMAL(28,10) = ");
            
            #line 20 "C:\Users\Avaisuddin\OneDrive\GitHubRepository\SunFixes\OpenTraderSunFixes.Repository\Templates\SunChangedPremiumsTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(sunFixAttributes.BrokerCommNew));
            
            #line default
            #line hidden
            this.Write(" -- Broker Commission Amount\r\nDECLARE @NewWholesalerCommissionAmount DECIMAL(28,1" +
                    "0) = ");
            
            #line 21 "C:\Users\Avaisuddin\OneDrive\GitHubRepository\SunFixes\OpenTraderSunFixes.Repository\Templates\SunChangedPremiumsTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(sunFixAttributes.PowerplaceCommNew));
            
            #line default
            #line hidden
            this.Write(" -- Wholesaler Commission Amount (powerplace)\r\n\r\nDECLARE @NewBrokerCommissionRate" +
                    " DECIMAL(28,10) = ");
            
            #line 23 "C:\Users\Avaisuddin\OneDrive\GitHubRepository\SunFixes\OpenTraderSunFixes.Repository\Templates\SunChangedPremiumsTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(sunFixAttributes.BrokerCommissionRate));
            
            #line default
            #line hidden
            this.Write(" -- Broker Commission Rate\r\nDECLARE @NewWholesalerCommissionRate DECIMAL(28,10) =" +
                    " ");
            
            #line 24 "C:\Users\Avaisuddin\OneDrive\GitHubRepository\SunFixes\OpenTraderSunFixes.Repository\Templates\SunChangedPremiumsTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(sunFixAttributes.PowerplaceCommissionRate));
            
            #line default
            #line hidden
            this.Write(" -- Wholesaler Commission Rate (powerplace)\r\n\r\n\r\nBEGIN TRANSACTION T1\r\n\r\nBEGIN TR" +
                    "Y\r\n\r\n\tINSERT INTO CCTransaction(\r\n\t\t\tRiskId, \r\n\t\t\tCCTransactionStatusId, \r\n\t\t\tCC" +
                    "PaymentTypeId, \r\n\t\t\tCCAccountingPeriodId, \r\n\t\t\tAmount, \r\n\t\t\tReference, \r\n\t\t\tPaym" +
                    "entDate, \r\n\t\t\tEffectiveDate, \r\n\t\t\tProcessDate, \r\n\t\t\tCurrencyId, \r\n\t\t\tCreatorUser" +
                    "Id, \r\n\t\t\tCreatorCompanyId, \r\n\t\t\tCreationDate, \r\n\t\t\tLastUpdateUserId, \r\n\t\t\tLastUp" +
                    "datedDate,\r\n\t\t\tSettlementDate, \r\n\t\t\tComments, \r\n\t\t\tCCOpenTransactionTypeId, \r\n\t\t" +
                    "\tBrokerCompanyId, \r\n\t\t\tInsurerCompanyId, \r\n\t\t\tClientCompanyId, \r\n\t\t\tBrokerRefere" +
                    "nce, \r\n\t\t\tCCOpenPremiumTypeId, \r\n\t\t\tHasBeenReversed, \r\n\t\t\tReversesCCTransactionI" +
                    "d\r\n\t\t)\r\n\t\tSELECT\r\n\t\t\tcct.RiskId,\t\t\t\t\t\t\t-- RiskId \r\n\t\t\t@Contra_CCTransactionStatu" +
                    "sId,\t\t-- CCTransactionStatusId \r\n\t\t\tcct.CCPaymentTypeId,\t\t\t\t-- CCPaymentTypeId \r" +
                    "\n\t\t\t@Contra_CCAccountingPeriodId,\t\t-- CCAccountingPeriodId \r\n\t\t\t@NewCCAmount,   " +
                    "       \t\t\t\t-- Amount \r\n\t\t\tcct.Reference,\t\t\t\t\t\t-- Reference \r\n\t\t\tNULL,\t\t\t\t\t\t\t\t-- " +
                    "PaymentDate \r\n\t\t\tcct.EffectiveDate,\t\t\t\t\t-- EffectiveDate \r\n\t\t\tGETDATE(),\t\t\t\t\t\t\t-" +
                    "- ProcessDate \r\n\t\t\tcct.CurrencyId,\t\t\t\t\t\t-- CurrencyId \r\n\t\t\t@Contra_LogonUserId,\t" +
                    "\t\t\t-- CreatorUserId \r\n\t\t\t@Contra_CompanyId,\t\t\t\t\t-- CreatorCompanyId \r\n\t\t\tGETDATE" +
                    "(),\t\t\t\t\t\t\t-- CreationDate \r\n\t\t\t@Contra_LogonUserId,\t\t\t\t-- LastUpdateUserId \r\n\t\t\t" +
                    "GETDATE(),\t\t\t\t\t\t\t-- LastUpdatedDate\r\n\t\t\tNULL,\t\t\t\t\t\t\t\t-- SettlementDate \r\n\t\t\tCCT." +
                    "Comments,\t\t\t\t\t\t-- Comments \r\n\t\t\t@Contra_CCOpenTransactionTypeId,\t-- CCOpenTransa" +
                    "ctionTypeId \r\n\t\t\tcct.BrokerCompanyId,\t\t\t\t-- BrokerCompanyId \r\n\t\t\tcct.InsurerComp" +
                    "anyId,\t\t\t\t-- InsurerCompanyId \r\n\t\t\tcct.ClientCompanyId,\t\t\t\t-- ClientCompanyId \r\n" +
                    "\t\t\tcct.BrokerReference,\t\t\t\t-- BrokerReference \r\n\t\t\tcct.CCOpenPremiumTypeId,\t\t\t--" +
                    " CCOpenPremiumTypeId \r\n\t\t\t0,\t\t\t\t\t\t\t\t\t-- HasBeenReversed \r\n\t\t\tcct.CCTransactionId" +
                    "\t\t\t\t\t-- ReversesCCTransactionId\r\n\t\tFROM \r\n\t\t\tCCTransaction cct\r\n\t\t\tWHERE cct.CCT" +
                    "ransactionId = @OriginalCCTransactionId\r\n\r\n\tSET @NewCCTransactionId = SCOPE_IDEN" +
                    "TITY()\r\n\r\n\tINSERT INTO CCTransactionItem(\r\n\t\t\tCCTransactionId,\r\n\t\t\tCCCategoryTyp" +
                    "eId,\r\n\t\t\tCCSubCategoryTypeId,\r\n\t\t\tCompanyId,\r\n\t\t\tAmount,\r\n\t\t\tCreatorUserId,\r\n\t\t\t" +
                    "CreatorCompanyId,\r\n\t\t\tCreationDate,\r\n\t\t\tLastUpdateUserId,\r\n\t\t\tLastUpdatedDate,\r\n" +
                    "\t\t\tRate\r\n\t\t)\r\n\t\tSELECT\r\n\t\t\t@NewCCTransactionId,\t\t-- CCTransactionId\r\n\t\t\tccti.CCC" +
                    "ategoryTypeId,\t\t-- CCCategoryTypeId\r\n\t\t\tccti.CCSubCategoryTypeId,\t-- CCSubCatego" +
                    "ryTypeId\r\n\t\t\tccti.CompanyId,\t\t\t\t-- CompanyId\r\n\t\t\tCASE ccti.CCCategoryTypeId\r\n\t\t\t" +
                    "\tWHEN 3 THEN @NewTaxAmount -- Tax\r\n\t\t\t\tWHEN 4 THEN @NewMemoAmount\r\n\t\t\t\tWHEN 2 TH" +
                    "EN\r\n\t\t\t\tCASE ccti.CCSubCategoryTypeId\r\n\t\t\t\t\tWHEN 5 THEN @NewBrokerCommissionAmou" +
                    "nt --Broker Commission amount\r\n\t\t\t\t\tWHEN 6 THEN @NewWholesalerCommissionAmount -" +
                    "-Wholesaler Commission amount\r\n\t\t\t\tEND\r\n\t\t\tEND, \r\n\t\t\t@Contra_LogonUserId,\t\t-- Cr" +
                    "eatorUserId\r\n\t\t\t@Contra_CompanyId,\t\t\t-- CreatorCompanyId\r\n\t\t\tGETDATE(),\t\t\t\t\t-- C" +
                    "reationDate\r\n\t\t\t@Contra_LogonUserId,\t\t-- LastUpdateUserId\r\n\t\t\tGETDATE(),\t\t\t\t\t-- " +
                    "LastUpdatedDate\r\n\t\t\tCASE ccti.CCCategoryTypeId\r\n\t\t\t\tWHEN 3 THEN ccti.Rate\r\n\t\t\t\tW" +
                    "HEN 4 THEN ccti.Rate\r\n\t\t\t\tWHEN 2 THEN\r\n\t\t\t\tCASE ccti.CCSubCategoryTypeId\r\n\t\t\t\t\tW" +
                    "HEN 5 THEN @NewBrokerCommissionRate --Broker Commission rate\r\n\t\t\t\t\tWHEN 6 THEN @" +
                    "NewWholesalerCommissionRate --Wholesaler Commission rate\r\n\t\t\t\tEND\r\n\t\t\tEND\r\n\t\tFRO" +
                    "M\r\n\t\t\tCCTransactionItem ccti\r\n\t\t\tWHERE\r\n\t\t\tccti.CCTransactionId = @OriginalCCTra" +
                    "nsactionId\r\n\r\n\t\t\tIF (@NewCCTransactionId IS NOT NULL)\r\n\t\t\tBEGIN\r\n\t    \t\tEXEC dbo" +
                    ".usp_open_acc_updTransactionStatus @NewCCTransactionId, 1, \'\'\r\n\t\t\t\tCOMMIT TRANSA" +
                    "CTION T1\r\n\t\t\t\tSELECT @NewCCTransactionId\r\n\t\t\tEND\r\n\t\t\tELSE\r\n\t\t\tBEGIN\r\n\t\t\t\tPRINT \'" +
                    "NEW CCTRANSID IS NULL...ROLLBACKING\'\r\n\t\t\t\tROLLBACK TRANSACTION T1\r\n\t\t\tEND\r\n\t   \r" +
                    "\nEND TRY\r\nBEGIN CATCH\r\n\t\tROLLBACK TRANSACTION T1\r\n\t\tPRINT \'Error Occured\'\r\n\t\tSEL" +
                    "ECT\r\n\t\tERROR_NUMBER() AS ErrorNumber\r\n\t\t,ERROR_SEVERITY() AS ErrorSeverity\r\n\t\t,E" +
                    "RROR_STATE() AS ErrorState\r\n\t\t,ERROR_PROCEDURE() AS ErrorProcedure\r\n\t\t,ERROR_LIN" +
                    "E() AS ErrorLine\r\n\t\t,ERROR_MESSAGE() AS ErrorMessage;\r\nEND CATCH\r\n");
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
    public class SunChangedPremiumsTemplateBase
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
