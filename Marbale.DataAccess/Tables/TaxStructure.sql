USE [Marbale]
GO

/****** Object:  Table [dbo].[TaxStructure]    Script Date: 3/24/2019 5:32:00 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TaxStructure](
	[TaxStructureId] [int] IDENTITY(1,1) NOT NULL,
	[TaxId] [int] NULL,
	[StructureName] [varchar](max) NULL,
	[TaxStructurePercentage] [decimal](18, 0) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


