        
-- =============================================        
-- Author:  Harish   Modified:Shridhar     
-- =============================================        
        
CREATE PROCEDURE [dbo].[sp_InsertOrUpdateProduct]        
@name varchar(150),        
@type varchar(50) = null,        
@active bit=null,        
@price decimal(18,3)=null,        
@effectivePrice decimal(18,3)=null,        
@finalPrice decimal(18,3)=null,      
@faceValue decimal(18,3)=null,        
@displayGroup varchar(50)=null,        
@displayInPOS bit=null,        
@autoGenerateCardNumber bit=null,        
@category varchar(50)=null,        
@onlyVIP bit=null,        
@posCounter varchar(50)=null,        
@taxInclusive bit=null,        
@taxPercentage decimal(18,3)=null,        
@id int=null  ,      
@Bonus decimal(18,3) =null,      
@LastUpdatedUser varchar(max)=null,      
@TaxName varchar(max)=null,      
@StartDate datetime=null,      
@LastUpdatedDate datetime=null,      
@Games decimal(18,3)=null,      
@CreditsPlus decimal(18,3)=null,      
@Credits decimal(18,3)=null,      
@CardValidFor int=null  ,    
@Courtesy bigint=null   ,
@ExpiryDate datetime =null,
@taxId int = 0
AS        
BEGIN        
 -- SET NOCOUNT ON added to prevent extra result sets from        
 -- interfering with SELECT statements.        
 SET NOCOUNT ON;        
 declare @TotalDays int declare @expire datetime      
  select @TotalDays= Defaultvalue from Settings where name ='CARD_VALIDITY'      
  select @expire=   DATEADD(day, @TotalDays, getdate())       
      
if not exists (select id from Product with (updlock,serializable) where Id = @id)        
begin        
insert into Product(        
[Name],        
[Type],        
Active,        
Price,        
EffectivePrice,        
FaceValue,        
DisplayGroup,        
DisplayInPOS,        
AutoGenerateCardNumber,        
Category,        
OnlyVIP,        
POSCounter,        
TaxInclusive,        
TaxPercentage,      
Bonus,      
LastUpdatedUser,TaxName,LastUpdatedDate,Games,CreditsPlus,Credits,CardValidFor,Courtesy,  
finalprice    ,
ExpiryDate ,StartDate,TaxId
      
      
)         
Values(@name,@type,@active,@price,@effectivePrice,@faceValue,@displayGroup,@displayInPOS,        
@autoGenerateCardNumber,@category,@onlyVIP,@posCounter,@taxInclusive,@taxPercentage,@Bonus,@LastUpdatedUser,@TaxName,      
@LastUpdatedDate,@Games,@CreditsPlus,@Credits,@CardValidFor,@Courtesy,@finalPrice,@ExpiryDate,@StartDate,@taxId)        
end        
else        
begin        
 update Product set [Name]= @name,[Type]=@type,[Active]=@active,Price=@price,FinalPrice=@finalPrice,        
     EffectivePrice=@effectivePrice,FaceValue=@faceValue,DisplayGroup=@displayGroup,        
     DisplayInPOS=@displayInPOS,AutoGenerateCardNumber=@autoGenerateCardNumber,Category=@category,        
     OnlyVIP=@onlyVIP,POSCounter=@posCounter,TaxInclusive=@taxInclusive,TaxPercentage=@taxPercentage  ,      
  Bonus=@Bonus,LastUpdatedUser=@LastUpdatedUser,TaxName=@TaxName,Games=@Games,CreditsPlus=@CreditsPlus,      
  Credits=@Credits,CardValidFor=@CardValidFor , Courtesy=@Courtesy    ,ExpiryDate=@ExpiryDate,
  TaxId = @taxId
      
      
      
     where Id=@id        
end        
        
END 