USE [Marbale]
GO

/****** Object:  StoredProcedure [dbo].[sp_GetUserRoles]    Script Date: 3/23/2019 7:11:54 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Harish
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetUsers]
AS
BEGIN
	Select * from [User]
END
GO


