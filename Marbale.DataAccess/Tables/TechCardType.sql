USE [Marbale]
GO

/****** Object:  Table [dbo].[TechCardType]    Script Date: 7/7/2019 3:38:04 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TechCardType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NULL,
	[Active] [bit] NULL
) ON [PRIMARY]
GO


