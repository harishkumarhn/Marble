USE [Marbale]
GO

/****** Object:  Table [dbo].[ListItem]    Script Date: 10/2/2019 4:50:37 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ListItem](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GroupId] [int] NOT NULL,
	[Name] [varchar](50) NULL
	 PRIMARY KEY (Id)
) ON [PRIMARY]
GO


