USE [Marbale]
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateSettings]    Script Date: 7/18/2020 11:35:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[sp_UpdateSettings] 
@id int,
@name varchar(255),
@description varchar(255),
@defaultvalue varchar(200),
@type varchar(100),
@screengroup varchar(50),
@active bit,
@userlevel bit,
@poslevel bit,
@updatedby varchar(100),
@caption varchar(255)


AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	IF @id > 0
	BEGIN
	update Settings set [Name] = @name,[Description] = @description,
							[Caption] = @caption,DefaultValue = @defaultvalue,
							[Type] = @type,ScreenGroup = @screengroup,Active =@active,UserLevel = @userlevel,
							PosLevel =@poslevel,LastUpdatedBy = @updatedby,LastUpdatedDate = GETDATE()
							where ID = @id
	END
	ELSE
	BEGIN
	 insert into Settings values (@name,@description,@defaultvalue,@type,@screengroup,@active,@userlevel,@poslevel,NULL,@updatedby
									,GETDATE(),@caption)
	END
END
