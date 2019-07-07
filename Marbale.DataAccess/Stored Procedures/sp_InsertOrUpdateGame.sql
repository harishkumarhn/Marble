USE [Marbale]
GO

/****** Object:  StoredProcedure [dbo].[sp_InsertOrUpdateGameProfile]    Script Date: 4/20/2019 8:06:51 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[sp_InsertOrUpdateGame] 
    @id int,
	@name varchar(50),
	@description varchar(max),
	@gameProfile int,
	@normalPrice int,
	@vipPrice int,
	@repeatPlayDiscountPercentage int,
	@gameCompanyName varchar(500),
	@notes varchar(max),
	@lastUpdatedDate datetime,
	@lastUpdatedBy varchar(50)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

begin tran
if exists (select id from Game with (updlock,serializable) where Id = @id)
   begin
   -- Insert statements for procedure here
	Update [Game] set [Name] = @name,
	NormalPrice = @normalPrice,
	VIPPrice = @vipPrice,
	RepeatPlayDiscountPercentage = @repeatPlayDiscountPercentage,
	[Description] = @Description,
	Notes = @notes,
	GameProfile = @gameProfile,
	GameCompanyName = @gameCompanyName,
	[LastUpdatedDate] = @lastUpdatedDate,
	[LastUpdatedBy] = @lastUpdatedDate where Id = @Id
end
else
begin
    -- Insert statements for procedure here
	INSERT INTO [dbo].[Game]
           ([Name]
		   ,[Description]
           ,[NormalPrice]
           ,[VIPPrice]
		   ,RepeatPlayDiscountPercentage
		   ,GameProfile
		   ,GameCompanyName
		   ,Notes
           ,[LastUpdatedDate]
           ,[LastUpdatedBy])
     VALUES
           (@name ,
		   @description,
	@normalPrice ,
	@vipPrice ,
	@repeatPlayDiscountPercentage,
	@gameProfile,
	@gameCompanyName,
	@notes,
	@lastUpdatedDate ,
	@lastUpdatedBy)
end
commit tran
END
GO


