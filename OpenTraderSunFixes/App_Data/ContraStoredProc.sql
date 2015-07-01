SET NOCOUNT ON
 set transaction isolation level read uncommitted
BEGIN TRAN TransactionName
BEGIN
 
	DECLARE	@Contra_CCTransactionStatusId INT				= 1	-- Selected for Payment
	DECLARE	@Contra_CCAccountingPeriodId INT				= 0	-- Not Specified
	DECLARE	@Contra_LogonUserId INT						= 4	-- Batch User (Countrywide)
	DECLARE	@Contra_CompanyId INT						= 3	-- Countrywide
	DECLARE	@Contra_CCOpenTransactionTypeId INT				= 3	-- Account Adjustment
 
	DECLARE @New_CCTransactionStatusId INT					= 1	-- Selected for Payment
	DECLARE @New_CCPaymentType INT						= 4 	-- Direct Debit
	DECLARE	@New_CCAccountingPeriodId INT					= 0	-- Not Specified
	DECLARE	@New_LogonUserId INT						= 4	-- Batch User (Countrywide)
	DECLARE	@New_CompanyId INT						= 3	-- Countrywide
	DECLARE	@New_CCOpenTransactionTypeId INT				= 3	-- Account Adjustment
 
	DECLARE @GrossPremium_CCCategoryTypeId INT				= 4 	-- Gross Premium
	DECLARE @GrossPremium_CCSubCategoryTypeId INT				= 1 	-- None
	DECLARE @IPT_CCCategoryTypeId INT					= 3 	-- Tax
	DECLARE @IPT_CCSubCategoryTypeId INT					= 1 	-- None
	DECLARE @BrokerCommission_CCCategoryTypeId INT				= 2 	-- Commission
	DECLARE @BrokerCommission_CCSubCategoryTypeId INT			= 5 	-- Broker
	DECLARE @WholesalerCommission_CCCategoryTypeId INT			= 2 	-- Commission
	DECLARE @WholesalerCommission_CCSubCategoryTypeId INT			= 6 	-- Wholesaler
	DECLARE @Tax_CCCategoryTypeId INT					= 3 	-- Tax
	DECLARE @Tax_CCSubCategoryTypeId INT					= 1 	-- None
 
	DECLARE @UF_CCOpenPremiumTypeId INT					= 3 	-- Underwriting Fee
	DECLARE @UF_OpenSectionPremiumTypeId INT				= 56 	-- Underwriting Fee
	DECLARE @UF_CommissionTypeId_Commission INT				= 1 	-- Commission
	DECLARE @UF_CommissionTypeId_Brokerage INT				= 3 	-- Brokerage
 
 
 
 
 
	-----------------------------------------------------------------------------------------------
	-- STEP 1: Compile list of all contra transactions --------------------------------------------
	-----------------------------------------------------------------------------------------------
	DECLARE @ContraTransactions TABLE
	(
		i INT PRIMARY KEY IDENTITY,
		CCTransactionId INT NOT NULL
	)
 
	--DECLARE @ContraUFTransactions TABLE
	--(
	--	i INT PRIMARY KEY IDENTITY,
	--	CCTransactionId INT NOT NULL
	--)
 
	INSERT INTO @ContraTransactions(CCTransactionId) VALUES (508685)
	
 
