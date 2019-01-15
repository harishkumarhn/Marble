USE [Marbale]
GO

/****** Object:  Table [dbo].[ProductType]    Script Date: 1/16/2019 12:28:46 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ProductType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Type] [varchar](50) NULL,
	[Description] [varchar](500) NULL,
	[ReportGroup] [varchar](50) NULL,
	[CardSale] [bit] NULL,
	[Active] [bit] NULL,
	[LastUpdatedDate] [datetime] NULL,
	[LastUpdatedBy] [varchar](50) NULL
) ON [PRIMARY]
GO


