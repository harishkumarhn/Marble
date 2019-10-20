USE [Marbale]
GO

/****** Object:  Table [dbo].[TransactionDiscountLines]    Script Date: 28/09/2019 12:12:33 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TransactionDiscountLines](
	[TrxDiscountId] [int] IDENTITY(1,1) NOT NULL,
	[TrxId] [int] NOT NULL,
	[LineId] [int] NOT NULL,
	[DiscountId] [int] NOT NULL,
	[DiscountPercentage] [decimal](18, 4) NULL,
	[DiscountAmount] [decimal](18, 4) NOT NULL,
	[Remarks] [nvarchar](100) NULL,
	[ApprovedBy] [int] NULL,
 CONSTRAINT [PK_TransactionDiscountLines] PRIMARY KEY CLUSTERED 
(
	[TrxDiscountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO


