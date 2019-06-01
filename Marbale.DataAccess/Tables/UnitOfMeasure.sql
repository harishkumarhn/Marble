USE [Marbale]
GO

/****** Object:  Table [dbo].[Category]    Script Date: 19/05/2019 16:24:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UnitOfMeasure](
	[UomId] [int] IDENTITY(1,1) NOT NULL,
	[UomName] [nvarchar](100) NOT NULL,
	[Notes][nvarchar](255) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[LastupdatedBy] [nvarchar](50) NULL,
	[LastupdatedDate] [datetime] NULL
) ON [PRIMARY]

GO


