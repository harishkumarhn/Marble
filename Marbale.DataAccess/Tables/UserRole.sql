USE [Marbale]
GO

/****** Object:  Table [dbo].[UserRole]    Script Date: 3/3/2019 12:00:05 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UserRole](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Role] [varchar](500) NULL,
	[RoleDescription] [varchar](max) NULL,
	[ManagerFlag] [bit] NULL,
	[AllowPOSAccesss] [bit] NULL,
	[POSClockInOut] [bit] NULL,
	[AllowShiftOpenClose] [bit] NULL,
	[LastUpdatedBy] [varchar](500) NULL,
	[LastUpdatedDate] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


