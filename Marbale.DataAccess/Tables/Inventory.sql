USE [Marbale]
GO

/****** Object:  Table [dbo].[Inventory]    Script Date: 9/8/2019 4:44:20 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Inventory](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[NumberOfCards] [int] NULL,
	[Action] [varchar](10) NULL,
	[ActionDate] [datetime] NULL,
	[ActionBy] [varchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


