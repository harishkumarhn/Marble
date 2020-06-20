USE [Marbale]
GO

/****** Object:  Table [dbo].[LookupValues]    Script Date: 6/7/2020 9:02:03 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[LookupValues](
	[LookupValueId] [int] IDENTITY(1,1) NOT NULL,
	[LookupId] [int] NOT NULL,
	[LookupValue] [nvarchar](200) NULL,
	[Description] [nvarchar](100) NULL,
	[Guid] [uniqueidentifier] NULL,
	[SynchStatus] [bit] NULL,
	[site_id] [int] NULL,
	[MasterEntityId] [int] NULL,
 CONSTRAINT [PK_LookupValues] PRIMARY KEY CLUSTERED 
(
	[LookupValueId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[LookupValues] ADD  CONSTRAINT [DF_LookupValues_Guid]  DEFAULT (newid()) FOR [Guid]
GO

ALTER TABLE [dbo].[LookupValues]  WITH CHECK ADD  CONSTRAINT [FK_LookupValues_Lookups] FOREIGN KEY([LookupId])
REFERENCES [dbo].[Lookups] ([LookupId])
GO

ALTER TABLE [dbo].[LookupValues] CHECK CONSTRAINT [FK_LookupValues_Lookups]
GO


