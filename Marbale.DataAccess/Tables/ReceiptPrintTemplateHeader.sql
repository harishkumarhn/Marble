USE [Marbale]
GO

/****** Object:  Table [dbo].[ReceiptPrintTemplateHeader]    Script Date: 11/12/2019 11:39:36 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ReceiptPrintTemplateHeader](
	[TemplateId] [int] IDENTITY(1,1) NOT NULL,
	[TemplateName] [varchar](50) NOT NULL,
	[FontName] [nvarchar](50) NULL,
	[FontSize] [numeric](4, 2) NULL,
	[Guid] [uniqueidentifier] NULL,
	[site_id] [int] NULL,
	[SynchStatus] [bit] NULL,
	[MasterEntityId] [int] NULL,
 CONSTRAINT [PK_ReceiptPrintTemplateHeader] PRIMARY KEY CLUSTERED 
(
	[TemplateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ReceiptPrintTemplateHeader] ADD  CONSTRAINT [DF_ReceiptPrintTemplateHeader_Guid]  DEFAULT (newid()) FOR [Guid]
GO


