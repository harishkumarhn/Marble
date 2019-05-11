USE [Marbale]
GO

/****** Object:  Table [dbo].[Game]    Script Date: 4/20/2019 8:17:07 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Game](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Description] [varchar](max) NULL,
	[GameProfile] [int] NULL,
	[NormalPrice] [int] NULL,
	[VIPPrice] [int] NULL,
	[RepeatPlayDiscountPercentage] [int] NULL,
	[GameCompanyName] [varchar](max) NULL,
	[Notes] [varchar](max) NULL,
	[LastUpdatedDate] [datetime] NULL,
	[LastUpdatedBy] [varchar](50) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


