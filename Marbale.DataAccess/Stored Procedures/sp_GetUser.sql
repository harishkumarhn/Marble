USE [Marbale]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetUser]    Script Date: 1/6/2020 12:05:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Harish
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[sp_GetUser] 
	@loginId varchar(200) = null,
	@password varchar(200) = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from [User] where LoginId = @loginId and [Password] = @password
END
