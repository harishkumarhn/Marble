CREATE TABLE [dbo].[GamePlay](
	[Id] [int] IDENTITY(1,1) Primary key,
	[MachineId] [int] NOT NULL foreign key references machine(Id)  ,
	[CardId] [int] NOT NULL foreign key references card(CardId)  ,
	[Credits] [decimal](10, 2) NULL,
	[Courtesy] [decimal](10, 2) NULL,
	[Bonus] [decimal](10, 2) NULL,
	[Time] [decimal](10, 2) NULL,
	[PlayedDate] [datetime] NULL,
	[TicketCount] [numeric](8, 0) NULL,
	[TicketMode] [char](1) NULL,
	[Guid] [uniqueidentifier] NULL,
	[Comments] [varchar](500) NULL,
	CreatedDate  [datetime] NULL 
 )
 