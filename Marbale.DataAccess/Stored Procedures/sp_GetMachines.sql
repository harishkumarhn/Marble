USE [Marbale]
GO

/****** Object:  StoredProcedure [dbo].[sp_GetGames]    Script Date: 5/7/2019 10:08:15 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetMachines]
	
AS
BEGIN
	SET NOCOUNT ON;
	select * from Machine
END
GO


