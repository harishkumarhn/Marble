USE [Marbale]
GO

/****** Object:  Table [dbo].[Card]    Script Date: 11/9/2019 11:06:13 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Card](
	[CardId] [int] IDENTITY(1,1) NOT NULL,
	[CardNumber] [varchar](50) NOT NULL,
	[IssueDate] [datetime] NOT NULL,
	[FaceValue] [float] NULL,
	[RefundFlag] [bit] NULL,
	[RefundAmount] [decimal](18, 4) NULL,
	[RefundDate] [datetime] NULL,
	[ValidFlag] [bit] NULL,
	[TicketCount] [int] NULL,
	[Notes] [nvarchar](500) NULL,
	[LastUpdated] [datetime] NULL,
	[Credits] [decimal](18, 4) NULL,
	[Courtesy] [decimal](18, 4) NULL,
	[Bonus] [decimal](18, 4) NULL,
	[CustomerId] [int] NULL,
	[CreditsPlayed] [decimal](18, 4) NULL,
	[TicketAllowed] [bit] NULL,
	[RealTicketMode] [bit] NULL,
	[VipCustomer] [bit] NULL,
	[SiteId] [int] NULL,
	[StartDateTtime] [datetime] NULL,
	[LastTimePlayed] [datetime] NULL,
	[TechnicianCard] [int] NULL,
	[TechGames] [int] NULL,
	[TimerResetCard] [bit] NULL,
	[LoyaltyPoints] [numeric](18, 4) NULL,
	[LastUpdatedBy] [nvarchar](50) NULL,
	[CardTypeId] [int] NULL,
	[Guid] [uniqueidentifier] NULL,
	[UploadSiteId] [int] NULL,
	[UploadTime] [datetime] NULL,
	[SynchStatus] [bit] NULL,
	[ExpiryDate] [datetime] NULL,
	[DownloadBatchId] [int] NULL,
	[RefreshFromHQTime] [datetime] NULL,
	[LastUpdatedTime] [datetime] NULL,
	[Custemer] [varchar](100) NULL,
	[Note] [varchar](100) NULL,
	[CreditPlus] [decimal](18, 2) NULL,
 CONSTRAINT [PK_Card] PRIMARY KEY CLUSTERED 
(
	[CardId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Card] ADD  CONSTRAINT [DF_Card_Guid]  DEFAULT (newid()) FOR [Guid]
GO

ALTER TABLE [dbo].[Card]  WITH CHECK ADD  CONSTRAINT [FK_Card_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([CustomerId])
GO

ALTER TABLE [dbo].[Card] CHECK CONSTRAINT [FK_Card_Customer]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Card Master Table' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Card'
GO


