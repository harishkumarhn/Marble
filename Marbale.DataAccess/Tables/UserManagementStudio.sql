USE [Marbale]
GO

/****** Object:  Table [dbo].[UserManagementStudio]    Script Date: 3/2/2019 11:59:24 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UserManagementStudio](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserRoleId] [int] NULL,
	[Root] [varchar](50) NULL,
	[Module] [varchar](50) NULL,
	[Page] [varchar](50) NULL
) ON [PRIMARY]
GO