--	INSERT INTO @ContraUFTransactions(CCTransactionId)
--select CCTransactionId from @ContraTransactions
	--SELECT	u_cct.CCTransactionId
	--FROM	CCTransaction cct
	--JOIN	@ContraTransactions ct
	--	ON	ct.CCTransactionId = cct.CCTransactionId
	--JOIN	CCTransaction u_cct
	--	ON	u_cct.RiskId = cct.RiskId
	--	AND	u_cct.CCOpenPremiumTypeId = 3 -- Underwriting Fee
	--	AND	u_cct.HasBeenReversed = 0
	--	AND	u_cct.ReversesCCTransactionId IS NULL
 --select * from @ContraUFTransactions
	-----------------------------------------------------------------------------------------------
	-- STEP 2: Create contras for these transactions ----------------------------------------------
	-----------------------------------------------------------------------------------------------
 
	-- STEP 2a: Main Transactions
	-----------------------------------------------------------------------------------------------	
	INSERT INTO CCTransaction(
		RiskId, 
		CCTransactionStatusId, 
		CCPaymentTypeId, 
		CCAccountingPeriodId, 
		Amount, 
		Reference, 
		PaymentDate, 
		EffectiveDate, 
		ProcessDate, 
		CurrencyId, 
		CreatorUserId, 
		CreatorCompanyId, 
		CreationDate, 
		LastUpdateUserId, 
		LastUpdatedDate,
		SettlementDate, 
		Comments, 
		CCOpenTransactionTypeId, 
		BrokerCompanyId, 
		InsurerCompanyId, 
		ClientCompanyId, 
		BrokerReference, 
		CCOpenPremiumTypeId, 
		HasBeenReversed, 
		ReversesCCTransactionId
	)
	SELECT
		cct.RiskId,							-- RiskId 
		@Contra_CCTransactionStatusId,		-- CCTransactionStatusId 
		cct.CCPaymentTypeId,				-- CCPaymentTypeId 
		@Contra_CCAccountingPeriodId,		-- CCAccountingPeriodId 
		cct.Amount * -1,					-- Amount 
		cct.Reference,						-- Reference 
		NULL,								-- PaymentDate 
		cct.EffectiveDate,					-- EffectiveDate 
		GETDATE(),							-- ProcessDate 
		cct.CurrencyId,						-- CurrencyId 
		@Contra_LogonUserId,				-- CreatorUserId 
		@Contra_CompanyId,					-- CreatorCompanyId 
		GETDATE(),							-- CreationDate 
		@Contra_LogonUserId,				-- LastUpdateUserId 
		GETDATE(),							-- LastUpdatedDate
		NULL,								-- SettlementDate 
		'Contra Main',						-- Comments 
		@Contra_CCOpenTransactionTypeId,	-- CCOpenTransactionTypeId 
		cct.BrokerCompanyId,				-- BrokerCompanyId 
		cct.InsurerCompanyId,				-- InsurerCompanyId 
		cct.ClientCompanyId,				-- ClientCompanyId 
		cct.BrokerReference,				-- BrokerReference 
		cct.CCOpenPremiumTypeId,			-- CCOpenPremiumTypeId 
		0,									-- HasBeenReversed 
		cct.CCTransactionId					-- ReversesCCTransactionId
	FROM	@ContraTransactions ct
	JOIN	CCTransaction cct
		ON	cct.CCTransactionId = ct.CCTransactionId
 declare @newCCTransId int = Scope_Identity()
 select @newCCTransId
	-- STEP 2b: Underwriting Fee Transactions
	-----------------------------------------------------------------------------------------------
	--INSERT INTO CCTransaction(
	--	RiskId, 
	--	CCTransactionStatusId, 
	--	CCPaymentTypeId, 
	--	CCAccountingPeriodId, 
	--	Amount, 
	--	Reference, 
	--	PaymentDate, 
	--	EffectiveDate, 
	--	ProcessDate, 
	--	CurrencyId, 
	--	CreatorUserId, 
	--	CreatorCompanyId, 
	--	CreationDate, 
	--	LastUpdateUserId, 
	--	LastUpdatedDate,
	--	SettlementDate, 
	--	Comments, 
	--	CCOpenTransactionTypeId, 
	--	BrokerCompanyId, 
	--	InsurerCompanyId, 
	--	ClientCompanyId, 
	--	BrokerReference, 
	--	CCOpenPremiumTypeId, 
	--	HasBeenReversed, 
	--	ReversesCCTransactionId
	--)
	--SELECT
	--	cct.RiskId,						-- RiskId 
	--	@Contra_CCTransactionStatusId,	-- CCTransactionStatusId 
	--	cct.CCPaymentTypeId,			-- CCPaymentTypeId 
	--	@Contra_CCAccountingPeriodId,	-- CCAccountingPeriodId 
	--	cct.Amount * -1,				-- Amount 
	--	cct.Reference,					-- Reference 
	--	NULL,							-- PaymentDate 
	--	cct.EffectiveDate,				-- EffectiveDate 
	--	GETDATE(),						-- ProcessDate 
	--	cct.CurrencyId,					-- CurrencyId 
	--	@Contra_LogonUserId,			-- CreatorUserId 
	--	@Contra_CompanyId,				-- CreatorCompanyId 
	--	GETDATE(),						-- CreationDate 
	--	@Contra_LogonUserId,			-- LastUpdateUserId 
	--	GETDATE(),						-- LastUpdatedDate
	--	NULL,							-- SettlementDate 
	--	'Contra Underwriting Fee',		-- Comments 
	--	@Contra_CCOpenTransactionTypeId,-- CCOpenTransactionTypeId 
	--	cct.BrokerCompanyId,			-- BrokerCompanyId 
	--	cct.InsurerCompanyId,			-- InsurerCompanyId 
	--	cct.ClientCompanyId,			-- ClientCompanyId 
	--	cct.BrokerReference,			-- BrokerReference 
	--	cct.CCOpenPremiumTypeId,		-- CCOpenPremiumTypeId 
	--	0,								-- HasBeenReversed 
	--	cct.CCTransactionId				-- ReversesCCTransactionId
	--FROM	@ContraUFTransactions ct
	--JOIN	CCTransaction cct
	--	ON	cct.CCTransactionId = ct.CCTransactionId
 
    

 
	-----------------------------------------------------------------------------------------------
	-- STEP 3: Update the old transactions to show that they have been reversed -------------------
	-----------------------------------------------------------------------------------------------		
	--UPDATE	CCTransaction
	--SET		HasBeenReversed = 1
	--WHERE	CCTransactionId IN (
	--	SELECT	CCTransactionId 
	--	FROM	@ContraTransactions 
	--	UNION
	--	SELECT	CCTransactionId
	--	FROM	@ContraUFTransactions
	--)
 
	-----------------------------------------------------------------------------------------------
	-- STEP 4: Create contras for all transaction items -------------------------------------------
	-----------------------------------------------------------------------------------------------
	INSERT INTO CCTransactionItem(
		CCTransactionId,
		CCCategoryTypeId,
		CCSubCategoryTypeId,
		CompanyId,
		Amount,
		CreatorUserId,
		CreatorCompanyId,
		CreationDate,
		LastUpdateUserId,
		LastUpdatedDate,
		Rate
	)
	SELECT
		cct.CCTransactionId,		-- CCTransactionId
		ccti.CCCategoryTypeId,		-- CCCategoryTypeId
		ccti.CCSubCategoryTypeId,	-- CCSubCategoryTypeId
		ccti.CompanyId,				-- CompanyId
		ccti.Amount * -1,			-- Amount
		@Contra_LogonUserId,		-- CreatorUserId
		@Contra_CompanyId,			-- CreatorCompanyId
		GETDATE(),					-- CreationDate
		@Contra_LogonUserId,		-- LastUpdateUserId
		GETDATE(),					-- LastUpdatedDate
		ccti.Rate					-- Rate
	FROM	@ContraTransactions ct
	JOIN	CCTransactionItem ccti
		ON	ccti.CCTransactionId = ct.CCTransactionId
	JOIN	CCTransaction cct
		ON	cct.ReversesCCTransactionId = ccti.CCTransactionId
	UNION
	SELECT
		cct.CCTransactionId,		-- CCTransactionId
		ccti.CCCategoryTypeId,		-- CCCategoryTypeId
		ccti.CCSubCategoryTypeId,	-- CCSubCategoryTypeId
		ccti.CompanyId,				-- CompanyId
		ccti.Amount * -1,			-- Amount
		@Contra_LogonUserId,		-- CreatorUserId
		@Contra_CompanyId,			-- CreatorCompanyId
		GETDATE(),					-- CreationDate
		@Contra_LogonUserId,		-- LastUpdateUserId
		GETDATE(),					-- LastUpdatedDate
		ccti.Rate					-- Rate
	FROM	@ContraTransactions ct
	JOIN	CCTransactionItem ccti
		ON	ccti.CCTransactionId = ct.CCTransactionId
	JOIN	CCTransaction cct
		ON	cct.ReversesCCTransactionId = ccti.CCTransactionId
 

--GO
 
	-----------------------------------------------------------------------------------------------
	-- STEP 5: Create the new CCExternalTransactionProcess to be picked up by Sun -----------------
	-----------------------------------------------------------------------------------------------
	DECLARE @i INT = 1
	DECLARE @ContraContraMain INT
	SELECT	@ContraContraMain = COUNT(*) FROM @ContraTransactions
 
	WHILE @i <= @ContraContraMain
	BEGIN
 
		DECLARE @Contra_CCTransactionId INT
 
		SELECT	@Contra_CCTransactionId = cct.CCTransactionId
		FROM	@ContraTransactions ct
		JOIN	CCTransaction cct
			ON	cct.ReversesCCTransactionId = ct.CCTransactionId
		WHERE	ct.i = @i
 
		IF (@Contra_CCTransactionId IS NOT NULL)
		BEGIN
			EXEC dbo.usp_open_acc_updTransactionStatus @Contra_CCTransactionId, 1, ''
		END
 
		SET @i = @i + 1
 
 DECLARE @Xml varchar(MAX)
