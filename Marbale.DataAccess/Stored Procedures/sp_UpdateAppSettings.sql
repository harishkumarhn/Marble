USE [Marbale]
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateAppSettings]    Script Date: 1/15/2019 11:55:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[sp_UpdateAppSettings] 
@id int,
@name varchar(255),
@description varchar(255),
@defaultvalue varchar(200),
@type varchar(100),
@screengroup varchar(50),
@active bit,
@userlevel bit,
@poslevel bit,
@updatedby varchar(100)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	update Settings set [Name] = @name,[Description] = @description,DefaultValue = @defaultvalue,
							[Type] = @type,ScreenGroup = @screengroup,Active =@active,UserLevel = @userlevel,
							PosLevel =@poslevel,LastUpdatedBy = @updatedby,LastUpdatedDate = GETDATE()
							where ID = @id
END
