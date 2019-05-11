USE [Marbale]
GO

/****** Object:  StoredProcedure [dbo].[sp_InsertOrUpdateHub]    Script Date: 4/7/2019 4:29:30 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_InsertOrUpdateHub] 
    @id int,
	@name varchar(50),
	@note varchar(50),
	@frequency int,
	@address varchar(500),
	@macaddress varchar(500),
	@ipaddress varchar(500),
	@tcpport int,
	@active bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

begin tran
if exists (select id from Hub with (updlock,serializable) where Id = @id)
   begin
   -- Insert statements for procedure here
	Update [Hub] set [Name] = @name,[Address] = @address,
							IPAddress = @ipaddress,Active= @active,MacAddress = @macaddress,
							Note = @note,Frequency = @frequency,TCPPort = @tcpport
							where Id = @Id
end
else
begin
    -- Insert statements for procedure here
	INSERT INTO [dbo].[Hub]
           ([Name]
           ,[Address]
           ,[Note]
           ,[Frequency]
           ,[Active]
           ,[IPAddress]
           ,[MacAddress]
		   ,[TCPPort])
     VALUES
           (@name
           ,@address
           ,@note
           ,@frequency
           ,@active
		   ,@ipaddress
           ,@macaddress
		   ,@tcpport
           )
end
commit tran
END
GO


