SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE sp_UpdateProductKey
	@SiteId int,
	@SiteKey image,
	@LicenseKey image
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   Update ProductKey set SiteKey = @SiteKey,LicenseKey = @LicenseKey where site_id = @SiteId
END
GO
