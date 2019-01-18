USE [Marbale]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAppSettingsByScreen]    Script Date: 1/18/2019 10:50:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Harish>
-- =============================================
ALTER PROCEDURE [dbo].[sp_GetAppSettingsByScreen] 
@screen varchar(100)
AS
BEGIN
	SET NOCOUNT ON;
    select S.Name,APS.Value,S.Type from AppSettings APS join Settings S on S.ID = APS.SettingID
	where S.Active = 1 and S.ScreenGroup = @screen
END
