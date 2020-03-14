USE [Marbale]
GO
/****** Object:  StoredProcedure [dbo].[sp_get_new_recharge_product]    Script Date: 1/4/2020 8:51:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- DROP PROC sp_get_new_recharge_product 
-- EXEC sp_get_new_recharge_product

ALTER PROCEDURE [dbo].[sp_get_new_recharge_product]     
 
AS    
BEGIN    
 -- SET NOCOUNT ON added to prevent extra result sets from    
 -- interfering with SELECT statements.    
 SET NOCOUNT ON;    
 

 SELECT       
			 p.Id ,Name ,PT.Type ,POSCounter, P.Active, 
			 Courtesy, DisplayInPOS ,DG.DisplayGroupId ,Category ,
			 AutoGenerateCardNumber ,OnlyVIP, Price, FaceValue, 
			 TaxInclusive, T.TaxPercent TaxPercentage, FinalPrice, 
			 EffectivePrice, P.LastUpdatedBy, P.LastUpdatedDate, Bonus, 
			 T.TaxName, StartDate as 'StartDate', Games ,    
			 CreditsPlus, Credits ,CardValidFor, ExpiryDate,
		     T.TaxId,p.TicketAllowed,
			 p.Tickets,
			 p.AllowPriceOverride,
			 p.ManagerApprovalRequired,
			 p.TrxHeaderRemarksMandatory,
			 p.TrxLineRemarksMandatory,
			 p.QuantityPrompt,
			 p.MinimumQuantity,
			 PT.Type as TypeName,
			p.Time		
		FROM Product P
  JOIN Tax T ON T.TaxId = p.TaxId
  LEFT JOIN ProductType PT on P.Type = PT.Id
  LEFT JOIN DisplayGroup DG on P.DisplayGroupId = DG.DisplayGroupId
 -- where PT.Type in ('NEW', 'RECHARGE') 
END 




