USE [Marbale]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetRoleModuleActions]    Script Date: 3/29/2020 5:00:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[sp_GetRoleModuleActions]
	@id int,
	@isSuperUser bit
AS
BEGIN
	SET NOCOUNT ON;
	if @isSuperUser = 1
	begin
		select AM.Id,AM.Module,AM.[Root],AM.[URL],AM.Active,AM.[Page],AM.URL,AM.DisplayOrder,
		CASE WHEN RMA.[Page] IS NULL THEN 'false' ELSE 'true' END AS IsChecked from AppModule AM 
		left join RoleModuleAction RMA on AM.Id = RMA.PageId AND RMA.RoleId = @id
	end
	else
	begin
		select AM.Id,AM.Module,AM.[Root],AM.[URL],AM.Active,AM.[Page],AM.URL,AM.DisplayOrder,
		CASE WHEN RMA.[Page] IS NULL THEN 'false' ELSE 'true' END AS IsChecked from AppModule AM 
		join RoleModuleAction RMA on AM.Id = RMA.PageId AND RMA.RoleId = @id
	end
END
