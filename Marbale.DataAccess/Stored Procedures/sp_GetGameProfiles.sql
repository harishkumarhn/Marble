USE [Marbale]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetHubs]    Script Date: 4/18/2019 6:00:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[sp_GetGameProfiles]
	
AS
BEGIN
	SET NOCOUNT ON;
	select * from GameProfile
END
