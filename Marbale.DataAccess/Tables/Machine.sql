--USE [Marbale]
--GO

/****** Object:  Table [dbo].[GameProfile]    Script Date: 5/6/2019 8:27:32 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
 
--drop table Machine
--drop table GamePlay
--drop table Game
--drop table GameProfile

CREATE TABLE [dbo].[Machine](
	[Id] [int] IDENTITY(1,1) NOT NULL Primary key,
	[Name] [varchar](50) NULL,
	[GameName] [varchar](50) NULL,
	[GameId] int foreign key references game(Id) ,
	[HubName] [varchar](50) NULL,
	[HubAddress] [varchar](50) NULL,
	[MachineAddress] [varchar](50) NULL,
	[EffectiveMachineAddress] [varchar](50) NULL,
	[Active] [bit] NULL,
	[ReaderType] [varchar](50) NULL,
	[SoftwareVersion] [varchar](50) NULL,
	[TicketMode] [varchar](50) NULL,
	[VIPPrice] [int] NULL,
	[TicketAllowed] [bit] NULL,
	[PurchasePrice] [int] NULL,
	[Notes] [varchar](max) NULL,
	[Theme] [varchar](100) NULL,
	[LastUpdatedDate] [datetime] NULL,
	[LastUpdatedBy] [varchar](50) NULL
) 

