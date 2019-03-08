
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Harish
-- =============================================
CREATE PROCEDURE sp_GetUserRoles
AS
BEGIN
	Select * from UserRole
END
GO
