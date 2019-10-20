USE [Marbale]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetCard]    Script Date: 1/19/2019 6:58:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- DROP PROCEDURE sp_GetCard
Create proc [dbo].[sp_GetCard] 
(
@cardId INT = NULL,
@cardNumber NVARCHAR(50) = NULL
)
as 
begin 

SELECT
	*
		FROM 
		Card

	WHERE 
		(@cardId IS NULL OR CardId = @cardId)
	AND
		(@cardNumber IS NULL OR CardNumber = LTRIM(RTRIM(@cardNumber)))
end

