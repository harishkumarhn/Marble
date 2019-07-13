USE [Marbale]
GO

/****** Object:  StoredProcedure [dbo].[sp_GetVendor]    Script Date: 26/05/2019 19:22:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


--EXEC [sp_GetVendor]
CREATE proc [dbo].[sp_GetVendor]
as 
begin 
select 
		VendorId,
		Name,
		AddressLine1,
		AddressLine2,
		Code,
		Remarks,
		City,
		State,
		Country,
		PostalCode,
		AddressRemarks,
		ContactName,
		Phone,
		Email,
		IsActive,
		Website,
		CreatedBy,
		CreatedDate,
		LastupdatedBy,
		LastupdatedDate
			from vendor
end



GO


