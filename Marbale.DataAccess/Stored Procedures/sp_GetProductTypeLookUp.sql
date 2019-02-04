USE [Marbale]
GO

/****** Object:  StoredProcedure [dbo].[sp_GetProductTypeLookUp]    Script Date: 2/3/2019 8:07:47 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Harish>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetProductTypeLookUp]
AS
BEGIN
	SET NOCOUNT ON;
    select distinct Id,[Type] from ProductType where Active = 1
END
GO


