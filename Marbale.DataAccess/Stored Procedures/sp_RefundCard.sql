USE [Marbale]
GO
/****** Object:  StoredProcedure [dbo].[sp_RefundCard]    Script Date: 3/24/2019 5:13:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- DROP PROC sp_RefundCard
GO

CREATE proc [dbo].[sp_RefundCard]  
(    
   @card_id INT,
   @refund_amount decimal(18,4),
   @credits INT,
   @faceValue INT,
   @valid BIT,   
   @LastUpdatedBy NVARCHAR(20) = NULL
  
)
AS BEGIN   

      UPDATE card 
				SET RefundAmount = ISNULL(RefundAmount, 0) + @refund_amount, 
                    credits = credits - @credits, 
                    FaceValue = FaceValue - @faceValue, 
                    LastUpdated = GETDATE(),
				    LastUpdatedBy = @LastUpdatedBy, 
                    RefundDate = case @valid when 1 then RefundDate else GETDATE() end, 
                    RefundFlag = case @valid when 0 then RefundFlag else 0 end, 
                    ValidFlag = @valid 
      WHERE CardId = @card_id
				
END


