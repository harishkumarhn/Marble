USE [Marbale]
GO

/****** Object:  Table [dbo].[Location]    Script Date: 01/06/2019 17:38:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Location](
	[LocationId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[IsActive] [bit] NULL,
	[IsAvailableToSell] [bit] NOT NULL,
	[barCode] [nvarchar](50) NULL,
	[IsTurnInLocation] [bit] NULL,
	[IsStore] [bit] NULL,
	[AllowForMassUpdate] [bit] NULL,
	[LocationTypeId] [int] NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[LastupdatedBy] [nvarchar](50) NULL,
	[LastupdatedDate] [datetime] NULL,
 CONSTRAINT [PK_Location] PRIMARY KEY CLUSTERED 
(
	[LocationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Location]  WITH CHECK ADD  CONSTRAINT [FK_LocationType_Location] FOREIGN KEY([LocationId])
REFERENCES [dbo].[Location] ([LocationId])
GO

ALTER TABLE [dbo].[Location] CHECK CONSTRAINT [FK_LocationType_Location]
GO


