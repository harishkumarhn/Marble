USE [Marbale]
GO

/****** Object:  StoredProcedure [dbo].[sp_GetLocation]    Script Date: 01/06/2019 17:41:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


--EXEC [sp_GetCategory]
create proc [dbo].[sp_GetLocation]
as 
begin 
select 
	LocationId,
	Name,
	IsActive,
	IsAvailableToSell,
	barCode,
	IsTurnInLocation,
	IsStore,
	AllowForMassUpdate,
	LocationTypeId,
	CreatedBy,
	CreatedDate,
	LastupdatedBy,
	LastupdatedDate
				
	 from Location
end



GO


