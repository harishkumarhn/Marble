USE [Marbale]
GO

/****** Object:  Table [dbo].[productCategory]    Script Date: 2/2/2019 3:37:29 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[productCategory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NULL,
	[Active] [bit] NULL,
	[ParentCategory] [varchar](100) NULL
) ON [PRIMARY]
GO


