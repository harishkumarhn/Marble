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
CREATE PROCEDURE dbo.sp_InsertTransactionTaxLines 
												@TrxId INT,
												@LineId INT,
												@TaxId INT, 
												@TaxStructureId INT,
												@Percentage numeric (18, 4),
												@Amount numeric (9, 4),
												@ProductSplitAmount numeric (9, 4) = 0
AS 
  BEGIN 
      -- SET NOCOUNT ON added to prevent extra result sets from 
      -- interfering with SELECT statements. 

            -- Insert statements for procedure here 
            INSERT INTO [dbo].[TransactionTaxLines]
                        (
							[TrxId],
							[LineId],
							[TaxId],
							[TaxStructureId],
							[Percentage],
							[Amount],
							[ProductSplitAmount] 

						 ) 

            VALUES      (
					        @TrxId,
							@LineId, 
							@TaxId, 
							@TaxStructureId,
							@Percentage, 
							@Amount, 
							@ProductSplitAmount
						 ) 
        END 


go 

