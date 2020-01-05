USE [Marbale]
GO

/****** Object:  Table [dbo].[Product]    Script Date: 1/4/2020 8:55:06 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](150) NULL,
	[Type] [int] NULL,
	[POSCounter] [varchar](50) NULL,
	[Active] [bit] NULL,
	[DisplayInPOS] [bit] NULL,
	[DisplayGroupId] [int] NULL,
	[Category] [int] NULL,
	[AutoGenerateCardNumber] [bit] NULL,
	[OnlyVIP] [bit] NULL,
	[Price] [decimal](18, 3) NULL,
	[FaceValue] [decimal](18, 3) NULL,
	[TaxInclusive] [bit] NULL,
	[TaxPercentage] [decimal](18, 3) NULL,
	[FinalPrice] [decimal](18, 3) NULL,
	[EffectivePrice] [decimal](18, 3) NULL,
	[Bonus] [decimal](18, 3) NULL,
	[TaxName] [varchar](max) NULL,
	[StartDate] [datetime] NULL,
	[Games] [decimal](18, 3) NULL,
	[CreditsPlus] [decimal](18, 3) NULL,
	[Credits] [decimal](18, 3) NULL,
	[CardValidFor] [int] NULL,
	[ExpiryDate] [datetime] NULL,
	[Courtesy] [bigint] NULL,
	[TaxId] [int] NULL,
	[Time] [datetime] NULL,
	[Tickets] [numeric](8, 0) NULL,
	[TicketAllowed] [bit] NULL,
	[ManagerApprovalRequired] [bit] NULL,
	[TrxHeaderRemarksMandatory] [bit] NULL,
	[TrxLineRemarksMandatory] [bit] NULL,
	[AllowPriceOverride] [bit] NULL,
	[QuantityPrompt] [bit] NULL,
	[MinimumQuantity] [int] NULL,
	[LastUpdatedBy] [varchar](50) NULL,
	[LastUpdatedDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Product]  WITH CHECK ADD FOREIGN KEY([Category])
REFERENCES [dbo].[ProductCategory] ([Id])
GO

ALTER TABLE [dbo].[Product]  WITH CHECK ADD FOREIGN KEY([Type])
REFERENCES [dbo].[ProductType] ([Id])
GO


