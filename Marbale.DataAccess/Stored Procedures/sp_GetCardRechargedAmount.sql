USE [Marbale]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetCardRechargedAmount]    Script Date: 1/19/2019 6:58:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- DROP PROCEDURE sp_GetCardRechargedAmount
Create proc [dbo].[sp_GetCardRechargedAmount] 
(
	@cardId INT
)
as 
begin 


		SELECT SUM(Amount) 
				FROM TransactionLines
		WHERE
		CardId = @cardId
end

