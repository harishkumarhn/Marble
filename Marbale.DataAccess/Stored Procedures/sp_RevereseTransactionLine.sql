USE [Marbale]
GO

/****** Object:  StoredProcedure [dbo].[sp_ReverseTransactionLine]]   Script Date: 03/08/2019 12:26:45 ******/
-- DROP PROCEDURE [dbo].[sp_ReverseTransactionLine]
GO

/****** Object:  StoredProcedure [dbo].[sp_ReverseTransactionLine]    Script Date: 03/08/2019 12:26:45 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- EXEC [sp_ReverseTransactionLine]
-- =============================================
-- Author:		Amaresh
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_ReverseTransactionLine]
(
	@oldTrxid INT = NULL,
	@lineId INT = -1,
	@userId INT = 0,
	@loginId NVARCHAR = NULL,
	@pos_machineId INT = 0,
	@pos_machine NVARCHAR = NULL,
	@reference  NVARCHAR = NULL,
	@reversedTrxId INT OUT
)
AS
BEGIN

	INSERT 
		INTO TransactionHeader
			(
				TrxDate, 
				TrxNummber, 
				TrxAmount,
				TrxDiscountPercentage,
			    TaxAmount, 
				TrxNetAmount, 
				POSMachine, 
				POSMachineId,
				UserId, 
				PaymentMode, 
				CashAmount, 
				CreditCardAmount,
				GameCardAmount,
				OtherPaymentModeAmount,
				POSTypeId,
				PaymentReference,
				Status, 
				LastUpdateTime, 
				LastUpdatedBy,
				OriginalTrxID
			)
		SELECT 
				GETDATE()
				,TrxNummber
				,sum([Amount] * -1)
				,sum(Amount * isnull(d.discountPercentage, 0)) / case when sum([Amount]) = 0 then null else sum(amount) end * 100.0
				,sum(isnull(TaxPercentage/100.0, 0) * Price * Quantity * -1)  
				,sum(Amount * (1 - isnull(d.discountPercentage, 0)) * -1)  
				,isnull(@pos_machine, POSMachine)  
				,isnull(@pos_machineId, POSMachineId) 
				,@userId 
				,PaymentMode  
				,sum(isnull((case when [CashAmount] = 0 then null else [CashAmount] end * Amount * (1 - isnull(d.discountPercentage, 0)) * -1) / TrxNetAmount, 0))  
				,sum(isnull((case when [CreditCardAmount] = 0 then null else [CreditCardAmount] end * Amount * (1 - isnull(d.discountPercentage, 0)) * -1) / TrxNetAmount, 0))  
				,sum(isnull((case when [GameCardAmount] = 0 then null else [GameCardAmount] end * Amount * (1 - isnull(d.discountPercentage, 0)) * -1) / TrxNetAmount, 0))  
				,sum(isnull((case when [OtherPaymentModeAmount] = 0 then null else [OtherPaymentModeAmount] end * Amount * (1 - isnull(d.discountPercentage, 0)) * -1) / TrxNetAmount, 0))                        
				,POSTypeId  
				,@reference  
				,Status, 
				getdate(), 
				@loginId,
				@oldTrxid 
			
				FROM 
					TransactionHeader h, TransactionLines L LEFT JOIN
						(SELECT lineid, 
								isnull(sum(discountPercentage), 0)/100.0 discountPercentage
																FROM TransactionDiscountLines
																WHERE trxId = @oldTrxid GROUP BY lineid) 
					d ON d.lineId = l.lineId  
				WHERE 
						h.trxid = @oldTrxid  
				AND 
						h.trxid = l.trxid  
				AND 
						(l.lineId = @lineId OR CardId in (SELECT CardId  
																FROM TransactionLines l1, Product p, ProductType pt  
																							WHERE l1.trxid = @oldTrxid  
																							AND l1.lineId = @lineId  
																							AND p.Id = l1.ProductId  
																							AND p.Type = pt.Id  
																							AND pt.Type in ('NEW', 'CARDDEPOSIT'))
						)  
				GROUP BY 
				d.discountPercentage,
				POSMachine ,
				POSMachineId,  
				POSTypeId,
				Status,
				TrxNummber,
				PaymentMode
																						  
		SET @reversedTrxId = (SELECT SCOPE_IDENTITY())

	UPDATE 
			TransactionHeader
			SET Status = 'CANCELLED'
	WHERE 
			TrxId = @oldTrxid
			--AND
			--status in ('OPEN', 'CANCELLED')

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
			MasterEntityId,
			IsLineCancelled
		)

		SELECT 
			@reversedTrxId, 
			LineId, 
			ProductId, 
			Price, 
			Quantity * -1, 
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
			@loginId, 
			ProductDescription, 
			IsWaiverSignRequired,
			@lineId, 
			MasterEntityId,
			1
		FROM 
				TransactionLines
		WHERE 
				TrxId = @oldTrxid
		AND 
				LineId = @lineId

	UPDATE 
			TransactionLines
			SET IsLineCancelled = 1
	WHERE
			TrxId = @oldTrxid
		AND 
			LineId = @lineId

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
			TrxId = @oldTrxid
	 AND 
		    LineId = @lineId

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
				@reversedTrxId, 
				LineId, 
				DiscountId, 
				DiscountPercentage, 
				DiscountAmount * -1, 
				Remarks, 
				ApprovedBy
		FROM 
			TransactionDiscountLines
		WHERE
			TrxId = @oldTrxid
			
END

GO


--select * from TransactionDiscountLines