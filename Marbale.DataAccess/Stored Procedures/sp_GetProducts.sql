USE [Marbale]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetProducts]    Script Date: 1/4/2020 8:52:44 PM ******/
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
		p.TrxLineRemarksMandatory,
		p.MinimumQuantity,
		p.QuantityPrompt,
		PT.Type as TypeName
				FROM Product P
		LEFT JOIN ProductType PT ON P.Type = PT.Id
end


