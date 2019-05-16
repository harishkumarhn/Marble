USE [Marbale]
GO

/****** Object:  Table [dbo].[ValuesButtons]    Script Date: 5/16/2019 10:36:54 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ValuesButtons](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ButtonId] [varchar](max) NULL,
	[Class] [varchar](max) NULL,
	[Tittle] [varchar](max) NULL,
	[MethodName] [varchar](max) NULL,
	[Text] [varchar](max) NULL,
	[Active] [bit] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


