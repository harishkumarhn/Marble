USE [Marbale]
GO

/****** Object:  StoredProcedure [dbo].[sp_GetUom]    Script Date: 19/05/2019 16:25:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



create proc [dbo].[sp_GetUnitOfMeasure]
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
	LastupdatedDate from UnitOfMeasure
end


GO


