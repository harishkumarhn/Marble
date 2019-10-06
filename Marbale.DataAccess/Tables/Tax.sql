USE [Marbale]
GO

/****** Object:  Table [dbo].[Tax]    Script Date: 3/24/2019 5:31:35 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Tax](
	[TaxId] [int] IDENTITY(1,1) NOT NULL,
	[TaxName] [varchar](100) NULL,
	[TaxPercent] [decimal](18, 3) NULL,
	[ActiveFlag] [bit] NULL
) ON [PRIMARY]
GO


