USE [Marbale]
GO

/****** Object:  StoredProcedure [dbo].[sp_GetTrxHeaderLines]    Script Date: 03/08/2019 12:26:45 ******/
DROP PROCEDURE [dbo].[sp_GetTrxHeaderLines]
GO

/****** Object:  StoredProcedure [dbo].[sp_GetTrxHeaderLines]    Script Date: 03/08/2019 12:26:45 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- EXEC sp_GetTrxHeaderLines
-- =============================================
-- Author:		Amaresh
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetTrxHeaderLines] 
	@userId int = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
			* 
				FROM 
				TransactionHeader

	SELECT 
			ln.*, p.Name 
				FROM 
				TransactionLines ln
				left join Product p on ln.ProductId = p.Id
	 
END

GO


