USE [Marbale]
GO

/****** Object:  Table [dbo].[UserRole]    Script Date: 3/20/2020 2:22:15 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UserRole](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Role] [varchar](500) NULL,
	[Description] [varchar](max) NULL,
	[ManagerFlag] [bit] NULL,
	[AllowPOSAccess] [bit] NULL,
	[POSClockInOut] [bit] NULL,
	[AllowShiftOpenClose] [bit] NULL,
	[LastUpdatedBy] [varchar](500) NULL,
	[LastUpdatedDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


