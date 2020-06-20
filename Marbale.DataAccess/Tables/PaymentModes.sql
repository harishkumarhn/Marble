USE [Marbale]
GO

/****** Object:  Table [dbo].[PaymentModes]    Script Date: 6/7/2020 9:52:22 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PaymentModes](
	[PaymentModeId] [int] IDENTITY(1,1) NOT NULL,
	[PaymentMode] [varchar](50) NOT NULL,
	[isCreditCard] bit NULL,
	[CreditCardSurchargePercentage] int NULL,
	[Guid] [uniqueidentifier] NULL,
	[SynchStatus] [bit] NULL,
	[SiteId] [int] NULL,
	[isCash] bit NULL,
	[isDebitCard] bit NULL,
	[Gateway] [int] NULL,
	[ManagerApprovalRequired] bit NULL,
	[isRoundOff] bit NULL,
	[POSAvailable] [bit] NULL,
	[DisplayOrder] [smallint] NULL,
	[MasterEntityId] [int] NULL,
 CONSTRAINT [PK_PaymentModes] PRIMARY KEY CLUSTERED 
(
	[PaymentModeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[PaymentModes] ADD  CONSTRAINT [DF_PaymentModes_Guid]  DEFAULT (newid()) FOR [Guid]
GO

ALTER TABLE [dbo].[PaymentModes]  WITH CHECK ADD  CONSTRAINT [FK_PaymentModes_LookupValues] FOREIGN KEY([Gateway])
REFERENCES [dbo].[LookupValues] ([LookupValueId])
GO

ALTER TABLE [dbo].[PaymentModes] CHECK CONSTRAINT [FK_PaymentModes_LookupValues]
GO


