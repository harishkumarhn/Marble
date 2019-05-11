USE [Marbale]
GO

/****** Object:  StoredProcedure [dbo].[sp_GetHubs]    Script Date: 4/7/2019 4:28:46 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetHubs]
	
AS
BEGIN
	SET NOCOUNT ON;
	select * from Hub
END
GO


