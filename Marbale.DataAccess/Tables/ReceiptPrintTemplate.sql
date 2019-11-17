USE [Marbale]
GO

/****** Object:  Table [dbo].[ReceiptPrintTemplate]    Script Date: 11/12/2019 11:39:21 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ReceiptPrintTemplate](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Section] [nvarchar](50) NULL,
	[Sequence] [int] NOT NULL,
	[Col1Data] [nvarchar](100) NULL,
	[Col1Alignment] [nvarchar](1) NULL,
	[Col2Data] [nvarchar](100) NULL,
	[Col2Alignment] [nvarchar](1) NULL,
	[Col3Data] [nvarchar](100) NULL,
	[Col3Alignment] [nvarchar](1) NULL,
	[Col4Data] [nvarchar](100) NULL,
	[Col4Alignment] [nvarchar](1) NULL,
	[Col5Data] [nvarchar](100) NULL,
	[Col5Alignment] [nvarchar](1) NULL,
	[TemplateId] [int] NOT NULL,
	[Guid] [uniqueidentifier] NULL,
	[site_id] [int] NULL,
	[FontName] [nvarchar](50) NULL,
	[FontSize] [numeric](4, 2) NULL,
	[SynchStatus] [bit] NULL,
	[MasterEntityId] [int] NULL,
 CONSTRAINT [PK_ReceiptPrintTemplate] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ReceiptPrintTemplate] ADD  CONSTRAINT [DF_ReceiptPrintTemplate_Guid]  DEFAULT (newid()) FOR [Guid]
GO


