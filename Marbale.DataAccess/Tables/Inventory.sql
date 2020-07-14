 

CREATE TABLE [dbo].[Inventory](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[NumberOfCards] [int] NULL,
	[Action] [varchar](10) NULL,
	[ActionDate] [datetime] NULL,
	[ActionBy] [varchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


