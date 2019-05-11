USE [Marbale]
GO

/****** Object:  Table [dbo].[RoleModuleAction]    Script Date: 3/16/2019 5:35:05 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[RoleModuleAction](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [int] NULL,
	[PageId] [int] NULL,
	[Page] [varchar](50) NULL
) ON [PRIMARY]
GO


