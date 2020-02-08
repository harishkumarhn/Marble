USE marbale 

go 

/****** Object:  StoredProcedure dbo.sp_InsertOrUpdateGame    Script Date: 6/22/2019 10:07:54 PM ******/
SET ansi_nulls ON 

go 

SET quoted_identifier ON 

go 

-- DROP PROC sp_InsertOrUpdateTrxLines
-- ============================================= 
-- Author:    @Author,,Name 
-- Create date: @Create Date,, 
-- Description:  @Description,, 
-- ============================================= 
CREATE PROCEDURE dbo.sp_InsertOrUpdateTrxLines @TrxId INT,
												@LineId INT, 
												@ProductId INT, 
												@Price decimal(10,4),
												@Quantity decimal(10,0), 
												@Amount decimal(10,4), 
												@CardId INT, 
												@CardNumber NVARCHAR(20),
												@Credits decimal(10,4), 
												@Courtesy decimal(10,4), 
												@TaxPercentage decimal(10,4),
												@TaxId INT,
												@Time decimal(10,4),
												@Bonus  decimal(10,4),
												@Tickets decimal(10,4),
												@LoyaltyPoints decimal(10,4),
												@Remarks NVARCHAR(250),
												@PromotionId INT,
												@ReceiptPrinted BIT = 0,
												@ParentLineId INT,
												@UserPrice BIT = 0,
												@GameplayId INT,
												@CancelledTime datetime = NULL,
												@CancelledBy NVARCHAR(50) = NULL,
												@ProductDescription NVARCHAR(255),
												@OriginalLineID INT
												
AS 
  BEGIN 
      -- SET NOCOUNT ON added to prevent extra result sets from 
      -- interfering with SELECT statements. 

            -- Insert statements for procedure here 
            INSERT INTO [dbo].[TransactionLines]
                        (
							[TrxId],
							[LineId], 
							[ProductId], 
							[Price],
							[Quantity], 
							[Amount], 
							[CardId], 
							[CardNumber],
							[Credits], 
							[Courtesy], 
							[TaxPercentage],
							[TaxId],
							[Time],
							[Bonus],
							[Tickets],
							[LoyaltyPoints],
							[Guid],
							[Remarks],
							[PromotionId],
							[ReceiptPrinted],
							[ParentLineId],
							[UserPrice],
							[GameplayId],
							[CancelledTime],
							[CancelledBy],
							[ProductDescription],
							[OriginalLineID],
							[IsLineCancelled]

						 ) 

            VALUES      (
					        @TrxId,
							@LineId, 
							@ProductId, 
							@Price,
							@Quantity, 
							@Amount, 
							@CardId, 
							@CardNumber,
							@Credits, 
							@Courtesy, 
							@TaxPercentage,
							@TaxId,
							@Time,
							@Bonus,
							@Tickets,
							@LoyaltyPoints,
							NEWID(),
							@Remarks,
							@PromotionId,
							@ReceiptPrinted,
							@ParentLineId,
							@UserPrice,
							@GameplayId,
							@CancelledTime,
							@CancelledBy,
							@ProductDescription,
							@OriginalLineID,
							0
						 ) 
        END 


go 

