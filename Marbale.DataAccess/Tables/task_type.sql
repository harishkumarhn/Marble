USE [Marbale]
GO

/****** Object:  Table [dbo].[task_type]    Script Date: 3/24/2019 5:30:58 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[task_type](
	[TaskTypeId] [int] IDENTITY(1,1) NOT NULL,
	[TaskType] [nvarchar](50) NULL,
	[TaskTypeName] [char](200) NULL,
	[RequiresManagerApproval] [bit] NULL,
	[DisplayInPOS] [bit] NULL,
 CONSTRAINT [PK_task_type] PRIMARY KEY CLUSTERED 
(
	[TaskTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO


