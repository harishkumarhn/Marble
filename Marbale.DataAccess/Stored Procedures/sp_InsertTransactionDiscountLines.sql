USE [Marbale]
GO

/****** Object:  StoredProcedure [dbo].[sp_InsertTransactionDiscountLines]    Script Date: 28/09/2019 12:14:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- DROP PROC sp_InsertTransactionDiscountLines
-- ============================================= 
-- Author:    @Author,,Name 
-- Create date: @Create Date,, 
-- Description:  @Description,, 
-- ============================================= 
CREATE PROCEDURE [dbo].[sp_InsertTransactionDiscountLines] 
												@TrxId INT,
												@LineId INT,
												@DiscountId INT, 
												@DiscountAmount numeric (18, 4),
												@DiscountPercentage numeric (18, 4),
												@Remarks NVARCHAR(200),
												@ApprovedBy INT = 0
AS 
  BEGIN 
      -- SET NOCOUNT ON added to prevent extra result sets from 
      -- interfering with SELECT statements. 

            -- Insert statements for procedure here 
            INSERT INTO [dbo].[TransactionDiscountLines]
                        (
							[TrxId],
							[LineId],
							[DiscountId],
							[DiscountAmount],
							[DiscountPercentage],
							[Remarks],
							[ApprovedBy] 

						 ) 

            VALUES      (
					        @TrxId,
							@LineId, 
							@DiscountId, 
							@DiscountAmount,
							@DiscountPercentage, 
							@Remarks, 
							@ApprovedBy
						 ) 
        END 



GO


