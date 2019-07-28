USE [Marbale]
GO

/****** Object:  Table [dbo].[ProductKey]    Script Date: 7/28/2019 4:03:56 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ProductKey](
	[SiteKey] [image] NULL,
	[LicenseKey] [image] NOT NULL,
	[FeatureKey] [image] NULL,
	[Guid] [uniqueidentifier] NULL,
	[site_id] [int] NULL,
	[SynchStatus] [bit] NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_ProductKey] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[ProductKey] ADD  CONSTRAINT [DF_ProductKey_Guid]  DEFAULT (newid()) FOR [Guid]
GO


