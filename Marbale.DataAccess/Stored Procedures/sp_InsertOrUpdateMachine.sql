USE [Marbale]
GO

/****** Object:  StoredProcedure [dbo].[sp_InsertOrUpdateGame]    Script Date: 5/9/2019 11:44:29 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_InsertOrUpdateMachine] 
    @id int,
	@name varchar(50),
	@gameName varchar(50),
	@hubName varchar(50),
	@hubAddress varchar(50),
	@machineAddress varchar(50),
	@effectiveMachineAddress varchar(50),
	@active bit,
	@readerType varchar(50),
	@vipPrice int,
	@softwareVersion varchar(50),
	@ticketMode varchar(50),
	@ticketAllowed bit,
	@purchasePrice int,
	@notes varchar(max),
	@theme varchar(50),
	@lastUpdatedDate datetime,
	@lastUpdatedBy varchar(50)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

begin tran
if exists (select id from Machine with (updlock,serializable) where Id = @id)
   begin
   -- Insert statements for procedure here
	Update [Machine] set [Name] = @name,
	GameName = @gameName,
	HubName = @hubName,
	HubAddress = @hubAddress,
	MachineAddress = @machineAddress,
	EffectiveMachineAddress = @effectiveMachineAddress,
	Active = @active,
	ReaderType = @readerType,
	SoftwareVersion = @softwareVersion,
	TicketMode = @ticketMode,
	TicketAllowed = @ticketAllowed, 
	VIPPrice = @vipPrice,
	PurchasePrice = @purchasePrice,
	Notes = @notes,
	Theme = @theme,
	[LastUpdatedDate] = @lastUpdatedDate,
	[LastUpdatedBy] = @lastUpdatedDate where Id = @Id
end
else
begin
    -- Insert statements for procedure here
	INSERT INTO [dbo].[Machine]
           ([Name]
		   ,[GameName]
           ,[HubName]
		   ,HubAddress
		   ,MachineAddress
		   ,EffectiveMachineAddress
		   ,Active
		   ,SoftwareVersion
		   ,ReaderType
		   ,TicketMode
		   ,TicketAllowed
		   ,VIPPrice
		   ,PurchasePrice
		   ,Notes
		   ,Theme
           ,[LastUpdatedDate]
           ,[LastUpdatedBy])
     VALUES
           (@name ,
		   @gameName,
	@hubName ,
	@hubAddress ,
	@machineAddress,
	@effectiveMachineAddress,
	@active,
	@softwareVersion,
	@readerType ,
	@ticketMode,
	@ticketAllowed,
	@vipPrice,
	@purchasePrice,
	@notes,
	@theme,
	@lastUpdatedDate,
	@lastUpdatedBy)
end
commit tran
END
GO


