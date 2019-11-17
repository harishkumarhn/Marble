USE [Marbale]
GO

/****** Object:  Table [dbo].[Printers]    Script Date: 11/16/2019 5:25:29 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Printers](
	[PrinterId] [int] IDENTITY(1,1) NOT NULL,
	[PrinterName] [nvarchar](500) NULL,
	[PrinterLocation] [nvarchar](100) NULL,
	[IPAddress] [nvarchar](50) NULL,
	[Remarks] [nvarchar](100) NULL,
	[Guid] [uniqueidentifier] NULL,
	[site_id] [int] NULL,
	[SynchStatus] [bit] NULL,
	[KDSTerminal] [bit] NULL,
	[MasterEntityId] [int] NULL,
 CONSTRAINT [PK_Printers] PRIMARY KEY CLUSTERED 
(
	[PrinterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO


