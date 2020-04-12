USE [Marbale]
GO

/****** Object:  Table [dbo].[User]    Script Date: 3/20/2020 2:21:16 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NULL,
	[LoginId] [varchar](100) NULL,
	[Password] [image] NULL,
	[RoleId] [int] NULL,
	[Status] [varchar](max) NULL,
	[POSCounter] [varchar](500) NULL,
	[PasswordChangeDate] [datetime] NULL,
	[InvalidAttempts] [int] NULL,
	[Email] [varchar](200) NULL,
	[CompanyAdmin] [bit] NULL,
	[Department] [varchar](200) NULL,
	[Manager] [varchar](200) NULL,
	[ReadOnly] [bit] NULL,
	[EmpStartDate] [datetime] NULL,
	[EmpEndDate] [datetime] NULL,
	[EmpEndReason] [varchar](200) NULL,
	[LastLogInTime] [datetime] NULL,
	[LastLogOutTime] [datetime] NULL,
	[CreatationDate] [datetime] NULL,
	[CreatedBy] [varchar](500) NULL,
	[LastUpdatedBy] [varchar](500) NULL,
	[LastUpdatedDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[User]  WITH CHECK ADD FOREIGN KEY([RoleId])
REFERENCES [dbo].[UserRole] ([Id])
GO


