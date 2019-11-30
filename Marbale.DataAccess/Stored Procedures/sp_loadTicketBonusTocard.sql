USE [Marbale]
GO
/****** Object:  StoredProcedure [dbo].[sp_loadTicketBonusTocard]    Script Date: 06/07/2019 23:41:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ============================================= 
-- Author:    @Author,,Name 
-- Create date: @Create Date,, 
-- Description:  @Description,, 
-- ============================================= 
CREATE PROCEDURE [dbo].[sp_loadTicketBonusTocard]  
											   @cardId            INT,
                                               @bonus             INT = 0,
											   @ticket			  INT = 0,
											   @lastupdatedBy NVARCHAR(255) = NULL
AS 
  BEGIN 
      -- SET NOCOUNT ON added to prevent extra result sets from 
      -- interfering with SELECT statements. 
      SET nocount ON; 

					UPDATE card
					SET 
						TicketCount  = ISNULL(TicketCount,0) + @ticket,
						bonus = ISNULL(bonus,0) + @bonus,
						LastUpdatedBy = @lastupdatedBy,
						LastUpdated = GETDATE()
					WHERE 
						CardId = @cardId 

  END 

