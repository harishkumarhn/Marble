USE [Marbale]
GO

/****** Object:  Table [dbo].[Product]    Script Date: 12/31/2018 6:21:48 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](150) NULL,
	[Type] [varchar](50) NULL,
	[POSCounter] [varchar](50) NULL,
	[Active] [bit] NULL,
	[DisplayInPOS] [bit] NULL,
	[DisplayGroup] [varchar](50) NULL,
	[Category] [varchar](50) NULL,
	[AutoGenerateCardNumber] [bit] NULL,
	[OnlyVIP] [bit] NULL,
	[Price] [int] NULL,
	[FaceValue] [int] NULL,
	[TaxInclusive] [bit] NULL,
	[TaxPercentage] [int] NULL,
	[FinalPrice] [int] NULL,
	[EffectivePrice] [int] NULL
) ON [PRIMARY]
GO


