USE [Marbale]
GO

/****** Object:  Table [dbo].[Hub]    Script Date: 4/7/2019 4:28:13 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Hub](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Address] [varchar](500) NULL,
	[Frequency] [int] NULL,
	[Note] [varchar](max) NULL,
	[Active] [bit] NULL,
	[MacAddress] [varchar](50) NULL,
	[IPAddress] [varchar](50) NULL,
	[TCPPort] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


