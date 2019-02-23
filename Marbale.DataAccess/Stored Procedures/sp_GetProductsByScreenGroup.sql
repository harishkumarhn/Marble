USE [Marbale]
GO

/****** Object:  StoredProcedure [dbo].[sp_GetProductsByScreenGroup]    Script Date: 2/16/2019 3:24:29 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Harish
-- Create date: <Create Date,,>
-- Description:	get products by screen
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetProductsByScreenGroup] 
	-- Add the parameters for the stored procedure here
	@screen varchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from product where DisplayGroup = @screen
END
GO


