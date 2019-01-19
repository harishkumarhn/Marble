USE [Marbale]
GO

/****** Object:  StoredProcedure [dbo].[sp_InsertOrUpdateProductType]    Script Date: 1/19/2019 5:11:03 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_InsertOrUpdateProductType] 
    @id int,
	@type varchar(50),
	@description varchar(500),
	@reportgroup varchar(50),
	@cardsale bit,
	@active bit,
	@lastUpdatedBy varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

begin tran
if exists (select id from ProductType with (updlock,serializable) where Id = @id)
   begin
   -- Insert statements for procedure here
	Update [ProductType] set [Type] = @type,[Description] = @description,
							ReportGroup = @reportgroup,Active= @active,CardSale = @cardsale,
							@lastUpdatedBy = @lastUpdatedBy,LastUpdatedDate = GetDate()
							where Id = @Id
end
else
begin
    -- Insert statements for procedure here
	INSERT INTO [dbo].[ProductType]
           ([Type]
           ,[Description]
           ,[ReportGroup]
           ,[CardSale]
           ,[Active]
           ,[LastUpdatedDate]
           ,[LastUpdatedBy])
     VALUES
           (@type
           ,@description
           ,@reportgroup
           ,@cardsale
           ,@active
           ,@lastUpdatedBy
           ,GetDate())
end
commit tran
END
GO


