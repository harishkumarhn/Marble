

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
	[Price] [decimal](18, 3) NULL,
	[FaceValue] [decimal](18, 3) NULL,
	[TaxInclusive] [bit] NULL,
	[TaxPercentage] [decimal](18, 3) NULL,
	[FinalPrice] [decimal](18, 3) NULL,
	[EffectivePrice] [decimal](18, 3) NULL,
	[LastUpdatedBy] [varchar](50) NULL,
	[LastUpdatedDate] [datetime] NULL,
	[Bonus] [decimal](18, 3) NULL,
	[LastUpdatedUser] [varchar](max) NULL,
	[TaxName] [varchar](max) NULL,
	[StartDate] [datetime] NULL,
	[Games] [decimal](18, 3) NULL,
	[CreditsPlus] [decimal](18, 3) NULL,
	[Credits] [decimal](18, 3) NULL,
	[CardValidFor] [int] NULL,
	[ExpiryDate] [datetime] NULL,
	[Courtesy] [bigint] NULL,
	[TaxId] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


