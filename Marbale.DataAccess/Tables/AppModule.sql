USE [Marbale]
GO

/****** Object:  Table [dbo].[AppModule]    Script Date: 2/25/2019 11:23:21 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create TABLE [dbo].[AppModule](
	[Id] [int] NULL,
	[Module] [varchar](50) NULL,
	[Root] [varchar](50) NULL,
	[Page] [varchar](50) NULL,
	[URL] [varchar](500) NULL,
	[Active] [bit] NULL
) ON [PRIMARY]
GO


