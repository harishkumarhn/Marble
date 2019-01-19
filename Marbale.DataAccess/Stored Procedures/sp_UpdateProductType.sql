USE [Marbale]
GO

/****** Object:  StoredProcedure [dbo].[sp_UpdateProductType]    Script Date: 1/15/2019 10:39:19 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Harish
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_UpdateProductType] 
@id int,
@productType varchar(50),
@description varchar(500),
@reportGroup varchar(50),
@cardSale bit,
@active bit,
@updatedBy varchar(50)

AS
BEGIN
	SET NOCOUNT ON;
	 UPDATE ProductType SET [Type] = @productType
      ,[Description] = @description
      ,[ReportGroup] = @reportGroup
      ,[CardSale] = @cardSale
      ,[Active] = @active
      ,[LastUpdatedDate] = GetDate()
      ,[LastUpdatedBy] = @updatedBy
	WHERE Id = @id
END

GO


