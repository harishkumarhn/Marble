USE [Marbale]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetSites]    Script Date: 11/12/2019 10:29:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[sp_GetPrinters]
	
AS
BEGIN
	SET NOCOUNT ON;
	select * from Printers
END
