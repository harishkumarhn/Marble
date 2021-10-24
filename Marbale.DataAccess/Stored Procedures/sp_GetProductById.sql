USE [Marbale]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetProductById]    Script Date: 10/9/2021 11:53:08 PM 
Modified: Vijeth 10/10/2021
******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- DROP PROC sp_GetProductById

ALTER PROCEDURE [dbo].[sp_GetProductById]     
 @id int    
AS    
BEGIN    
 -- SET NOCOUNT ON added to prevent extra result sets from    
 -- interfering with SELECT statements.    
 SET NOCOUNT ON;    
  declare @expiredate datetime  
  declare @withoutExpireDate datetime 
  declare @cardvalidFor int
  declare @startDate datetime
  select @cardvalidFor= DefaultValue  from Settings where name ='CARD_VALIDITY'
  select @expiredate = ExpiryDate from Product where id=@id
  select @startDate = startDate from Product where id=@id
  select @withoutExpireDate =DATEADD(DAY,@cardvalidFor,@startDate)  
 
 SELECT     
 Courtesy,  
 p.Id ,Name ,PT.Id as Type ,POSCounter, P.Active, DisplayInPOS ,DG.Id as DisplayGroupId ,Category ,
 AutoGenerateCardNumber ,OnlyVIP, Price, FaceValue, TaxInclusive, T.TaxPercent TaxPercentage, FinalPrice, EffectivePrice,    
  P.LastUpdatedBy, P.LastUpdatedDate, Bonus,T.TaxName, StartDate as 'StartDate', Games ,    
  CreditsPlus, Credits ,CardValidFor,case when isnull(@expiredate,'') ='' then @withoutExpireDate else ExpiryDate end as 'ExpiryDate',
  --ExpiryDate 'ExpiryDate'    
    T.TaxId,p.TicketAllowed,
		p.Tickets,
		p.AllowPriceOverride,
		p.ManagerApprovalRequired,
		p.TrxHeaderRemarksMandatory,
		p.TrxLineRemarksMandatory,
		p.QuantityPrompt,
		p.MinimumQuantity,
		P.DisplayOrder,
		P.CardExpiryDate,
		P.MaximumQuantity,
		P.HSNSACCode,
		P.vipCard,
		P.LineRemarksMandatory,
		P.InvokeCustomerRegistration,
		PT.Type as TypeName,
		p.Time,
		p.discount,
		p.Description,
		p.InventoryProductCode
  from Product P
  JOIN Tax T ON T.TaxId = (case when p.TaxId > 0 then p.TaxId else 8 end)
  LEFT JOIN ProductType PT on P.Type = PT.Id
  LEFT JOIN DisplayGroup DG on P.DisplayGroupId = DG.Id
  where P.Id = @id    
END 




