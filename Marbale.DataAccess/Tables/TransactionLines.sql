USE [Marbale]
GO

/****** Object:  Table [dbo].[trx_lines]    Script Date: 6/8/2019 11:12:51 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
-- DROP TABLE  [TransactionLines]
CREATE TABLE [dbo].[TransactionLines](
	[TrxId] [int] NOT NULL,
	[LineId] [int] NOT NULL,
	[ProductId] [int] NULL,
	[Price] [float] NULL,
	[Quantity] [numeric](10, 4) NULL,
	[Amount] [float] NULL,
	[CardId] [int] NULL,
	[CardNumber] [nvarchar](50) NULL,
	[Credits] [decimal](18, 4) NULL,
	[Courtesy] [decimal](18, 4) NULL,
	[TaxPercentage] [float] NULL,
	[TaxId] [int] NULL,
	[Time] [decimal](18, 4) NULL,
	[Bonus] [decimal](18, 4) NULL,
	[Tickets] [numeric](8, 0) NULL,
	[LoyaltyPoints] [decimal](18, 4) NULL,
	[Guid] [uniqueidentifier] NULL,
	[SiteId] [int] NULL,
	[Remarks] [nvarchar](100) NULL,
	[PromotionId] [int] NULL,
	[SynchStatus] [bit] NULL,
	[ReceiptPrinted] [bit] NULL,
	[ParentLineId] [int] NULL,
	[UserPrice] [bit] NULL,
	[KOTPrintCount] [int] NULL,
	[GameplayId] [int] NULL,
	[KDSSent] [bit] NULL,
	[CreditPlusConsumptionId] [int] NULL,
	[CancelledTime] [datetime] NULL,
	[CancelledBy] [nvarchar](50) NULL,
	[ProductDescription] [nvarchar](200) NULL,
	[IsWaiverSignRequired] [char](1) NULL,
	[OriginalLineID] [int] NULL,
	[MasterEntityId] [int] NULL,
	[IsLineCancelled] BIT 
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[TransactionLines] SET (LOCK_ESCALATION = DISABLE)
GO

ALTER TABLE [dbo].[TransactionLines] ADD  CONSTRAINT [DF_TransactionLines_Guid]  DEFAULT (newid()) FOR [Guid]
GO

ALTER TABLE [dbo].[TransactionLines]  WITH CHECK ADD  CONSTRAINT [FK_TransactionLines_TransactionHeader] FOREIGN KEY([TrxId])
REFERENCES [dbo].[TransactionHeader] ([TrxId])
GO

ALTER TABLE [dbo].[TransactionLines] CHECK CONSTRAINT [FK_TransactionLines_TransactionHeader]
GO


