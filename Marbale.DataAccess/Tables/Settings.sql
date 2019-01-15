USE [Marbale]
GO

/****** Object:  Table [dbo].[Settings]    Script Date: 1/16/2019 12:29:36 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Settings](
	[Name] [nvarchar](255) NULL,
	[Description] [nvarchar](255) NULL,
	[DefaultValue] [varchar](200) NULL,
	[Type] [varchar](100) NULL,
	[ScreenGroup] [varchar](50) NULL,
	[Active] [bit] NULL,
	[UserLevel] [bit] NULL,
	[PosLevel] [bit] NULL,
	[Protected] [bit] NULL,
	[LastUpdatedBy] [varchar](100) NULL,
	[LastUpdatedDate] [datetime] NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Caption] [varchar](250) NULL
) ON [PRIMARY]
GO


