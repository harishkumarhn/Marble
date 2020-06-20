USE [Marbale]
GO

/****** Object:  Table [dbo].[PaymentTerms]    Script Date: 6/7/2020 9:00:56 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PaymentTerms](
	[PaymentTermsId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[DaysDue] [int] NOT NULL,
	[Timestamp] [datetime] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[site_id] [int] NULL,
	[Guid] [uniqueidentifier] NULL,
	[SynchStatus] [bit] NULL,
	[MasterEntityId] [int] NULL,
 CONSTRAINT [PK_BASE_PaymentTerms] PRIMARY KEY CLUSTERED 
(
	[PaymentTermsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[PaymentTerms] ADD  CONSTRAINT [DF_BASE_PaymentTerms_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO

ALTER TABLE [dbo].[PaymentTerms] ADD  CONSTRAINT [DF_PaymentTerms_Guid]  DEFAULT (newid()) FOR [Guid]
GO


