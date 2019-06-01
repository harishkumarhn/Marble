USE [Marbale]
GO

/****** Object:  StoredProcedure [dbo].[sp_GetDiscounts]    Script Date: 19/05/2019 15:26:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

--EXEC [sp_GetCategory]
create proc [dbo].[sp_GetCategory]
as 
begin 
select 
	CategoryId,
	CategoryName,
	IsActive,
	CreatedBy,
	CreatedDate,
	LastupdatedBy,
	LastupdatedDate from category
end

GO


