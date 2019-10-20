CREATE TABLE [dbo].[DisplayGroup](
	[DisplayGroupId] [int] IDENTITY(1,1) NOT NULL,
	[DisplayGroup] [nvarchar(300)] NOT NULL,
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