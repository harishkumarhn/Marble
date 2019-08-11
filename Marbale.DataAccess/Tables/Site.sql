USE [Marbale]
GO

/****** Object:  Table [dbo].[Site]    Script Date: 8/11/2019 12:13:30 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Site](
	[SiteId] [int] NOT NULL,
	[SiteName] [nvarchar](50) NOT NULL,
	[SiteAddress] [nvarchar](500) NULL,
	[Notes] [nvarchar](500) NULL,
	[SiteGUID] [uniqueidentifier] NULL,
	[Logo] [varbinary](max) NULL,
	[Guid] [uniqueidentifier] NULL,
	[LastUpdatedTime] [datetime] NULL,
	[MaxCards] [nvarchar](100) NULL,
	[CustomerKey] [nvarchar](50) NULL,
	[Version] [nvarchar](50) NULL,
	[CompanyId] [int] NULL,
	[SiteCode] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


