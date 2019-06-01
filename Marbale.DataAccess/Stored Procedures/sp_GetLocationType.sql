USE [Marbale]
GO

/****** Object:  StoredProcedure [dbo].[sp_GetLocationType]    Script Date: 01/06/2019 17:41:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


--EXEC [sp_GetLocationType]
create proc [dbo].[sp_GetLocationType]
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
end


GO


