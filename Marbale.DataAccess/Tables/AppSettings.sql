USE [Marbale]
GO

/****** Object:  Table [dbo].[AppSettings]    Script Date: 1/16/2019 12:29:18 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AppSettings](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SettingID] [int] NULL,
	[Value] [varchar](100) NULL,
	[ScreenGroup] [varchar](50) NULL,
	[UpdatedDate] [datetime] NULL
) ON [PRIMARY]
GO


