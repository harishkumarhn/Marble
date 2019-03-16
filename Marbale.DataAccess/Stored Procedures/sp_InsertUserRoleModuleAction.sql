-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE sp_InsertUserRoleModuleAction
	
	@RoleId varchar(50),
	@PageIds varchar(max)
AS
BEGIN
	-- Insert statement
	    DELETE from RoleModuleAction where RoleId = @RoleId
		INSERT INTO RoleModuleAction
		SELECT @RoleId, CAST(Item AS INT) , (select [Page] from AppModule where Id = CAST(Item AS INT)) 
		FROM  dbo.SplitString(@PageIds, ',')  
END
GO
