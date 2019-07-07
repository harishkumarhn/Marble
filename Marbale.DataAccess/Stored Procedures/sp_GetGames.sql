USE [Marbale]
GO

/****** Object:  StoredProcedure [dbo].[sp_GetGameProfiles]    Script Date: 4/20/2019 8:14:49 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetGames]
	
AS
BEGIN
	SET NOCOUNT ON;
	select * from Game
END
GO


