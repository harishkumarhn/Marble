USE [Marbale]
GO

/****** Object:  StoredProcedure [dbo].[[sp_ReverseTransaction]]    Script Date: 03/08/2019 12:26:45 ******/
DROP PROCEDURE [dbo].[sp_ReverseTransaction]
GO

/****** Object:  StoredProcedure [dbo].[[sp_ReverseTransaction]]    Script Date: 03/08/2019 12:26:45 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- EXEC [sp_ReverseTransaction]
-- =============================================
-- Author:		Amaresh
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_ReverseTransaction]
(
	@RevereseTrxId INT = 0,
	@POSMachineId INT = 0,
	@LoginName NVARCHAR(100) = NULL,
	@trxId INT OUT
)
AS
BEGIN

	INSERT INTO 
			TransactionHeader
				( 
				TrxDate, 
				TrxAmount, 
				TrxDiscountPercentage, 
				TaxAmount, 
				TrxNetAmount, 
				POSMachine, 
				UserId, 
				PaymentMode, 
				CashAmount, 
				CreditCardAmount,
				GameCardAmount, 
				PaymentReference, 
				PrimaryCardId,
				OrderId, 
				POSTypeId, 
				SiteId,
				TrxNummber,
				Remarks, 
				POSMachineId, 
				SynchStatus, 
				OtherPaymentModeAmount,
				Status, 
				TrxProfileId, 
				LastUpdateTime, 
				LastUpdatedBy,
				TokenNumber, 
				Original_System_Reference, 
				CustomerId, 
				ExternalSystemReference, 
				ReprintCount,
				OriginalTrxID, 
				MasterEntityId 
			)

	SELECT 
				GETDATE(), 
				TrxAmount * -1, 
				TrxDiscountPercentage, 
				TaxAmount  * -1, 
				TrxNetAmount  * -1, 
				POSMachine, 
				UserId, 
				PaymentMode, 
				CashAmount  * -1, 
				CreditCardAmount  * -1,
				GameCardAmount  * -1, 
				PaymentReference, 
				PrimaryCardId,
				OrderId, 
				POSTypeId, 
				SiteId,
				TrxNummber,
				Remarks, 
				@POSMachineId, 
				SynchStatus, 
				OtherPaymentModeAmount  * -1,
				Status, 
				TrxProfileId, 
				LastUpdateTime, 
				LastUpdatedBy,
				TokenNumber, 
				'Reversal Transaction for TrxId ' + CONVERT(varchar(100),@RevereseTrxId), 
				CustomerId, 
				ExternalSystemReference, 
				ReprintCount,
				@RevereseTrxId, 
				MasterEntityId 
			
				FROM 
						TransactionHeader 
				WHERE 
						TrxId = @RevereseTrxId

	     SET @trxId = (SELECT SCOPE_IDENTITY())

	UPDATE 
			TransactionHeader
			SET Status = 'CANCELLED'
	WHERE 
			TrxId = @RevereseTrxId
			AND
			status in ('OPEN', 'CANCELLED')
  
    
	INSERT INTO 
		TransactionLines
		(
			TrxId, 
			LineId, 
			ProductId, 
			Price, 
			Quantity, 
			Amount, 
			CardId, 
			CardNumber, 
			Credits, 
			Courtesy, 
			TaxPercentage, 
			TaxId, 
			Time, 
			Bonus, 
			Tickets, 
			LoyaltyPoints, 
			SiteId, 
			Remarks, 
			PromotionId, 
			ReceiptPrinted, 
			ParentLineId, 
			UserPrice, 
			KOTPrintCount, 
			GameplayId, 
			KDSSent, 
			CreditPlusConsumptionId, 
			CancelledTime, 
			CancelledBy, 
			ProductDescription, 
			IsWaiverSignRequired,
			OriginalLineID, 
			MasterEntityId
		)

		SELECT 
			TrxId, 
			LineId, 
			ProductId, 
			Price * -1, 
			Quantity, 
			Amount * -1, 
			CardId, 
			CardNumber, 
			Credits * -1, 
			Courtesy * -1, 
			TaxPercentage, 
			TaxId, 
			Time * -1, 
			Bonus * -1, 
			Tickets * -1, 
			LoyaltyPoints * -1, 
			SiteId, 
			Remarks, 
			PromotionId, 
			ReceiptPrinted, 
			ParentLineId, 
			UserPrice * -1, 
			KOTPrintCount, 
			GameplayId, 
			KDSSent, 
			CreditPlusConsumptionId, 
			GETDATE(), 
			@loginName, 
			ProductDescription, 
			IsWaiverSignRequired,
			@RevereseTrxId, 
			MasterEntityId
		FROM 
				TransactionLines
			WHERE 
				TrxId = @RevereseTrxId
			 
	INSERT INTO 
			 TransactionTaxLines
			 (
				TrxId, 
				LineId, 
				TaxId, 
				TaxStructureId, 
				Percentage, 
				Amount, 
				ProductSplitAmount
			 )
	 SELECT 
				TrxId, 
				LineId, 
				TaxId, 
				TaxStructureId, 
				Percentage, 
				Amount * -1, 
				ProductSplitAmount

	 FROM
			TransactionTaxLines
	 WHERE
			TrxId = @RevereseTrxId


	INSERT INTO 
			TransactionDiscountLines
			(
				TrxId, 
				LineId, 
				DiscountId, 
				DiscountPercentage, 
				DiscountAmount, 
				Remarks, 
				ApprovedBy
			)
		SELECT 
				TrxId, 
				LineId, 
				DiscountId, 
				DiscountPercentage, 
				DiscountAmount * -1, 
				Remarks, 
				ApprovedBy

		FROM 
			TransactionDiscountLines
		WHERE
			TrxId = @RevereseTrxId
			
END

GO


--select * from TransactionDiscountLines