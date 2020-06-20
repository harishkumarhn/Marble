USE [Marbale]
GO

/****** Object:  Table [dbo].[Lookups]    Script Date: 6/7/2020 8:03:39 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Lookups](
	[LookupId] [int] IDENTITY(1,1) NOT NULL,
	[LookupName] [nvarchar](50) NULL,
	[Protected] [char](1) NOT NULL,
	[Guid] [uniqueidentifier] NULL,
	[SynchStatus] [bit] NULL,
	[site_id] [int] NULL,
	[MasterEntityId] [int] NULL,
 CONSTRAINT [PK_Lookups] PRIMARY KEY CLUSTERED 
(
	[LookupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Lookups] ADD  CONSTRAINT [DF_Lookups_Guid]  DEFAULT (newid()) FOR [Guid]
GO


