USE [Marbale]
GO

/****** Object:  StoredProcedure [dbo].[sp_GetHubs]    Script Date: 8/11/2019 10:17:12 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetSites]
	
AS
BEGIN
	SET NOCOUNT ON;
	select * from [Site]
END
GO


