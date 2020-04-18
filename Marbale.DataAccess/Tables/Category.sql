--USE [MarbleMg]
--GO

--/****** Object:  Table [dbo].[Category]    Script Date: 4/6/2020 8:23:43 PM ******/
--SET ANSI_NULLS ON
--GO

--SET QUOTED_IDENTIFIER ON
--GO
--drop table [Category]
CREATE TABLE [dbo].[Category](
	[CategoryId] [int] IDENTITY(1,1)primary key,
	[CategoryName] [nvarchar](100) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[LastupdatedBy] [nvarchar](50) NULL,
	[LastupdatedDate] [datetime] NULL
) ON [PRIMARY]

GO


