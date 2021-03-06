USE [Marbale]
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertOrUpdateSite]    Script Date: 8/18/2019 6:53:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[sp_InsertOrUpdateSite] 
    @siteId int,
	@siteName varchar(50),
	@siteAddress varchar(100),
	@notes varchar(50),
	@siteGUID uniqueidentifier,
	@logo image,
	@guid uniqueidentifier,
	@CompanyId int,
	@customerKey nvarchar(50),
	@siteCode int,
	@version nvarchar(50)
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
   SET [SiteName] = @siteName
      ,[SiteAddress] = @siteAddress
      ,[Notes] = @notes
      ,[SiteGUID] = @siteGUID
	  ,[CustomerKey] = @customerKey
	  ,[CompanyId] = @CompanyId
	  ,[SiteCode] = @siteCode
      ,[Logo] = @logo
      ,[LastUpdatedTime] = GETDATE()
	  ,[Version] = @version
 WHERE SiteId = @siteId
end
else
begin
    -- Insert statements for procedure here
	INSERT INTO [dbo].[Site]
           (
           [SiteName]
           ,[SiteAddress]
           ,[Notes]
           ,[SiteGUID]
           ,[Logo]
           ,[Guid]
           ,[LastUpdatedTime]
           ,[CustomerKey]
           ,[SiteCode]
		   ,[Version])
     VALUES
           (
           @siteName
           ,@siteAddress
           ,@notes
           ,@siteGUID
           ,@logo
           ,newid()
           ,getdate()
           ,@customerKey
           ,@siteCode
		   ,@version)
end
commit tran
END
