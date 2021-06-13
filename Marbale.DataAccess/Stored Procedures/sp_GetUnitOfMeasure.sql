USE [Marbale]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetUnitOfMeasure]    Script Date: 4/10/2020 8:25:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



ALTER proc [dbo].[sp_GetUnitOfMeasure]
as 
begin 
select 
	UomId,
	UomName,
	Notes,
	IsActive,
	CreatedBy,
	CreatedDate,
	LastupdatedBy,
	LastupdatedDate from UnitOfMeasure where IsActive=1
end


