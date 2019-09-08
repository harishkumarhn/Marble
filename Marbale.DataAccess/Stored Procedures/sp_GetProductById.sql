USE [Marbale]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetProductById]    Script Date: 8/15/2019 1:19:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- DROP PROC sp_GetProductById

CREATE PROCEDURE [dbo].[sp_GetProductById]     
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
 p.Id ,Name ,PT.Type ,POSCounter, P.Active, DisplayInPOS ,DisplayGroup ,Category ,
 AutoGenerateCardNumber ,OnlyVIP, Price, FaceValue, TaxInclusive, TaxPercentage, FinalPrice, EffectivePrice,    
  P.LastUpdatedBy, P.LastUpdatedDate, Bonus, LastUpdatedUser ,TaxName, StartDate as 'StartDate', Games ,    
  CreditsPlus, Credits ,CardValidFor,case when isnull(@expiredate,'') ='' then @withoutExpireDate else ExpiryDate end as 'ExpiryDate',
  --ExpiryDate 'ExpiryDate'    
    TaxId
  from Product P
  LEFT JOIN ProductType PT on P.Type = PT.Id
   

  where P.Id = @id    
END 




