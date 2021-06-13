USE [Marbale]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetCategory]    Script Date: 4/10/2020 8:19:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--EXEC [sp_GetCategory]
ALTER proc [dbo].[sp_GetCategory]
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
	where IsActive=1
end

