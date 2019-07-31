USE [Marbale]
GO

/****** Object:  Table [dbo].[Customers]    Script Date: 6/17/2019 11:38:18 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Customers](
	[CustomerId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerName] [nvarchar](50) NOT NULL,
	[Address1] [nvarchar](50) NULL,
	[Address2] [nvarchar](50) NULL,
	[Address3] [nvarchar](50) NULL,
	[City] [nvarchar](50) NULL,
	[State] [nvarchar](50) NULL,
	[Country] [nvarchar](50) NULL,
	[Pin] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[DateOfBirth] [datetime] NULL,
	[Gender] [char](1) NULL,
	[Anniversary] [datetime] NULL,
	[ContactPhone1] [nvarchar](50) NULL,
	[ContactPhone2] [nvarchar](50) NULL,
	[Notes] [nvarchar](max) NULL,
	[LastUpdatedDate] [datetime] NULL,
	[LastUpdatedUser] [nvarchar](50) NULL,
	[MiddleName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[CustomDataSetId] [int] NULL,
	[Company] [nvarchar](200) NULL,
	[Designation] [nvarchar](200) NULL,
	[PhotoFileName] [nvarchar](100) NULL,
	[Guid] [uniqueidentifier] NULL,
	[SiteId] [int] NULL,
	[UniqueID] [varchar](100) NULL,
	[Username] [nvarchar](50) NULL,
	[FBUserId] [nvarchar](20) NULL,
	[FBAccessToken] [nvarchar](20) NULL,
	[TWAccessToken] [nvarchar](20) NULL,
	[TWAccessSecret] [nvarchar](20) NULL,
	[RightHanded] bit NULL,
	[TeamUser] bit NULL,
	[SynchStatus] [bit] NULL,
	[Verified] [char](1) NULL,
	[Password] [nvarchar](100) NULL,
	[LastLoginTime] [datetime] NULL,
	[ExternalSystemRef] [nvarchar](50) NULL,
	[IsValid] [bit] NULL,
	[DownloadBatchId] [int] NULL,
	[IDProofFileName] [nvarchar](100) NULL,
	[Title] [nvarchar](20) NULL
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Customers] ADD  CONSTRAINT [DF_Customers_Guid]  DEFAULT (newid()) FOR [Guid]
GO

ALTER TABLE [dbo].[Customers] ADD  DEFAULT ((1)) FOR [IsValid]
GO

--ALTER TABLE [dbo].[Customers]  WITH CHECK ADD  CONSTRAINT [FK_Customers_CustomDataSet] FOREIGN KEY([CustomDataSetId])
--REFERENCES [dbo].[CustomDataSet] ([CustomDataSetId])
--GO

--ALTER TABLE [dbo].[Customers] CHECK CONSTRAINT [FK_Customers_CustomDataSet]
--GO


