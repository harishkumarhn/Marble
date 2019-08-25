USE [Marbale]
GO

/****** Object:  Table [dbo].[Site]    Script Date: 8/18/2019 9:01:10 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Site](
	[SiteId] [int] IDENTITY(1,1) NOT NULL,
	[SiteName] [nvarchar](50) NOT NULL,
	[SiteCode] [int] NULL,
	[SiteAddress] [nvarchar](500) NULL,
	[SiteGUID] [uniqueidentifier] NULL,
	[Notes] [nvarchar](500) NULL,
	[Logo] [varbinary](max) NULL,
	[Guid] [uniqueidentifier] NULL,
	[CompanyId] [int] NULL,
	[MaxCards] [nvarchar](100) NULL,
	[CustomerKey] [nvarchar](50) NULL,
	[Version] [nvarchar](50) NULL,
	[LastUpdatedTime] [datetime] NULL,
	CONSTRAINT UC_Person UNIQUE (SiteCode)
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


