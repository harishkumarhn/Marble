USE [Marbale]
GO

/****** Object:  Table [dbo].[GameProfile]    Script Date: 4/18/2019 7:25:15 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[GameProfile](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[NormalPrice] [int] NULL,
	[VIPPrice] [int] NULL,
	[CreditAllowed] [bit] NULL,
	[BonusAllowed] [bit] NULL,
	[CourtesyAllowed] [bit] NULL,
	[TimeAllowed] [bit] NULL,
	[TiketAllowedOnCredit] [bit] NULL,
	[TiketAllowedOnBonus] [bit] NULL,
	[TiketAllowedOnCourtesy] [bit] NULL,
	[TiketAllowedOnTime] [bit] NULL,
	[LastUpdatedDate] [datetime] NULL,
	[LastUpdatedBy] [varchar](50) NULL
) ON [PRIMARY]
GO


