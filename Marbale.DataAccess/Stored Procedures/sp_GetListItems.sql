USE [Marbale]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetListItems]    Script Date: 10/9/2021 6:44:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[sp_GetListItems]
	@groupId int
AS
BEGIN
	SELECT Id,DisplayGroup from Displaygroup
END
