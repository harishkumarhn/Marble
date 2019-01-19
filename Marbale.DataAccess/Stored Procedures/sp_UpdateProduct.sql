USE [Marbale]
GO

/****** Object:  StoredProcedure [dbo].[sp_UpdateProduct]    Script Date: 1/19/2019 5:11:19 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Harish
-- =============================================

-- exec [sp_InsertProduct] 'name','type',true,10,10,10,'',true,true,'',true,'',true,1
Create PROCEDURE [dbo].[sp_UpdateProduct]
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

update Product set [Name]= @name,[Type]=@type,[Active]=@active,Price=@price,FinalPrice=@faceValue,
					EffectivePrice=@effectivePrice,FaceValue=@faceValue,DisplayGroup=@displayGroup,
					DisplayInPOS=@displayInPOS,AutoGenerateCardNumber=@autoGenerateCardNumber,Category=@category,
					OnlyVIP=@onlyVIP,POSCounter=@posCounter,TaxInclusive=@taxInclusive,TaxPercentage=@taxPercentage
					where Id=@id
END
GO


