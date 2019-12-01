  
-- DROP PROC sp_GetProductById  
  
alter PROCEDURE [dbo].[sp_GetProductById]       
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
 p.Id ,Name ,PT.Type ,POSCounter, P.Active, DisplayInPOS ,DG.DisplayGroupId ,Category ,  
 AutoGenerateCardNumber ,OnlyVIP, Price, FaceValue, TaxInclusive, T.TaxPercent TaxPercentage, FinalPrice, EffectivePrice,      
  P.LastUpdatedBy, P.LastUpdatedDate, Bonus, LastUpdatedUser ,P.TaxName, StartDate as 'StartDate', Games ,      
  CreditsPlus, Credits ,CardValidFor,case when isnull(@expiredate,'') ='' then @withoutExpireDate else ExpiryDate end as 'ExpiryDate',  
  --ExpiryDate 'ExpiryDate'      
    T.TaxId  
  from Product P  
  LEFT JOIN Tax T ON T.TaxId = p.TaxName 
  LEFT JOIN ProductType PT on P.Type = PT.Id  
  LEFT JOIN DisplayGroup DG on P.DisplayGroupId = DG.DisplayGroupId  
  where P.Id = @id      
END   
  
  
  
  