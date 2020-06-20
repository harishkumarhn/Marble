--USE [MarbleMg]
--GO

--/****** Object:  Table [dbo].[UnitOfMeasure]    Script Date: 4/6/2020 8:24:36 PM ******/
--SET ANSI_NULLS ON
--GO

--SET QUOTED_IDENTIFIER ON
--GO
--drop table UnitOfMeasure
CREATE TABLE [dbo].[UnitOfMeasure](
	[UomId] [int] IDENTITY(1,1) primary key,
	[UomName] [nvarchar](100) NOT NULL,
	[Notes] [nvarchar](255) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[LastupdatedBy] [nvarchar](50) NULL,
	[LastupdatedDate] [datetime] NULL
) ON [PRIMARY]

GO


