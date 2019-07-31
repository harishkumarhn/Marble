USE [Marbale]
GO

/****** Object:  Table [dbo].[Category]    Script Date: 19/05/2019 15:29:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Category](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](100) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[LastupdatedBy] [nvarchar](50) NULL,
	[LastupdatedDate] [datetime] NULL
) ON [PRIMARY]

GO


