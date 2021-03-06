USE [Marbale]
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertOrUpdateAppSetting]    Script Date: 12/23/2018 5:38:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[sp_InsertOrUpdateAppSetting]
@name varchar(255),
@value varchar(255),
@screen varchar(100)
AS
BEGIN
DECLARE @settingId int = (select id from Settings where [Name] = @name);
  UPDATE Settings set [DefaultValue] = @value,[LastUpdatedDate] = GETDATE() where ID = @settingId
END
