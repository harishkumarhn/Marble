USE [Marbale]
GO

/****** Object:  StoredProcedure [dbo].[sp_GetProductsByScreenGroup]    Script Date: 2/16/2019 3:24:29 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- EXEC sp_GetProductsByScreenGroup
 -- DROP PROC [sp_GetProductsByScreenGroup]
-- =============================================
-- Author:		Harish
-- Create date: <Create Date,,>
-- Description:	get products by screen
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetProductsByScreenGroup] 
	-- Add the parameters for the stored procedure here
	@displayGroupId INT = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	 SELECT     
 Courtesy,  
 p.Id ,Name  ,POSCounter, P.Active, DisplayInPOS, P.Type, DG.DisplayGroup ,Category ,
 AutoGenerateCardNumber ,OnlyVIP, Price, FaceValue, TaxInclusive, TaxPercentage, FinalPrice, EffectivePrice,    
  P.LastUpdatedBy, P.LastUpdatedDate, Bonus, LastUpdatedUser ,TaxName, StartDate as 'StartDate', Games ,    
  CreditsPlus, Credits ,CardValidFor   
  from Product P

  LEFT JOIN DisplayGroup DG on P.DisplayGroupId = DG.DisplayGroupId 
 
	  where @displayGroupId = 0 OR dg.DisplayGroupId = @displayGroupId
	 ORDER BY DG.sortorder
END
GO


