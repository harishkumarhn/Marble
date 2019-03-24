USE [Marbale]
GO

/****** Object:  Table [dbo].[Messages]    Script Date: 3/24/2019 5:32:40 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Messages](
	[MessageNo] [int] IDENTITY(1,1) NOT NULL,
	[MessageName] [nvarchar](max) NULL,
	[MessageDescription] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


