USE [Marbale]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetPrintTemplateHeaders]    Script Date: 11/16/2019 12:40:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[sp_GetPrintTemplateHeaders]
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from ReceiptPrintTemplateHeader
END
