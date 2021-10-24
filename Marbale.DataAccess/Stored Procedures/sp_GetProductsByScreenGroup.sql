use marbale 
/****** Object:  StoredProcedure [dbo].[sp_GetProductsByScreenGroup]    Script Date: 10/10/2021 5:19:37 AM ******/
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
ALTER PROCEDURE [dbo].[sp_GetProductsByScreenGroup] 
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
 p.Id ,Name  ,POSCounter, P.Active, DisplayInPOS, P.Type, DG.Id DisplayGroupId ,DG.DisplayGroup DisplayGroup ,Category ,
 AutoGenerateCardNumber ,OnlyVIP, Price, FaceValue, TaxInclusive, TaxPercentage, FinalPrice, EffectivePrice,    
  P.LastUpdatedBy, P.LastUpdatedDate, Bonus ,TaxName, StartDate as 'StartDate', Games ,    
  CreditsPlus, Credits ,CardValidFor   
  from Product P

  LEFT JOIN DisplayGroup DG on P.DisplayGroupId = DG.Id 
 
	  where @displayGroupId = 0 OR dg.Id = @displayGroupId
	 ORDER BY DG.sortorder,p.DisplayOrder
END