DECLARE @BatchSize int
DECLARE @More bit

EXECUTE [dbo].[LiveSupport_usp_open_acc_xmlSSCTransaction_NS] 
   1
  ,'TST'
  ,0
  ,@Contra_CCTransactionId
  ,@Xml OUTPUT
  ,@BatchSize OUTPUT
  ,@More OUTPUT
 
 select Convert(XML,@xml)
	END
 
	SET @i = 1
 
 
  

	--DECLARE @ContraContraUF INT
	--SELECT	@ContraContraUF = COUNT(*) FROM @ContraUFTransactions
 
	--WHILE @i <= @ContraContraUF
	--BEGIN
 
	--	DECLARE @ContraUF_CCTransactionId INT
 
	--	SELECT	@ContraUF_CCTransactionId = cct.CCTransactionId
	--	FROM	@ContraUFTransactions ct
	--	JOIN	CCTransaction cct
	--		ON	cct.ReversesCCTransactionId = ct.CCTransactionId
	--	WHERE	ct.i = @i
 
	--	IF (@ContraUF_CCTransactionId IS NOT NULL)
	--	BEGIN
	--		EXEC dbo.usp_open_acc_updTransactionStatus @ContraUF_CCTransactionId, 1, ''
	--	END
 
	--	SET @i = @i + 1
 
	--END
 
	-----------------------------------------------------------------------------------------------
	-- STEP 6: Correct the values on PowerPlace ---------------------------------------------------
	-----------------------------------------------------------------------------------------------
 
	-- STEP 6a: Risk Commission Ratio (Wholesaler)
	-----------------------------------------------------------------------------------------------
	UPDATE	rc
	SET		CommissionRatio = 
			CASE
				WHEN rkir.KeyReferenceId = 71 -- Standard
					THEN ppsc.StandardCommRatio
				WHEN rkir.KeyReferenceId = 72 -- Preferred
					THEN ppsc.PreferredCommRatio
				WHEN rkir.KeyReferenceId = 346 -- Bespoke
					THEN rkid.DecimalValue
			END,
			LastUpdateDateTime = GETDATE(),
			LastUpdateLogonUserId = @New_LogonUserId
	FROM	RiskCommission rc
	JOIN	CCTransaction cct
		ON	cct.RiskId = rc.RiskId
	JOIN	@ContraTransactions ct
		ON	ct.CCTransactionId = cct.CCTransactionId
	JOIN	Risk r
		ON	r.RiskId = rc.RiskId
	JOIN	Company c
		ON	r.AllocatedCompanyId = c.CompanyId
	JOIN	[DATA].Risk sbt_r
		ON	sbt_r.ParentRiskId = r.ParentRiskId
		AND	sbt_r.AllocatedCompanyId = c.RootCompanyId
		AND	sbt_r.RiskTypeId = 24 -- Scheme Broker Template
	JOIN	RiskKeyItemReference rkir
		ON	rkir.RiskId = sbt_r.RiskId
		AND	rkir.KeyTypeId = 129 -- CommissionLevel
	JOIN	PolicyPremiumSchemeCommission ppsc
		ON	ppsc.SchemeId = r.ParentRiskId
		AND	ppsc.CommissionTypeId = 1 -- Commission
		AND	ppsc.EffectiveFromDate <= r.CreatedDate
		AND	(ppsc.EffectiveToDate > r.CreatedDate 
		OR	ppsc.EffectiveToDate IS NULL)
	LEFT JOIN	RiskKeyItemDecimal rkid
		ON	rkid.RiskId = sbt_r.RiskId
		AND	rkid.KeyTypeId = 320 -- BespokePowerPlaceCommissionPercentage
	WHERE	rc.CommissionTypeId = 1 -- Commission
 
	-- STEP 6b: Risk Commission Ratio (Broker)
	-----------------------------------------------------------------------------------------------
	UPDATE	rc
	SET		CommissionRatio = 
			CASE
				WHEN rkir.KeyReferenceId = 71 -- Standard
					THEN ppsc.StandardCommRatio
				WHEN rkir.KeyReferenceId = 72 -- Preferred
					THEN ppsc.PreferredCommRatio
				WHEN rkir.KeyReferenceId = 346 -- Bespoke
					THEN rkid.DecimalValue
			END,
			LastUpdateDateTime = GETDATE(),
			LastUpdateLogonUserId = @New_LogonUserId
	FROM	RiskCommission rc
	JOIN	CCTransaction cct
		ON	cct.RiskId = rc.RiskId
	JOIN	@ContraTransactions ct
		ON	ct.CCTransactionId = cct.CCTransactionId
	JOIN	Risk r
		ON	r.RiskId = rc.RiskId
	JOIN	Company c
		ON	r.AllocatedCompanyId = c.CompanyId
	JOIN	[DATA].Risk sbt_r
		ON	sbt_r.ParentRiskId = r.ParentRiskId
		AND	sbt_r.AllocatedCompanyId = c.RootCompanyId
		AND	sbt_r.RiskTypeId = 24 -- Scheme Broker Template
	JOIN	RiskKeyItemReference rkir
		ON	rkir.RiskId = sbt_r.RiskId
		AND	rkir.KeyTypeId = 129 -- CommissionLevel
	JOIN	PolicyPremiumSchemeCommission ppsc
		ON	ppsc.SchemeId = r.ParentRiskId
		AND	ppsc.CommissionTypeId = 3 -- Brokerage
		AND	ppsc.EffectiveFromDate <= r.CreatedDate
		AND	(ppsc.EffectiveToDate > r.CreatedDate 
		OR	ppsc.EffectiveToDate IS NULL)
	LEFT JOIN	RiskKeyItemDecimal rkid
		ON	rkid.RiskId = sbt_r.RiskId
		AND	rkid.KeyTypeId = 312 -- BespokeBrokerCommissionPercentage
	WHERE	rc.CommissionTypeId = 3 -- Brokerage
 
	-- STEP 6c: Open Calculated Result
	-----------------------------------------------------------------------------------------------
	UPDATE	ocr
	SET		NewPremiumInclIPT = ocr.NewPremiumExclIPT * ocr.IPTRate,
			EffectiveAnnualPremiumInclIPT = ocr.NewPremiumExclIPT * ocr.IPTRate,
			TotalPremiumPayableInclIPT = ocr.NewPremiumExclIPT / ((100 - (w_rc.CommissionRatio + b_rc.CommissionRatio)) / 100) * ocr.IPTRate,
			IPTAmount = (ocr.NewPremiumExclIPT / ((100 - (w_rc.CommissionRatio + b_rc.CommissionRatio)) / 100) * ocr.IPTRate) - (ocr.NewPremiumExclIPT / ((100 - (w_rc.CommissionRatio + b_rc.CommissionRatio)) / 100)),
			EffectiveAnnualPremiumExclIPT = ocr.NewPremiumExclIPT,
			TotalPremiumPayableExclIPT = ocr.NewPremiumExclIPT / ((100 - (w_rc.CommissionRatio + b_rc.CommissionRatio)) / 100),
			LastUpdateLogonUserId = @New_LogonUserId,
			LastUpdateDateTime = GETDATE()
	FROM	OpenCalculatedResult ocr
	JOIN	CCTransaction cct
		ON	cct.RiskId = ocr.RiskId
	JOIN	@ContraTransactions ct
		ON	ct.CCTransactionId = cct.CCTransactionId
	JOIN	RiskCommission w_rc
		ON	w_rc.RiskId = ocr.RiskId
		AND	w_rc.CommissionTypeId = 1 -- Commission
	JOIN	RiskCommission b_rc
		ON	b_rc.RiskId = ocr.RiskId
		AND	b_rc.CommissionTypeId = 3 -- Brokerage
 
	-- STEP 6d: Risk Commission Amounts (Wholesaler and Broker)
	-----------------------------------------------------------------------------------------------
	UPDATE	rc
	SET		CommissionAmount = ocr.TotalPremiumPayableExclIPT * (rc.CommissionRatio / 100),
			LastUpdateDateTime = GETDATE(),
			LastUpdateLogonUserId = @New_LogonUserId
	FROM	RiskCommission rc
	JOIN	CCTransaction cct
		ON	cct.RiskId = rc.RiskId
	JOIN	@ContraTransactions ct
		ON	ct.CCTransactionId = cct.CCTransactionId
	JOIN	OpenCalculatedResult ocr
		ON	ocr.RiskId = rc.RiskId
 
	-- STEP 6d: Insert Missing Underwriting Fee RiskSectionCommission Values
	-----------------------------------------------------------------------------------------------	
	INSERT INTO RiskSectionCommission(
		RiskID,
		EntityUniqueID,
		OpenSectionPremiumTypeID,
		CommissionTypeID,
		CommissionRatio,
		CommissionAmount,
		LastUpdateDateTime,
		LastUpdateLogonUserID
	)
	SELECT
		cct.RiskId,							-- RiskID
		0,									-- EntityUniqueID
		@UF_OpenSectionPremiumTypeId,		-- OpenSectionPremiumTypeID
		@UF_CommissionTypeId_Commission,	-- CommissionTypeID
		0,									-- CommissionRatio
		0,									-- CommissionAmount
		GETDATE(),							-- LastUpdateDateTime
		@New_LogonUserId					-- LastUpdateLogonUserID
	FROM	@ContraTransactions ct
	JOIN	CCTransaction cct
		ON	cct.CCTransactionId = ct.CCTransactionId
	JOIN	OpenCalculatedSectionResult ocsr
		ON	ocsr.RiskId = cct.RiskId
		AND	ocsr.OpenSectionPremiumTypeID = 56 -- Underwriting Fee
	LEFT JOIN	RiskSectionCommission rsc
		ON	rsc.RiskID = cct.RiskId
		AND	rsc.OpenSectionPremiumTypeID = @UF_OpenSectionPremiumTypeId
		AND	rsc.CommissionTypeID = @UF_CommissionTypeId_Commission
	WHERE	rsc.RiskSectionCommissionID IS NULL
 
	INSERT INTO RiskSectionCommission(
		RiskID,
		EntityUniqueID,
		OpenSectionPremiumTypeID,
		CommissionTypeID,
		CommissionRatio,
		CommissionAmount,
		LastUpdateDateTime,
		LastUpdateLogonUserID
	)
	SELECT
		cct.RiskId,							-- RiskID
		0,									-- EntityUniqueID
		@UF_OpenSectionPremiumTypeId,		-- OpenSectionPremiumTypeID
		@UF_CommissionTypeId_Brokerage,		-- CommissionTypeID
		0,									-- CommissionRatio
		0,									-- CommissionAmount
		GETDATE(),							-- LastUpdateDateTime
		@New_LogonUserId					-- LastUpdateLogonUserID
	FROM	@ContraTransactions ct
	JOIN	CCTransaction cct
		ON	cct.CCTransactionId = ct.CCTransactionId
	JOIN	OpenCalculatedSectionResult ocsr
		ON	ocsr.RiskId = cct.RiskId
		AND	ocsr.OpenSectionPremiumTypeID = 56 -- Underwriting Fee
	LEFT JOIN	RiskSectionCommission rsc
		ON	rsc.RiskID = cct.RiskId
		AND	rsc.OpenSectionPremiumTypeID = @UF_OpenSectionPremiumTypeId
		AND	rsc.CommissionTypeID = @UF_CommissionTypeId_Brokerage
	WHERE	rsc.RiskSectionCommissionID IS NULL
 
	-----------------------------------------------------------------------------------------------
	-- STEP 7: Create new transaction with correct values -----------------------------------------
	-----------------------------------------------------------------------------------------------
	INSERT INTO CCTransaction(
		RiskId, 
		CCTransactionStatusId, 
		CCPaymentTypeId, 
		CCAccountingPeriodId, 
		Amount, 
		Reference, 
		PaymentDate, 
		EffectiveDate, 
		ProcessDate, 
		CurrencyId, 
		CreatorUserId, 
		CreatorCompanyId, 
		CreationDate, 
		LastUpdateUserId, 
		LastUpdatedDate,
		SettlementDate, 
		Comments, 
		CCOpenTransactionTypeId, 
		BrokerCompanyId, 
		InsurerCompanyId, 
		ClientCompanyId, 
		BrokerReference, 
		CCOpenPremiumTypeId, 
		HasBeenReversed, 
		ReversesCCTransactionId
	)
	SELECT
		cct.RiskId,							-- RiskId 
		@New_CCTransactionStatusId,			-- CCTransactionStatusId 
		@New_CCPaymentType,					-- CCPaymentTypeId 
		@New_CCAccountingPeriodId,			-- CCAccountingPeriodId 
		(
			ocr.TotalPremiumPayableInclIPT
			- b_rc.CommissionAmount
		) * 
		CASE WHEN cct.Amount >= 0 THEN 1 ELSE -1 END,
											-- Amount (Net Premium) 
		cct.Reference,						-- Reference 
		NULL,								-- PaymentDate 
		cct.EffectiveDate,					-- EffectiveDate 
		GETDATE(),							-- ProcessDate 
		cct.CurrencyId,						-- CurrencyId 
		@Contra_LogonUserId,				-- CreatorUserId 
		@Contra_CompanyId,					-- CreatorCompanyId 
		GETDATE(),							-- CreationDate 
		@Contra_LogonUserId,				-- LastUpdateUserId 
		GETDATE(),							-- LastUpdatedDate
		NULL,								-- SettlementDate 
		'Recalculated Main',				-- Comments 
		@New_CCOpenTransactionTypeId,		-- CCOpenTransactionTypeId 
		cct.BrokerCompanyId,				-- BrokerCompanyId 
		cct.InsurerCompanyId,				-- InsurerCompanyId 
		cct.ClientCompanyId,				-- ClientCompanyId 
		cct.BrokerReference,				-- BrokerReference 
		cct.CCOpenPremiumTypeId,			-- CCOpenPremiumTypeId 
		0,									-- HasBeenReversed 
		NULL								-- ReversesCCTransactionId
	FROM	@ContraTransactions ct
	JOIN	CCTransaction cct
		ON	cct.CCTransactionId = ct.CCTransactionId
	JOIN	OpenCalculatedResult ocr
		ON	ocr.RiskID = cct.RiskId
	JOIN	RiskCommission b_rc
		ON	b_rc.RiskId = cct.RiskId
		AND	b_rc.CommissionTypeId = 3 -- Brokerage
 
	INSERT INTO CCTransaction(
		RiskId, 
		CCTransactionStatusId, 
		CCPaymentTypeId, 
		CCAccountingPeriodId, 
		Amount, 
		Reference, 
		PaymentDate, 
		EffectiveDate, 
		ProcessDate, 
		CurrencyId, 
		CreatorUserId, 
		CreatorCompanyId, 
		CreationDate, 
		LastUpdateUserId, 
		LastUpdatedDate,
		SettlementDate, 
		Comments, 
		CCOpenTransactionTypeId, 
		BrokerCompanyId, 
		InsurerCompanyId, 
		ClientCompanyId, 
		BrokerReference, 
		CCOpenPremiumTypeId, 
		HasBeenReversed, 
		ReversesCCTransactionId
	)
	SELECT
		cct.RiskId,							-- RiskId 
		@New_CCTransactionStatusId,			-- CCTransactionStatusId 
		@New_CCPaymentType,					-- CCPaymentTypeId 
		@New_CCAccountingPeriodId,			-- CCAccountingPeriodId 
		oscp.TotalPremiumPayableExclIPT * 
		CASE WHEN cct.Amount >= 0 THEN 1 ELSE -1 END,
											-- Amount
		cct.Reference,						-- Reference 
		NULL,								-- PaymentDate 
		cct.EffectiveDate,					-- EffectiveDate 
		GETDATE(),							-- ProcessDate 
		cct.CurrencyId,						-- CurrencyId 
		@Contra_LogonUserId,				-- CreatorUserId 
		@Contra_CompanyId,					-- CreatorCompanyId 
		GETDATE(),							-- CreationDate 
		@Contra_LogonUserId,				-- LastUpdateUserId 
		GETDATE(),							-- LastUpdatedDate
		NULL,								-- SettlementDate 
		'Recalculated Underwriting Fee',	-- Comments 
		@New_CCOpenTransactionTypeId,		-- CCOpenTransactionTypeId 
		cct.BrokerCompanyId,				-- BrokerCompanyId 
		cct.InsurerCompanyId,				-- InsurerCompanyId 
		cct.ClientCompanyId,				-- ClientCompanyId 
		cct.BrokerReference,				-- BrokerReference 
		@UF_CCOpenPremiumTypeId,			-- CCOpenPremiumTypeId 
		0,									-- HasBeenReversed 
		NULL								-- ReversesCCTransactionId
	FROM	@ContraTransactions ct
	JOIN	CCTransaction cct
		ON	cct.CCTransactionId = ct.CCTransactionId
	JOIN	OpenCalculatedSectionResult oscp
		ON	oscp.RiskId = cct.RiskId
		AND	oscp.OpenSectionPremiumTypeId = 56 -- Underwriting Fee
 
	-----------------------------------------------------------------------------------------------
	-- STEP 8: Create new transaction items with correct values -----------------------------------
	-----------------------------------------------------------------------------------------------
 
	-- STEP 8a: Gross Premium Main Transaction Item
	-----------------------------------------------------------------------------------------------
	INSERT INTO CCTransactionItem(
		CCTransactionId,
		CCCategoryTypeId,
		CCSubCategoryTypeId,
		CompanyId,
		Amount,
		CreatorUserId,
		CreatorCompanyId,
		CreationDate,
		LastUpdateUserId,
		LastUpdatedDate,
		Rate
	)
	SELECT
		n_cct.CCTransactionId,				-- CCTransactionId
		@GrossPremium_CCCategoryTypeId,		-- CCCategoryTypeId
		@GrossPremium_CCSubCategoryTypeId,	-- CCSubCategoryTypeId
		n_cct.BrokerCompanyId,				-- CompanyId
		(
			ocr.TotalPremiumPayableInclIPT
			- ISNULL(t_ocsr.TotalPremiumPayableInclIPT, 0)
			- ISNULL(u_ocsr.TotalPremiumPayableInclIPT, 0)
		) * 
		CASE WHEN o_cct.Amount >= 0 THEN 1 ELSE -1 END,
											-- Amount (Gross Premium)
		@New_LogonUserId,					-- CreatorUserId
		@New_CompanyId,						-- CreatorCompanyId
		GETDATE(),							-- CreationDate
		@New_LogonUserId,					-- LastUpdateUserId
		GETDATE(),							-- LastUpdatedDate
		0									-- Rate (0%)
	FROM	@ContraTransactions ct
	JOIN	CCTransaction o_cct
		ON	o_cct.CCTransactionId = ct.CCTransactionId
	JOIN	CCTransaction n_cct
		ON	n_cct.RiskId = o_cct.RiskId
		AND	n_cct.CCTransactionId <> o_cct.CCTransactionId
		AND	n_cct.CCOpenPremiumTypeId = 1 -- Main
		AND	n_cct.ReversesCCTransactionId IS NULL
		AND	n_cct.HasBeenReversed = 0
	JOIN	OpenCalculatedResult ocr
		ON	ocr.RiskId = n_cct.RiskId
	LEFT JOIN	OpenCalculatedSectionResult t_ocsr
		ON	t_ocsr.RiskId = n_cct.RiskId
		AND	t_ocsr.OpenSectionPremiumTypeID = 23 -- Terrorism Total
	LEFT JOIN	OpenCalculatedSectionResult u_ocsr
		ON	u_ocsr.RiskId = n_cct.RiskId
		AND	u_ocsr.OpenSectionPremiumTypeID = 56 -- Underwriting Fee
 
	-- STEP 8b: IPT Main Transaction Item
	-----------------------------------------------------------------------------------------------
	INSERT INTO CCTransactionItem(
		CCTransactionId,
		CCCategoryTypeId,
		CCSubCategoryTypeId,
		CompanyId,
		Amount,
		CreatorUserId,
		CreatorCompanyId,
		CreationDate,
		LastUpdateUserId,
		LastUpdatedDate,
		Rate
	)
	SELECT
		n_cct.CCTransactionId,				-- CCTransactionId
		@IPT_CCCategoryTypeId,				-- CCCategoryTypeId
		@IPT_CCSubCategoryTypeId,			-- CCSubCategoryTypeId
		n_cct.BrokerCompanyId,				-- CompanyId
		(
			ocr.IPTAmount
			- ISNULL(t_ocsr.IPTAmount, 0)
			- ISNULL(u_ocsr.IPTAmount, 0)
		) * 
		CASE WHEN o_cct.Amount >= 0 THEN 1 ELSE -1 END,
											-- Amount (IPT Amount)
		@New_LogonUserId,					-- CreatorUserId
		@New_CompanyId,						-- CreatorCompanyId
		GETDATE(),							-- CreationDate
		@New_LogonUserId,					-- LastUpdateUserId
		GETDATE(),							-- LastUpdatedDate
		((ocr.IPTRate - 1) * 100)			-- Rate (IPT Rate)
	FROM	@ContraTransactions ct
	JOIN	CCTransaction o_cct
		ON	o_cct.CCTransactionId = ct.CCTransactionId
	JOIN	CCTransaction n_cct
		ON	n_cct.RiskId = o_cct.RiskId
		AND	n_cct.CCTransactionId <> o_cct.CCTransactionId
		AND	n_cct.CCOpenPremiumTypeId = 1 -- Main
		AND	n_cct.ReversesCCTransactionId IS NULL
		AND	n_cct.HasBeenReversed = 0
	JOIN	OpenCalculatedResult ocr
		ON	ocr.RiskId = n_cct.RiskId
	LEFT JOIN	OpenCalculatedSectionResult t_ocsr
		ON	t_ocsr.RiskId = n_cct.RiskId
		AND	t_ocsr.OpenSectionPremiumTypeID = 23 -- Terrorism Total
	LEFT JOIN	OpenCalculatedSectionResult u_ocsr
		ON	u_ocsr.RiskId = n_cct.RiskId
		AND	u_ocsr.OpenSectionPremiumTypeID = 56 -- Underwriting Fee
 
	-- STEP 8c: Broker Comission Main Transaction Item
	-----------------------------------------------------------------------------------------------
	INSERT INTO CCTransactionItem(
		CCTransactionId,
		CCCategoryTypeId,
		CCSubCategoryTypeId,
		CompanyId,
		Amount,
		CreatorUserId,
		CreatorCompanyId,
		CreationDate,
		LastUpdateUserId,
		LastUpdatedDate,
		Rate
	)
	SELECT
		n_cct.CCTransactionId,					-- CCTransactionId
		@BrokerCommission_CCCategoryTypeId,		-- CCCategoryTypeId
		@BrokerCommission_CCSubCategoryTypeId,	-- CCSubCategoryTypeId
		n_cct.BrokerCompanyId,					-- CompanyId
		b_rc.CommissionAmount * 
		CASE WHEN o_cct.Amount >= 0 THEN 1 ELSE -1 END,
												-- Amount (Broker Commission)
		@New_LogonUserId,						-- CreatorUserId
		@New_CompanyId,							-- CreatorCompanyId
		GETDATE(),								-- CreationDate
		@New_LogonUserId,						-- LastUpdateUserId
		GETDATE(),								-- LastUpdatedDate
		b_rc.CommissionRatio					-- Rate (Broker Rate)
	FROM	@ContraTransactions ct
	JOIN	CCTransaction o_cct
		ON	o_cct.CCTransactionId = ct.CCTransactionId
	JOIN	CCTransaction n_cct
		ON	n_cct.RiskId = o_cct.RiskId
		AND	n_cct.CCTransactionId <> o_cct.CCTransactionId
		AND	n_cct.CCOpenPremiumTypeId = 1 -- Main
		AND	n_cct.ReversesCCTransactionId IS NULL
		AND	n_cct.HasBeenReversed = 0
	JOIN	RiskCommission b_rc
		ON	b_rc.RiskId = n_cct.RiskId
		AND	b_rc.CommissionTypeId = 3 -- Brokerage
 
	-- STEP 8d: Wholesaler Comission Main Transaction Item
	-----------------------------------------------------------------------------------------------
	INSERT INTO CCTransactionItem(
		CCTransactionId,
		CCCategoryTypeId,
		CCSubCategoryTypeId,
		CompanyId,
		Amount,
		CreatorUserId,
		CreatorCompanyId,
		CreationDate,
		LastUpdateUserId,
		LastUpdatedDate,
		Rate
	)
	SELECT
		n_cct.CCTransactionId,						-- CCTransactionId
		@WholesalerCommission_CCCategoryTypeId,		-- CCCategoryTypeId
		@WholesalerCommission_CCSubCategoryTypeId,	-- CCSubCategoryTypeId
		n_cct.BrokerCompanyId,						-- CompanyId
		w_rc.CommissionAmount * 
		CASE WHEN o_cct.Amount >= 0 THEN 1 ELSE -1 END,
													-- Amount (Wholesaler Commission)
		@New_LogonUserId,							-- CreatorUserId
		@New_CompanyId,								-- CreatorCompanyId
		GETDATE(),									-- CreationDate
		@New_LogonUserId,							-- LastUpdateUserId
		GETDATE(),									-- LastUpdatedDate
		w_rc.CommissionRatio						-- Rate (Wholesaler Rate)
	FROM	@ContraTransactions ct
	JOIN	CCTransaction o_cct
		ON	o_cct.CCTransactionId = ct.CCTransactionId
	JOIN	CCTransaction n_cct
		ON	n_cct.RiskId = o_cct.RiskId
		AND	n_cct.CCTransactionId <> o_cct.CCTransactionId
		AND	n_cct.CCOpenPremiumTypeId = 1 -- Main
		AND	n_cct.ReversesCCTransactionId IS NULL
		AND	n_cct.HasBeenReversed = 0
	JOIN	RiskCommission w_rc
		ON	w_rc.RiskId = n_cct.RiskId
		AND	w_rc.CommissionTypeId = 1 -- Commission
 
	-- STEP 8e: Tax Underwriting Fee Transaction Item
	-----------------------------------------------------------------------------------------------
	INSERT INTO CCTransactionItem(
		CCTransactionId,
		CCCategoryTypeId,
		CCSubCategoryTypeId,
		CompanyId,
		Amount,
		CreatorUserId,
		CreatorCompanyId,
		CreationDate,
		LastUpdateUserId,
		LastUpdatedDate,
		Rate
	)
	SELECT
		n_cct.CCTransactionId,				-- CCTransactionId
		@Tax_CCCategoryTypeId,				-- CCCategoryTypeId
		@Tax_CCSubCategoryTypeId,			-- CCSubCategoryTypeId
		n_cct.BrokerCompanyId,				-- CompanyId
		0,									-- Amount
		@New_LogonUserId,					-- CreatorUserId
		@New_CompanyId,						-- CreatorCompanyId
		GETDATE(),							-- CreationDate
		@New_LogonUserId,					-- LastUpdateUserId
		GETDATE(),							-- LastUpdatedDate
		1									-- Rate (100%)
	FROM	@ContraTransactions ct
	JOIN	CCTransaction o_cct
		ON	o_cct.CCTransactionId = ct.CCTransactionId
	JOIN	CCTransaction n_cct
		ON	n_cct.RiskId = o_cct.RiskId
		AND	n_cct.CCTransactionId <> o_cct.CCTransactionId
		AND	n_cct.CCOpenPremiumTypeId = 3 -- Underwriting Fee
		AND	n_cct.ReversesCCTransactionId IS NULL
		AND n_cct.HasBeenReversed = 0
 
	-- STEP 8f: Gross Premium Underwriting Fee Transaction Item
	-----------------------------------------------------------------------------------------------
	INSERT INTO CCTransactionItem(
		CCTransactionId,
		CCCategoryTypeId,
		CCSubCategoryTypeId,
		CompanyId,
		Amount,
		CreatorUserId,
		CreatorCompanyId,
		CreationDate,
		LastUpdateUserId,
		LastUpdatedDate,
		Rate
	)
	SELECT
		n_cct.CCTransactionId,				-- CCTransactionId
		@GrossPremium_CCCategoryTypeId,		-- CCCategoryTypeId
		@GrossPremium_CCSubCategoryTypeId,	-- CCSubCategoryTypeId
		n_cct.BrokerCompanyId,				-- CompanyId
		ocsr.TotalPremiumPayableInclIPT * 
			CASE WHEN o_cct.Amount >= 0 THEN 1 ELSE -1 END,
											-- Amount
		@New_LogonUserId,					-- CreatorUserId
		@New_CompanyId,						-- CreatorCompanyId
		GETDATE(),							-- CreationDate
		@New_LogonUserId,					-- LastUpdateUserId
		GETDATE(),							-- LastUpdatedDate
		0									-- Rate (0%)
	FROM	@ContraTransactions ct
	JOIN	CCTransaction o_cct
		ON	o_cct.CCTransactionId = ct.CCTransactionId
	JOIN	CCTransaction n_cct
		ON	n_cct.RiskId = o_cct.RiskId
		AND	n_cct.CCTransactionId <> o_cct.CCTransactionId
		AND	n_cct.CCOpenPremiumTypeId = 3 -- Underwriting Fee
		AND	n_cct.ReversesCCTransactionId IS NULL
		AND n_cct.HasBeenReversed = 0
	JOIN	OpenCalculatedSectionResult ocsr
		ON	ocsr.RiskId = n_cct.RiskId
		AND	ocsr.OpenSectionPremiumTypeID = 56 -- Underwriting Fee
 
	-- STEP 8g: Broker Comission Underwriting Fee Transaction Item
	-----------------------------------------------------------------------------------------------
	INSERT INTO CCTransactionItem(
		CCTransactionId,
		CCCategoryTypeId,
		CCSubCategoryTypeId,
		CompanyId,
		Amount,
		CreatorUserId,
		CreatorCompanyId,
		CreationDate,
		LastUpdateUserId,
		LastUpdatedDate,
		Rate
	)
	SELECT
		n_cct.CCTransactionId,					-- CCTransactionId
		@BrokerCommission_CCCategoryTypeId,		-- CCCategoryTypeId
		@BrokerCommission_CCSubCategoryTypeId,	-- CCSubCategoryTypeId
		n_cct.BrokerCompanyId,					-- CompanyId
		0,										-- Amount (Broker Commission)
		@New_LogonUserId,						-- CreatorUserId
		@New_CompanyId,							-- CreatorCompanyId
		GETDATE(),								-- CreationDate
		@New_LogonUserId,						-- LastUpdateUserId
		GETDATE(),								-- LastUpdatedDate
		0										-- Rate (Broker Rate)
	FROM	@ContraTransactions ct
	JOIN	CCTransaction o_cct
		ON	o_cct.CCTransactionId = ct.CCTransactionId
	JOIN	CCTransaction n_cct
		ON	n_cct.RiskId = o_cct.RiskId
		AND	n_cct.CCTransactionId <> o_cct.CCTransactionId
		AND	n_cct.CCOpenPremiumTypeId = 3 -- Underwriting Fee
		AND	n_cct.ReversesCCTransactionId IS NULL
		AND n_cct.HasBeenReversed = 0
 
	-- STEP 8h: Wholesaler Comission Underwriting Fee Transaction Item
	-----------------------------------------------------------------------------------------------
	INSERT INTO CCTransactionItem(
		CCTransactionId,
		CCCategoryTypeId,
		CCSubCategoryTypeId,
		CompanyId,
		Amount,
		CreatorUserId,
		CreatorCompanyId,
		CreationDate,
		LastUpdateUserId,
		LastUpdatedDate,
		Rate
	)
	SELECT
		n_cct.CCTransactionId,						-- CCTransactionId
		@WholesalerCommission_CCCategoryTypeId,		-- CCCategoryTypeId
		@WholesalerCommission_CCSubCategoryTypeId,	-- CCSubCategoryTypeId
		n_cct.BrokerCompanyId,						-- CompanyId
		0 * 
		CASE WHEN o_cct.Amount >= 0 THEN 1 ELSE -1 END,
													-- Amount (Wholesaler Commission)
		@New_LogonUserId,							-- CreatorUserId
		@New_CompanyId,								-- CreatorCompanyId
		GETDATE(),									-- CreationDate
		@New_LogonUserId,							-- LastUpdateUserId
		GETDATE(),									-- LastUpdatedDate
		0											-- Rate (Wholesaler Rate)
	FROM	@ContraTransactions ct
	JOIN	CCTransaction o_cct
		ON	o_cct.CCTransactionId = ct.CCTransactionId
	JOIN	CCTransaction n_cct
		ON	n_cct.RiskId = o_cct.RiskId
		AND	n_cct.CCTransactionId <> o_cct.CCTransactionId
		AND	n_cct.CCOpenPremiumTypeId = 3 -- Underwriting Fee
		AND	n_cct.ReversesCCTransactionId IS NULL
		AND n_cct.HasBeenReversed = 0
 
	-----------------------------------------------------------------------------------------------
	-- STEP 9: Create the new CCExternalTransactionProcess to be picked up by Sun -----------------
	-----------------------------------------------------------------------------------------------
	SET @i = 1
	DECLARE @CountNew INT
	SELECT	@CountNew = COUNT(*) FROM @ContraTransactions
 
	WHILE @i <= @CountNew
	BEGIN
 
		DECLARE @New_CCTransactionId INT
 
		SELECT	@New_CCTransactionId = n_cct.CCTransactionId
		FROM	@ContraTransactions ct
		JOIN	CCTransaction o_cct
			ON	o_cct.CCTransactionId = ct.CCTransactionId
		JOIN	CCTransaction n_cct
			ON	n_cct.RiskId = o_cct.RiskId
			AND	n_cct.CCTransactionId <> o_cct.CCTransactionId
			AND	n_cct.CCOpenPremiumTypeId = 1 -- Main
			AND	n_cct.ReversesCCTransactionId IS NULL 
		WHERE	ct.i = @i
 
		IF (@New_CCTransactionId IS NOT NULL)
		BEGIN
			EXEC dbo.usp_open_acc_updTransactionStatus @New_CCTransactionId, 1, ''
		END
 
		SET @i = @i + 1
 
	END
 
	SET @i = 1
 
	WHILE @i <= @CountNew
	BEGIN
 
		DECLARE @NewUF_CCTransactionId INT
 
		SELECT	@NewUF_CCTransactionId = n_cct.CCTransactionId
		FROM	@ContraTransactions ct
		JOIN	CCTransaction o_cct
			ON	o_cct.CCTransactionId = ct.CCTransactionId
		JOIN	CCTransaction n_cct
			ON	n_cct.RiskId = o_cct.RiskId
			AND	n_cct.CCTransactionId <> o_cct.CCTransactionId
			AND	n_cct.CCOpenPremiumTypeId = 3 -- Underwriting Fee
			AND	n_cct.ReversesCCTransactionId IS NULL
			AND	n_cct.HasBeenReversed = 0
		WHERE	ct.i = @i
 
		IF (@NewUF_CCTransactionId IS NOT NULL)
		BEGIN
			EXEC dbo.usp_open_acc_updTransactionStatus @NewUF_CCTransactionId, 1, ''
		END
 
		SET @i = @i + 1
 
	END
 
	-----------------------------------------------------------------------------------------------
	-- STEP 10: Review transactions (TEST ONLY) ---------------------------------------------------
	-----------------------------------------------------------------------------------------------
	--SELECT	a_cct.*
	--FROM	@ContraTransactions ct
	--JOIN	CCTransaction o_cct
	--	ON	o_cct.CCTransactionId = ct.CCTransactionId
	--JOIN	CCTransaction a_cct
	--	ON	a_cct.RiskId = o_cct.RiskId
 
	--SELECT	ccti.*
	--FROM	@ContraTransactions ct
	--JOIN	CCTransaction o_cct
	--	ON	o_cct.CCTransactionId = ct.CCTransactionId
	--JOIN	CCTransaction a_cct
	--	ON	a_cct.RiskId = o_cct.RiskId
	--JOIN	CCTransactionItem ccti
	--	ON	ccti.CCTransactionId = a_cct.CCTransactionId
 
	--SELECT	ccetp.*
	--FROM	@ContraTransactions ct
	--JOIN	CCTransaction o_cct
	--	ON	o_cct.CCTransactionId = ct.CCTransactionId
	--JOIN	CCTransaction a_cct
	--	ON	a_cct.RiskId = o_cct.RiskId
	--JOIN	CCExternalTransactionProcess ccetp
	--	ON	ccetp.CCTransactionId = a_cct.CCTransactionId
 
	--SELECT	rsc.*
	--FROM	@ContraTransactions ct
	--JOIN	CCTransaction o_cct
	--	ON	o_cct.CCTransactionId = ct.CCTransactionId
	--JOIN	RiskSectionCommission rsc
	--	ON	rsc.RiskID = o_cct.RiskId
	--WHERE	rsc.OpenSectionPremiumTypeID = 56
 
END
IF @@ERROR > 0
BEGIN
	PRINT 'ERROR: An error has occured. Performing ROLLBACK.'
	ROLLBACK 
END
ELSE
BEGIN



--UPDATE @TransactionIDs SET Processed = 1 WHERE TransactionId = 508685 -- Will prevent duplication too

	PRINT 'SUCCESS: The script was successful. Performing COMMIT.'
	
	
	
	ROLLBACK 
END
 
SET NOCOUNT OFF