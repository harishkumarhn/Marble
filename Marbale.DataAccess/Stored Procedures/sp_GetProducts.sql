USE [Marbale]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetDiscounts]    Script Date: 1/19/2019 6:58:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- DROP PROC sp_GetProducts
Create proc [dbo].[sp_GetProducts]
as 
begin 

select 
		p.Id,
		Name,
		PT.Id as Type,
		POSCounter,
		P.Active,
		DisplayInPOS,
		DisplayGroup,
		Category,
		AutoGenerateCardNumber,
		OnlyVIP,
		Price,
		FaceValue,
		TaxInclusive,
		TaxPercentage,
		FinalPrice,
		EffectivePrice,
		p.LastUpdatedBy,
		p.LastUpdatedDate,
		Bonus,
		LastUpdatedUser,
		TaxName,
		StartDate,
		Games,
		CreditsPlus,
		Credits,
		CardValidFor,
		ExpiryDate,
		Courtesy,
		TaxId 
				FROM Product P
		LEFT JOIN ProductType PT ON P.Type = PT.Id
end


