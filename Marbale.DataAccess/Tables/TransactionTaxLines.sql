USE [Marbale]
GO



/****** Object:  Table [dbo].[TrxTaxLines]    Script Date: 23/08/2019 23:13:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TransactionTaxLines](
	[TrxId] [int] NOT NULL,
	[LineId] [int] NOT NULL,
	[TaxId] [int] NOT NULL,
	[TaxStructureId] [int] NULL,
	[Percentage] [numeric](18, 4) NOT NULL,
	[Amount] [numeric](18, 4) NOT NULL,
	[ProductSplitAmount] [numeric](18, 4) NULL
) ON [PRIMARY]

GO



