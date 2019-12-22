USE [Marbale]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetProducts]    Script Date: 12/21/2019 11:14:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- DROP PROC sp_GetProducts
ALTER proc [dbo].[sp_GetProducts]
as 
begin 

select 
		p.Id,
		Name,
		PT.Id as Type,
		POSCounter,
		P.Active,
		DisplayInPOS,
		P.DisplayGroupId,
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
		TaxId,
		p.TicketAllowed,
		p.Tickets,
		p.AllowPriceOverride,
		p.ManagerApprovalRequired,
		p.TrxHeaderRemarksMandatory,
		p.TrxRemarksMandatory,
		p.QuantityPrompt,
		PT.Type as TypeName
				FROM Product P
		LEFT JOIN ProductType PT ON P.Type = PT.Id
end


