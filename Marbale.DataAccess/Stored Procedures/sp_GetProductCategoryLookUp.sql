USE [Marbale]
GO

/****** Object:  StoredProcedure [dbo].[sp_GetProductCategoryLookUp]    Script Date: 2/3/2019 8:10:18 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Harish>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetProductCategoryLookUp]
AS
BEGIN
	SET NOCOUNT ON;
    select distinct Id,[Name] from ProductCategory where Active = 1
END
GO


