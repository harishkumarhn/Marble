USE [Marbale]
GO

/****** Object:  StoredProcedure [dbo].[sp_InsertOrUpdateProduct]    Script Date: 1/19/2019 5:10:19 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Harish
-- =============================================

CREATE PROCEDURE [dbo].[sp_InsertOrUpdateProduct]
@name varchar(150),
@type varchar(50) = null,
@active bit,
@price int,
@effectivePrice int,
@faceValue int,
@displayGroup varchar(50),
@displayInPOS bit,
@autoGenerateCardNumber bit,
@category varchar(50),
@onlyVIP bit,
@posCounter varchar(50),
@taxInclusive bit,
@taxPercentage int,
@id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

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
TaxPercentage) 
Values(@name,@type,@active,@price,@effectivePrice,@faceValue,@displayGroup,@displayInPOS,
@autoGenerateCardNumber,@category,@onlyVIP,@posCounter,@taxInclusive,@taxPercentage)
end
else
begin
 update Product set [Name]= @name,[Type]=@type,[Active]=@active,Price=@price,FinalPrice=@faceValue,
					EffectivePrice=@effectivePrice,FaceValue=@faceValue,DisplayGroup=@displayGroup,
					DisplayInPOS=@displayInPOS,AutoGenerateCardNumber=@autoGenerateCardNumber,Category=@category,
					OnlyVIP=@onlyVIP,POSCounter=@posCounter,TaxInclusive=@taxInclusive,TaxPercentage=@taxPercentage
					where Id=@id
end

END
GO


