USE marbale 

go 

/****** Object:  StoredProcedure dbo.sp_InsertOrUpdateGame    Script Date: 6/22/2019 10:07:54 PM ******/
SET ansi_nulls ON 

go 

SET quoted_identifier ON 

go 

-- DROP PROC sp_InsertOrUpdateTrxHeader
-- ============================================= 
-- Author:    @Author,,Name 
-- Create date: @Create Date,, 
-- Description:  @Description,, 
-- ============================================= 
CREATE PROCEDURE dbo.sp_InsertOrUpdateTrxHeader @trxId  INT, 
                                                @TrxDate DATE,
												@TrxAmount NUMERIC(10,4), 
												@TrxDiscountPercentage NUMERIC(4,4),
												@TaxAmount  NUMERIC(10,4),  
												@TrxNetAmount  NUMERIC(10,4), 
												@POSMachine NVARCHAR(50) = NULL,
												@UserId INT,
												@PaymentMode INT, 
												@CashAmount NUMERIC(10,4), 
												@CreditCardAmount NUMERIC(10,4),  
												@GameCardAmount NUMERIC(10,4),
												@PaymentReference  NVARCHAR(50),
												@PrimaryCardId INT,
												@OrderId INT,
												@POSTypeId INT,
												@TrxNummber NVARCHAR(50),
												@Remarks NVARCHAR(50),
												@POSMachineId INT,
												@OtherPaymentModeAmount NUMERIC(10,4),
												@Status NVARCHAR(50),
												@TrxProfileId INT,
												@LastUpdateTime DATETIME,
												@LastUpdatedBy NVARCHAR(50),
												@TokenNumber INT = 0,
												@Original_System_Reference NVARCHAR(50) = NULL,
												@CustomerId INT = NULL,
												@ExternalSystemReference  NVARCHAR(50) = NULL,
												@OriginalTrxID INT,
												@txId INT OUT
AS 
  BEGIN 
      -- SET NOCOUNT ON added to prevent extra result sets from 
      -- interfering with SELECT statements. 
      SET nocount ON; 

      IF NOT EXISTS (SELECT TrxId 
                 FROM   TransactionHeader WITH (updlock, serializable) 
                 WHERE  TrxId = @trxId) 
            BEGIN
            -- Insert statements for procedure here 
            INSERT INTO [dbo].[TransactionHeader] 
                        (
						 [TrxDate],
						 [TrxAmount], 
						 [TrxDiscountPercentage],
						 [TaxAmount], 
						 [TrxNetAmount], 
						 [POSMachine], 
						 [UserId],
						 [PaymentMode], 
						 [CashAmount], 
						 [CreditCardAmount], 
						 [GameCardAmount],
						 [PaymentReference],
						 [PrimaryCardId],
						 [OrderId],
						 [POSTypeId],
						 [Guid],						 
						 [TrxNummber],
						 [Remarks],
						 [POSMachineId],
						 [OtherPaymentModeAmount],
						 [Status],
						 [TrxProfileId],
						 [LastUpdateTime],
						 [LastUpdatedBy],
						 [TokenNumber],
						 [Original_System_Reference],
						 [CustomerId],
						 [ExternalSystemReference],
						 [OriginalTrxID]
						 ) 

            VALUES      (
					     @TrxDate,
						 @TrxAmount, 
						 @TrxDiscountPercentage,
						 @TaxAmount, 
						 @TrxNetAmount, 
						 @POSMachine, 
						 @UserId,
						 @PaymentMode, 
						 @CashAmount, 
						 @CreditCardAmount, 
						 @GameCardAmount,
						 @PaymentReference,
						 @PrimaryCardId,
						 @OrderId,
						 @POSTypeId,
						 NEWID(),
						 @TrxNummber,
						 @Remarks,
						 @POSMachineId,
						 @OtherPaymentModeAmount,
						 @Status,
						 @TrxProfileId,
						 @LastUpdateTime,
						 @LastUpdatedBy,
						 @TokenNumber,
						 @Original_System_Reference,
						 @CustomerId,
						 @ExternalSystemReference,
						 @OriginalTrxID
						 ) 
						 SET @txId = (select SCOPE_IDENTITY())

			SELECT @txId;
        END 

  END 

go 

