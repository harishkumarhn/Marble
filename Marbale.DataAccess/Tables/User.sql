USE [Marbale]
GO

/****** Object:  Table [dbo].[User]    Script Date: 28/07/2019 21:31:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NULL,
	[LoginId] [varchar](100) NULL,
	[Password] [nvarchar](100) NULL,
	[Role] [varchar](200) NULL,
	[Status] [varchar](max) NULL,
	[POSCounter] [varchar](500) NULL,
	[PasswordChangeDate] [datetime] NULL,
	[InvalidAttempts] [int] NULL,
	[Email] [varchar](200) NULL,
	[CompanyAdmin] [bit] NULL,
	[Department] [varchar](200) NULL,
	[Manager] [varchar](200) NULL,
	[EmpStartDate] [datetime] NULL,
	[EmpEndDate] [datetime] NULL,
	[EmpEndReason] [varchar](200) NULL,
	[LastLogInTime] [datetime] NULL,
	[LastLogOutTimee] [datetime] NULL,
	[CreatationDate] [datetime] NULL,
	[CreatedBy] [varchar](500) NULL,
	[LastUpdatedBy] [varchar](500) NULL,
	[LastUpdatedDate] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


