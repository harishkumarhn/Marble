USE [Marbale]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetListItems]    Script Date: 10/2/2019 10:00:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--DROP PROC [sp_GetDisplayGroup]
CREATE PROCEDURE [dbo].[sp_GetDisplayGroup]
	@displayGroupId int = 0
AS

BEGIN
	SELECT * from displaygroup 
		where @displayGroupId = 0 OR DisplayGroup = @displayGroupId 
		ORDER BY SortOrder
END
