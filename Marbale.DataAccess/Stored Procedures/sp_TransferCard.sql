USE [Marbale]
GO
/****** Object:  StoredProcedure [dbo].[sp_Transfercard]    Script Date: 3/24/2019 5:13:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

DROP PROC sp_TransferCard
GO

CREATE proc [dbo].[sp_TransferCard]  
(
   @fromCardId INT,      
   @toCardId INT,
   @LastUpdatedBy NVARCHAR(20) = NULL
)
AS BEGIN   

        UPDATE TransactionLines 
			   SET CardId = @toCardId, 
			   CardNumber = (select CardNumber from Card WHERE CardId = @toCardId) 
               WHERE CardId = @fromCardId


	    UPDATE TransactionHeader 
			   SET PrimaryCardId = @toCardId
               WHERE PrimaryCardId = @fromCardId

        UPDATE Card 
				SET  ValidFlag = 0,
				LastUpdated = GETDATE(),
				LastUpdatedBy = @LastUpdatedBy
			    WHERE CardId = @fromCardId
				
END


