using OpenTraderSunFixes.Model.GeneratedModel;
using OpenTraderSunFixes.Repository.Templates;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace OpenTraderSunFixes.Repository
{
    public class SunRepository:EFRepository<CCTransaction>,ISunRepository,IDisposable
    {
        public SunRepository(DbContext dbContext)
            : base(dbContext)
        {

        }


        public XmlDocument GenerateXML(Model.SunFixAttributes sunFixAttributes)
        {
            XmlDocument sunXML = null;
            CCTransaction ccTransaction = GetById(sunFixAttributes.CCTransactionId);
              using (dbContext)
                {
                    dbContext.Database.Connection.Open();
                    using (DbTransaction dbTansaction = dbContext.Database.Connection.BeginTransaction())
                    {
                        //When Premiums are edited, Contra Radio is hidden but if user selected contra first then edited premiums the transactiontype submitted would 
                        //be hidden. We dont want to do a contra if premiums are edited!
                        if (sunFixAttributes.TransactionType == Model.SunTransactionType.CONTRA && !sunFixAttributes.PremiumsEdited)
                        {
                            #region templateconstructor
                            //public CCTransaction ccTransaction;
                            //public DateTime? ccTransactionDateTimeNeeded;

                            //public SunContraTransaction(CCTransaction ccTransaction,DateTime? postingDate)
                            //{
                            //    this.ccTransaction = ccTransaction;
                            //    this.ccTransactionDateTimeNeeded = postingDate;

                            //}
                            #endregion
                            SunContraTransaction contraTransactionTemplate = new SunContraTransaction(ccTransaction, sunFixAttributes.PostingDate);
                            string transformedText = contraTransactionTemplate.TransformText();

                            int contraCCTransactionId;

                            using (DbCommand dbCommand = dbContext.Database.Connection.CreateCommand())
                            {
                                dbCommand.CommandText = transformedText;
                                dbCommand.Transaction = dbTansaction;
                                contraCCTransactionId = (int)dbCommand.ExecuteScalar();
                            }
                            sunXML = GenerateXML(dbTansaction, sunFixAttributes.maxReturn, sunFixAttributes.BusinessUnit, sunFixAttributes.resendProcessing, contraCCTransactionId);

                            dbTansaction.Rollback();

                        }
                        else if (sunFixAttributes.PremiumsEdited)
                        {
                            SunChangedPremiumsTemplate scriptTemplate = new SunChangedPremiumsTemplate(sunFixAttributes); ;
                            string transformedText = scriptTemplate.TransformText();

                            int newCCTransactionId;

                            using (DbCommand dbCommand = dbContext.Database.Connection.CreateCommand())
                            {
                                dbCommand.CommandText = transformedText;
                                dbCommand.Transaction = dbTansaction;
                                newCCTransactionId = (int)dbCommand.ExecuteScalar();
                            }
                            sunXML = GenerateXML(dbTansaction, sunFixAttributes.maxReturn, sunFixAttributes.BusinessUnit, sunFixAttributes.resendProcessing, newCCTransactionId);

                            dbTansaction.Rollback();
                        }
                        else
                        {
                            sunXML = GenerateXML(dbTansaction, sunFixAttributes.maxReturn, sunFixAttributes.BusinessUnit, sunFixAttributes.resendProcessing, sunFixAttributes.CCTransactionId);
                        }
                    }


                }
            return sunXML;
        }

        public System.Xml.XmlDocument GenerateXML(DbTransaction dbTransaction, int maxReturn, string businessUnit, int resendProcessing, int transactionId)
        {
            string generatedXML=null;
            XmlDocument generatedXMLDoc = new XmlDocument();
            //using (dbContext)
            //{
                //dbContext.Database.Connection.Open();
                DbCommand command = dbContext.Database.Connection.CreateCommand();
                command.CommandText = "LiveSupport_usp_open_acc_xmlSSCTransaction_NS";
                command.Transaction = dbTransaction;
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@MaxReturn",maxReturn));
                command.Parameters.Add(new SqlParameter("@BusinessUnit",businessUnit));
                command.Parameters.Add(new SqlParameter("@ResendProcessing",resendProcessing));
                command.Parameters.Add(new SqlParameter("@TransactionId",transactionId));
                
                SqlParameter outPara1 = new SqlParameter("@Xml", SqlDbType.VarChar,-1);
                outPara1.Direction = System.Data.ParameterDirection.Output;
                command.Parameters.Add(outPara1);


                SqlParameter outPara2 = new SqlParameter("@BatchSize", SqlDbType.Int);
                outPara2.Direction = System.Data.ParameterDirection.Output;
                command.Parameters.Add(outPara2);


                outPara2 = new SqlParameter("@More", SqlDbType.Bit);
                outPara2.Direction = System.Data.ParameterDirection.Output;
                
                command.Parameters.Add(outPara2);


                DbDataReader reader = command.ExecuteReader();

                generatedXML = (string)outPara1.Value;
            //}

            using (TextReader sr = new StringReader(generatedXML))
            {
                generatedXMLDoc.Load(sr);
            }

            return generatedXMLDoc;
        }

        public override IQueryable<Model.GeneratedModel.CCTransaction> GetAll()
        {
            return base.GetAll();
        }

        public override Model.GeneratedModel.CCTransaction GetById(int id)
        {
            return base.GetById(id);
        }

        public override Model.GeneratedModel.CCTransaction GetByReference(string reference)
        {
            return base.GetByReference(reference);
        }


        public string GenerateScript(Model.SunFixAttributes sunFixAttributes)
        {
            #region templateConstructor
            // public SunFixAttributes sunFixAttributes;
            //public SunChangedPremiumsTemplate(SunFixAttributes sunFixAttr)
            //{
            //    this.sunFixAttributes = sunFixAttr;
            //}
            #endregion
            SunChangedPremiumsTemplate scriptTemplate = new SunChangedPremiumsTemplate(sunFixAttributes);
            return scriptTemplate.TransformText();

        }


        public XmlDocument GenerateXML(string modifiedScript,Model.SunFixAttributes sunFixAttributes)
        {
            XmlDocument xmlDoc;
            int tempCCTransId;
            using (dbContext)
            {
                dbContext.Database.Connection.Open();
                using (DbTransaction dbTransaction = dbContext.Database.Connection.BeginTransaction())
                {
                    using (DbCommand command = dbContext.Database.Connection.CreateCommand())
                    {
                        command.CommandText = modifiedScript;
                        command.CommandType = CommandType.Text;
                        command.Transaction = dbTransaction;
                        tempCCTransId = (int)command.ExecuteScalar();

                        xmlDoc = GenerateXML(dbTransaction, sunFixAttributes.maxReturn, "TST", sunFixAttributes.resendProcessing, tempCCTransId);
                    }
                }
            }

            return xmlDoc;
        }

        public void Dispose()
        {
            dbContext.Dispose();

        }
    }
}
