USE [Marbale]
GO
/****** Object:  StoredProcedure [dbo].[sp_ConsolidateCards]    Script Date: 3/24/2019 5:13:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--DROP PROC sp_ConsolidateCards
GO

CREATE proc [dbo].[sp_ConsolidateCards]  
(
   @toCardId INT,
   @credits Numeric(18,5) = 0,
   @courtesy Numeric(18,5) = 0,
   @bonus Numeric(18,5) = 0,
   @ticket_count INT = 0,
   @lastUpdatedBy NVARCHAR(20) = NULL
)
AS BEGIN   

        UPDATE Card 
				SET  credits = @credits,
				courtesy = @courtesy,
				bonus = @bonus,
				TicketCount = @ticket_count,
				LastUpdated = GETDATE(),
				LastUpdatedBy = @LastUpdatedBy
			    WHERE CardId = @toCardId
				
END


