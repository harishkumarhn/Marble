USE [Marbale]
GO

/****** Object:  StoredProcedure [dbo].[sp_GetAppModules]    Script Date: 2/25/2019 12:20:48 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Harish>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetAppModules] 
@module varchar(100)
AS
BEGIN
	SET NOCOUNT ON;
    select APM.Root, APM.Page from AppModule APM
	where APM.Active = 1 and APM.Module = @module
END
GO


