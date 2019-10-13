USE [Marbale]
GO

/****** Object:  Table [dbo].[DisplayGroup]    Script Date: 06/10/2019 11:46:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[DisplayGroup](
	[DisplayGroupId] [int] IDENTITY(1,1) NOT NULL,
	[DisplayGroup] [int] NOT NULL,
	[SortOrder] [int] NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[LastUpdatedBy] [nvarchar](50) NULL,
	[LastUpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_DisplayGroup] PRIMARY KEY CLUSTERED 
(
	[DisplayGroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


