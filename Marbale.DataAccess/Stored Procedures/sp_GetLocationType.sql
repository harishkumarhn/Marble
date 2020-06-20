USE [MarbleMg]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetLocationType]    Script Date: 4/10/2020 9:10:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--EXEC [sp_GetLocationType]
ALTER proc [dbo].[sp_GetLocationType]
as 
begin 
select 
	LocationTypeId,
	LocationType,
	IsActive,
	Notes,
	CreatedBy,
	CreatedDate,
	LastupdatedBy,
	LastupdatedDate from LocationType
	where isActive=1
end


