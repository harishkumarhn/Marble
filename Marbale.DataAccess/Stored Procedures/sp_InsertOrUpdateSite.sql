USE [Marbale]
GO

/****** Object:  StoredProcedure [dbo].[sp_InsertOrUpdateUser]    Script Date: 8/11/2019 12:32:18 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_InsertOrUpdateSite] 
    @siteId int,
	@siteName varchar(50),
	@siteAddress varchar(100),
	@notes varchar(50),
	@siteGUID uniqueidentifier,
	@logo image,
	@guid uniqueidentifier,
	@CompanyId int,
	@customerKey varchar(50),
	@siteCode int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

begin tran
if exists (select SiteId from [Site] with (updlock,serializable) where SiteId = @siteId)
   begin
   -- Insert statements for procedure here
	UPDATE [dbo].[Site]
   SET [SiteId] = @siteId
      ,[SiteName] = @siteName
      ,[SiteAddress] = @siteAddress
      ,[Notes] = @notes
      ,[SiteGUID] = @siteGUID
	  ,[CustomerKey] = @customerKey
	  ,[CompanyId] = @CompanyId
	  ,[SiteCode] = @siteCode
      ,[Logo] = @logo
      ,[LastUpdatedTime] = GETDATE()
 WHERE SiteId = @siteId
end
else
begin
    -- Insert statements for procedure here
	INSERT INTO [dbo].[Site]
           ([SiteId]
           ,[SiteName]
           ,[SiteAddress]
           ,[Notes]
           ,[SiteGUID]
           ,[Logo]
           ,[Guid]
           ,[LastUpdatedTime]
           ,[CustomerKey]
           ,[SiteCode])
     VALUES
           (@siteId
           ,@siteName
           ,@siteAddress
           ,@notes
           ,@siteGUID
           ,@logo
           ,newid()
           ,getdate()
           ,@customerKey
           ,@siteCode)
end
commit tran
END
GO


